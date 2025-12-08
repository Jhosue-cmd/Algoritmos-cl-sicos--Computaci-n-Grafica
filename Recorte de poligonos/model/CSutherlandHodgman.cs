using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Algoritmo_de_lineas.Recorte_de_poligonos.model
{
    /// <summary>
    /// Implementación del algoritmo de Sutherland-Hodgman para recorte de polígonos
    /// Recorta un polígono contra una ventana rectangular
    /// </summary>
    public class CSutherlandHodgman
    {
        #region Propiedades de la ventana de recorte

        public float XMin { get; private set; }
        public float YMin { get; private set; }
        public float XMax { get; private set; }
        public float YMax { get; private set; }

        #endregion

        #region Enumeración de bordes

        private enum Borde
        {
            Izquierdo,
            Derecho,
            Inferior,
            Superior
        }

        #endregion

        #region Resultado del recorte

        public class ResultadoRecorte
        {
            public bool PoligonoVisible { get; set; }
            public List<PointF> PoligonoRecortado { get; set; }
            public int VerticesOriginales { get; set; }
            public int VerticesResultantes { get; set; }
            public string Descripcion { get; set; }

            public ResultadoRecorte()
            {
                PoligonoRecortado = new List<PointF>();
            }
        }

        #endregion

        #region Validaciones

        public bool ValidarVentana(float xMin, float yMin, float xMax, float yMax)
        {
            return xMin < xMax && yMin < yMax &&
                   !float.IsNaN(xMin) && !float.IsNaN(yMin) &&
                   !float.IsNaN(xMax) && !float.IsNaN(yMax);
        }

        public bool ValidarPunto(float x, float y)
        {
            return !float.IsNaN(x) && !float.IsNaN(y) &&
                   !float.IsInfinity(x) && !float.IsInfinity(y) &&
                   x >= -10000 && x <= 10000 &&
                   y >= -10000 && y <= 10000;
        }

        public bool ValidarPoligono(List<PointF> poligono)
        {
            if (poligono == null || poligono.Count < 3)
                return false;

            foreach (var punto in poligono)
            {
                if (!ValidarPunto(punto.X, punto.Y))
                    return false;
            }
            return true;
        }

        #endregion

        #region Configuración

        public void ConfigurarVentana(float xMin, float yMin, float xMax, float yMax)
        {
            if (!ValidarVentana(xMin, yMin, xMax, yMax))
                throw new ArgumentException("Coordenadas de ventana inválidas");

            XMin = xMin;
            YMin = yMin;
            XMax = xMax;
            YMax = yMax;
        }

        #endregion

        #region Algoritmo Sutherland-Hodgman

        public ResultadoRecorte Recortar(List<PointF> poligono)
        {
            ResultadoRecorte resultado = new ResultadoRecorte();
            resultado.VerticesOriginales = poligono?.Count ?? 0;

            if (!ValidarPoligono(poligono))
            {
                resultado.PoligonoVisible = false;
                resultado.Descripcion = "Polígono inválido (mínimo 3 vértices)";
                return resultado;
            }

            // Copiar polígono de entrada
            List<PointF> poligonoActual = new List<PointF>(poligono);

            // Recortar contra cada borde de la ventana
            poligonoActual = RecortarContraBorde(poligonoActual, Borde.Izquierdo);
            if (poligonoActual.Count == 0)
            {
                resultado.PoligonoVisible = false;
                resultado.Descripcion = "Polígono completamente fuera (borde izquierdo)";
                return resultado;
            }

            poligonoActual = RecortarContraBorde(poligonoActual, Borde.Derecho);
            if (poligonoActual.Count == 0)
            {
                resultado.PoligonoVisible = false;
                resultado.Descripcion = "Polígono completamente fuera (borde derecho)";
                return resultado;
            }

            poligonoActual = RecortarContraBorde(poligonoActual, Borde.Inferior);
            if (poligonoActual.Count == 0)
            {
                resultado.PoligonoVisible = false;
                resultado.Descripcion = "Polígono completamente fuera (borde inferior)";
                return resultado;
            }

            poligonoActual = RecortarContraBorde(poligonoActual, Borde.Superior);
            if (poligonoActual.Count == 0)
            {
                resultado.PoligonoVisible = false;
                resultado.Descripcion = "Polígono completamente fuera (borde superior)";
                return resultado;
            }

            resultado.PoligonoVisible = true;
            resultado.PoligonoRecortado = poligonoActual;
            resultado.VerticesResultantes = poligonoActual.Count;

            if (resultado.VerticesOriginales == resultado.VerticesResultantes)
            {
                resultado.Descripcion = "Polígono completamente dentro de la ventana";
            }
            else
            {
                resultado.Descripcion = $"Polígono recortado: {resultado.VerticesOriginales} → {resultado.VerticesResultantes} vértices";
            }

            return resultado;
        }

        private List<PointF> RecortarContraBorde(List<PointF> poligono, Borde borde)
        {
            if (poligono.Count == 0)
                return new List<PointF>();

            List<PointF> salida = new List<PointF>();

            for (int i = 0; i < poligono.Count; i++)
            {
                PointF puntoActual = poligono[i];
                PointF puntoSiguiente = poligono[(i + 1) % poligono.Count];

                bool actualDentro = EstaDentro(puntoActual, borde);
                bool siguienteDentro = EstaDentro(puntoSiguiente, borde);

                if (actualDentro && siguienteDentro)
                {
                    // Caso 1: Ambos dentro - agregar siguiente
                    salida.Add(puntoSiguiente);
                }
                else if (actualDentro && !siguienteDentro)
                {
                    // Caso 2: Sale - agregar intersección
                    PointF interseccion = CalcularInterseccion(puntoActual, puntoSiguiente, borde);
                    salida.Add(interseccion);
                }
                else if (!actualDentro && siguienteDentro)
                {
                    // Caso 3: Entra - agregar intersección y siguiente
                    PointF interseccion = CalcularInterseccion(puntoActual, puntoSiguiente, borde);
                    salida.Add(interseccion);
                    salida.Add(puntoSiguiente);
                }
                // Caso 4: Ambos fuera - no agregar nada
            }

            return salida;
        }

        private bool EstaDentro(PointF punto, Borde borde)
        {
            switch (borde)
            {
                case Borde.Izquierdo:
                    return punto.X >= XMin;
                case Borde.Derecho:
                    return punto.X <= XMax;
                case Borde.Inferior:
                    return punto.Y >= YMin;
                case Borde.Superior:
                    return punto.Y <= YMax;
                default:
                    return false;
            }
        }

        private PointF CalcularInterseccion(PointF p1, PointF p2, Borde borde)
        {
            float x = 0, y = 0;
            float dx = p2.X - p1.X;
            float dy = p2.Y - p1.Y;

            switch (borde)
            {
                case Borde.Izquierdo:
                    x = XMin;
                    y = p1.Y + (XMin - p1.X) * dy / dx;
                    break;
                case Borde.Derecho:
                    x = XMax;
                    y = p1.Y + (XMax - p1.X) * dy / dx;
                    break;
                case Borde.Inferior:
                    y = YMin;
                    x = p1.X + (YMin - p1.Y) * dx / dy;
                    break;
                case Borde.Superior:
                    y = YMax;
                    x = p1.X + (YMax - p1.Y) * dx / dy;
                    break;
            }

            return new PointF(x, y);
        }

        #endregion

        #region Métodos de dibujo

        public void DibujarVentanaRecorte(Graphics g, int offsetX, int offsetY, int escala, Color color)
        {
            int px1 = offsetX + (int)(XMin * escala);
            int py1 = offsetY - (int)(YMax * escala);
            int ancho = (int)((XMax - XMin) * escala);
            int alto = (int)((YMax - YMin) * escala);

            using (Pen pen = new Pen(color, 2))
            {
                pen.DashStyle = DashStyle.Dash;
                g.DrawRectangle(pen, px1, py1, ancho, alto);
            }

            using (Font font = new Font("Arial", 7))
            using (Brush brush = new SolidBrush(color))
            {
                g.DrawString($"({XMin},{YMax})", font, brush, px1 - 25, py1 - 15);
                g.DrawString($"({XMax},{YMax})", font, brush, px1 + ancho + 2, py1 - 15);
                g.DrawString($"({XMin},{YMin})", font, brush, px1 - 25, py1 + alto + 2);
                g.DrawString($"({XMax},{YMin})", font, brush, px1 + ancho + 2, py1 + alto + 2);
            }
        }

        public void DibujarPoligono(Graphics g, List<PointF> poligono, int offsetX, int offsetY, 
            int escala, Color colorBorde, Color colorRelleno, bool rellenar = false)
        {
            if (poligono == null || poligono.Count < 3)
                return;

            PointF[] puntos = new PointF[poligono.Count];
            for (int i = 0; i < poligono.Count; i++)
            {
                puntos[i] = new PointF(
                    offsetX + poligono[i].X * escala,
                    offsetY - poligono[i].Y * escala
                );
            }

            if (rellenar)
            {
                using (Brush brush = new SolidBrush(Color.FromArgb(80, colorRelleno)))
                {
                    g.FillPolygon(brush, puntos);
                }
            }

            using (Pen pen = new Pen(colorBorde, 2))
            {
                g.DrawPolygon(pen, puntos);
            }

            // Dibujar vértices
            using (Brush brush = new SolidBrush(colorBorde))
            {
                foreach (var punto in puntos)
                {
                    g.FillEllipse(brush, punto.X - 4, punto.Y - 4, 8, 8);
                }
            }
        }

        #endregion
    }
}
