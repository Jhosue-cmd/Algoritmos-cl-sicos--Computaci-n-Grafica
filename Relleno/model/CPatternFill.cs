using System;
using System.Collections.Generic;
using System.Drawing;

namespace Algoritmo_de_lineas.Relleno.model
{
    /// <summary>
    /// Clase que implementa el algoritmo Pattern Fill para relleno con patrones
    /// </summary>
    public class CPatternFill
    {
        #region Enumeraciones

        /// <summary>
        /// Tipos de patrones disponibles
        /// </summary>
        public enum TipoPatron
        {
            Lineas_Horizontales,
            Lineas_Verticales,
            Lineas_Diagonales_Derecha,
            Lineas_Diagonales_Izquierda,
            Cuadricula,
            Puntos,
            Cruces,
            Tablero_Ajedrez
        }

        #endregion

        #region Propiedades

        /// <summary>
        /// Tamaño del patrón (espaciado entre elementos)
        /// </summary>
        public int TamanoPatron { get; set; } = 8;

        /// <summary>
        /// Grosor de las líneas del patrón
        /// </summary>
        public int GrosorLinea { get; set; } = 1;

        #endregion

        #region Validaciones

        /// <summary>
        /// Valida que el polígono tenga al menos 3 vértices
        /// </summary>
        /// <param name="vertices">Lista de vértices</param>
        /// <returns>True si es válido</returns>
        public bool ValidarPoligono(List<Point> vertices)
        {
            return vertices != null && vertices.Count >= 3;
        }

        /// <summary>
        /// Valida que los vértices no sean colineales
        /// </summary>
        /// <param name="vertices">Lista de vértices</param>
        /// <returns>True si forman un área válida</returns>
        public bool ValidarNoColineal(List<Point> vertices)
        {
            if (vertices == null || vertices.Count < 3)
                return false;

            double area = CalcularAreaPoligono(vertices);
            return Math.Abs(area) > 0.5;
        }

        /// <summary>
        /// Valida el tamaño del patrón
        /// </summary>
        /// <param name="tamano">Tamaño a validar</param>
        /// <returns>True si está en rango válido (1-50)</returns>
        public bool ValidarTamanoPatron(int tamano)
        {
            return tamano >= 1 && tamano <= 50;
        }

        /// <summary>
        /// Valida el grosor de línea
        /// </summary>
        /// <param name="grosor">Grosor a validar</param>
        /// <returns>True si está en rango válido (1-10)</returns>
        public bool ValidarGrosorLinea(int grosor)
        {
            return grosor >= 1 && grosor <= 10;
        }

        /// <summary>
        /// Valida las coordenadas de un punto
        /// </summary>
        /// <param name="x">Coordenada X</param>
        /// <param name="y">Coordenada Y</param>
        /// <returns>True si las coordenadas son válidas</returns>
        public bool ValidarPunto(int x, int y)
        {
            return x >= -1000 && x <= 1000 && y >= -1000 && y <= 1000;
        }

        /// <summary>
        /// Valida las coordenadas de todos los vértices
        /// </summary>
        /// <param name="vertices">Lista de vértices</param>
        /// <param name="maxX">Coordenada X máxima</param>
        /// <param name="maxY">Coordenada Y máxima</param>
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

        #endregion

        #region Generación de Patrones

        /// <summary>
        /// Genera un patrón como matriz de bits
        /// </summary>
        /// <param name="tipo">Tipo de patrón</param>
        /// <param name="tamano">Tamaño del patrón</param>
        /// <returns>Matriz booleana donde true indica píxel del patrón</returns>
        public bool[,] GenerarPatron(TipoPatron tipo, int tamano)
        {
            if (!ValidarTamanoPatron(tamano))
                tamano = 8;

            bool[,] patron = new bool[tamano, tamano];

            switch (tipo)
            {
                case TipoPatron.Lineas_Horizontales:
                    patron = GenerarLineasHorizontales(tamano);
                    break;
                case TipoPatron.Lineas_Verticales:
                    patron = GenerarLineasVerticales(tamano);
                    break;
                case TipoPatron.Lineas_Diagonales_Derecha:
                    patron = GenerarLineasDiagonalesDerecha(tamano);
                    break;
                case TipoPatron.Lineas_Diagonales_Izquierda:
                    patron = GenerarLineasDiagonalesIzquierda(tamano);
                    break;
                case TipoPatron.Cuadricula:
                    patron = GenerarCuadricula(tamano);
                    break;
                case TipoPatron.Puntos:
                    patron = GenerarPuntos(tamano);
                    break;
                case TipoPatron.Cruces:
                    patron = GenerarCruces(tamano);
                    break;
                case TipoPatron.Tablero_Ajedrez:
                    patron = GenerarTableroAjedrez(tamano);
                    break;
            }

            return patron;
        }

