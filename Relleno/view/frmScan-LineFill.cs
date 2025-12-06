using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Algoritmo_de_lineas.Relleno.model;

namespace Algoritmo_de_lineas.Relleno.view
{
    public partial class frmScan_LineFill : Form
    {
        #region Campos privados

        private CScanLineFill algoritmo;
        private Bitmap bmp;
        private Graphics g;
        private List<Point> vertices;
        private const int ESCALA = 10;

        #endregion

        #region Constructor

        public frmScan_LineFill()
        {
            InitializeComponent();
            algoritmo = new CScanLineFill();
            vertices = new List<Point>();
        }

        #endregion

        #region Eventos del formulario

        private void frmScan_LineFill_Load(object sender, EventArgs e)
        {
            InicializarLienzo();
            cmbColorRelleno.SelectedIndex = 0;
            cmbColorBorde.SelectedIndex = 1;
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

        private void btnAgregarVertice_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar campos no vacíos
                if (string.IsNullOrWhiteSpace(txtX.Text) || string.IsNullOrWhiteSpace(txtY.Text))
                {
                    MessageBox.Show("Por favor, ingrese las coordenadas X e Y del vértice.",
                        "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validar que sean números enteros
                if (!int.TryParse(txtX.Text, out int x) || !int.TryParse(txtY.Text, out int y))
                {
                    MessageBox.Show("Por favor, ingrese solo números enteros.",
                        "Datos inválidos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Validar rango de coordenadas
                if (!algoritmo.ValidarPunto(x, y))
                {
                    MessageBox.Show("Las coordenadas deben estar entre -1000 y 1000.",
                        "Coordenadas fuera de rango", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Convertir a coordenadas de pantalla
                int centroX = pictureBox1.Width / 2;
                int centroY = pictureBox1.Height / 2;
                int px = centroX + (x * ESCALA);
                int py = centroY - (y * ESCALA);

                // Agregar vértice
                vertices.Add(new Point(px, py));
                lstVertices.Items.Add($"V{vertices.Count}: ({x}, {y})");

                // Dibujar punto
                using (Brush brush = new SolidBrush(Color.Blue))
                {
                    g.FillEllipse(brush, px - 4, py - 4, 8, 8);
                }

                // Dibujar línea si hay más de un vértice
                if (vertices.Count > 1)
                {
                    using (Pen pen = new Pen(Color.Blue, 1))
                    {
                        pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                        g.DrawLine(pen, vertices[vertices.Count - 2], vertices[vertices.Count - 1]);
                    }
                }

                pictureBox1.Refresh();

                // Limpiar campos
                txtX.Clear();
                txtY.Clear();
                txtX.Focus();

                lblEstado.Text = $"Vértices: {vertices.Count}. Mínimo 3 para rellenar.";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar vértice: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRellenar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar polígono
                if (!algoritmo.ValidarPoligono(vertices))
                {
                    MessageBox.Show("Se necesitan al menos 3 vértices para formar un polígono.",
                        "Polígono inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validar que no sean colineales
                if (!algoritmo.ValidarNoColineal(vertices))
                {
                    MessageBox.Show("Los vértices son colineales y no forman un polígono válido.\n" +
                        "Por favor, agregue vértices que no estén en línea recta.",
                        "Polígono inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Obtener colores
                Color colorRelleno = ObtenerColorSeleccionado(cmbColorRelleno);
                Color colorBorde = ObtenerColorSeleccionado(cmbColorBorde);

                // Limpiar y redibujar
                g.Clear(Color.White);
                DibujarCuadricula();
                DibujarEjes();

                // Dibujar el polígono rellenado
                algoritmo.DibujarRellenoPoligono(g, vertices, colorRelleno, colorBorde);

                pictureBox1.Refresh();

                // Calcular y mostrar información
                double area = algoritmo.CalcularAreaPoligono(vertices) / (ESCALA * ESCALA);
                double perimetro = algoritmo.CalcularPerimetroPoligono(vertices) / ESCALA;

                MessageBox.Show($"Polígono rellenado correctamente.\n\n" +
                    $"Número de vértices: {vertices.Count}\n" +
                    $"Área aproximada: {area:F2} unidades²\n" +
                    $"Perímetro aproximado: {perimetro:F2} unidades\n\n" +
                    $"Algoritmo: Scan-Line Fill",
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                lblEstado.Text = "Relleno completado con Scan-Line Fill.";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al rellenar el polígono: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            vertices.Clear();
            lstVertices.Items.Clear();
            txtX.Clear();
            txtY.Clear();

            g.Clear(Color.White);
            DibujarCuadricula();
            DibujarEjes();
            pictureBox1.Refresh();

            lblEstado.Text = "Listo. Agregue vértices para crear un polígono.";
            txtX.Focus();
        }

        private void btnQuitarVertice_Click(object sender, EventArgs e)
        {
            if (vertices.Count > 0)
            {
                vertices.RemoveAt(vertices.Count - 1);
                lstVertices.Items.RemoveAt(lstVertices.Items.Count - 1);

                // Redibujar
                g.Clear(Color.White);
                DibujarCuadricula();
                DibujarEjes();

                // Redibujar vértices y líneas
                for (int i = 0; i < vertices.Count; i++)
                {
                    using (Brush brush = new SolidBrush(Color.Blue))
                    {
                        g.FillEllipse(brush, vertices[i].X - 4, vertices[i].Y - 4, 8, 8);
                    }
                    if (i > 0)
                    {
                        using (Pen pen = new Pen(Color.Blue, 1))
                        {
                            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                            g.DrawLine(pen, vertices[i - 1], vertices[i]);
                        }
                    }
                }

                pictureBox1.Refresh();
                lblEstado.Text = $"Vértices: {vertices.Count}. Mínimo 3 para rellenar.";
            }
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (chkDibujarConMouse.Checked)
            {
                // Convertir coordenadas de pantalla a coordenadas del sistema
                int centroX = pictureBox1.Width / 2;
                int centroY = pictureBox1.Height / 2;
                int x = (e.X - centroX) / ESCALA;
                int y = (centroY - e.Y) / ESCALA;

                // Convertir de vuelta para precisión
                int px = centroX + (x * ESCALA);
                int py = centroY - (y * ESCALA);

                vertices.Add(new Point(px, py));
                lstVertices.Items.Add($"V{vertices.Count}: ({x}, {y})");

                using (Brush brush = new SolidBrush(Color.Blue))
                {
                    g.FillEllipse(brush, px - 4, py - 4, 8, 8);
                }

                if (vertices.Count > 1)
                {
                    using (Pen pen = new Pen(Color.Blue, 1))
                    {
                        pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                        g.DrawLine(pen, vertices[vertices.Count - 2], vertices[vertices.Count - 1]);
                    }
                }

                pictureBox1.Refresh();
                lblEstado.Text = $"Vértices: {vertices.Count}. Mínimo 3 para rellenar.";
            }
        }

        #endregion

        #region Métodos auxiliares

        private Color ObtenerColorSeleccionado(ComboBox cmb)
        {
            switch (cmb.SelectedIndex)
            {
                case 0: return Color.FromArgb(100, 0, 150, 255); // Azul transparente
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
    }
}
