using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LojaDeFerramentas
{
    class GradientePainel : Panel
    {
        public Color ColorTop { get; set; }
        public Color ColorBottom { get; set; }
        public Color BorderColor { get; set; } = Color.Black; // Default border color
        public float GradientAngle { get; set; } = 45F; // Default gradient angle
        public int BorderWidth { get; set; } = 2; // Default border width

        protected override void OnPaint(PaintEventArgs e)
        {
            using (LinearGradientBrush lgb = new LinearGradientBrush(this.ClientRectangle, this.ColorTop, this.ColorBottom, this.GradientAngle))
            {
                Graphics g = e.Graphics;

                g.FillRectangle(lgb, this.ClientRectangle);

                if (BorderWidth > 0)
                {
                    using (Pen borderPen = new Pen(this.BorderColor, this.BorderWidth))
                    {
                        Rectangle borderRectangle = new Rectangle(
                            this.ClientRectangle.X + BorderWidth / 2,
                            this.ClientRectangle.Y + BorderWidth / 2,
                            this.ClientRectangle.Width - BorderWidth,
                            this.ClientRectangle.Height - BorderWidth
                        );
                        g.DrawRectangle(borderPen, borderRectangle);
                    }
                }
            }

            base.OnPaint(e);
        }

    }
}
