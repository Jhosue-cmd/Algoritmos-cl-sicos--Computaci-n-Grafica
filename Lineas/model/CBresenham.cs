using System;
using System.Collections.Generic;
using System.Drawing;

namespace Algoritmo_de_lineas
{
    internal class CBresenham
    {
        /// <summary>
        /// Calcula los puntos de una línea usando el algoritmo de Bresenham
        /// </summary>
        /// <param name="x1">Coordenada X del punto inicial</param>
        /// <param name="y1">Coordenada Y del punto inicial</param>
        /// <param name="x2">Coordenada X del punto final</param>
        /// <param name="y2">Coordenada Y del punto final</param>
        /// <returns>Lista de puntos que forman la línea</returns>
        public List<Point> CalcularLinea(int x1, int y1, int x2, int y2)
        {
            List<Point> puntos = new List<Point>();

            int dx = Math.Abs(x2 - x1);
            int dy = Math.Abs(y2 - y1);
            int sx = x1 < x2 ? 1 : -1;
            int sy = y1 < y2 ? 1 : -1;
            int err = dx - dy;

            int x = x1;
            int y = y1;

            while (true)
            {
                puntos.Add(new Point(x, y));

                if (x == x2 && y == y2)
                    break;

                int e2 = 2 * err;

                if (e2 > -dy)
                {
                    err -= dy;
                    x += sx;
                }

                if (e2 < dx)
                {
                    err += dx;
                    y += sy;
                }
            }

            return puntos;
        }

        /// <summary>
        /// Dibuja una línea en el gráfico usando el algoritmo de Bresenham
        /// </summary>
        public void DibujarLinea(Graphics g, int x1, int y1, int x2, int y2, Color color, int grosor = 3)
        {
            List<Point> puntos = CalcularLinea(x1, y1, x2, y2);

            // Dibujar cada píxel de la línea
            using (Brush brush = new SolidBrush(color))
            {
                foreach (Point p in puntos)
                {
                    g.FillRectangle(brush, p.X - grosor / 2, p.Y - grosor / 2, grosor, grosor);
                }
            }

            // Dibujar puntos inicial y final
            using (Brush brushInicio = new SolidBrush(Color.Green))
            using (Brush brushFin = new SolidBrush(Color.Red))
            {
                g.FillEllipse(brushInicio, x1 - 4, y1 - 4, 8, 8);
                g.FillEllipse(brushFin, x2 - 4, y2 - 4, 8, 8);
            }
        }

        /// <summary>
        /// Calcula la pendiente de una línea
        /// </summary>
        public double CalcularPendiente(int x1, int y1, int x2, int y2)
        {
            int dx = x2 - x1;
            int dy = y2 - y1;

            if (dx == 0)
            {
                return double.PositiveInfinity; // Línea vertical
            }

            return (double)dy / dx;
        }

        /// <summary>
        /// Valida que la pendiente no sea cero
        /// </summary>
        public bool ValidarPendiente(int x1, int y1, int x2, int y2)
        {
            // La pendiente es 0 cuando la línea es horizontal (y1 == y2)
            return y2 != y1;
        }
    }
}
