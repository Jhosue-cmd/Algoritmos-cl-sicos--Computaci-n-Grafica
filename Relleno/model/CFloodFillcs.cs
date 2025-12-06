using System;
using System.Collections.Generic;
using System.Drawing;

namespace Algoritmo_de_lineas.Relleno.model
{
    /// <summary>
    /// Clase que implementa el algoritmo Flood Fill para relleno de áreas
    /// </summary>
    public class CFloodFill
    {
        #region Constantes

        /// <summary>
        /// Límite máximo de píxeles para evitar desbordamiento de pila
        /// </summary>
        private const int MAX_PIXELES = 500000;

        #endregion

        #region Validaciones

        /// <summary>
        /// Valida que las coordenadas del punto semilla estén dentro de los límites
        /// </summary>
        /// <param name="x">Coordenada X del punto semilla</param>
        /// <param name="y">Coordenada Y del punto semilla</param>
        /// <param name="ancho">Ancho del área de dibujo</param>
        /// <param name="alto">Alto del área de dibujo</param>
        /// <returns>True si las coordenadas son válidas</returns>
        public bool ValidarPuntoSemilla(int x, int y, int ancho, int alto)
        {
            return x >= 0 && x < ancho && y >= 0 && y < alto;
        }

        /// <summary>
        /// Valida que el color no sea nulo y sea válido
        /// </summary>
        /// <param name="color">Color a validar</param>
        /// <returns>True si el color es válido</returns>
        public bool ValidarColor(Color color)
        {
            return !color.IsEmpty;
        }

        /// <summary>
        /// Valida que el punto semilla no esté sobre el color de relleno (evita loop infinito)
        /// </summary>
        /// <param name="bitmap">Imagen donde se realizará el relleno</param>
        /// <param name="x">Coordenada X del punto semilla</param>
        /// <param name="y">Coordenada Y del punto semilla</param>
        /// <param name="colorRelleno">Color de relleno</param>
        /// <returns>True si el punto no tiene ya el color de relleno</returns>
        public bool ValidarPuntoNoRellenado(Bitmap bitmap, int x, int y, Color colorRelleno)
        {
            if (bitmap == null || x < 0 || y < 0 || x >= bitmap.Width || y >= bitmap.Height)
                return false;

            Color colorActual = bitmap.GetPixel(x, y);
            return colorActual.ToArgb() != colorRelleno.ToArgb();
        }

        /// <summary>
        /// Valida que el bitmap no sea nulo y tenga dimensiones válidas
        /// </summary>
        /// <param name="bitmap">Bitmap a validar</param>
        /// <returns>True si el bitmap es válido</returns>
        public bool ValidarBitmap(Bitmap bitmap)
        {
            return bitmap != null && bitmap.Width > 0 && bitmap.Height > 0;
        }

        /// <summary>
        /// Valida las coordenadas de un punto
        /// </summary>
        /// <param name="x">Coordenada X</param>
        /// <param name="y">Coordenada Y</param>
        /// <returns>True si las coordenadas son válidas (no negativas excesivas)</returns>
        public bool ValidarCoordenadas(int x, int y)
        {
            return x >= -1000 && x <= 10000 && y >= -1000 && y <= 10000;
        }

        #endregion

        #region Algoritmo Flood Fill (4-conectividad)

        /// <summary>
        /// Ejecuta el algoritmo Flood Fill con 4-conectividad usando método iterativo
        /// </summary>
        /// <param name="bitmap">Bitmap donde realizar el relleno</param>
        /// <param name="xSemilla">Coordenada X del punto semilla</param>
        /// <param name="ySemilla">Coordenada Y del punto semilla</param>
        /// <param name="colorRelleno">Color de relleno</param>
        /// <returns>Número de píxeles rellenados</returns>
        public int RellenarArea4Conectividad(Bitmap bitmap, int xSemilla, int ySemilla, Color colorRelleno)
        {
            if (!ValidarBitmap(bitmap))
                return 0;

            if (!ValidarPuntoSemilla(xSemilla, ySemilla, bitmap.Width, bitmap.Height))
                return 0;

            if (!ValidarColor(colorRelleno))
                return 0;

            Color colorOriginal = bitmap.GetPixel(xSemilla, ySemilla);

            // Si el color original es igual al de relleno, no hacer nada
            if (colorOriginal.ToArgb() == colorRelleno.ToArgb())
                return 0;

            return FloodFillIterativo4(bitmap, xSemilla, ySemilla, colorOriginal, colorRelleno);
        }

