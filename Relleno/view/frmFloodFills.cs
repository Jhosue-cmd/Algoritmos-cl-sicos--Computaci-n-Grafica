using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Algoritmo_de_lineas.Relleno.model;

namespace Algoritmo_de_lineas.Relleno.view
{
    public partial class frmFloodFills : Form
    {
        #region Campos privados

        private CFloodFill algoritmo;
        private Bitmap bmp;
        private Graphics g;
        private const int ESCALA = 10;
        private List<Point> verticesBorde;
        private Point? puntoSemilla;
        private bool esperandoPuntoSemilla = false;

        #endregion

        #region Constructor

        public frmFloodFills()
        {
            InitializeComponent();
            algoritmo = new CFloodFill();
            verticesBorde = new List<Point>();
            puntoSemilla = null;
        }

        #endregion

        #region Eventos del formulario

        private void frmFloodFills_Load(object sender, EventArgs e)
        {
            InicializarLienzo();
            cmbColorRelleno.SelectedIndex = 0;
            cmbColorBorde.SelectedIndex = 1;
            cmbTipoConectividad.SelectedIndex = 0;
            cmbForma.SelectedIndex = 0;
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

        private void btnDibujarForma_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar datos según la forma seleccionada
                if (cmbForma.SelectedIndex == 0) // Círculo
                {
                    if (!ValidarDatosCirculo())
                        return;

                    DibujarCirculo();
                }
                else if (cmbForma.SelectedIndex == 1) // Rectángulo
                {
                    if (!ValidarDatosRectangulo())
                        return;

                    DibujarRectangulo();
                }
                else if (cmbForma.SelectedIndex == 2) // Polígono manual
                {
                    if (verticesBorde.Count < 3)
                    {
                        MessageBox.Show("Agregue al menos 3 vértices para crear un polígono.",
                            "Polígono incompleto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    DibujarPoligonoManual();
                }

                lblEstado.Text = "Forma dibujada. Ahora haga clic en el área para seleccionar punto semilla.";
                esperandoPuntoSemilla = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al dibujar forma: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRellenar_Click(object sender, EventArgs e)
        {
            try
            {
                if (puntoSemilla == null)
                {
                    MessageBox.Show("Primero debe seleccionar un punto semilla haciendo clic dentro de la forma.",
                        "Punto semilla requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validar que el punto semilla esté dentro de los límites del bitmap
                if (!algoritmo.ValidarPuntoSemilla(puntoSemilla.Value.X, puntoSemilla.Value.Y,
                    bmp.Width, bmp.Height))
                {
                    MessageBox.Show("El punto semilla está fuera del área de dibujo.",
                        "Punto inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Obtener color de relleno
                Color colorRelleno = ObtenerColorSeleccionado(cmbColorRelleno);
                Color colorBorde = ObtenerColorSeleccionado(cmbColorBorde);

                // Validar que el punto semilla no esté sobre el borde
                Color colorEnPunto = bmp.GetPixel(puntoSemilla.Value.X, puntoSemilla.Value.Y);
                if (colorEnPunto.ToArgb() == colorBorde.ToArgb())
                {
                    MessageBox.Show("El punto semilla está sobre el borde. Seleccione un punto dentro del área a rellenar.",
                        "Punto inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int pixelesRellenados;

                // Ejecutar algoritmo según conectividad seleccionada
                if (cmbTipoConectividad.SelectedIndex == 0) // 4-conectividad
                {
                    pixelesRellenados = algoritmo.RellenarHastaBorde(bmp, puntoSemilla.Value.X,
                        puntoSemilla.Value.Y, colorRelleno, colorBorde);
                }
                else // 8-conectividad
                {
                    pixelesRellenados = algoritmo.RellenarArea8Conectividad(bmp, puntoSemilla.Value.X,
                        puntoSemilla.Value.Y, colorRelleno);
                }

                pictureBox1.Refresh();

                string tipoConectividad = cmbTipoConectividad.SelectedIndex == 0 ? "4-conectividad" : "8-conectividad";

                MessageBox.Show($"Relleno completado.\n\n" +
                    $"Píxeles rellenados: {pixelesRellenados}\n" +
                    $"Punto semilla: ({puntoSemilla.Value.X}, {puntoSemilla.Value.Y})\n" +
                    $"Tipo: Flood Fill ({tipoConectividad})",
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                lblEstado.Text = $"Relleno completado. {pixelesRellenados} píxeles rellenados.";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al rellenar: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            verticesBorde.Clear();
            lstVertices.Items.Clear();
            puntoSemilla = null;
            esperandoPuntoSemilla = false;

            txtCentroX.Clear();
            txtCentroY.Clear();
            txtRadio.Clear();
            txtAncho.Clear();
            txtAlto.Clear();

            g.Clear(Color.White);
            DibujarCuadricula();
            DibujarEjes();
            pictureBox1.Refresh();

            lblEstado.Text = "Listo. Dibuje una forma para comenzar.";
        }

        private void btnAgregarVertice_Click(object sender, EventArgs e)
        {
            if (cmbForma.SelectedIndex != 2)
            {
                MessageBox.Show("Seleccione 'Polígono Manual' en el tipo de forma para agregar vértices.",
                    "Forma incorrecta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                if (string.IsNullOrWhiteSpace(txtVerticeX.Text) || string.IsNullOrWhiteSpace(txtVerticeY.Text))
                {
                    MessageBox.Show("Ingrese las coordenadas X e Y del vértice.",
                        "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(txtVerticeX.Text, out int x) || !int.TryParse(txtVerticeY.Text, out int y))
                {
                    MessageBox.Show("Ingrese solo números enteros.",
                        "Datos inválidos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!algoritmo.ValidarCoordenadas(x, y))
                {
                    MessageBox.Show("Las coordenadas deben estar en un rango válido.",
                        "Coordenadas inválidas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Convertir a coordenadas de pantalla
                int centroX = pictureBox1.Width / 2;
                int centroY = pictureBox1.Height / 2;
                int px = centroX + (x * ESCALA);
                int py = centroY - (y * ESCALA);

                verticesBorde.Add(new Point(px, py));
                lstVertices.Items.Add($"V{verticesBorde.Count}: ({x}, {y})");

                txtVerticeX.Clear();
                txtVerticeY.Clear();
                txtVerticeX.Focus();

                lblEstado.Text = $"Vértice agregado. Total: {verticesBorde.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (esperandoPuntoSemilla)
            {
                puntoSemilla = new Point(e.X, e.Y);

                // Dibujar indicador del punto semilla
                algoritmo.DibujarPuntoSemilla(g, e.X, e.Y, Color.Green);
                pictureBox1.Refresh();

                int centroX = pictureBox1.Width / 2;
                int centroY = pictureBox1.Height / 2;
                int coordX = (e.X - centroX) / ESCALA;
                int coordY = (centroY - e.Y) / ESCALA;

                lblEstado.Text = $"Punto semilla seleccionado: ({coordX}, {coordY}). Presione 'Rellenar'.";
            }
            else if (cmbForma.SelectedIndex == 2 && chkDibujarConMouse.Checked)
            {
                // Agregar vértice con clic
                int centroX = pictureBox1.Width / 2;
                int centroY = pictureBox1.Height / 2;
                int x = (e.X - centroX) / ESCALA;
                int y = (centroY - e.Y) / ESCALA;

                int px = centroX + (x * ESCALA);
                int py = centroY - (y * ESCALA);

                verticesBorde.Add(new Point(px, py));
                lstVertices.Items.Add($"V{verticesBorde.Count}: ({x}, {y})");

                using (Brush brush = new SolidBrush(Color.Blue))
                {
                    g.FillEllipse(brush, px - 3, py - 3, 6, 6);
                }
                pictureBox1.Refresh();

                lblEstado.Text = $"Vértice agregado. Total: {verticesBorde.Count}";
            }
        }

        private void cmbForma_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Habilitar/deshabilitar controles según la forma
            bool esCirculo = cmbForma.SelectedIndex == 0;
            bool esRectangulo = cmbForma.SelectedIndex == 1;
            bool esPoligono = cmbForma.SelectedIndex == 2;

            groupBoxCirculo.Enabled = esCirculo;
            groupBoxRectangulo.Enabled = esRectangulo;
            groupBoxPoligono.Enabled = esPoligono;
        }

        #endregion

        #region Métodos de dibujo

        private void DibujarCirculo()
        {
            int.TryParse(txtCentroX.Text, out int cx);
            int.TryParse(txtCentroY.Text, out int cy);
            int.TryParse(txtRadio.Text, out int radio);

            int centroX = pictureBox1.Width / 2;
            int centroY = pictureBox1.Height / 2;
            int pcx = centroX + (cx * ESCALA);
            int pcy = centroY - (cy * ESCALA);
            int pradio = radio * ESCALA;

            g.Clear(Color.White);
            DibujarCuadricula();
            DibujarEjes();

            Color colorBorde = ObtenerColorSeleccionado(cmbColorBorde);
            algoritmo.DibujarCirculoBorde(g, pcx, pcy, pradio, colorBorde);

            pictureBox1.Refresh();
        }

        private void DibujarRectangulo()
        {
            int.TryParse(txtAncho.Text, out int ancho);
            int.TryParse(txtAlto.Text, out int alto);

            // El rectángulo se dibuja centrado en el origen (0,0)
            int centroX = pictureBox1.Width / 2;
            int centroY = pictureBox1.Height / 2;
            
            // Calcular esquina superior izquierda para centrar en origen
            int px = centroX - (ancho * ESCALA / 2);
            int py = centroY - (alto * ESCALA / 2);
            int pAncho = ancho * ESCALA;
            int pAlto = alto * ESCALA;

            g.Clear(Color.White);
            DibujarCuadricula();
            DibujarEjes();

            Color colorBorde = ObtenerColorSeleccionado(cmbColorBorde);
            algoritmo.DibujarRectanguloBorde(g, px, py, pAncho, pAlto, colorBorde);

            pictureBox1.Refresh();
        }

        private void DibujarPoligonoManual()
        {
            g.Clear(Color.White);
            DibujarCuadricula();
            DibujarEjes();

            Color colorBorde = ObtenerColorSeleccionado(cmbColorBorde);
            algoritmo.DibujarPoligonoBorde(g, verticesBorde, colorBorde);

            pictureBox1.Refresh();
        }

        #endregion

        #region Validaciones

        private bool ValidarDatosCirculo()
        {
            if (string.IsNullOrWhiteSpace(txtCentroX.Text) ||
                string.IsNullOrWhiteSpace(txtCentroY.Text) ||
                string.IsNullOrWhiteSpace(txtRadio.Text))
            {
                MessageBox.Show("Ingrese todos los datos del círculo (Centro X, Centro Y, Radio).",
                    "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!int.TryParse(txtCentroX.Text, out int cx) ||
                !int.TryParse(txtCentroY.Text, out int cy) ||
                !int.TryParse(txtRadio.Text, out int radio))
            {
                MessageBox.Show("Ingrese solo números enteros.",
                    "Datos inválidos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (radio <= 0)
            {
                MessageBox.Show("El radio debe ser mayor que cero.",
                    "Radio inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (radio > 20)
            {
                MessageBox.Show("El radio no debe exceder 20 unidades para visualización óptima.",
                    "Radio muy grande", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private bool ValidarDatosRectangulo()
        {
            // Solo validar ancho y alto (el rectángulo se centra en el origen automáticamente)
            if (string.IsNullOrWhiteSpace(txtAncho.Text) ||
                string.IsNullOrWhiteSpace(txtAlto.Text))
            {
                MessageBox.Show("Ingrese el ancho y alto del rectángulo.",
                    "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!int.TryParse(txtAncho.Text, out int ancho) ||
                !int.TryParse(txtAlto.Text, out int alto))
            {
                MessageBox.Show("Ingrese solo números enteros.",
                    "Datos inválidos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (ancho <= 0 || alto <= 0)
            {
                MessageBox.Show("El ancho y alto deben ser mayores que cero.",
                    "Dimensiones inválidas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (ancho > 40 || alto > 40)
            {
                MessageBox.Show("El ancho y alto no deben exceder 40 unidades para visualización óptima.",
                    "Dimensiones muy grandes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        #endregion

        #region Métodos auxiliares

        private Color ObtenerColorSeleccionado(ComboBox cmb)
        {
            switch (cmb.SelectedIndex)
            {
                case 0: return Color.FromArgb(150, 0, 150, 255); // Azul transparente
                case 1: return Color.DarkBlue;
                case 2: return Color.Red;
                case 3: return Color.Green;
                case 4: return Color.Orange;
                case 5: return Color.Purple;
                case 6: return Color.Cyan;
                case 7: return Color.Magenta;
                default: return Color.Blue;
            }
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

        private void groupBoxForma_Enter(object sender, EventArgs e)
        {

        }
    }
}
