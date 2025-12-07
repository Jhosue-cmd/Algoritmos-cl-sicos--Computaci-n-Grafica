using System;
using System.Drawing;

namespace Algoritmo_de_lineas.Recorte_de_Lineas.model
{
    /// <summary>
    /// Implementación del algoritmo de Liang-Barsky para recorte de líneas
    /// </summary>
    public class CLiangBarsky
    {
        #region Propiedades de la ventana de recorte

        public float XMin { get; private set; }
        public float YMin { get; private set; }
        public float XMax { get; private set; }
        public float YMax { get; private set; }

        #endregion

        #region Resultado del recorte

        /// <summary>
        /// Resultado del algoritmo de recorte
        /// </summary>
        public class ResultadoRecorte
        {
            public bool LineaVisible { get; set; }
            public PointF PuntoInicio { get; set; }
            public PointF PuntoFin { get; set; }
            public float T1 { get; set; }
            public float T2 { get; set; }
            public string Descripcion { get; set; }
            public float[] ValoresP { get; set; }
            public float[] ValoresQ { get; set; }
        }

        #endregion

        #region Validaciones

        /// <summary>
        /// Valida que las coordenadas de la ventana sean válidas
        /// </summary>
        public bool ValidarVentana(float xMin, float yMin, float xMax, float yMax)
        {
            return xMin < xMax && yMin < yMax &&
                   !float.IsNaN(xMin) && !float.IsNaN(yMin) &&
                   !float.IsNaN(xMax) && !float.IsNaN(yMax);
        }

        /// <summary>
        /// Valida que un punto tenga coordenadas en rango válido
        /// </summary>
        public bool ValidarPunto(float x, float y)
        {
            return !float.IsNaN(x) && !float.IsNaN(y) &&
                   !float.IsInfinity(x) && !float.IsInfinity(y) &&
                   x >= -10000 && x <= 10000 &&
                   y >= -10000 && y <= 10000;
        }

        /// <summary>
        /// Valida que la línea tenga puntos diferentes
        /// </summary>
        public bool ValidarLinea(float x1, float y1, float x2, float y2)
        {
            return !(Math.Abs(x1 - x2) < 0.0001f && Math.Abs(y1 - y2) < 0.0001f);
        }

        #endregion

        #region Algoritmo Liang-Barsky

        /// <summary>
        /// Configura la ventana de recorte
        /// </summary>
        public void ConfigurarVentana(float xMin, float yMin, float xMax, float yMax)
        {
            if (!ValidarVentana(xMin, yMin, xMax, yMax))
                throw new ArgumentException("Coordenadas de ventana inválidas");

            XMin = xMin;
            YMin = yMin;
            XMax = xMax;
            YMax = yMax;
        }

        /// <summary>
        /// Función auxiliar para calcular los parámetros de recorte
        /// </summary>
        private bool ClipTest(float p, float q, ref float t1, ref float t2)
        {
            float r;
            bool resultado = true;

            if (p < 0)
            {
                // Línea entra (de afuera hacia adentro)
                r = q / p;
                if (r > t2)
                    resultado = false;
                else if (r > t1)
                    t1 = r;
            }
            else if (p > 0)
            {
                // Línea sale (de adentro hacia afuera)
                r = q / p;
                if (r < t1)
                    resultado = false;
                else if (r < t2)
                    t2 = r;
            }
            else if (q < 0)
            {
                // Línea paralela y fuera del borde
                resultado = false;
            }
            // Si p == 0 y q >= 0, la línea está dentro del borde (paralela)

            return resultado;
        }

