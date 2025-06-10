using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tubes_KPL_GUI
{
    public class RoundedButton : Button
    {
        public RoundedButton()
        {
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.BackColor = Color.White;
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);

            Graphics g = pevent.Graphics;
            Color baseColor = this.BackColor;
            Color shadowColor = Color.FromArgb(100, 0, 0, 0);

            g.FillEllipse(new SolidBrush(shadowColor), 10, 10, this.Width, this.Height);

            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddArc(0, 0, 20, 20, 180, 90);
                path.AddArc(this.Width - 20, 0, 20, 20, 270, 90);
                path.AddArc(this.Width - 20, this.Height - 20, 20, 20, 0, 90);
                path.AddArc(0, this.Height - 20, 20, 20, 90, 90);
                path.CloseAllFigures();

                this.Region = new Region(path);
                using (Brush brush = new SolidBrush(baseColor))
                {
                    g.FillPath(brush, path);
                }
            }

            using (Brush textBrush = new SolidBrush(this.ForeColor))
            {
                g.DrawString(this.Text, this.Font, textBrush, new PointF(this.Width / 2 - g.MeasureString(this.Text, this.Font).Width / 2, this.Height / 2 - g.MeasureString(this.Text, this.Font).Height / 2));
            }
        }
    }
}
