using System;
using System.Collections.Generic;
using System.Drawing;

namespace Algoritmo_de_lineas.Circulos.model
{
    internal class CBresenhamModificado
    {
        /// <summary>
        /// Calcula los puntos de una circunferencia usando el algoritmo de Bresenham Modificado
        /// Utiliza aritmética entera y simetría de 8 octantes
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
            int d = 3 - 2 * r; // Parámetro de decisión inicial

            // Agregar los puntos iniciales con simetría de 8 octantes
            AgregarPuntosOctantes(puntos, xc, yc, x, y);

            // Algoritmo de Bresenham Modificado para círculos
            while (x <= y)
            {
                x++;

                // Actualizar parámetro de decisión
                if (d < 0)
                {
                    // Punto medio está dentro del círculo
                    d = d + 4 * x + 6;
                }
                else
                {
                    // Punto medio está fuera del círculo
                    y--;
                    d = d + 4 * (x - y) + 10;
                }

                // Agregar los 8 puntos simétricos
                AgregarPuntosOctantes(puntos, xc, yc, x, y);
            }

            return puntos;
        }

        /// <summary>
        /// Agrega los 8 puntos simétricos de la circunferencia (simetría de 8 octantes)
        /// </summary>
        private void AgregarPuntosOctantes(List<Point> puntos, int xc, int yc, int x, int y)
        {
            // Simetría de 8 vías
            puntos.Add(new Point(xc + x, yc + y));  // Octante 1
            puntos.Add(new Point(xc - x, yc + y));  // Octante 2
            puntos.Add(new Point(xc + x, yc - y));  // Octante 3
            puntos.Add(new Point(xc - x, yc - y));  // Octante 4
            puntos.Add(new Point(xc + y, yc + x));  // Octante 5
            puntos.Add(new Point(xc - y, yc + x));  // Octante 6
            puntos.Add(new Point(xc + y, yc - x));  // Octante 7
            puntos.Add(new Point(xc - y, yc - x));  // Octante 8
        }

        /// <summary>
        /// Dibuja una circunferencia usando el algoritmo de Bresenham Modificado
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

        /// <summary>
        /// Calcula el área de la circunferencia
        /// </summary>
        public double CalcularArea(int radio)
        {
            return Math.PI * radio * radio;
        }

        /// <summary>
        /// Calcula el perímetro de la circunferencia
        /// </summary>
        public double CalcularPerimetro(int radio)
        {
            return 2 * Math.PI * radio;
        }
    }
}
