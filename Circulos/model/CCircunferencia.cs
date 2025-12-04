using System;
using System.Collections.Generic;
using System.Drawing;

namespace Algoritmo_de_lineas
{
    internal class CCircunferencia
    {
        /// <summary>
        /// Calcula los puntos de una circunferencia usando el algoritmo de punto medio
        /// </summary>
        /// <param name="xc">Coordenada X del centro</param>
        /// <param name="yc">Coordenada Y del centro</param>
        /// <param name="r">Radio de la circunferencia</param>
        /// <returns>Lista de puntos que forman la circunferencia</returns>
        public List<Point> CalcularCircunferencia(int xc, int yc, int r)
        {
            List<Point> puntos = new List<Point>();

            int x = 0;
            int y = r;
            int p = 1 - r;

            // Agregar los 8 puntos simétricos iniciales
            AgregarPuntosOctantes(puntos, xc, yc, x, y);

            // Algoritmo de punto medio
            while (x < y)
            {
                x = x + 1;
                if (p < 0)
                {
                    p = p + 2 * x + 3;
                }
                else
                {
                    y = y - 1;
                    p = p + 2 * (x - y) + 5;
                }

                // Agregar los 8 puntos simétricos para cada punto calculado
                AgregarPuntosOctantes(puntos, xc, yc, x, y);
            }

            return puntos;
        }

        /// <summary>
        /// Agrega los 8 puntos simétricos de la circunferencia
        /// </summary>
        private void AgregarPuntosOctantes(List<Point> puntos, int xc, int yc, int x, int y)
        {
            // Simetría de 8 lados
            puntos.Add(new Point(xc + x, yc + y));  // (x, y)
            puntos.Add(new Point(xc - x, yc + y));  // (-x, y)
            puntos.Add(new Point(xc + x, yc - y));  // (x, -y)
            puntos.Add(new Point(xc - x, yc - y));  // (-x, -y)
            puntos.Add(new Point(xc + y, yc + x));  // (y, x)
            puntos.Add(new Point(xc - y, yc + x));  // (-y, x)
            puntos.Add(new Point(xc + y, yc - x));  // (y, -x)
            puntos.Add(new Point(xc - y, yc - x));  // (-y, -x)
        }

        /// <summary>
        /// Dibuja una circunferencia en el gráfico
        /// </summary>
        public void DibujarCircunferencia(Graphics g, int xc, int yc, int r, Color color, int grosor = 2)
        {
            List<Point> puntos = CalcularCircunferencia(xc, yc, r);

            // Dibujar cada píxel de la circunferencia
            using (Brush brush = new SolidBrush(color))
            {
                foreach (Point p in puntos)
                {
                    g.FillRectangle(brush, p.X - grosor / 2, p.Y - grosor / 2, grosor, grosor);
                }
            }

            // Dibujar el centro
            using (Brush brushCentro = new SolidBrush(Color.Red))
            {
                g.FillEllipse(brushCentro, xc - 4, yc - 4, 8, 8);
            }
        }

        /// <summary>
        /// Valida que el radio sea positivo
        /// </summary>
        public bool ValidarRadio(int radio)
        {
            return radio > 0;
        }
    }
}
