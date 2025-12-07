using System;
using System.Drawing;

namespace Algoritmo_de_lineas.Recorte_de_Lineas.model
{
    /// <summary>
    /// Implementación del algoritmo de Cohen-Sutherland para recorte de líneas
    /// </summary>
    public class CCohenSutherland
    {
        #region Códigos de región (outcodes)

        // Códigos de 4 bits para las 9 regiones
        private const int INSIDE = 0;  // 0000
        private const int LEFT = 1;    // 0001
        private const int RIGHT = 2;   // 0010
        private const int BOTTOM = 4;  // 0100
        private const int TOP = 8;     // 1000

        #endregion

        #region Propiedades de la ventana de recorte

        public int XMin { get; private set; }
        public int YMin { get; private set; }
        public int XMax { get; private set; }
        public int YMax { get; private set; }

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
            public int OutcodeInicio { get; set; }
            public int OutcodeFin { get; set; }
            public string Descripcion { get; set; }
            public int Iteraciones { get; set; }
        }

        #endregion

        #region Validaciones

        /// <summary>
        /// Valida que las coordenadas de la ventana sean válidas
        /// </summary>
        public bool ValidarVentana(int xMin, int yMin, int xMax, int yMax)
        {
            return xMin < xMax && yMin < yMax;
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
            return !(x1 == x2 && y1 == y2);
        }

        #endregion

        #region Algoritmo Cohen-Sutherland

        /// <summary>
        /// Configura la ventana de recorte
        /// </summary>
        public void ConfigurarVentana(int xMin, int yMin, int xMax, int yMax)
        {
            if (!ValidarVentana(xMin, yMin, xMax, yMax))
                throw new ArgumentException("Coordenadas de ventana inválidas");

            XMin = xMin;
            YMin = yMin;
            XMax = xMax;
            YMax = yMax;
        }

        /// <summary>
        /// Calcula el código de región (outcode) para un punto
        /// </summary>
        public int CalcularOutcode(float x, float y)
        {
            int code = INSIDE;

            if (x < XMin)
                code |= LEFT;
            else if (x > XMax)
                code |= RIGHT;

            if (y < YMin)
                code |= BOTTOM;
            else if (y > YMax)
                code |= TOP;

            return code;
        }

        /// <summary>
        /// Obtiene la descripción del código de región
        /// </summary>
        public string ObtenerDescripcionOutcode(int outcode)
        {
            if (outcode == INSIDE) return "DENTRO";

            string desc = "";
            if ((outcode & LEFT) != 0) desc += "IZQUIERDA ";
            if ((outcode & RIGHT) != 0) desc += "DERECHA ";
            if ((outcode & BOTTOM) != 0) desc += "ABAJO ";
            if ((outcode & TOP) != 0) desc += "ARRIBA ";

            return desc.Trim();
        }

        /// <summary>
        /// Ejecuta el algoritmo de Cohen-Sutherland
        /// </summary>
        public ResultadoRecorte Recortar(float x1, float y1, float x2, float y2)
        {
            ResultadoRecorte resultado = new ResultadoRecorte();
            resultado.Iteraciones = 0;

            // Validar entrada
            if (!ValidarPunto(x1, y1) || !ValidarPunto(x2, y2))
            {
                resultado.LineaVisible = false;
                resultado.Descripcion = "Coordenadas inválidas";
                return resultado;
            }

            // Calcular outcodes iniciales
            int outcode1 = CalcularOutcode(x1, y1);
            int outcode2 = CalcularOutcode(x2, y2);

            resultado.OutcodeInicio = outcode1;
            resultado.OutcodeFin = outcode2;

            bool aceptada = false;

            while (true)
            {
                resultado.Iteraciones++;

                // Prevenir bucle infinito
                if (resultado.Iteraciones > 100)
                {
                    resultado.LineaVisible = false;
                    resultado.Descripcion = "Exceso de iteraciones";
                    return resultado;
                }

                // Caso 1: Ambos puntos dentro - aceptar trivialmente
                if ((outcode1 | outcode2) == 0)
                {
                    aceptada = true;
                    resultado.Descripcion = "Línea completamente visible (aceptación trivial)";
                    break;
                }
                // Caso 2: Ambos puntos en el mismo lado externo - rechazar trivialmente
                else if ((outcode1 & outcode2) != 0)
                {
                    resultado.Descripcion = "Línea completamente fuera (rechazo trivial)";
                    break;
                }
                // Caso 3: Necesita recorte
                else
                {
                    float x = 0, y = 0;

                    // Seleccionar el punto fuera de la ventana
                    int outcodeOut = (outcode1 != 0) ? outcode1 : outcode2;

                    // Calcular intersección con el borde
                    if ((outcodeOut & TOP) != 0)
                    {
                        // Intersección con borde superior
                        x = x1 + (x2 - x1) * (YMax - y1) / (y2 - y1);
                        y = YMax;
                    }
                    else if ((outcodeOut & BOTTOM) != 0)
                    {
                        // Intersección con borde inferior
                        x = x1 + (x2 - x1) * (YMin - y1) / (y2 - y1);
                        y = YMin;
                    }
                    else if ((outcodeOut & RIGHT) != 0)
                    {
                        // Intersección con borde derecho
                        y = y1 + (y2 - y1) * (XMax - x1) / (x2 - x1);
                        x = XMax;
                    }
                    else if ((outcodeOut & LEFT) != 0)
                    {
                        // Intersección con borde izquierdo
                        y = y1 + (y2 - y1) * (XMin - x1) / (x2 - x1);
                        x = XMin;
                    }

                    // Reemplazar el punto fuera con el punto de intersección
                    if (outcodeOut == outcode1)
                    {
                        x1 = x;
                        y1 = y;
                        outcode1 = CalcularOutcode(x1, y1);
                    }
                    else
                    {
                        x2 = x;
                        y2 = y;
                        outcode2 = CalcularOutcode(x2, y2);
                    }
                }
            }

            resultado.LineaVisible = aceptada;
            if (aceptada)
            {
                resultado.PuntoInicio = new PointF(x1, y1);
                resultado.PuntoFin = new PointF(x2, y2);
                if (resultado.Iteraciones > 1)
                {
                    resultado.Descripcion = $"Línea recortada en {resultado.Iteraciones - 1} iteración(es)";
                }
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
            int px1 = offsetX + XMin * escala;
            int py1 = offsetY - YMax * escala;
            int ancho = (XMax - XMin) * escala;
            int alto = (YMax - YMin) * escala;

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
