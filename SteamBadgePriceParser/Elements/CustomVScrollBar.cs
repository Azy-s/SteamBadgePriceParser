using System.ComponentModel;

namespace SteamBadgePriceParser
{
    [DefaultEvent("Scroll")]
    public class CustomVScrollBar : UserControl
    {
        public event EventHandler ValueChanged;

        // Цвета
        private Color arrowColor = Color.Gray;
        private Color thumbColor = Color.DarkGray;
        private Color trackColor = Color.FromArgb(40, 40, 40);
        private Color borderColor = Color.Black;

        // Размеры элементов
        private const int ArrowHeight = 17;
        private const int BorderWidth = 1;

        // Состояние
        private int mousePos;
        private bool thumbDown;
        private bool topArrowDown;
        private bool bottomArrowDown;

        // Таймер для автопрокрутки
        private readonly System.Windows.Forms.Timer autoScrollTimer = new System.Windows.Forms.Timer { Interval = 50 };

        // Свойства
        private int minimum;
        private int maximum = 100;
        private int value;
        private int largeChange = 10;

        public CustomVScrollBar()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.ResizeRedraw |
                     ControlStyles.UserPaint, true);
            this.DoubleBuffered = true;
            autoScrollTimer.Tick += AutoScrollTimer_Tick;
        }

        [Category("Appearance")]
        public Color ArrowColor
        {
            get => arrowColor;
            set { arrowColor = value; Invalidate(); }
        }

        [Category("Appearance")]
        public Color ThumbColor
        {
            get => thumbColor;
            set { thumbColor = value; Invalidate(); }
        }

        [Category("Appearance")]
        public Color TrackColor
        {
            get => trackColor;
            set { trackColor = value; Invalidate(); }
        }

        [Category("Appearance")]
        public Color BorderColor
        {
            get => borderColor;
            set { borderColor = value; Invalidate(); }
        }

        [Category("Behavior")]
        [DefaultValue(0)]
        public int Minimum
        {
            get => minimum;
            set { minimum = value; AdjustValue(); Invalidate(); }
        }

        [Category("Behavior")]
        [DefaultValue(100)]
        public int Maximum
        {
            get => maximum;
            set { maximum = value; AdjustValue(); Invalidate(); }
        }

        [Category("Behavior")]
        [DefaultValue(0)]
        public int Value
        {
            get => value;
            set
            {
                if (this.value != value)
                {
                    this.value = Math.Max(minimum, Math.Min(maximum, value));
                    Invalidate();
                    OnScroll();
                    OnValueChanged();
                }
            }
        }

        [Category("Behavior")]
        [DefaultValue(10)]
        public int LargeChange
        {
            get => largeChange;
            set { largeChange = value; Invalidate(); }
        }

        public event ScrollEventHandler Scroll;

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var g = e.Graphics;

            // Фон
            using (var brush = new SolidBrush(trackColor))
                g.FillRectangle(brush, ClientRectangle);

            // Граница
            using (var pen = new Pen(borderColor))
                g.DrawRectangle(pen, 0, 0, Width - 1, Height - 1);

            // Стрелки
            DrawArrow(g, true);
            DrawArrow(g, false);

            // Ползунок
            DrawThumb(g);
        }

        private void DrawArrow(Graphics g, bool top)
        {
            using (var brush = new SolidBrush(arrowColor))
            {
                int y = top ? BorderWidth : Height - ArrowHeight - BorderWidth;
                var rect = new Rectangle(BorderWidth, y, Width - BorderWidth * 2, ArrowHeight);

                g.FillRectangle(brush, rect);

                // Рисуем треугольник
                var arrowSize = ArrowHeight / 3;
                var points = new Point[3];
                if (top)
                {
                    points[0] = new Point(Width / 2 - arrowSize, y + ArrowHeight / 2);
                    points[1] = new Point(Width / 2 + arrowSize, y + ArrowHeight / 2);
                    points[2] = new Point(Width / 2, y + ArrowHeight / 2 - arrowSize);
                }
                else
                {
                    points[0] = new Point(Width / 2 - arrowSize, y + ArrowHeight / 2);
                    points[1] = new Point(Width / 2 + arrowSize, y + ArrowHeight / 2);
                    points[2] = new Point(Width / 2, y + ArrowHeight / 2 + arrowSize);
                }
                g.FillPolygon(Brushes.Black, points);
            }
        }

        private void DrawThumb(Graphics g)
        {
            var thumbRect = GetThumbRect();
            using (var brush = new SolidBrush(thumbColor))
                g.FillRectangle(brush, thumbRect);
        }

        private Rectangle GetThumbRect()
        {
            if (maximum - minimum == 0) return Rectangle.Empty;

            int trackHeight = Height - 2 * ArrowHeight - 2 * BorderWidth;
            int thumbHeight = (int)(trackHeight * (largeChange / (float)(maximum - minimum + largeChange)));
            thumbHeight = Math.Max(20, thumbHeight);

            int thumbY = (int)((value - minimum) / (float)(maximum - minimum) * (trackHeight - thumbHeight));
            thumbY += ArrowHeight + BorderWidth;

            return new Rectangle(BorderWidth, thumbY, Width - BorderWidth * 2, thumbHeight);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            var thumbRect = GetThumbRect();
            var topArrowRect = new Rectangle(0, 0, Width, ArrowHeight);
            var bottomArrowRect = new Rectangle(0, Height - ArrowHeight, Width, ArrowHeight);

            if (thumbRect.Contains(e.Location))
            {
                thumbDown = true;
                mousePos = e.Y - thumbRect.Top;
            }
            else if (topArrowRect.Contains(e.Location))
            {
                Value -= 1;
                topArrowDown = true;
                autoScrollTimer.Start();
            }
            else if (bottomArrowRect.Contains(e.Location))
            {
                Value += 1;
                bottomArrowDown = true;
                autoScrollTimer.Start();
            }
            else
            {
                int trackY = e.Y - ArrowHeight - BorderWidth;
                if (trackY < thumbRect.Top)
                    Value -= largeChange;
                else
                    Value += largeChange;
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            thumbDown = false;
            topArrowDown = false;
            bottomArrowDown = false;
            autoScrollTimer.Stop();
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (!thumbDown) return;

            int trackHeight = Height - 2 * ArrowHeight - 2 * BorderWidth;
            int thumbHeight = GetThumbRect().Height;
            int newY = e.Y - mousePos - ArrowHeight - BorderWidth;

            Value = (int)(minimum + (newY / (float)(trackHeight - thumbHeight)) * (maximum - minimum));
        }

        private void AutoScrollTimer_Tick(object sender, EventArgs e)
        {
            if (topArrowDown) Value -= 1;
            if (bottomArrowDown) Value += 1;
        }

        private void AdjustValue()
        {
            value = Math.Max(minimum, Math.Min(maximum, value));
        }

        protected virtual void OnScroll()
        {
            Scroll?.Invoke(this, new ScrollEventArgs(ScrollEventType.ThumbPosition, value));
        }

        protected virtual void OnValueChanged()
        {
            ValueChanged?.Invoke(this, EventArgs.Empty);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) autoScrollTimer.Dispose();
            base.Dispose(disposing);
        }
    }
}
