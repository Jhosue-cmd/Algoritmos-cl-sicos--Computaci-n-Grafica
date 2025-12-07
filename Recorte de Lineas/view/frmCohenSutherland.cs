using System;
using System.Drawing;
using System.Windows.Forms;
using Algoritmo_de_lineas.Recorte_de_Lineas.model;

namespace Algoritmo_de_lineas.Recorte_de_Lineas.view
{
    public partial class frmCohenSutherland : Form
    {
        #region Campos privados

        private CCohenSutherland algoritmo;
        private Bitmap bmp;
        private Graphics g;
        private const int ESCALA = 15;

        #endregion

        #region Constructor

        public frmCohenSutherland()
        {
            InitializeComponent();
            algoritmo = new CCohenSutherland();
        }

        #endregion

        #region Eventos del formulario

        private void frmCohenSutherland_Load(object sender, EventArgs e)
        {
            InicializarLienzo();
            // Valores predeterminados para la ventana de recorte
            txtXMin.Text = "-10";
            txtYMin.Text = "-10";
            txtXMax.Text = "10";
            txtYMax.Text = "10";
            // Valores predeterminados para la línea
            txtX1.Text = "-15";
            txtY1.Text = "-5";
            txtX2.Text = "15";
            txtY2.Text = "12";
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

        private void btnRecortar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar datos de la ventana
                if (!ValidarDatosVentana())
                    return;

                // Validar datos de la línea
                if (!ValidarDatosLinea())
                    return;

                // Obtener valores
                int xMin = int.Parse(txtXMin.Text);
                int yMin = int.Parse(txtYMin.Text);
                int xMax = int.Parse(txtXMax.Text);
                int yMax = int.Parse(txtYMax.Text);

                float x1 = float.Parse(txtX1.Text);
                float y1 = float.Parse(txtY1.Text);
                float x2 = float.Parse(txtX2.Text);
                float y2 = float.Parse(txtY2.Text);

                // Configurar ventana
                algoritmo.ConfigurarVentana(xMin, yMin, xMax, yMax);

                // Limpiar y redibujar
                g.Clear(Color.White);
                DibujarCuadricula();
                DibujarEjes();

                int centroX = pictureBox1.Width / 2;
                int centroY = pictureBox1.Height / 2;

                // Dibujar ventana de recorte
                algoritmo.DibujarVentanaRecorte(g, centroX, centroY, ESCALA, Color.Blue);

                // Dibujar línea original
                algoritmo.DibujarLineaOriginal(g, x1, y1, x2, y2, centroX, centroY, ESCALA, Color.LightGray);

                // Ejecutar algoritmo
                var resultado = algoritmo.Recortar(x1, y1, x2, y2);

                // Mostrar resultado
                if (resultado.LineaVisible)
                {
                    algoritmo.DibujarLineaRecortada(g, resultado.PuntoInicio, resultado.PuntoFin,
                        centroX, centroY, ESCALA, Color.Red);
                }

                pictureBox1.Refresh();

                // Mostrar información del resultado
                string outcodeInicioDesc = algoritmo.ObtenerDescripcionOutcode(resultado.OutcodeInicio);
                string outcodeFinDesc = algoritmo.ObtenerDescripcionOutcode(resultado.OutcodeFin);

                string mensaje = $"═══ RESULTADO COHEN-SUTHERLAND ═══\n\n" +
                    $"Línea Original: ({x1}, {y1}) → ({x2}, {y2})\n\n" +
                    $"Outcode P1: {resultado.OutcodeInicio:D4} ({outcodeInicioDesc})\n" +
                    $"Outcode P2: {resultado.OutcodeFin:D4} ({outcodeFinDesc})\n\n" +
                    $"Iteraciones: {resultado.Iteraciones}\n\n";

                if (resultado.LineaVisible)
                {
                    mensaje += $"✓ LÍNEA VISIBLE\n" +
                        $"Línea Recortada: ({resultado.PuntoInicio.X:F2}, {resultado.PuntoInicio.Y:F2}) → " +
                        $"({resultado.PuntoFin.X:F2}, {resultado.PuntoFin.Y:F2})\n\n";
                }
                else
                {
                    mensaje += $"✗ LÍNEA NO VISIBLE\n\n";
                }

                mensaje += $"Descripción: {resultado.Descripcion}";

                txtResultado.Text = mensaje;
                lblEstado.Text = resultado.LineaVisible ? "Línea recortada correctamente" : "Línea fuera de la ventana";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al recortar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            DibujarCuadricula();
            DibujarEjes();
            pictureBox1.Refresh();

            txtResultado.Clear();
            lblEstado.Text = "Listo. Ingrese los datos y presione Recortar.";
        }

        #endregion

        #region Validaciones

        private bool ValidarDatosVentana()
        {
            if (string.IsNullOrWhiteSpace(txtXMin.Text) ||
                string.IsNullOrWhiteSpace(txtYMin.Text) ||
                string.IsNullOrWhiteSpace(txtXMax.Text) ||
                string.IsNullOrWhiteSpace(txtYMax.Text))
            {
                MessageBox.Show("Ingrese todos los valores de la ventana de recorte.",
                    "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!int.TryParse(txtXMin.Text, out int xMin) ||
                !int.TryParse(txtYMin.Text, out int yMin) ||
                !int.TryParse(txtXMax.Text, out int xMax) ||
                !int.TryParse(txtYMax.Text, out int yMax))
            {
                MessageBox.Show("Los valores de la ventana deben ser números enteros.",
                    "Datos inválidos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!algoritmo.ValidarVentana(xMin, yMin, xMax, yMax))
            {
                MessageBox.Show("XMin debe ser menor que XMax y YMin debe ser menor que YMax.",
                    "Ventana inválida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private bool ValidarDatosLinea()
        {
            if (string.IsNullOrWhiteSpace(txtX1.Text) ||
                string.IsNullOrWhiteSpace(txtY1.Text) ||
                string.IsNullOrWhiteSpace(txtX2.Text) ||
                string.IsNullOrWhiteSpace(txtY2.Text))
            {
                MessageBox.Show("Ingrese todos los valores de la línea.",
                    "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!float.TryParse(txtX1.Text, out float x1) ||
                !float.TryParse(txtY1.Text, out float y1) ||
                !float.TryParse(txtX2.Text, out float x2) ||
                !float.TryParse(txtY2.Text, out float y2))
            {
                MessageBox.Show("Los valores de la línea deben ser números válidos.",
                    "Datos inválidos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!algoritmo.ValidarPunto(x1, y1) || !algoritmo.ValidarPunto(x2, y2))
            {
                MessageBox.Show("Las coordenadas deben estar en un rango válido (-10000 a 10000).",
                    "Coordenadas fuera de rango", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
