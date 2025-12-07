using System;
using System.Drawing;

namespace Algoritmo_de_lineas.Recorte_de_Lineas.model
{
    /// <summary>
    /// Implementación del algoritmo de Nicholl-Lee-Nicholl para recorte de líneas
    /// Este algoritmo es más eficiente que Cohen-Sutherland al reducir las operaciones de recorte
    /// </summary>
    public class CNichollLeeNicholl
    {
        #region Enumeraciones de regiones

        /// <summary>
        /// Regiones del algoritmo NLN para el punto P1
        /// </summary>
        public enum RegionP1
        {
            Dentro,         // P1 dentro de la ventana
            Izquierda,      // P1 a la izquierda
            Derecha,        // P1 a la derecha
            Arriba,         // P1 arriba
            Abajo,          // P1 abajo
            ArribaIzquierda,
            ArribaDerecha,
            AbajoIzquierda,
            AbajoDerecha
        }

        #endregion

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
            public RegionP1 RegionPuntoInicio { get; set; }
            public string Descripcion { get; set; }
            public string RegionDescripcion { get; set; }
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

        #region Algoritmo Nicholl-Lee-Nicholl

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
        /// Determina la región donde se encuentra P1
        /// </summary>
        public RegionP1 DeterminarRegion(float x, float y)
        {
            bool izquierda = x < XMin;
            bool derecha = x > XMax;
            bool abajo = y < YMin;
            bool arriba = y > YMax;

            if (!izquierda && !derecha && !abajo && !arriba)
                return RegionP1.Dentro;

            if (izquierda && arriba) return RegionP1.ArribaIzquierda;
            if (derecha && arriba) return RegionP1.ArribaDerecha;
            if (izquierda && abajo) return RegionP1.AbajoIzquierda;
            if (derecha && abajo) return RegionP1.AbajoDerecha;
            if (izquierda) return RegionP1.Izquierda;
            if (derecha) return RegionP1.Derecha;
            if (arriba) return RegionP1.Arriba;
            if (abajo) return RegionP1.Abajo;

            return RegionP1.Dentro;
        }

        /// <summary>
        /// Obtiene descripción de la región
        /// </summary>
        public string ObtenerDescripcionRegion(RegionP1 region)
        {
            switch (region)
            {
                case RegionP1.Dentro: return "Dentro de la ventana";
                case RegionP1.Izquierda: return "Izquierda";
                case RegionP1.Derecha: return "Derecha";
                case RegionP1.Arriba: return "Arriba";
                case RegionP1.Abajo: return "Abajo";
                case RegionP1.ArribaIzquierda: return "Arriba-Izquierda";
                case RegionP1.ArribaDerecha: return "Arriba-Derecha";
                case RegionP1.AbajoIzquierda: return "Abajo-Izquierda";
                case RegionP1.AbajoDerecha: return "Abajo-Derecha";
                default: return "Desconocida";
            }
        }

        /// <summary>
        /// Ejecuta el algoritmo de Nicholl-Lee-Nicholl
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

            // Determinar región de P1
            RegionP1 regionP1 = DeterminarRegion(x1, y1);
            resultado.RegionPuntoInicio = regionP1;
            resultado.RegionDescripcion = ObtenerDescripcionRegion(regionP1);

            float xn1 = x1, yn1 = y1;
            float xn2 = x2, yn2 = y2;

            bool visible = false;