        private bool[,] GenerarLineasHorizontales(int tamano)
        {
            bool[,] patron = new bool[tamano, tamano];
            for (int y = 0; y < tamano; y++)
            {
                if (y % 4 == 0)
                {
                    for (int x = 0; x < tamano; x++)
                        patron[x, y] = true;
                }
            }
            return patron;
        }

        private bool[,] GenerarLineasVerticales(int tamano)
        {
            bool[,] patron = new bool[tamano, tamano];
            for (int x = 0; x < tamano; x++)
            {
                if (x % 4 == 0)
                {
                    for (int y = 0; y < tamano; y++)
                        patron[x, y] = true;
                }
            }
            return patron;
        }

        private bool[,] GenerarLineasDiagonalesDerecha(int tamano)
        {
            bool[,] patron = new bool[tamano, tamano];
            for (int i = 0; i < tamano; i++)
            {
                for (int j = 0; j < tamano; j++)
                {
                    if ((i + j) % 4 == 0)
                        patron[i, j] = true;
                }
            }
            return patron;
        }

        private bool[,] GenerarLineasDiagonalesIzquierda(int tamano)
        {
            bool[,] patron = new bool[tamano, tamano];
            for (int i = 0; i < tamano; i++)
            {
                for (int j = 0; j < tamano; j++)
                {
                    if ((i - j + tamano) % 4 == 0)
                        patron[i, j] = true;
                }
            }
            return patron;
        }

        private bool[,] GenerarCuadricula(int tamano)
        {
            bool[,] patron = new bool[tamano, tamano];
            for (int i = 0; i < tamano; i++)
            {
                for (int j = 0; j < tamano; j++)
                {
                    if (i % 4 == 0 || j % 4 == 0)
                        patron[i, j] = true;
                }
            }
            return patron;
        }

        private bool[,] GenerarPuntos(int tamano)
        {
            bool[,] patron = new bool[tamano, tamano];
            for (int i = 0; i < tamano; i++)
            {
                for (int j = 0; j < tamano; j++)
                {
                    if (i % 4 == 0 && j % 4 == 0)
                        patron[i, j] = true;
                }
            }
            return patron;
        }

        private bool[,] GenerarCruces(int tamano)
        {
            bool[,] patron = new bool[tamano, tamano];
            int centro = tamano / 2;
            
            // Cruz horizontal
            for (int x = 0; x < tamano; x++)
                patron[x, centro] = true;
            
            // Cruz vertical
            for (int y = 0; y < tamano; y++)
                patron[centro, y] = true;
            
            return patron;
        }

        private bool[,] GenerarTableroAjedrez(int tamano)
        {
            bool[,] patron = new bool[tamano, tamano];
            int mitad = tamano / 2;
            
            for (int i = 0; i < tamano; i++)
            {
                for (int j = 0; j < tamano; j++)
                {
                    bool bloqueX = (i / mitad) % 2 == 0;
                    bool bloqueY = (j / mitad) % 2 == 0;
                    patron[i, j] = bloqueX == bloqueY;
                }
            }
            return patron;
        }

        #endregion

        #region Algoritmo Pattern Fill

        /// <summary>
        /// Rellena un polígono con un patrón específico
        /// </summary>
        /// <param name="vertices">Vértices del polígono</param>
        /// <param name="patron">Matriz del patrón</param>
        /// <returns>Lista de puntos a rellenar con el patrón</returns>
        public List<Point> RellenarConPatron(List<Point> vertices, bool[,] patron)
        {
            List<Point> puntosRelleno = new List<Point>();

            if (!ValidarPoligono(vertices) || !ValidarNoColineal(vertices))
                return puntosRelleno;

            if (patron == null || patron.GetLength(0) == 0 || patron.GetLength(1) == 0)
                return puntosRelleno;

            // Obtener todos los puntos del relleno sólido usando Scan-Line
            List<Point> puntosSolido = ObtenerPuntosScanLine(vertices);
            
            int tamanoX = patron.GetLength(0);
            int tamanoY = patron.GetLength(1);

            // Filtrar puntos según el patrón
            foreach (Point p in puntosSolido)
            {
                int px = ((p.X % tamanoX) + tamanoX) % tamanoX;
                int py = ((p.Y % tamanoY) + tamanoY) % tamanoY;

                if (patron[px, py])
                {
                    puntosRelleno.Add(p);
                }
            }

            return puntosRelleno;
        }

