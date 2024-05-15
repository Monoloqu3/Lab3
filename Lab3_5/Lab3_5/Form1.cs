
namespace Lab3_5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Ustawienia rysowania
            Pen pen = new Pen(Color.Blue); // Narz�dzie do rysowania
            int scale = 100; // Skala/wysoko�� sinusoidy osi X
            int offsetX = ClientSize.Width / 2; // Przesuni�cie osi X
            int offsetY = ClientSize.Height / 2; // Przesuni�cie osi Y

            
            e.Graphics.DrawLine(Pens.Black, 0, offsetY, ClientSize.Width, offsetY); // Rysuje O� X
            e.Graphics.DrawLine(Pens.Black, offsetX, 0, offsetX, ClientSize.Height); // Rysuje O� Y

            // Rysowanie sinusoidy
            double step = 0.01; // Krok dla sinusoidy
            double maxValue = 2 * Math.PI * scale; // Max warto�� dla sinusoidy

            for (double x = 0; x < maxValue; x += step)
            {
                double y = Math.Sin(x / scale) * scale;
                int pixelX = (int)(x + offsetX);
                int pixelY = (int)(offsetY - y);
                e.Graphics.DrawRectangle(pen, pixelX, pixelY, 1, 1); // Rysuje punkt sinusoidy
            }
        }
    }
}