        /// <summary>
        /// Ejecuta el algoritmo de Liang-Barsky
        /// </summary>
        public ResultadoRecorte Recortar(float x1, float y1, float x2, float y2)
        {
            ResultadoRecorte resultado = new ResultadoRecorte();

            // Validar entrada
            if (!ValidarPunto(x1, y1) || !ValidarPunto(x2, y2))
            {
                resultado.LineaVisible = false;
                resultado.Descripcion = "Coordenadas inválidas";
                return resultado;
            }

            // Calcular diferencias (dirección de la línea)
            float dx = x2 - x1;
            float dy = y2 - y1;

            // Parámetros iniciales
            float t1 = 0.0f;
            float t2 = 1.0f;

            // Calcular p y q para cada borde
            // p[i] = -dx, dx, -dy, dy
            // q[i] = x1-xmin, xmax-x1, y1-ymin, ymax-y1
            float[] p = new float[4];
            float[] q = new float[4];

            p[0] = -dx;         // Borde izquierdo
            q[0] = x1 - XMin;

            p[1] = dx;          // Borde derecho
            q[1] = XMax - x1;

            p[2] = -dy;         // Borde inferior
            q[2] = y1 - YMin;

            p[3] = dy;          // Borde superior
            q[3] = YMax - y1;

            resultado.ValoresP = p;
            resultado.ValoresQ = q;

            // Aplicar test de recorte para cada borde
            bool visible = true;
            string[] bordes = { "izquierdo", "derecho", "inferior", "superior" };

            for (int i = 0; i < 4 && visible; i++)
            {
                visible = ClipTest(p[i], q[i], ref t1, ref t2);
            }

            resultado.T1 = t1;
            resultado.T2 = t2;

            if (visible)
            {
                resultado.LineaVisible = true;

                // Calcular puntos recortados
                float xInicio = x1 + t1 * dx;
                float yInicio = y1 + t1 * dy;
                float xFin = x1 + t2 * dx;
                float yFin = y1 + t2 * dy;

                resultado.PuntoInicio = new PointF(xInicio, yInicio);
                resultado.PuntoFin = new PointF(xFin, yFin);

                if (t1 == 0 && t2 == 1)
                {
                    resultado.Descripcion = "Línea completamente visible (sin recorte)";
                }
                else
                {
                    resultado.Descripcion = $"Línea recortada: t1={t1:F3}, t2={t2:F3}";
                }
            }
            else
            {
                resultado.LineaVisible = false;
                resultado.Descripcion = "Línea completamente fuera de la ventana";
            }

            return resultado;
        }

        #endregion

        #region Métodos de dibujo

        /// <summary>
        /// Dibuja la ventana de recorte
        /// </summary>
        public void DibujarVentanaRecorte(Graphics g, int offsetX, int offsetY, int escala, Color color)
        {
            int px1 = offsetX + (int)(XMin * escala);
            int py1 = offsetY - (int)(YMax * escala);
            int ancho = (int)((XMax - XMin) * escala);
            int alto = (int)((YMax - YMin) * escala);

            using (Pen pen = new Pen(color, 2))
            {
                pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                g.DrawRectangle(pen, px1, py1, ancho, alto);
            }

            // Etiquetas de esquinas
            using (Font font = new Font("Arial", 7))
            using (Brush brush = new SolidBrush(color))
            {
                g.DrawString($"({XMin},{YMax})", font, brush, px1 - 25, py1 - 15);
                g.DrawString($"({XMax},{YMax})", font, brush, px1 + ancho + 2, py1 - 15);
                g.DrawString($"({XMin},{YMin})", font, brush, px1 - 25, py1 + alto + 2);
                g.DrawString($"({XMax},{YMin})", font, brush, px1 + ancho + 2, py1 + alto + 2);
            }
        }

        /// <summary>
        /// Dibuja una línea original (antes del recorte)
        /// </summary>
        public void DibujarLineaOriginal(Graphics g, float x1, float y1, float x2, float y2,
            int offsetX, int offsetY, int escala, Color color)
        {
            int px1 = offsetX + (int)(x1 * escala);
            int py1 = offsetY - (int)(y1 * escala);
            int px2 = offsetX + (int)(x2 * escala);
            int py2 = offsetY - (int)(y2 * escala);

            using (Pen pen = new Pen(color, 1))
            {
                pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
                g.DrawLine(pen, px1, py1, px2, py2);
            }

            // Puntos extremos
            using (Brush brush = new SolidBrush(color))
            {
                g.FillEllipse(brush, px1 - 4, py1 - 4, 8, 8);
                g.FillEllipse(brush, px2 - 4, py2 - 4, 8, 8);
            }
        }

        /// <summary>
        /// Dibuja la línea recortada
        /// </summary>
        public void DibujarLineaRecortada(Graphics g, PointF inicio, PointF fin,
            int offsetX, int offsetY, int escala, Color color)
        {
            int px1 = offsetX + (int)(inicio.X * escala);
            int py1 = offsetY - (int)(inicio.Y * escala);
            int px2 = offsetX + (int)(fin.X * escala);
            int py2 = offsetY - (int)(fin.Y * escala);

            using (Pen pen = new Pen(color, 3))
            {
                g.DrawLine(pen, px1, py1, px2, py2);
            }

            // Puntos de la línea recortada
            using (Brush brush = new SolidBrush(Color.Green))
            {
                g.FillEllipse(brush, px1 - 5, py1 - 5, 10, 10);
                g.FillEllipse(brush, px2 - 5, py2 - 5, 10, 10);
            }
        }

        #endregion
    }
}
