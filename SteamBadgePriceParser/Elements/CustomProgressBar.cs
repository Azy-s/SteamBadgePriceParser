namespace SteamBadgePriceParser
{
    public class CustomProgressBar : ProgressBar
    {
        public CustomProgressBar()
        {
            // Включаем пользовательский рендеринг
            this.SetStyle(ControlStyles.UserPaint, true);

            // Устанавливаем фиксированную высоту
            this.Height = 10;

            // Цвет полосы прогресса
            this.ForeColor = Color.FromArgb(25, 153, 255);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.Clear(this.BackColor);

            float percent = (float)this.Value / this.Maximum;
            int fillWidth = (int)(percent * this.Width);

            using (SolidBrush brush = new SolidBrush(this.ForeColor))
            {
                Rectangle rect = new Rectangle(0, 0, fillWidth, this.Height);
                e.Graphics.FillRectangle(brush, rect);
            }

            //Border
            //using (Pen borderPen = new Pen(Color.FromArgb(23,25,31)))
            //{
            //    e.Graphics.DrawRectangle(borderPen, 0, 0, this.Width - 1, this.Height - 1);
            //}
        }
    }
}