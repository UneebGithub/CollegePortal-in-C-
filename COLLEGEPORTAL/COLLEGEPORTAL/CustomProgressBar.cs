using System;
using System.Drawing;
using System.Windows.Forms;

public class CustomProgressBar : ProgressBar
{
    public Color BarColor { get; set; }

    public CustomProgressBar()
    {
        this.SetStyle(ControlStyles.UserPaint, true);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        Rectangle rect = this.ClientRectangle;
        Graphics g = e.Graphics;

        ProgressBarRenderer.DrawHorizontalBar(g, rect);
        rect.Inflate(-3, -3);

        if (this.Value > 0)
        {
            Rectangle clip = new Rectangle(rect.X, rect.Y, (int)(rect.Width * ((double)this.Value / this.Maximum)), rect.Height);
            using (SolidBrush brush = new SolidBrush(BarColor))
            {
                g.FillRectangle(brush, clip);
            }
        }
    }
}
