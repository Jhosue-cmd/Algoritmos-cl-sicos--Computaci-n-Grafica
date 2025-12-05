using System;
using System.Collections.Generic;
using System.Drawing;

namespace Algoritmo_de_lineas.Circulos.model
{
    internal class CParametrico
    {
        /// <summary>
        /// Calcula los puntos de una circunferencia usando ecuaciones paramétricas
        /// x = xc + r*cos(θ)
        /// y = yc + r*sin(θ)
        /// </summary>
        /// <param name="xc">Coordenada X del centro</param>
        /// <param name="yc">Coordenada Y del centro</param>
        /// <param name="r">Radio de la circunferencia</param>
        /// <returns>Lista de puntos que forman la circunferencia</returns>
        public List<Point> CalcularCircunferencia(int xc, int yc, int r)
        {
            List<Point> puntos = new List<Point>();

            // Iterar desde 0° hasta 360° (0 a 2π radianes)
            // Usamos incrementos pequeños para mayor precisión
            double incremento = 0.01; // Incremento en radianes
            
            for (double theta = 0; theta <= 2 * Math.PI; theta += incremento)
            {
                // Ecuaciones paramétricas
                double x = xc + r * Math.Cos(theta);
                double y = yc + r * Math.Sin(theta);

                // Redondear al entero más cercano para obtener coordenadas de píxel
                int px = (int)Math.Round(x);
                int py = (int)Math.Round(y);

                // Evitar duplicados consecutivos
                if (puntos.Count == 0 || puntos[puntos.Count - 1].X != px || puntos[puntos.Count - 1].Y != py)
                {
                    puntos.Add(new Point(px, py));
                }
            }

            return puntos;
        }

        /// <summary>
        /// Dibuja una circunferencia usando ecuaciones paramétricas
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
