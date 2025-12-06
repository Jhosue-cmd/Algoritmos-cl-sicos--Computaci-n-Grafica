using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Algoritmo_de_lineas.Relleno.model
{
    /// <summary>
    /// Clase que implementa el algoritmo Scan-Line Fill para relleno de polígonos
    /// </summary>
    public class CScanLineFill
    {
        #region Estructuras auxiliares

        /// <summary>
        /// Representa una arista del polígono para el algoritmo scan-line
        /// </summary>
        private class Arista
        {
            public int YMin { get; set; }
            public int YMax { get; set; }
            public float XActual { get; set; }
            public float IncrementoX { get; set; }

            public Arista(int yMin, int yMax, float xInicial, float incrementoX)
            {
                YMin = yMin;
                YMax = yMax;
                XActual = xInicial;
                IncrementoX = incrementoX;
            }
        }

        #endregion

        #region Validaciones

        /// <summary>
        /// Valida que el polígono tenga al menos 3 vértices
        /// </summary>
        /// <param name="vertices">Lista de vértices del polígono</param>
        /// <returns>True si es válido, False en caso contrario</returns>
        public bool ValidarPoligono(List<Point> vertices)
        {
            return vertices != null && vertices.Count >= 3;
        }

        /// <summary>
        /// Valida que los vértices no sean colineales (que formen un área válida)
        /// </summary>
        /// <param name="vertices">Lista de vértices del polígono</param>
        /// <returns>True si no son colineales, False si lo son</returns>
        public bool ValidarNoColineal(List<Point> vertices)
        {
            if (vertices == null || vertices.Count < 3)
                return false;

            // Calcular el área usando la fórmula del zapato (Shoelace)
            double area = CalcularAreaPoligono(vertices);
            return Math.Abs(area) > 0.5; // Tolerancia para evitar áreas insignificantes
        }

        /// <summary>
        /// Valida que las coordenadas estén dentro del rango permitido
        /// </summary>
        /// <param name="vertices">Lista de vértices</param>
        /// <param name="maxX">Coordenada X máxima permitida</param>
        /// <param name="maxY">Coordenada Y máxima permitida</param>
        /// <returns>True si todas las coordenadas son válidas</returns>
        public bool ValidarCoordenadas(List<Point> vertices, int maxX, int maxY)
        {
            if (vertices == null || vertices.Count == 0)
                return false;

            foreach (var vertice in vertices)
            {
                if (vertice.X < -1000 || vertice.X > maxX ||
                    vertice.Y < -1000 || vertice.Y > maxY)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Valida que un punto individual sea válido
        /// </summary>
        /// <param name="x">Coordenada X</param>
        /// <param name="y">Coordenada Y</param>
        /// <returns>True si el punto es válido</returns>
        public bool ValidarPunto(int x, int y)
        {
            return x >= -1000 && x <= 1000 && y >= -1000 && y <= 1000;
        }

        #endregion

        #region Algoritmo Scan-Line Fill

        /// <summary>
        /// Ejecuta el algoritmo Scan-Line Fill para rellenar un polígono
        /// </summary>
        /// <param name="vertices">Lista de vértices del polígono</param>
        /// <returns>Lista de puntos que representan el relleno del polígono</returns>
        public List<Point> RellenarPoligono(List<Point> vertices)
        {
            List<Point> puntosRelleno = new List<Point>();

            if (!ValidarPoligono(vertices) || !ValidarNoColineal(vertices))
                return puntosRelleno;

            // Encontrar los límites Y del polígono
            int yMin = vertices.Min(v => v.Y);
            int yMax = vertices.Max(v => v.Y);

            // Crear la tabla de aristas (Edge Table)
            Dictionary<int, List<Arista>> tablaAristas = CrearTablaAristas(vertices);

            // Lista de aristas activas (Active Edge List)
            List<Arista> aristasActivas = new List<Arista>();

            // Escanear de yMin a yMax
            for (int y = yMin; y <= yMax; y++)
            {
                // Agregar nuevas aristas que comienzan en esta línea de escaneo
                if (tablaAristas.ContainsKey(y))
                {
                    aristasActivas.AddRange(tablaAristas[y]);
                }

                // Eliminar aristas que terminan en esta línea de escaneo
                aristasActivas.RemoveAll(a => a.YMax == y);

                // Ordenar aristas activas por X actual
                aristasActivas = aristasActivas.OrderBy(a => a.XActual).ToList();

                // Rellenar entre pares de intersecciones
                for (int i = 0; i < aristasActivas.Count - 1; i += 2)
                {
                    int xInicio = (int)Math.Ceiling(aristasActivas[i].XActual);
                    int xFin = (int)Math.Floor(aristasActivas[i + 1].XActual);

                    for (int x = xInicio; x <= xFin; x++)
                    {
                        puntosRelleno.Add(new Point(x, y));
                    }
                }

                // Actualizar X para la siguiente línea de escaneo
                foreach (var arista in aristasActivas)
                {
                    arista.XActual += arista.IncrementoX;
                }
            }

            return puntosRelleno;
        }

        /// <summary>
        /// Crea la tabla de aristas (Edge Table) para el algoritmo
        /// </summary>
        /// <param name="vertices">Vértices del polígono</param>
        /// <returns>Diccionario con las aristas organizadas por Y mínimo</returns>
        private Dictionary<int, List<Arista>> CrearTablaAristas(List<Point> vertices)
        {
            Dictionary<int, List<Arista>> tablaAristas = new Dictionary<int, List<Arista>>();

            int n = vertices.Count;
            for (int i = 0; i < n; i++)
            {
                Point p1 = vertices[i];
                Point p2 = vertices[(i + 1) % n];

                // Ignorar aristas horizontales
                if (p1.Y == p2.Y)
                    continue;

                // Asegurar que p1 tenga el menor Y
                if (p1.Y > p2.Y)
                {
                    Point temp = p1;
                    p1 = p2;
                    p2 = temp;
                }

                int yMin = p1.Y;
                int yMax = p2.Y;
                float xInicial = p1.X;
                float incrementoX = (float)(p2.X - p1.X) / (p2.Y - p1.Y);

                Arista arista = new Arista(yMin, yMax, xInicial, incrementoX);

                if (!tablaAristas.ContainsKey(yMin))
                {
                    tablaAristas[yMin] = new List<Arista>();
                }
                tablaAristas[yMin].Add(arista);
            }

            return tablaAristas;
        }

        #endregion

        #region Métodos de dibujo

        /// <summary>
        /// Dibuja el relleno del polígono en el Graphics
        /// </summary>
        /// <param name="g">Objeto Graphics donde dibujar</param>
        /// <param name="vertices">Vértices del polígono (en coordenadas de pantalla)</param>
        /// <param name="colorRelleno">Color de relleno</param>
        /// <param name="colorBorde">Color del borde</param>
        public void DibujarRellenoPoligono(Graphics g, List<Point> vertices, Color colorRelleno, Color colorBorde)
        {
            if (!ValidarPoligono(vertices))
                return;

            // Obtener puntos de relleno
            List<Point> puntosRelleno = RellenarPoligono(vertices);

            // Dibujar el relleno
            using (Brush brushRelleno = new SolidBrush(colorRelleno))
            {
                foreach (Point p in puntosRelleno)
                {
                    g.FillRectangle(brushRelleno, p.X, p.Y, 1, 1);
                }
            }

            // Dibujar el borde del polígono
            DibujarBordePoligono(g, vertices, colorBorde);
        }

        /// <summary>
        /// Dibuja solo el borde del polígono
        /// </summary>
        /// <param name="g">Objeto Graphics</param>
        /// <param name="vertices">Vértices del polígono</param>
        /// <param name="color">Color del borde</param>
        public void DibujarBordePoligono(Graphics g, List<Point> vertices, Color color)
        {
            if (!ValidarPoligono(vertices))
                return;

            using (Pen pen = new Pen(color, 2))
            {
                int n = vertices.Count;
                for (int i = 0; i < n; i++)
                {
                    g.DrawLine(pen, vertices[i], vertices[(i + 1) % n]);
                }
            }

            // Dibujar los vértices
            using (Brush brush = new SolidBrush(Color.Red))
            {
                foreach (Point v in vertices)
                {
                    g.FillEllipse(brush, v.X - 4, v.Y - 4, 8, 8);
                }
            }
        }

        #endregion

        #region Utilidades

        /// <summary>
        /// Calcula el área del polígono usando la fórmula del zapato (Shoelace formula)
        /// </summary>
        /// <param name="vertices">Vértices del polígono</param>
        /// <returns>Área del polígono (puede ser negativa dependiendo de la orientación)</returns>
        public double CalcularAreaPoligono(List<Point> vertices)
        {
            if (vertices == null || vertices.Count < 3)
                return 0;

            double area = 0;
            int n = vertices.Count;

            for (int i = 0; i < n; i++)
            {
                int j = (i + 1) % n;
                area += vertices[i].X * vertices[j].Y;
                area -= vertices[j].X * vertices[i].Y;
            }

            return Math.Abs(area) / 2.0;
        }

        /// <summary>
        /// Calcula el perímetro del polígono
        /// </summary>
        /// <param name="vertices">Vértices del polígono</param>
        /// <returns>Perímetro del polígono</returns>
        public double CalcularPerimetroPoligono(List<Point> vertices)
        {
            if (vertices == null || vertices.Count < 3)
                return 0;

            double perimetro = 0;
            int n = vertices.Count;

            for (int i = 0; i < n; i++)
            {
                int j = (i + 1) % n;
                double dx = vertices[j].X - vertices[i].X;
                double dy = vertices[j].Y - vertices[i].Y;
                perimetro += Math.Sqrt(dx * dx + dy * dy);
            }

            return perimetro;
        }

        #endregion
    }
}
