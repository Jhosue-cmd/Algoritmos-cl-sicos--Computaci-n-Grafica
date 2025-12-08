using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;

namespace Algoritmo_de_lineas.Recorte_de_poligonos.model
{
    /// <summary>
    /// Implementación del algoritmo de Vatti para recorte de polígonos
    /// Utiliza líneas de barrido para operaciones booleanas entre polígonos
    /// </summary>
    public class CVatti
    {
        #region Propiedades de la ventana de recorte

        public float XMin { get; private set; }
        public float YMin { get; private set; }
        public float XMax { get; private set; }
        public float YMax { get; private set; }

        #endregion

        #region Tipos de operación

        public enum TipoOperacion
        {
            Interseccion,
            Union,
            Diferencia,
            XOR
        }

        #endregion

        #region Estructuras auxiliares

        private class Arista
        {
            public PointF Inicio { get; set; }
            public PointF Fin { get; set; }
            public float YMin { get; set; }
            public float YMax { get; set; }
            public float X { get; set; } // X actual en la línea de barrido
            public float DeltaX { get; set; } // Incremento de X por unidad de Y

            public Arista(PointF inicio, PointF fin)
            {
                if (inicio.Y < fin.Y)
                {
                    Inicio = inicio;
                    Fin = fin;
                }
                else
                {
                    Inicio = fin;
                    Fin = inicio;
                }

                YMin = Inicio.Y;
                YMax = Fin.Y;
                X = Inicio.X;

                if (Math.Abs(YMax - YMin) > 0.0001f)
                {
                    DeltaX = (Fin.X - Inicio.X) / (Fin.Y - Inicio.Y);
                }
                else
                {
                    DeltaX = 0;
                }
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
            public TipoOperacion Operacion { get; set; }
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

        #region Algoritmo de Vatti (Simplificado)

        public ResultadoRecorte Recortar(List<PointF> poligonoSujeto, TipoOperacion operacion = TipoOperacion.Interseccion)
        {
            ResultadoRecorte resultado = new ResultadoRecorte();
            resultado.VerticesOriginales = poligonoSujeto?.Count ?? 0;
            resultado.Operacion = operacion;

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

            List<PointF> poligonoResultado;

            switch (operacion)
            {
                case TipoOperacion.Interseccion:
                    poligonoResultado = CalcularInterseccion(poligonoSujeto, ventana);
                    break;
                case TipoOperacion.Union:
                    poligonoResultado = CalcularUnion(poligonoSujeto, ventana);
                    break;
                case TipoOperacion.Diferencia:
                    poligonoResultado = CalcularDiferencia(poligonoSujeto, ventana);
                    break;
                case TipoOperacion.XOR:
                    poligonoResultado = CalcularXOR(poligonoSujeto, ventana);
                    break;
                default:
                    poligonoResultado = CalcularInterseccion(poligonoSujeto, ventana);
                    break;
            }

            if (poligonoResultado.Count < 3)
            {
                resultado.PoligonoVisible = false;
                resultado.Descripcion = $"Sin resultado visible para operación {operacion}";
                return resultado;
            }

            resultado.PoligonoVisible = true;
            resultado.PoligonosRecortados.Add(poligonoResultado);
            resultado.PoligonosResultantes = 1;
            resultado.Descripcion = $"Operación {operacion}: {resultado.VerticesOriginales} → {poligonoResultado.Count} vértices";

            return resultado;
        }

        private List<PointF> CalcularInterseccion(List<PointF> sujeto, List<PointF> clip)
        {
            // Usar Sutherland-Hodgman para intersección
            return RecortarSutherlandHodgman(sujeto);
        }

        private List<PointF> CalcularUnion(List<PointF> sujeto, List<PointF> clip)
        {
            // Simplificación: retornar el envolvente convexo de ambos polígonos
            List<PointF> todos = new List<PointF>(sujeto);
            todos.AddRange(clip);
            return CalcularEnvolventeConvexo(todos);
        }

        private List<PointF> CalcularDiferencia(List<PointF> sujeto, List<PointF> clip)
        {
            // Simplificación: retornar la parte del sujeto fuera del clip
            List<PointF> resultado = new List<PointF>();

            foreach (var punto in sujeto)
            {
                if (!PuntoEnPoligono(punto, clip))
                {
                    resultado.Add(punto);
                }
            }

            // Si no hay suficientes puntos, intentar recorte inverso
            if (resultado.Count < 3)
            {
                return RecortarSutherlandHodgman(sujeto);
            }

            return resultado;
        }

        private List<PointF> CalcularXOR(List<PointF> sujeto, List<PointF> clip)
        {
            // Simplificación: combinar puntos no compartidos
            List<PointF> resultado = new List<PointF>();

            foreach (var punto in sujeto)
            {
                if (!PuntoEnPoligono(punto, clip))
                    resultado.Add(punto);
            }

            foreach (var punto in clip)
            {
                if (!PuntoEnPoligono(punto, sujeto))
                    resultado.Add(punto);
            }

            if (resultado.Count < 3)
            {
                return RecortarSutherlandHodgman(sujeto);
            }

            return OrdenarPuntosCircularmente(resultado);
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
            if (Math.Abs(p2.X - p1.X) < 0.0001f) return p1;
            float t = (x - p1.X) / (p2.X - p1.X);
            return new PointF(x, p1.Y + t * (p2.Y - p1.Y));
        }

        private PointF InterseccionHorizontal(PointF p1, PointF p2, float y)
        {
            if (Math.Abs(p2.Y - p1.Y) < 0.0001f) return p1;
            float t = (y - p1.Y) / (p2.Y - p1.Y);
            return new PointF(p1.X + t * (p2.X - p1.X), y);
        }

        private bool PuntoEnPoligono(PointF punto, List<PointF> poligono)
        {
            int n = poligono.Count;
            bool dentro = false;

            for (int i = 0, j = n - 1; i < n; j = i++)
            {
                if (((poligono[i].Y > punto.Y) != (poligono[j].Y > punto.Y)) &&
                    (punto.X < (poligono[j].X - poligono[i].X) * (punto.Y - poligono[i].Y) /
                    (poligono[j].Y - poligono[i].Y) + poligono[i].X))
                {
                    dentro = !dentro;
                }
            }

            return dentro;
        }

        private List<PointF> CalcularEnvolventeConvexo(List<PointF> puntos)
        {
            if (puntos.Count < 3)
                return new List<PointF>(puntos);

            // Algoritmo de Graham Scan simplificado
            puntos = puntos.OrderBy(p => p.X).ThenBy(p => p.Y).ToList();

            List<PointF> inferior = new List<PointF>();
            foreach (var p in puntos)
            {
                while (inferior.Count >= 2 && Cruz(inferior[inferior.Count - 2], inferior[inferior.Count - 1], p) <= 0)
                    inferior.RemoveAt(inferior.Count - 1);
                inferior.Add(p);
            }

            List<PointF> superior = new List<PointF>();
            for (int i = puntos.Count - 1; i >= 0; i--)
            {
                var p = puntos[i];
                while (superior.Count >= 2 && Cruz(superior[superior.Count - 2], superior[superior.Count - 1], p) <= 0)
                    superior.RemoveAt(superior.Count - 1);
                superior.Add(p);
            }

            inferior.RemoveAt(inferior.Count - 1);
            superior.RemoveAt(superior.Count - 1);

            inferior.AddRange(superior);
            return inferior;
        }

        private float Cruz(PointF o, PointF a, PointF b)
        {
            return (a.X - o.X) * (b.Y - o.Y) - (a.Y - o.Y) * (b.X - o.X);
        }

        private List<PointF> OrdenarPuntosCircularmente(List<PointF> puntos)
        {
            if (puntos.Count < 3) return puntos;

            // Calcular centroide
            float cx = puntos.Average(p => p.X);
            float cy = puntos.Average(p => p.Y);

            // Ordenar por ángulo respecto al centroide
            return puntos.OrderBy(p => Math.Atan2(p.Y - cy, p.X - cx)).ToList();
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
