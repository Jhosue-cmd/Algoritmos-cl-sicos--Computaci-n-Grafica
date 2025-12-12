using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Algoritmo_de_lineas
{
    public partial class frmBresenham : Form
    {
        private CBresenham algoritmo;
        private Bitmap bmp;
        private Graphics g;
        private const int ESCALA = 10;
        private List<Point> puntosLinea;
        private int pasoActual;
        private bool enSimulacion;
        private Timer timerSimulacion;
        private int px1, py1, px2, py2;

        public frmBresenham()
        {
            InitializeComponent();
            algoritmo = new CBresenham();
            puntosLinea = new List<Point>();
            timerSimulacion = new Timer();
            timerSimulacion.Interval = 500;
            timerSimulacion.Tick += TimerSimulacion_Tick;
        }

        private void frmBresenham_Load(object sender, EventArgs e)
        {
            InicializarLienzo();
            ActualizarEstadoBotones(false);
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
            using (Pen pen = new Pen(Color.FromArgb(240, 240, 240), 1))
            {
                int cx = pictureBox1.Width / 2;
                int cy = pictureBox1.Height / 2;
                for (int i = -cx; i <= cx; i += ESCALA)
                    g.DrawLine(pen, cx + i, 0, cx + i, pictureBox1.Height);
                for (int i = -cy; i <= cy; i += ESCALA)
                    g.DrawLine(pen, 0, cy + i, pictureBox1.Width, cy + i);
            }
        }

        private void DibujarEjes()
        {
            int cx = pictureBox1.Width / 2;
            int cy = pictureBox1.Height / 2;
            using (Pen pen = new Pen(Color.Gray, 2))
            using (Font font = new Font("Arial", 7))
            using (Brush brush = new SolidBrush(Color.Black))
            {
                g.DrawLine(pen, 0, cy, pictureBox1.Width, cy);
                g.DrawLine(pen, cx, 0, cx, pictureBox1.Height);
                g.DrawString("X", new Font("Arial", 9, FontStyle.Bold), brush, pictureBox1.Width - 15, cy + 5);
                g.DrawString("Y", new Font("Arial", 9, FontStyle.Bold), brush, cx + 5, 5);
                g.DrawString("(0,0)", font, brush, cx + 3, cy + 3);
            }
        }

        private void ActualizarEstadoBotones(bool sim)
        {
            enSimulacion = sim;
            btnDibujar.Enabled = !sim;
            btnSimular.Enabled = !sim;
            btnPaso.Enabled = sim;
            btnDetener.Enabled = sim;
            txtX1.Enabled = !sim;
            txtY1.Enabled = !sim;
            txtX2.Enabled = !sim;
            txtY2.Enabled = !sim;
        }

        private bool ValidarEntradas(out int x1, out int y1, out int x2, out int y2)
        {
            x1 = y1 = x2 = y2 = 0;
            if (string.IsNullOrWhiteSpace(txtX1.Text) || string.IsNullOrWhiteSpace(txtY1.Text) ||
                string.IsNullOrWhiteSpace(txtX2.Text) || string.IsNullOrWhiteSpace(txtY2.Text))
            {
                MessageBox.Show("Ingrese todos los valores.", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!int.TryParse(txtX1.Text, out x1) || !int.TryParse(txtY1.Text, out y1) ||
                !int.TryParse(txtX2.Text, out x2) || !int.TryParse(txtY2.Text, out y2))
            {
                MessageBox.Show("Ingrese solo numeros enteros.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Validar rango de -15 a 15
            if (x1 < -15 || x1 > 15 || y1 < -15 || y1 > 15 ||
                x2 < -15 || x2 > 15 || y2 < -15 || y2 > 15)
            {
                MessageBox.Show("Los valores deben estar entre -15 y 15.", 
                    "Fuera de rango", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (x1 == x2 && y1 == y2)
            {
                MessageBox.Show("Los puntos no pueden ser iguales.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private bool ValidarPuntoEnArea(int x, int y)
        {
            return x >= 0 && x < pictureBox1.Width && y >= 0 && y < pictureBox1.Height;
        }

        private void btnDibujar_Click(object sender, EventArgs e)
        {
            if (!ValidarEntradas(out int x1, out int y1, out int x2, out int y2)) return;

            g.Clear(Color.White);
            DibujarCuadricula();
            DibujarEjes();

            int cx = pictureBox1.Width / 2;
            int cy = pictureBox1.Height / 2;
            px1 = cx + x1 * ESCALA;
            py1 = cy - y1 * ESCALA;
            px2 = cx + x2 * ESCALA;
            py2 = cy - y2 * ESCALA;

            algoritmo.DibujarLinea(g, px1, py1, px2, py2, Color.DarkGreen, 3);

            txtResultado.Text = "=== BRESENHAM ===\r\n\r\n" +
                $"({x1},{y1}) -> ({x2},{y2})\r\n" +
                $"dx={Math.Abs(x2-x1)}, dy={Math.Abs(y2-y1)}";
            pictureBox1.Refresh();
        }

        private void btnSimular_Click(object sender, EventArgs e)
        {
            if (!ValidarEntradas(out int x1, out int y1, out int x2, out int y2)) return;

            g.Clear(Color.White);
            DibujarCuadricula();
            DibujarEjes();

            int cx = pictureBox1.Width / 2;
            int cy = pictureBox1.Height / 2;
            px1 = cx + x1 * ESCALA;
            py1 = cy - y1 * ESCALA;
            px2 = cx + x2 * ESCALA;
            py2 = cy - y2 * ESCALA;

            puntosLinea = algoritmo.CalcularLineaConPasos(px1, py1, px2, py2);
            pasoActual = 0;

            using (Brush b1 = new SolidBrush(Color.Green))
            using (Brush b2 = new SolidBrush(Color.Red))
            {
                g.FillEllipse(b1, px1 - 5, py1 - 5, 10, 10);
                g.FillEllipse(b2, px2 - 5, py2 - 5, 10, 10);
            }

            txtResultado.Text = "=== SIMULACION BRESENHAM ===\r\n\r\n" +
                $"Pasos: {puntosLinea.Count}\r\n" +
                $"dx={algoritmo.Dx}, dy={algoritmo.Dy}\r\n" +
                $"sx={algoritmo.Sx}, sy={algoritmo.Sy}";

            ActualizarEstadoBotones(true);
            timerSimulacion.Start();
            pictureBox1.Refresh();
        }

        private void btnPaso_Click(object sender, EventArgs e)
        {
            timerSimulacion.Stop();
            EjecutarPaso();
        }

        private void btnDetener_Click(object sender, EventArgs e)
        {
            timerSimulacion.Stop();
            for (int i = pasoActual; i < puntosLinea.Count; i++)
                algoritmo.DibujarPixel(g, puntosLinea[i].X, puntosLinea[i].Y, Color.DarkGreen, ESCALA - 2);
            txtResultado.Text += "\r\n\r\n COMPLETADO!";
            ActualizarEstadoBotones(false);
            pictureBox1.Refresh();
        }

        private void TimerSimulacion_Tick(object sender, EventArgs e)
        {
            EjecutarPaso();
        }

        private void EjecutarPaso()
        {
            if (pasoActual < puntosLinea.Count)
            {
                var p = puntosLinea[pasoActual];
                algoritmo.DibujarPixel(g, p.X, p.Y, Color.DarkGreen, ESCALA - 2);

                if (pasoActual + 1 < algoritmo.PasosSimulacion.Count)
                {
                    var paso = algoritmo.PasosSimulacion[pasoActual + 1];
                    txtResultado.Text = $"=== PASO {pasoActual + 1}/{puntosLinea.Count} ===\r\n\r\n" +
                        $"{paso.Descripcion}\r\n\r\n" +
                        $"Decision: {paso.Decision}\r\n" +
                        $"Error: {paso.Error}";
                }
                pasoActual++;
                pictureBox1.Refresh();
            }
            else
            {
                timerSimulacion.Stop();
                txtResultado.Text += "\r\n\r\n[OK] LINEA COMPLETADA!";
                ActualizarEstadoBotones(false);
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            timerSimulacion.Stop();
            txtX1.Clear(); txtY1.Clear(); txtX2.Clear(); txtY2.Clear();
            txtResultado.Clear();
            g.Clear(Color.White);
            DibujarCuadricula();
            DibujarEjes();
            ActualizarEstadoBotones(false);
            pictureBox1.Refresh();
            txtX1.Focus();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            timerSimulacion?.Stop();
            timerSimulacion?.Dispose();
            g?.Dispose();
            bmp?.Dispose();
            base.OnFormClosing(e);
        }
    }
}
