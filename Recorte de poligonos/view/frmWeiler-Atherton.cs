using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Algoritmo_de_lineas.Recorte_de_poligonos.model;

namespace Algoritmo_de_lineas.Recorte_de_poligonos.view
{
    public partial class frmWeilerAtherton : Form
    {
        #region Campos privados

        private CWeilerAtherton algoritmo;
        private Bitmap bmp;
        private Graphics g;
        private const int ESCALA = 15;
        private List<PointF> verticesPoligono;

        #endregion

        #region Constructor

        public frmWeilerAtherton()
        {
            InitializeComponent();
            algoritmo = new CWeilerAtherton();
            verticesPoligono = new List<PointF>();
        }

        #endregion

        #region Eventos del formulario

        private void frmWeilerAtherton_Load(object sender, EventArgs e)
        {
            InicializarLienzo();
            txtXMin.Text = "-8";
            txtYMin.Text = "-8";
            txtXMax.Text = "8";
            txtYMax.Text = "8";
        }

        #endregion

        #region Inicialización del lienzo

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
                    g.DrawLine(penCuadricula, centroX + i, 0, centroX + i, pictureBox1.Height);
                for (int i = -centroY; i <= centroY; i += ESCALA)
                    g.DrawLine(penCuadricula, 0, centroY + i, pictureBox1.Width, centroY + i);
            }
        }

        private void DibujarEjes()
        {
            using (Pen penEje = new Pen(Color.Gray, 2))
            using (Font font = new Font("Arial", 7))
            using (Brush brush = new SolidBrush(Color.Black))
            {
                int centroX = pictureBox1.Width / 2;
                int centroY = pictureBox1.Height / 2;
                g.DrawLine(penEje, 0, centroY, pictureBox1.Width, centroY);
                g.DrawLine(penEje, centroX, 0, centroX, pictureBox1.Height);
                g.DrawString("X", new Font("Arial", 9, FontStyle.Bold), brush, pictureBox1.Width - 15, centroY + 5);
                g.DrawString("Y", new Font("Arial", 9, FontStyle.Bold), brush, centroX + 5, 5);
                g.DrawString("(0,0)", font, brush, centroX + 3, centroY + 3);
            }
        }

        #endregion

        #region Eventos de controles

        private void btnAgregarVertice_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtVerticeX.Text) || string.IsNullOrWhiteSpace(txtVerticeY.Text))
                {
                    MessageBox.Show("Ingrese las coordenadas X e Y del vértice.", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!float.TryParse(txtVerticeX.Text, out float x) || !float.TryParse(txtVerticeY.Text, out float y))
                {
                    MessageBox.Show("Ingrese solo números válidos.", "Datos inválidos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!algoritmo.ValidarPunto(x, y))
                {
                    MessageBox.Show("Las coordenadas deben estar en un rango válido.", "Coordenadas inválidas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                verticesPoligono.Add(new PointF(x, y));
                lstVertices.Items.Add($"V{verticesPoligono.Count}: ({x}, {y})");
                txtVerticeX.Clear();
                txtVerticeY.Clear();
                txtVerticeX.Focus();
                lblEstado.Text = $"Vértice agregado. Total: {verticesPoligono.Count}";
                RedibujarEscena();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRecortar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarDatosVentana()) return;

                if (verticesPoligono.Count < 3)
                {
                    MessageBox.Show("Agregue al menos 3 vértices para crear un polígono.", "Polígono incompleto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                float xMin = float.Parse(txtXMin.Text);
                float yMin = float.Parse(txtYMin.Text);
                float xMax = float.Parse(txtXMax.Text);
                float yMax = float.Parse(txtYMax.Text);

                algoritmo.ConfigurarVentana(xMin, yMin, xMax, yMax);
                var resultado = algoritmo.Recortar(verticesPoligono);

                g.Clear(Color.White);
                DibujarCuadricula();
                DibujarEjes();

                int centroX = pictureBox1.Width / 2;
                int centroY = pictureBox1.Height / 2;

                algoritmo.DibujarVentanaRecorte(g, centroX, centroY, ESCALA, Color.Blue);
                algoritmo.DibujarPoligono(g, verticesPoligono, centroX, centroY, ESCALA, Color.LightGray, Color.LightGray, true);

                if (resultado.PoligonoVisible)
                {
                    algoritmo.DibujarPoligonos(g, resultado.PoligonosRecortados, centroX, centroY, ESCALA, Color.Red, Color.Red, true);
                }

                pictureBox1.Refresh();

                string mensaje = $"═══ RESULTADO WEILER-ATHERTON ═══\n\n" +
                    $"Polígono Original: {resultado.VerticesOriginales} vértices\n" +
                    $"Ventana: ({xMin}, {yMin}) - ({xMax}, {yMax})\n\n";

                if (resultado.PoligonoVisible)
                {
                    mensaje += $"✓ POLÍGONO VISIBLE\n" +
                        $"Polígonos resultantes: {resultado.PoligonosResultantes}\n\n";
                    
                    for (int p = 0; p < resultado.PoligonosRecortados.Count; p++)
                    {
                        mensaje += $"Polígono {p + 1}:\n";
                        for (int i = 0; i < resultado.PoligonosRecortados[p].Count; i++)
                        {
                            var v = resultado.PoligonosRecortados[p][i];
                            mensaje += $"  V{i + 1}: ({v.X:F2}, {v.Y:F2})\n";
                        }
                    }
                }
                else
                {
                    mensaje += $"✗ POLÍGONO NO VISIBLE\n";
                }

                mensaje += $"\nEstado: {resultado.Descripcion}";
                txtResultado.Text = mensaje;
                lblEstado.Text = resultado.PoligonoVisible ? "Polígono recortado correctamente" : "Polígono fuera de la ventana";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al recortar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            verticesPoligono.Clear();
            lstVertices.Items.Clear();
            txtResultado.Clear();
            g.Clear(Color.White);
            DibujarCuadricula();
            DibujarEjes();
            pictureBox1.Refresh();
            lblEstado.Text = "Listo. Agregue vértices para crear un polígono.";
        }

        private void btnPoligonoEjemplo_Click(object sender, EventArgs e)
        {
            verticesPoligono.Clear();
            lstVertices.Items.Clear();

            // Polígono cóncavo de ejemplo
            verticesPoligono.Add(new PointF(-12, -5));
            verticesPoligono.Add(new PointF(0, -12));
            verticesPoligono.Add(new PointF(12, -5));
            verticesPoligono.Add(new PointF(6, 10));
            verticesPoligono.Add(new PointF(0, 3));
            verticesPoligono.Add(new PointF(-6, 10));

            foreach (var v in verticesPoligono)
                lstVertices.Items.Add($"V{lstVertices.Items.Count + 1}: ({v.X}, {v.Y})");

            RedibujarEscena();
            lblEstado.Text = "Polígono cóncavo de ejemplo cargado. Presione Recortar.";
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (chkDibujarConMouse.Checked)
            {
                int centroX = pictureBox1.Width / 2;
                int centroY = pictureBox1.Height / 2;
                float x = (float)Math.Round((e.X - centroX) / (float)ESCALA);
                float y = (float)Math.Round((centroY - e.Y) / (float)ESCALA);

                verticesPoligono.Add(new PointF(x, y));
                lstVertices.Items.Add($"V{verticesPoligono.Count}: ({x}, {y})");
                RedibujarEscena();
                lblEstado.Text = $"Vértice agregado. Total: {verticesPoligono.Count}";
            }
        }

        #endregion

        #region Métodos auxiliares

        private void RedibujarEscena()
        {
            g.Clear(Color.White);
            DibujarCuadricula();
            DibujarEjes();

            int centroX = pictureBox1.Width / 2;
            int centroY = pictureBox1.Height / 2;

            if (float.TryParse(txtXMin.Text, out float xMin) && float.TryParse(txtYMin.Text, out float yMin) &&
                float.TryParse(txtXMax.Text, out float xMax) && float.TryParse(txtYMax.Text, out float yMax))
            {
                if (algoritmo.ValidarVentana(xMin, yMin, xMax, yMax))
                {
                    algoritmo.ConfigurarVentana(xMin, yMin, xMax, yMax);
                    algoritmo.DibujarVentanaRecorte(g, centroX, centroY, ESCALA, Color.Blue);
                }
            }

            if (verticesPoligono.Count >= 3)
                algoritmo.DibujarPoligono(g, verticesPoligono, centroX, centroY, ESCALA, Color.Green, Color.LightGreen, true);
            else if (verticesPoligono.Count > 0)
            {
                using (Brush brush = new SolidBrush(Color.Green))
                {
                    foreach (var v in verticesPoligono)
                    {
                        float px = centroX + v.X * ESCALA;
                        float py = centroY - v.Y * ESCALA;
                        g.FillEllipse(brush, px - 4, py - 4, 8, 8);
                    }
                }
            }

            pictureBox1.Refresh();
        }

        private bool ValidarDatosVentana()
        {
            if (string.IsNullOrWhiteSpace(txtXMin.Text) || string.IsNullOrWhiteSpace(txtYMin.Text) ||
                string.IsNullOrWhiteSpace(txtXMax.Text) || string.IsNullOrWhiteSpace(txtYMax.Text))
            {
                MessageBox.Show("Ingrese todos los valores de la ventana de recorte.", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!float.TryParse(txtXMin.Text, out float xMin) || !float.TryParse(txtYMin.Text, out float yMin) ||
                !float.TryParse(txtXMax.Text, out float xMax) || !float.TryParse(txtYMax.Text, out float yMax))
            {
                MessageBox.Show("Los valores de la ventana deben ser números válidos.", "Datos inválidos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!algoritmo.ValidarVentana(xMin, yMin, xMax, yMax))
            {
                MessageBox.Show("XMin debe ser menor que XMax y YMin debe ser menor que YMax.", "Ventana inválida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        #endregion

        #region Limpieza de recursos

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (g != null) g.Dispose();
            if (bmp != null) bmp.Dispose();
            base.OnFormClosing(e);
        }

        #endregion
    }
}