        /// <summary>
        /// Obtiene los puntos de relleno sólido usando Scan-Line
        /// </summary>
        private List<Point> ObtenerPuntosScanLine(List<Point> vertices)
        {
            List<Point> puntos = new List<Point>();

            if (vertices == null || vertices.Count < 3)
                return puntos;

            // Encontrar límites Y
            int yMin = int.MaxValue, yMax = int.MinValue;
            foreach (var v in vertices)
            {
                if (v.Y < yMin) yMin = v.Y;
                if (v.Y > yMax) yMax = v.Y;
            }

            // Escanear línea por línea
            for (int y = yMin; y <= yMax; y++)
            {
                List<float> intersecciones = new List<float>();

                int n = vertices.Count;
                for (int i = 0; i < n; i++)
                {
                    Point p1 = vertices[i];
                    Point p2 = vertices[(i + 1) % n];

                    if (p1.Y == p2.Y)
                        continue;

                    if (p1.Y > p2.Y)
                    {
                        Point temp = p1;
                        p1 = p2;
                        p2 = temp;
                    }

                    if (y >= p1.Y && y < p2.Y)
                    {
                        float x = p1.X + (float)(y - p1.Y) / (p2.Y - p1.Y) * (p2.X - p1.X);
                        intersecciones.Add(x);
                    }
                }

                intersecciones.Sort();

                for (int i = 0; i < intersecciones.Count - 1; i += 2)
                {
                    int xInicio = (int)Math.Ceiling(intersecciones[i]);
                    int xFin = (int)Math.Floor(intersecciones[i + 1]);

                    for (int x = xInicio; x <= xFin; x++)
                    {
                        puntos.Add(new Point(x, y));
                    }
                }
            }

            return puntos;
        }

        #endregion

        #region Métodos de dibujo

        /// <summary>
        /// Dibuja el relleno con patrón en el Graphics
        /// </summary>
        /// <param name="g">Objeto Graphics</param>
        /// <param name="vertices">Vértices del polígono (coordenadas de pantalla)</param>
        /// <param name="tipo">Tipo de patrón</param>
        /// <param name="colorPatron">Color del patrón</param>
        /// <param name="colorFondo">Color de fondo (opcional)</param>
        /// <param name="colorBorde">Color del borde</param>
        public void DibujarRellenoPatron(Graphics g, List<Point> vertices, TipoPatron tipo, 
            Color colorPatron, Color colorFondo, Color colorBorde)
        {
            if (!ValidarPoligono(vertices))
                return;

            // Generar el patrón
            bool[,] patron = GenerarPatron(tipo, TamanoPatron);

            // Obtener puntos de relleno sólido
            List<Point> puntosSolido = ObtenerPuntosScanLine(vertices);

            // Dibujar el fondo primero (si no es transparente)
            if (colorFondo != Color.Transparent)
            {
                using (Brush brushFondo = new SolidBrush(colorFondo))
                {
                    foreach (Point p in puntosSolido)
                    {
                        g.FillRectangle(brushFondo, p.X, p.Y, 1, 1);
                    }
                }
            }

            // Dibujar el patrón
            List<Point> puntosPatron = RellenarConPatron(vertices, patron);
            using (Brush brushPatron = new SolidBrush(colorPatron))
            {
                foreach (Point p in puntosPatron)
                {
                    g.FillRectangle(brushPatron, p.X, p.Y, 1, 1);
                }
            }

            // Dibujar el borde
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

        /// <summary>
        /// Dibuja una vista previa del patrón
        /// </summary>
        /// <param name="g">Objeto Graphics</param>
        /// <param name="x">Posición X</param>
        /// <param name="y">Posición Y</param>
        /// <param name="ancho">Ancho de la vista previa</param>
        /// <param name="alto">Alto de la vista previa</param>
        /// <param name="tipo">Tipo de patrón</param>
        /// <param name="colorPatron">Color del patrón</param>
        /// <param name="colorFondo">Color de fondo</param>
        public void DibujarVistaPrevia(Graphics g, int x, int y, int ancho, int alto,
            TipoPatron tipo, Color colorPatron, Color colorFondo)
        {
            bool[,] patron = GenerarPatron(tipo, TamanoPatron);
            int tamanoX = patron.GetLength(0);
            int tamanoY = patron.GetLength(1);

            // Dibujar fondo
            using (Brush brushFondo = new SolidBrush(colorFondo))
            {
                g.FillRectangle(brushFondo, x, y, ancho, alto);
            }

            // Dibujar patrón
            using (Brush brushPatron = new SolidBrush(colorPatron))
            {
                for (int px = 0; px < ancho; px++)
                {
                    for (int py = 0; py < alto; py++)
                    {
                        int ix = px % tamanoX;
                        int iy = py % tamanoY;
                        if (patron[ix, iy])
                        {
                            g.FillRectangle(brushPatron, x + px, y + py, 1, 1);
                        }
                    }
                }
            }

            // Borde
            using (Pen pen = new Pen(Color.Black, 1))
            {
                g.DrawRectangle(pen, x, y, ancho, alto);
            }
        }

        #endregion

        #region Utilidades

        /// <summary>
        /// Calcula el área del polígono
        /// </summary>
        /// <param name="vertices">Vértices del polígono</param>
        /// <returns>Área del polígono</returns>
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

        /// <summary>
        /// Obtiene los nombres de los tipos de patrones disponibles
        /// </summary>
        /// <returns>Array con los nombres de los patrones</returns>
        public string[] ObtenerNombresPatrones()
        {
            return Enum.GetNames(typeof(TipoPatron));
        }

        #endregion
    }
}