            switch (regionP1)
            {
                case RegionP1.Dentro:
                    visible = RecortarDesdeDentro(ref xn1, ref yn1, ref xn2, ref yn2);
                    break;

                case RegionP1.Izquierda:
                    visible = RecortarDesdeIzquierda(ref xn1, ref yn1, ref xn2, ref yn2);
                    break;

                case RegionP1.Derecha:
                    visible = RecortarDesdeDerecha(ref xn1, ref yn1, ref xn2, ref yn2);
                    break;

                case RegionP1.Arriba:
                    visible = RecortarDesdeArriba(ref xn1, ref yn1, ref xn2, ref yn2);
                    break;

                case RegionP1.Abajo:
                    visible = RecortarDesdeAbajo(ref xn1, ref yn1, ref xn2, ref yn2);
                    break;

                case RegionP1.ArribaIzquierda:
                    visible = RecortarDesdeEsquina(ref xn1, ref yn1, ref xn2, ref yn2, true, true);
                    break;

                case RegionP1.ArribaDerecha:
                    visible = RecortarDesdeEsquina(ref xn1, ref yn1, ref xn2, ref yn2, true, false);
                    break;

                case RegionP1.AbajoIzquierda:
                    visible = RecortarDesdeEsquina(ref xn1, ref yn1, ref xn2, ref yn2, false, true);
                    break;

                case RegionP1.AbajoDerecha:
                    visible = RecortarDesdeEsquina(ref xn1, ref yn1, ref xn2, ref yn2, false, false);
                    break;
            }

            resultado.LineaVisible = visible;

            if (visible)
            {
                resultado.PuntoInicio = new PointF(xn1, yn1);
                resultado.PuntoFin = new PointF(xn2, yn2);

                if (xn1 == x1 && yn1 == y1 && xn2 == x2 && yn2 == y2)
                {
                    resultado.Descripcion = "Línea completamente visible (sin recorte)";
                }
                else
                {
                    resultado.Descripcion = "Línea recortada exitosamente";
                }
            }
            else
            {
                resultado.Descripcion = "Línea completamente fuera de la ventana";
            }

            return resultado;
        }

        #region Métodos de recorte por región

        private bool RecortarDesdeDentro(ref float x1, ref float y1, ref float x2, ref float y2)
        {
            // P1 está dentro, solo recortar P2 si está fuera
            float dx = x2 - x1;
            float dy = y2 - y1;

            if (dx == 0 && dy == 0)
                return true; // Punto, siempre visible

            // Calcular pendientes hacia las esquinas
            if (x2 < XMin)
            {
                y2 = y1 + (XMin - x1) * dy / dx;
                x2 = XMin;
            }
            else if (x2 > XMax)
            {
                y2 = y1 + (XMax - x1) * dy / dx;
                x2 = XMax;
            }

            if (y2 < YMin)
            {
                x2 = x1 + (YMin - y1) * dx / dy;
                y2 = YMin;
            }
            else if (y2 > YMax)
            {
                x2 = x1 + (YMax - y1) * dx / dy;
                y2 = YMax;
            }

            return true;
        }

