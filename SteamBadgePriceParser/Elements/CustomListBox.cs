using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamBadgePriceParser.Elements
{
    internal class CustomListBox : ListBox
    {
        public event EventHandler<MouseEventArgs> MouseWheelScroll;
        protected override CreateParams CreateParams
        {
            get
            {
                // Убираем стили скроллбара
                CreateParams cp = base.CreateParams;
                cp.Style &= ~0x200000; // Убираем WS_VSCROLL
                cp.Style &= ~0x100000; // Убираем WS_HSCROLL
                return cp;
            }
        }

        protected override void WndProc(ref Message m)
        {
            const int WM_MOUSEWHEEL = 0x020A; // Сообщение о прокрутке колеса мыши

            if (m.Msg == WM_MOUSEWHEEL)
            {
                // Получаем значение прокрутки (delta)
                int delta = (short)((m.WParam.ToInt64() >> 16) & 0xFFFF);

                MouseEventArgs args = new MouseEventArgs(MouseButtons.None, 0, 0, 0, delta);

                // Вызываем событие
                OnMouseWheelScroll(args);

                //HandleScroll(delta);
            }

            base.WndProc(ref m);
        }

        protected virtual void OnMouseWheelScroll(MouseEventArgs e)
        {
            // Вызываем событие, если на него подписались
            MouseWheelScroll?.Invoke(this, e);
        }

        public void HandleScroll(int delta)
        {
            // Реализуем собственную логику прокрутки
            int scrollDirection = Math.Sign(delta);
            int topIndex = this.TopIndex;

            // Изменяем индекс первого видимого элемента
            this.TopIndex = Math.Max(0, topIndex - scrollDirection);
        }
    }
}