        /// <summary>
        /// Implementación iterativa del Flood Fill 4-conectividad (evita stack overflow)
        /// </summary>
        private int FloodFillIterativo4(Bitmap bitmap, int xInicial, int yInicial, Color colorOriginal, Color colorRelleno)
        {
            int pixelesRellenados = 0;
            Stack<Point> pila = new Stack<Point>();
            pila.Push(new Point(xInicial, yInicial));

            int ancho = bitmap.Width;
            int alto = bitmap.Height;

            // Matriz para marcar píxeles visitados
            bool[,] visitado = new bool[ancho, alto];

            while (pila.Count > 0 && pixelesRellenados < MAX_PIXELES)
            {
                Point punto = pila.Pop();
                int x = punto.X;
                int y = punto.Y;

                // Validar límites y si ya fue visitado
                if (x < 0 || x >= ancho || y < 0 || y >= alto)
                    continue;

                if (visitado[x, y])
                    continue;

                Color colorActual = bitmap.GetPixel(x, y);

                // Verificar si el píxel tiene el color original
                if (colorActual.ToArgb() != colorOriginal.ToArgb())
                    continue;

                // Marcar como visitado y rellenar
                visitado[x, y] = true;
                bitmap.SetPixel(x, y, colorRelleno);
                pixelesRellenados++;

                // Agregar vecinos (4-conectividad: arriba, abajo, izquierda, derecha)
                pila.Push(new Point(x + 1, y));  // Derecha
                pila.Push(new Point(x - 1, y));  // Izquierda
                pila.Push(new Point(x, y + 1));  // Abajo
                pila.Push(new Point(x, y - 1));  // Arriba
            }

            return pixelesRellenados;
        }

        #endregion

        #region Algoritmo Flood Fill (8-conectividad)

        /// <summary>
        /// Ejecuta el algoritmo Flood Fill con 8-conectividad
        /// </summary>
        /// <param name="bitmap">Bitmap donde realizar el relleno</param>
        /// <param name="xSemilla">Coordenada X del punto semilla</param>
        /// <param name="ySemilla">Coordenada Y del punto semilla</param>
        /// <param name="colorRelleno">Color de relleno</param>
        /// <returns>Número de píxeles rellenados</returns>
        public int RellenarArea8Conectividad(Bitmap bitmap, int xSemilla, int ySemilla, Color colorRelleno)
        {
            if (!ValidarBitmap(bitmap))
                return 0;

            if (!ValidarPuntoSemilla(xSemilla, ySemilla, bitmap.Width, bitmap.Height))
                return 0;

            if (!ValidarColor(colorRelleno))
                return 0;

            Color colorOriginal = bitmap.GetPixel(xSemilla, ySemilla);

            if (colorOriginal.ToArgb() == colorRelleno.ToArgb())
                return 0;

            return FloodFillIterativo8(bitmap, xSemilla, ySemilla, colorOriginal, colorRelleno);
        }

        /// <summary>
        /// Implementación iterativa del Flood Fill 8-conectividad
        /// </summary>
        private int FloodFillIterativo8(Bitmap bitmap, int xInicial, int yInicial, Color colorOriginal, Color colorRelleno)
        {
            int pixelesRellenados = 0;
            Stack<Point> pila = new Stack<Point>();
            pila.Push(new Point(xInicial, yInicial));

            int ancho = bitmap.Width;
            int alto = bitmap.Height;

            bool[,] visitado = new bool[ancho, alto];

            // Direcciones para 8-conectividad
            int[] dx = { 1, -1, 0, 0, 1, -1, 1, -1 };
            int[] dy = { 0, 0, 1, -1, 1, -1, -1, 1 };

            while (pila.Count > 0 && pixelesRellenados < MAX_PIXELES)
            {
                Point punto = pila.Pop();
                int x = punto.X;
                int y = punto.Y;

                if (x < 0 || x >= ancho || y < 0 || y >= alto)
                    continue;

                if (visitado[x, y])
                    continue;

                Color colorActual = bitmap.GetPixel(x, y);

                if (colorActual.ToArgb() != colorOriginal.ToArgb())
                    continue;

                visitado[x, y] = true;
                bitmap.SetPixel(x, y, colorRelleno);
                pixelesRellenados++;

                // Agregar los 8 vecinos
                for (int i = 0; i < 8; i++)
                {
                    pila.Push(new Point(x + dx[i], y + dy[i]));
                }
            }

            return pixelesRellenados;
        }

        #endregion

        #region Algoritmo Boundary Fill

        /// <summary>
        /// Ejecuta el algoritmo Boundary Fill (rellena hasta encontrar un color de borde)
        /// </summary>
        /// <param name="bitmap">Bitmap donde realizar el relleno</param>
        /// <param name="xSemilla">Coordenada X del punto semilla</param>
        /// <param name="ySemilla">Coordenada Y del punto semilla</param>
        /// <param name="colorRelleno">Color de relleno</param>
        /// <param name="colorBorde">Color del borde que limita el relleno</param>
        /// <returns>Número de píxeles rellenados</returns>
        public int RellenarHastaBorde(Bitmap bitmap, int xSemilla, int ySemilla, Color colorRelleno, Color colorBorde)
        {
            if (!ValidarBitmap(bitmap))
                return 0;

            if (!ValidarPuntoSemilla(xSemilla, ySemilla, bitmap.Width, bitmap.Height))
                return 0;

            if (!ValidarColor(colorRelleno) || !ValidarColor(colorBorde))
                return 0;

            return BoundaryFillIterativo(bitmap, xSemilla, ySemilla, colorRelleno, colorBorde);
        }