        private bool RecortarDesdeIzquierda(ref float x1, ref float y1, ref float x2, ref float y2)
        {
            float dx = x2 - x1;
            float dy = y2 - y1;

            if (dx <= 0) return false; // P2 también a la izquierda or igual

            // Calcular intersección con borde izquierdo
            float yIntersect = y1 + (XMin - x1) * dy / dx;

            if (yIntersect < YMin || yIntersect > YMax)
            {
                // Verificar si cruza por arriba o abajo
                if (yIntersect < YMin && y2 >= YMin)
                {
                    x1 = x1 + (YMin - y1) * dx / dy;
                    y1 = YMin;
                }
                else if (yIntersect > YMax && y2 <= YMax)
                {
                    x1 = x1 + (YMax - y1) * dx / dy;
                    y1 = YMax;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                x1 = XMin;
                y1 = yIntersect;
            }

            // Ahora recortar P2 si es necesario
            return RecortarDesdeDentro(ref x1, ref y1, ref x2, ref y2);
        }

        private bool RecortarDesdeDerecha(ref float x1, ref float y1, ref float x2, ref float y2)
        {
            float dx = x2 - x1;
            float dy = y2 - y1;

            if (dx >= 0) return false; // P2 también a la derecha o igual

            float yIntersect = y1 + (XMax - x1) * dy / dx;

            if (yIntersect < YMin || yIntersect > YMax)
            {
                if (yIntersect < YMin && y2 >= YMin)
                {
                    x1 = x1 + (YMin - y1) * dx / dy;
                    y1 = YMin;
                }
                else if (yIntersect > YMax && y2 <= YMax)
                {
                    x1 = x1 + (YMax - y1) * dx / dy;
                    y1 = YMax;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                x1 = XMax;
                y1 = yIntersect;
            }

            return RecortarDesdeDentro(ref x1, ref y1, ref x2, ref y2);
        }

        private bool RecortarDesdeArriba(ref float x1, ref float y1, ref float x2, ref float y2)
        {
            float dx = x2 - x1;
            float dy = y2 - y1;

            if (dy >= 0) return false; // P2 también arriba o igual

            float xIntersect = x1 + (YMax - y1) * dx / dy;

            if (xIntersect < XMin || xIntersect > XMax)
            {
                if (xIntersect < XMin && x2 >= XMin)
                {
                    y1 = y1 + (XMin - x1) * dy / dx;
                    x1 = XMin;
                }
                else if (xIntersect > XMax && x2 <= XMax)
                {
                    y1 = y1 + (XMax - x1) * dy / dx;
                    x1 = XMax;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                x1 = xIntersect;
                y1 = YMax;
            }

            return RecortarDesdeDentro(ref x1, ref y1, ref x2, ref y2);
        }

        private bool RecortarDesdeAbajo(ref float x1, ref float y1, ref float x2, ref float y2)
        {
            float dx = x2 - x1;
            float dy = y2 - y1;

            if (dy <= 0) return false; // P2 también abajo o igual

            float xIntersect = x1 + (YMin - y1) * dx / dy;

            if (xIntersect < XMin || xIntersect > XMax)
            {
                if (xIntersect < XMin && x2 >= XMin)
                {
                    y1 = y1 + (XMin - x1) * dy / dx;
                    x1 = XMin;
                }
                else if (xIntersect > XMax && x2 <= XMax)
                {
                    y1 = y1 + (YMax - y1) * dx / dy;
                    x1 = XMax;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                x1 = xIntersect;
                y1 = YMin;
            }

            return RecortarDesdeDentro(ref x1, ref y1, ref x2, ref y2);
        }

        private bool RecortarDesdeEsquina(ref float x1, ref float y1, ref float x2, ref float y2, bool arriba, bool izquierda)
        {
            float dx = x2 - x1;
            float dy = y2 - y1;

            // Determinar bordes relevantes
            float bordeX = izquierda ? XMin : XMax;
            float bordeY = arriba ? YMax : YMin;

            // Verificar dirección hacia la ventana
            bool haciaX = izquierda ? (dx > 0) : (dx < 0);
            bool haciaY = arriba ? (dy < 0) : (dy > 0);

            if (!haciaX && !haciaY)
                return false; // Se aleja de la ventana

            // Calcular intersecciones
            float yEnBordeX = (dx != 0) ? y1 + (bordeX - x1) * dy / dx : float.MaxValue;
            float xEnBordeY = (dy != 0) ? x1 + (bordeY - y1) * dx / dy : float.MaxValue;

            // Determinar por dónde entra
            bool entraEnX = (arriba ? yEnBordeX <= YMax && yEnBordeX >= YMin : yEnBordeX >= YMin && yEnBordeX <= YMax);
            bool entraEnY = (izquierda ? xEnBordeY >= XMin && xEnBordeY <= XMax : xEnBordeY <= XMax && xEnBordeY >= XMin);

            if (entraEnX && haciaX)
            {
                x1 = bordeX;
                y1 = yEnBordeX;
            }
            else if (entraEnY && haciaY)
            {
                x1 = xEnBordeY;
                y1 = bordeY;
            }
            else
            {
                return false;
            }

            return RecortarDesdeDentro(ref x1, ref y1, ref x2, ref y2);
        }

        #endregion

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

            using (Brush brush = new SolidBrush(Color.Green))
            {
                g.FillEllipse(brush, px1 - 5, py1 - 5, 10, 10);
                g.FillEllipse(brush, px2 - 5, py2 - 5, 10, 10);
            }
        }

        #endregion
    }
}
