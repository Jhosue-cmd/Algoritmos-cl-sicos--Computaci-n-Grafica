using System;
using System.Drawing;
using System.Windows.Forms;

namespace Algoritmo_de_lineas
{
    public partial class frmCircuferenciacs : Form
    {
        private CCircunferencia algoritmo;
        private Bitmap bmp;
        private Graphics g;
        private const int ESCALA = 10;

        public frmCircuferenciacs()
        {
            InitializeComponent();
            algoritmo = new CCircunferencia();
        }

        private void frmCircuferencia_Load(object sender, EventArgs e)
        {
            InicializarLienzo();
        }

        private void InicializarLienzo()
        {
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(bmp);
            g.Clear(Color.White);

            DibujarCuadricula();
            DibujarEjes();

            pictureBox1.Image = bmp;
        }

        private void DibujarCuadricula()
        {
            using (Pen penCuadricula = new Pen(Color.FromArgb(240, 240, 240), 1))
            {
                int centroX = pictureBox1.Width / 2;
                int centroY = pictureBox1.Height / 2;

                for (int i = -centroX; i <= centroX; i += ESCALA)
                {
                    g.DrawLine(penCuadricula, centroX + i, 0, centroX + i, pictureBox1.Height);
                }

                for (int i = -centroY; i <= centroY; i += ESCALA)
                {
                    g.DrawLine(penCuadricula, 0, centroY + i, pictureBox1.Width, centroY + i);
                }
            }
        }

        private void DibujarEjes()
        {
            using (Pen penEje = new Pen(Color.Gray, 2))
            using (Pen penMarcas = new Pen(Color.Gray, 1))
            using (Font font = new Font("Arial", 7))
            using (Brush brush = new SolidBrush(Color.Black))
            {
                int centroX = pictureBox1.Width / 2;
                int centroY = pictureBox1.Height / 2;

                g.DrawLine(penEje, 0, centroY, pictureBox1.Width, centroY);
                g.DrawLine(penEje, centroX, 0, centroX, pictureBox1.Height);

                for (int i = -20; i <= 20; i++)
                {
                    if (i == 0) continue;
                    int x = centroX + (i * ESCALA * 5);
                    if (x >= 0 && x <= pictureBox1.Width)
                    {
                        g.DrawLine(penMarcas, x, centroY - 3, x, centroY + 3);
                        if (i % 2 == 0)
                        {
                            string texto = (i * 5).ToString();
                            SizeF size = g.MeasureString(texto, font);
                            g.DrawString(texto, font, brush, x - size.Width / 2, centroY + 5);
                        }
                    }
                }

                for (int i = -20; i <= 20; i++)
                {
                    if (i == 0) continue;
                    int y = centroY - (i * ESCALA * 5);
                    if (y >= 0 && y <= pictureBox1.Height)
                    {
                        g.DrawLine(penMarcas, centroX - 3, y, centroX + 3, y);
                        if (i % 2 == 0)
                        {
                            string texto = (i * 5).ToString();
                            g.DrawString(texto, font, brush, centroX + 5, y - 7);
                        }
                    }
                }

                g.DrawString("X", new Font("Arial", 9, FontStyle.Bold), brush, pictureBox1.Width - 15, centroY + 5);
                g.DrawString("Y", new Font("Arial", 9, FontStyle.Bold), brush, centroX + 5, 5);
                g.DrawString("(0,0)", font, brush, centroX + 3, centroY + 3);
            }
        }

        private void btnDibujar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtXc.Text) ||
                    string.IsNullOrWhiteSpace(txtYc.Text) ||
                    string.IsNullOrWhiteSpace(txtRadio.Text))
                {
                    MessageBox.Show("Por favor, ingrese todos los valores (Centro X, Centro Y, Radio).",
                        "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(txtXc.Text, out int xc) ||
                    !int.TryParse(txtYc.Text, out int yc) ||
                    !int.TryParse(txtRadio.Text, out int radio))
                {
                    MessageBox.Show("Por favor, ingrese solo números enteros.",
                        "Datos inválidos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (xc < 0 || yc < 0 || radio < 0)
                {
                    MessageBox.Show("Por favor, ingrese solo números enteros positivos.",
                        "Valores negativos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!algoritmo.ValidarRadio(radio))
                {
                    MessageBox.Show("El radio debe ser mayor que cero.",
                        "Radio inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                g.Clear(Color.White);
                DibujarCuadricula();
                DibujarEjes();

                int centroX = pictureBox1.Width / 2;
                int centroY = pictureBox1.Height / 2;

                int pxc = centroX + (xc * ESCALA);
                int pyc = centroY - (yc * ESCALA);
                int pradio = radio * ESCALA;

                if (!ValidarCircunferenciaEnArea(pxc, pyc, pradio))
                {
                    MessageBox.Show("La circunferencia está fuera del área visible.\n" +
                                  $"Use valores más pequeños.",
                        "Fuera de rango", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                algoritmo.DibujarCircunferencia(g, pxc, pyc, pradio, Color.DarkBlue, 2);

                double area = Math.PI * radio * radio;
                double perimetro = 2 * Math.PI * radio;

                MessageBox.Show($"Circunferencia dibujada correctamente.\n\n" +
                              $"Centro: ({xc}, {yc})\n" +
                              $"Radio: {radio} unidades\n" +
                              $"Área: {area:F2} unidades²\n" +
                              $"Perímetro: {perimetro:F2} unidades\n" +
                              $"Escala aplicada: {ESCALA}x\n\n" +
                              $"Algoritmo: Punto Medio (8 octantes)",
                              "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                pictureBox1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al dibujar la circunferencia: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidarCircunferenciaEnArea(int xc, int yc, int radio)
        {
            return (xc - radio >= 0 && xc + radio < pictureBox1.Width &&
                    yc - radio >= 0 && yc + radio < pictureBox1.Height);
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            txtXc.Clear();
            txtYc.Clear();
            txtRadio.Clear();

            g.Clear(Color.White);
            DibujarCuadricula();
            DibujarEjes();
            pictureBox1.Refresh();

            txtXc.Focus();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (g != null) g.Dispose();
            if (bmp != null) bmp.Dispose();
            base.OnFormClosing(e);
        }
    }
}