        /// <summary>
        /// Implementación iterativa del Boundary Fill
        /// </summary>
        private int BoundaryFillIterativo(Bitmap bitmap, int xInicial, int yInicial, Color colorRelleno, Color colorBorde)
        {
            int pixelesRellenados = 0;
            Stack<Point> pila = new Stack<Point>();
            pila.Push(new Point(xInicial, yInicial));

            int ancho = bitmap.Width;
            int alto = bitmap.Height;

            bool[,] visitado = new bool[ancho, alto];

            while (pila.Count > 0 && pixelesRellenados < MAX_PIXELES)
            {
                Point punto = pila.Pop();
                int x = punto.X;
                int y = punto.Y;

                if (x < 0 || x >= ancho || y < 0 || y >= alto)
                    continue;

                if (visitado[x, y])
                    continue;

                Color colorActual = bitmap.GetPixel(x, y);

                // Detener si es borde o ya está rellenado
                if (colorActual.ToArgb() == colorBorde.ToArgb() ||
                    colorActual.ToArgb() == colorRelleno.ToArgb())
                    continue;

                visitado[x, y] = true;
                bitmap.SetPixel(x, y, colorRelleno);
                pixelesRellenados++;

                // 4-conectividad
                pila.Push(new Point(x + 1, y));
                pila.Push(new Point(x - 1, y));
                pila.Push(new Point(x, y + 1));
                pila.Push(new Point(x, y - 1));
            }

            return pixelesRellenados;
        }

        #endregion

        #region Métodos de dibujo auxiliares

        /// <summary>
        /// Dibuja un círculo de borde para delimitar el área de relleno
        /// </summary>
        /// <param name="g">Objeto Graphics</param>
        /// <param name="xc">Centro X</param>
        /// <param name="yc">Centro Y</param>
        /// <param name="radio">Radio del círculo</param>
        /// <param name="colorBorde">Color del borde</param>
        public void DibujarCirculoBorde(Graphics g, int xc, int yc, int radio, Color colorBorde)
        {
            using (Pen pen = new Pen(colorBorde, 2))
            {
                g.DrawEllipse(pen, xc - radio, yc - radio, radio * 2, radio * 2);
            }
        }

        /// <summary>
        /// Dibuja un rectángulo de borde para delimitar el área de relleno
        /// </summary>
        /// <param name="g">Objeto Graphics</param>
        /// <param name="x">Coordenada X superior izquierda</param>
        /// <param name="y">Coordenada Y superior izquierda</param>
        /// <param name="ancho">Ancho del rectángulo</param>
        /// <param name="alto">Alto del rectángulo</param>
        /// <param name="colorBorde">Color del borde</param>
        public void DibujarRectanguloBorde(Graphics g, int x, int y, int ancho, int alto, Color colorBorde)
        {
            using (Pen pen = new Pen(colorBorde, 2))
            {
                g.DrawRectangle(pen, x, y, ancho, alto);
            }
        }

        /// <summary>
        /// Dibuja un polígono de borde para delimitar el área de relleno
        /// </summary>
        /// <param name="g">Objeto Graphics</param>
        /// <param name="vertices">Vértices del polígono</param>
        /// <param name="colorBorde">Color del borde</param>
        public void DibujarPoligonoBorde(Graphics g, List<Point> vertices, Color colorBorde)
        {
            if (vertices == null || vertices.Count < 3)
                return;

            using (Pen pen = new Pen(colorBorde, 2))
            {
                g.DrawPolygon(pen, vertices.ToArray());
            }
        }

        /// <summary>
        /// Dibuja el punto semilla para visualización
        /// </summary>
        /// <param name="g">Objeto Graphics</param>
        /// <param name="x">Coordenada X</param>
        /// <param name="y">Coordenada Y</param>
        /// <param name="color">Color del marcador</param>
        public void DibujarPuntoSemilla(Graphics g, int x, int y, Color color)
        {
            using (Brush brush = new SolidBrush(color))
            {
                g.FillEllipse(brush, x - 5, y - 5, 10, 10);
            }
            using (Pen pen = new Pen(Color.Black, 1))
            {
                g.DrawEllipse(pen, x - 5, y - 5, 10, 10);
            }
        }

        #endregion
    }
}
