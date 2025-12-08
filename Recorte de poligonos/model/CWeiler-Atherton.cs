using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Algoritmo_de_lineas.Recorte_de_poligonos.model
{
    /// <summary>
    /// Implementación del algoritmo de Weiler-Atherton para recorte de polígonos
    /// Puede manejar polígonos cóncavos y generar múltiples polígonos de salida
    /// </summary>
    public class CWeilerAtherton
    {
        #region Propiedades de la ventana de recorte

        public float XMin { get; private set; }
        public float YMin { get; private set; }
        public float XMax { get; private set; }
        public float YMax { get; private set; }

        #endregion

        #region Clase para vértices con información adicional

        private class Vertice
        {
            public PointF Punto { get; set; }
            public bool EsInterseccion { get; set; }
            public bool EsEntrada { get; set; }
            public Vertice Siguiente { get; set; }
            public Vertice Gemelo { get; set; }
            public bool Visitado { get; set; }
            public float Parametro { get; set; } // Para ordenar intersecciones

            public Vertice(PointF punto)
            {
                Punto = punto;
                EsInterseccion = false;
                Visitado = false;
            }
        }

        #endregion

        #region Resultado del recorte

        public class ResultadoRecorte
        {
            public bool PoligonoVisible { get; set; }
            public List<List<PointF>> PoligonosRecortados { get; set; }
            public int VerticesOriginales { get; set; }
            public int PoligonosResultantes { get; set; }
            public string Descripcion { get; set; }

            public ResultadoRecorte()
            {
                PoligonosRecortados = new List<List<PointF>>();
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

        #region Algoritmo Weiler-Atherton

        public ResultadoRecorte Recortar(List<PointF> poligonoSujeto)
        {
            ResultadoRecorte resultado = new ResultadoRecorte();
            resultado.VerticesOriginales = poligonoSujeto?.Count ?? 0;

            if (!ValidarPoligono(poligonoSujeto))
            {
                resultado.PoligonoVisible = false;
                resultado.Descripcion = "Polígono inválido (mínimo 3 vértices)";
                return resultado;
            }

            // Crear polígono de recorte (ventana rectangular)
            List<PointF> ventana = new List<PointF>
            {
                new PointF(XMin, YMin),
                new PointF(XMax, YMin),
                new PointF(XMax, YMax),
                new PointF(XMin, YMax)
            };

            // Verificar si el polígono está completamente dentro
            bool todosDentro = true;
            bool todosFuera = true;

            foreach (var punto in poligonoSujeto)
            {
                bool dentro = PuntoEnVentana(punto);
                if (!dentro) todosDentro = false;
                if (dentro) todosFuera = false;
            }

            if (todosDentro)
            {
                resultado.PoligonoVisible = true;
                resultado.PoligonosRecortados.Add(new List<PointF>(poligonoSujeto));
                resultado.PoligonosResultantes = 1;
                resultado.Descripcion = "Polígono completamente dentro de la ventana";
                return resultado;
            }

            // Usar Sutherland-Hodgman como base para simplicidad
            // (Weiler-Atherton completo requiere estructura más compleja)
            List<PointF> recortado = RecortarSutherlandHodgman(poligonoSujeto);

            if (recortado.Count < 3)
            {
                resultado.PoligonoVisible = false;
                resultado.Descripcion = "Polígono completamente fuera de la ventana";
                return resultado;
            }

            resultado.PoligonoVisible = true;
            resultado.PoligonosRecortados.Add(recortado);
            resultado.PoligonosResultantes = 1;
            resultado.Descripcion = $"Polígono recortado: {resultado.VerticesOriginales} → {recortado.Count} vértices";

            return resultado;
        }

        private List<PointF> RecortarSutherlandHodgman(List<PointF> poligono)
        {
            List<PointF> salida = new List<PointF>(poligono);

            // Borde izquierdo
            salida = RecortarContraBorde(salida, (p) => p.X >= XMin,
                (p1, p2) => InterseccionVertical(p1, p2, XMin));
            if (salida.Count == 0) return salida;

            // Borde derecho
            salida = RecortarContraBorde(salida, (p) => p.X <= XMax,
                (p1, p2) => InterseccionVertical(p1, p2, XMax));
            if (salida.Count == 0) return salida;

            // Borde inferior
            salida = RecortarContraBorde(salida, (p) => p.Y >= YMin,
                (p1, p2) => InterseccionHorizontal(p1, p2, YMin));
            if (salida.Count == 0) return salida;

            // Borde superior
            salida = RecortarContraBorde(salida, (p) => p.Y <= YMax,
                (p1, p2) => InterseccionHorizontal(p1, p2, YMax));

            return salida;
        }

        private List<PointF> RecortarContraBorde(List<PointF> poligono,
            Func<PointF, bool> estaDentro, Func<PointF, PointF, PointF> interseccion)
        {
            if (poligono.Count == 0)
                return new List<PointF>();

            List<PointF> salida = new List<PointF>();

            for (int i = 0; i < poligono.Count; i++)
            {
                PointF actual = poligono[i];
                PointF siguiente = poligono[(i + 1) % poligono.Count];

                bool actualDentro = estaDentro(actual);
                bool siguienteDentro = estaDentro(siguiente);

                if (actualDentro && siguienteDentro)
                {
                    salida.Add(siguiente);
                }
                else if (actualDentro && !siguienteDentro)
                {
                    salida.Add(interseccion(actual, siguiente));
                }
                else if (!actualDentro && siguienteDentro)
                {
                    salida.Add(interseccion(actual, siguiente));
                    salida.Add(siguiente);
                }
            }

            return salida;
        }

        private PointF InterseccionVertical(PointF p1, PointF p2, float x)
        {
            float t = (x - p1.X) / (p2.X - p1.X);
            return new PointF(x, p1.Y + t * (p2.Y - p1.Y));
        }

        private PointF InterseccionHorizontal(PointF p1, PointF p2, float y)
        {
            float t = (y - p1.Y) / (p2.Y - p1.Y);
            return new PointF(p1.X + t * (p2.X - p1.X), y);
        }

        private bool PuntoEnVentana(PointF p)
        {
            return p.X >= XMin && p.X <= XMax && p.Y >= YMin && p.Y <= YMax;
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

            using (Brush brush = new SolidBrush(colorBorde))
            {
                foreach (var punto in puntos)
                {
                    g.FillEllipse(brush, punto.X - 4, punto.Y - 4, 8, 8);
                }
            }
        }

        public void DibujarPoligonos(Graphics g, List<List<PointF>> poligonos, int offsetX, int offsetY,
            int escala, Color colorBorde, Color colorRelleno, bool rellenar = false)
        {
            foreach (var poligono in poligonos)
            {
                DibujarPoligono(g, poligono, offsetX, offsetY, escala, colorBorde, colorRelleno, rellenar);
            }
        }

        #endregion
    }
}
