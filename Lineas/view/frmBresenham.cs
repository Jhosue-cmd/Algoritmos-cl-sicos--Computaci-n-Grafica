using System;
using System.Drawing;
using System.Windows.Forms;

namespace Algoritmo_de_lineas
{
    public partial class frmBresenham : Form
    {
        private CBresenham algoritmo;
        private Bitmap bmp;
        private Graphics g;
        private const int ESCALA = 10; // Factor de escala para ampliar el dibujo

        public frmBresenham()
        {
            InitializeComponent();
            algoritmo = new CBresenham();
        }

        private void frmBresenham_Load(object sender, EventArgs e)
        {
            // Inicializar el bitmap y graphics para el PictureBox
            InicializarLienzo();
        }

        private void InicializarLienzo()
        {
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(bmp);
            g.Clear(Color.White);

            // Dibujar ejes de coordenadas y cuadrícula
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

                // Líneas verticales
                for (int i = -centroX; i <= centroX; i += ESCALA)
                {
                    g.DrawLine(penCuadricula, centroX + i, 0, centroX + i, pictureBox1.Height);
                }

                // Líneas horizontales
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

                // Eje X
                g.DrawLine(penEje, 0, centroY, pictureBox1.Width, centroY);
                // Eje Y
                g.DrawLine(penEje, centroX, 0, centroX, pictureBox1.Height);

                // Marcas en el eje X (cada 5 unidades)
                for (int i = -20; i <= 20; i++)
                {
                    if (i == 0) continue;
                    int x = centroX + (i * ESCALA * 5);
                    if (x >= 0 && x <= pictureBox1.Width)
                    {
                        g.DrawLine(penMarcas, x, centroY - 3, x, centroY + 3);
                        if (i % 2 == 0) // Mostrar número cada 10 unidades
                        {
                            string texto = (i * 5).ToString();
                            SizeF size = g.MeasureString(texto, font);
                            g.DrawString(texto, font, brush, x - size.Width / 2, centroY + 5);
                        }
                    }
                }

                // Marcas en el eje Y (cada 5 unidades)
                for (int i = -20; i <= 20; i++)
                {
                    if (i == 0) continue;
                    int y = centroY - (i * ESCALA * 5);
                    if (y >= 0 && y <= pictureBox1.Height)
                    {
                        g.DrawLine(penMarcas, centroX - 3, y, centroX + 3, y);
                        if (i % 2 == 0) // Mostrar número cada 10 unidades
                        {
                            string texto = (i * 5).ToString();
                            g.DrawString(texto, font, brush, centroX + 5, y - 7);
                        }
                    }
                }

                // Etiquetas de ejes
                g.DrawString("X", new Font("Arial", 9, FontStyle.Bold), brush, pictureBox1.Width - 15, centroY + 5);
                g.DrawString("Y", new Font("Arial", 9, FontStyle.Bold), brush, centroX + 5, 5);
                g.DrawString("(0,0)", font, brush, centroX + 3, centroY + 3);
            }
        }

        private void btnDibujar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar que todos los campos estén llenos
                if (string.IsNullOrWhiteSpace(txtX1.Text) ||
                    string.IsNullOrWhiteSpace(txtY1.Text) ||
                    string.IsNullOrWhiteSpace(txtX2.Text) ||
                    string.IsNullOrWhiteSpace(txtY2.Text))
                {
                    MessageBox.Show("Por favor, ingrese todos los valores de los puntos.",
                        "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validar que sean números enteros
                if (!int.TryParse(txtX1.Text, out int x1) ||
                    !int.TryParse(txtY1.Text, out int y1) ||
                    !int.TryParse(txtX2.Text, out int x2) ||
                    !int.TryParse(txtY2.Text, out int y2))
                {
                    MessageBox.Show("Por favor, ingrese solo números enteros.",
                        "Datos inválidos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Validar que sean números positivos
                if (x1 < 0 || y1 < 0 || x2 < 0 || y2 < 0)
                {
                    MessageBox.Show("Por favor, ingrese solo números enteros positivos.",
                        "Valores negativos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Validar que los puntos no sean iguales
                if (x1 == x2 && y1 == y2)
                {
                    MessageBox.Show("Los puntos inicial y final no pueden ser iguales.",
                        "Puntos iguales", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validar que la pendiente no sea cero (línea no horizontal)
                if (!algoritmo.ValidarPendiente(x1, y1, x2, y2))
                {
                    MessageBox.Show("La pendiente no puede ser cero.\nLa línea no puede ser horizontal (Y1 debe ser diferente de Y2).",
                        "Pendiente inválida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Limpiar el lienzo
                g.Clear(Color.White);
                DibujarCuadricula();
                DibujarEjes();

                // Convertir coordenadas a sistema de coordenadas del PictureBox
                // Aplicar escala y centrar en el origen
                int centroX = pictureBox1.Width / 2;
                int centroY = pictureBox1.Height / 2;

                int px1 = centroX + (x1 * ESCALA);
                int py1 = centroY - (y1 * ESCALA);
                int px2 = centroX + (x2 * ESCALA);
                int py2 = centroY - (y2 * ESCALA);

                // Validar que los puntos estén dentro del área visible
                if (!ValidarPuntoEnArea(px1, py1) || !ValidarPuntoEnArea(px2, py2))
                {
                    MessageBox.Show("Los puntos están fuera del área visible.\n" +
                                  $"Use valores entre 0 y {pictureBox1.Width / (2 * ESCALA)} aproximadamente.",
                        "Fuera de rango", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Dibujar la línea usando el algoritmo de Bresenham
                algoritmo.DibujarLinea(g, px1, py1, px2, py2, Color.DarkGreen, 3);

                // Calcular y mostrar información de la pendiente
                double pendiente = algoritmo.CalcularPendiente(x1, y1, x2, y2);
                string infoPendiente = double.IsPositiveInfinity(pendiente)
                    ? "? (línea vertical)"
                    : pendiente.ToString("F2");

                // Calcular distancia
                double distancia = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));

                MessageBox.Show($"Línea dibujada correctamente con Bresenham.\n\n" +
                              $"Punto inicial: ({x1}, {y1})\n" +
                              $"Punto final: ({x2}, {y2})\n" +
                              $"Pendiente: {infoPendiente}\n" +
                              $"Distancia: {distancia:F2} unidades\n" +
                              $"Escala aplicada: {ESCALA}x\n\n" +
                              $"Algoritmo: Bresenham (sin anti-aliasing)",
                              "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                pictureBox1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al dibujar la línea: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidarPuntoEnArea(int x, int y)
        {
            return x >= 0 && x < pictureBox1.Width && y >= 0 && y < pictureBox1.Height;
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            // Limpiar todos los TextBox
            txtX1.Clear();
            txtY1.Clear();
            txtX2.Clear();
            txtY2.Clear();

            // Limpiar el lienzo
            g.Clear(Color.White);
            DibujarCuadricula();
            DibujarEjes();
            pictureBox1.Refresh();

            // Enfocar el primer TextBox
            txtX1.Focus();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            // Liberar recursos
            if (g != null)
            {
                g.Dispose();
            }
            if (bmp != null)
            {
                bmp.Dispose();
            }
            base.OnFormClosing(e);
        }
    }
}
