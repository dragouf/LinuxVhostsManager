using System.Drawing;
using System.Windows.Forms;

namespace VhostManager
{
    public partial class ColorProgressBar : ProgressBar
    {
        //public ColorProgressBar()
        //{
        //    InitializeComponent();
        //}

        public ColorProgressBar()
        {
            this.SetStyle(ControlStyles.UserPaint, true);
            this.BrushColor = Brushes.Goldenrod;
        }

        public Brush BrushColor { get; set; }

        protected override void OnPaint(PaintEventArgs e)
        {
            Rectangle rec = e.ClipRectangle;

            rec.Width = (int)(rec.Width * ((double)Value / Maximum)) - 4;
            if (ProgressBarRenderer.IsSupported)
                ProgressBarRenderer.DrawHorizontalBar(e.Graphics, e.ClipRectangle);
            rec.Height = rec.Height - 4;
            e.Graphics.FillRectangle(BrushColor, 2, 2, rec.Width, rec.Height);
        }
    }
}