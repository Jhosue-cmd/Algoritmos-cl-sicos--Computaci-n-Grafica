using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Algoritmo_de_lineas
{
    public partial class frmDDA : Form
    {
        private CDDA algoritmo;
        private Bitmap bmp;
        private Graphics g;
        private const int ESCALA = 10;

        // Variables para simulación
        private List<Point> puntosLinea;
        private int pasoActual;
        private bool enSimulacion;
        private Timer timerSimulacion;
        private int x1Sim, y1Sim, x2Sim, y2Sim;
        private int px1, py1, px2, py2;

        public frmDDA()
        {
            InitializeComponent();
            algoritmo = new CDDA();
            puntosLinea = new List<Point>();
            
            // Configurar timer para simulación
            timerSimulacion = new Timer();
            timerSimulacion.Interval = 500; // 500ms entre pasos
            timerSimulacion.Tick += TimerSimulacion_Tick;
        }

        private void frmDDA_Load(object sender, EventArgs e)
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

        private void ActualizarEstadoBotones(bool simulando)
        {
            enSimulacion = simulando;
            btnDibujar.Enabled = !simulando;
            btnSimular.Enabled = !simulando;
            btnPaso.Enabled = simulando;
            btnDetener.Enabled = simulando;
            txtX1.Enabled = !simulando;
            txtY1.Enabled = !simulando;
            txtX2.Enabled = !simulando;
            txtY2.Enabled = !simulando;
        }

        private bool ValidarEntradas(out int x1, out int y1, out int x2, out int y2)
        {
            x1 = y1 = x2 = y2 = 0;

            if (string.IsNullOrWhiteSpace(txtX1.Text) || string.IsNullOrWhiteSpace(txtY1.Text) ||
                string.IsNullOrWhiteSpace(txtX2.Text) || string.IsNullOrWhiteSpace(txtY2.Text))
            {
                MessageBox.Show("Por favor, ingrese todos los valores.", "Datos incompletos", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!int.TryParse(txtX1.Text, out x1) || !int.TryParse(txtY1.Text, out y1) ||
                !int.TryParse(txtX2.Text, out x2) || !int.TryParse(txtY2.Text, out y2))
            {
                MessageBox.Show("Ingrese solo numeros enteros.", "Datos invalidos", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Los puntos no pueden ser iguales.", "Puntos iguales", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void btnDibujar_Click(object sender, EventArgs e)
        {
            if (!ValidarEntradas(out int x1, out int y1, out int x2, out int y2))
                return;

            g.Clear(Color.White);
            DibujarCuadricula();
            DibujarEjes();

            int centroX = pictureBox1.Width / 2;
            int centroY = pictureBox1.Height / 2;

            px1 = centroX + (x1 * ESCALA);
            py1 = centroY - (y1 * ESCALA);
            px2 = centroX + (x2 * ESCALA);
            py2 = centroY - (y2 * ESCALA);

            algoritmo.DibujarLinea(g, px1, py1, px2, py2, Color.Blue, 3);

            double pendiente = algoritmo.CalcularPendiente(x1, y1, x2, y2);
            txtResultado.Text = $"═══ RESULTADO DDA ═══\r\n\r\n" +
                $"Punto inicial: ({x1}, {y1})\r\n" +
                $"Punto final: ({x2}, {y2})\r\n" +
                $"Pendiente: {(double.IsInfinity(pendiente) ? "∞" : pendiente.ToString("F3"))}\r\n" +
                $"Distancia: {Math.Sqrt(Math.Pow(x2-x1, 2) + Math.Pow(y2-y1, 2)):F2}";


            // Enfocar en el TextBox de resultados
            txtResultado.Focus();

            pictureBox1.Refresh();
        }

        private void btnSimular_Click(object sender, EventArgs e)
        {
            if (!ValidarEntradas(out x1Sim, out y1Sim, out x2Sim, out y2Sim))
                return;

            // Preparar simulación
            g.Clear(Color.White);
            DibujarCuadricula();
            DibujarEjes();

            int centroX = pictureBox1.Width / 2;
            int centroY = pictureBox1.Height / 2;

            px1 = centroX + (x1Sim * ESCALA);
            py1 = centroY - (y1Sim * ESCALA);
            px2 = centroX + (x2Sim * ESCALA);
            py2 = centroY - (y2Sim * ESCALA);

            // Calcular línea con pasos
            puntosLinea = algoritmo.CalcularLineaConPasos(px1, py1, px2, py2);
            pasoActual = 0;

            // Dibujar puntos inicial y final
            using (Brush brushInicio = new SolidBrush(Color.Green))
            using (Brush brushFin = new SolidBrush(Color.Red))
            {
                g.FillEllipse(brushInicio, px1 - 5, py1 - 5, 10, 10);
                g.FillEllipse(brushFin, px2 - 5, py2 - 5, 10, 10);
            }

            // Mostrar información inicial
            txtResultado.Text = $"═══ SIMULACIÓN DDA ═══\r\n\r\n" +
                $"Total de pasos: {puntosLinea.Count}\r\n" +
                $"X incremento: {algoritmo.XIncremento:F3}\r\n" +
                $"Y incremento: {algoritmo.YIncremento:F3}\r\n\r\n" +
                $"Presione 'Paso' o espere...\r\n" +
                $"━━━━━━━━━━━━━━━━━━━━━";

            ActualizarEstadoBotones(true);
            timerSimulacion.Start();
            pictureBox1.Refresh();
        }

        private void btnPaso_Click(object sender, EventArgs e)
        {
            if (enSimulacion)
            {
                timerSimulacion.Stop();
                EjecutarPaso();
            }
        }

        private void btnDetener_Click(object sender, EventArgs e)
        {
            timerSimulacion.Stop();
            
            // Dibujar todos los píxeles restantes
            for (int i = pasoActual; i < puntosLinea.Count; i++)
            {
                algoritmo.DibujarPixel(g, puntosLinea[i].X, puntosLinea[i].Y, Color.Blue, ESCALA - 2);
            }

            txtResultado.Text += $"\r\n\r\n¡SIMULACIÓN COMPLETADA!\r\nTotal píxeles: {puntosLinea.Count}";
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
                Point p = puntosLinea[pasoActual];
                
                // Dibujar el píxel actual con color destacado
                algoritmo.DibujarPixel(g, p.X, p.Y, Color.Blue, ESCALA - 2);
                
                // Mostrar información del paso
                if (pasoActual < algoritmo.PasosSimulacion.Count)
                {
                    var paso = algoritmo.PasosSimulacion[pasoActual + 1]; // +1 porque el primero es INICIO
                    txtResultado.Text = $"═══ SIMULACIÓN DDA ═══\r\n\r\n" +
                        $"PASO {pasoActual + 1} de {puntosLinea.Count}\r\n" +
                        $"━━━━━━━━━━━━━━━━━━━━━\r\n" +
                        $"{paso.Descripcion}\r\n" +
                        $"━━━━━━━━━━━━━━━━━━━━━\r\n" +
                        $"Píxel dibujado: ({paso.XRedondeado}, {paso.YRedondeado})";
                }

                pasoActual++;
                pictureBox1.Refresh();
            }
            else
            {
                timerSimulacion.Stop();
                txtResultado.Text += $"\r\n\r\n✓ ¡LÍNEA COMPLETADA!\r\nTotal píxeles: {puntosLinea.Count}";
                ActualizarEstadoBotones(false);
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            timerSimulacion.Stop();
            txtX1.Clear();
            txtY1.Clear();
            txtX2.Clear();
            txtY2.Clear();
            txtResultado.Clear();

            g.Clear(Color.White);
            DibujarCuadricula();
            DibujarEjes();
            pictureBox1.Refresh();

            ActualizarEstadoBotones(false);
            txtX1.Focus();
        }

        private void groupBox2_Enter(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            timerSimulacion.Stop();
            timerSimulacion.Dispose();
            if (g != null) g.Dispose();
            if (bmp != null) bmp.Dispose();
            base.OnFormClosing(e);
        }
    }
}
