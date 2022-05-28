using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _8bitVonNeiman.ExternalDevices.SerialController.View
{
    class CNTButton : Button
    {
        private const int PADDING_PX = 4;

        private Brush disabledBrush = new SolidBrush(Color.FromArgb(255, 0, 0, 0));
        private Brush enabledBrush = new SolidBrush(Color.FromArgb(255, 255, 0, 0));
        private Rectangle rect = new Rectangle();

        private bool Pressed = false;

        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            base.OnMouseDown(mevent);

            Pressed = true;
            Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            base.OnMouseUp(mevent);

            Pressed = false;
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);

            int r = Height / 2 - PADDING_PX;
            rect.X = Width / 2 - r;
            rect.Y = PADDING_PX;
            rect.Width = rect.Height = r * 2;
            Brush brush = disabledBrush;
            if (Pressed)
            {
                brush = enabledBrush;
            }
            var smoothing = pevent.Graphics.SmoothingMode;
            pevent.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            pevent.Graphics.FillEllipse(brush, rect);
            pevent.Graphics.SmoothingMode = smoothing;
        }
    }
}
