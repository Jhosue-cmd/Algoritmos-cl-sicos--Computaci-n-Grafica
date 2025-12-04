using System;
using System.Collections.Generic;
using System.Drawing;

namespace Algoritmo_de_lineas
{
    internal class CXiaolinWu
    {
        /// <summary>
        /// Estructura para almacenar un píxel con intensidad (anti-aliasing)
        /// </summary>
        public struct PixelIntensidad
        {
            public int X;
            public int Y;
            public float Intensidad;

            public PixelIntensidad(int x, int y, float intensidad)
            {
                X = x;
                Y = y;
                Intensidad = intensidad;
            }
        }

        /// <summary>
        /// Calcula los puntos de una línea usando el algoritmo de Xiaolin Wu
        /// </summary>
        /// <param name="x1">Coordenada X del punto inicial</param>
        /// <param name="y1">Coordenada Y del punto inicial</param>
        /// <param name="x2">Coordenada X del punto final</param>
        /// <param name="y2">Coordenada Y del punto final</param>
        /// <returns>Lista de píxeles con intensidad</returns>
        public List<PixelIntensidad> CalcularLinea(int x1, int y1, int x2, int y2)
        {
            List<PixelIntensidad> pixeles = new List<PixelIntensidad>();

            float dx = x2 - x1;
            float dy = y2 - y1;

            // Determinar si la línea es más vertical que horizontal
            bool steep = Math.Abs(dy) > Math.Abs(dx);

            // Si es más vertical, intercambiar x e y
            if (steep)
            {
                Swap(ref x1, ref y1);
                Swap(ref x2, ref y2);
                Swap(ref dx, ref dy);
            }

            // Asegurar que dibujamos de izquierda a derecha
            if (x1 > x2)
            {
                Swap(ref x1, ref x2);
                Swap(ref y1, ref y2);
                dx = -dx;
                dy = -dy;
            }

            float gradient = dy / dx;
            float y = y1;

            // Dibujar los puntos de la línea
            for (int x = x1; x <= x2; x++)
            {
                float fraccionY = y - (int)y;

                // Píxel principal
                if (steep)
                    pixeles.Add(new PixelIntensidad((int)y, x, 1 - fraccionY));
                else
                    pixeles.Add(new PixelIntensidad(x, (int)y, 1 - fraccionY));

                // Píxel secundario (anti-aliasing)
                if (steep)
                    pixeles.Add(new PixelIntensidad((int)y + 1, x, fraccionY));
                else
                    pixeles.Add(new PixelIntensidad(x, (int)y + 1, fraccionY));

                y += gradient;
            }

            return pixeles;
        }

        /// <summary>
        /// Dibuja una línea en el gráfico usando el algoritmo de Xiaolin Wu (con anti-aliasing)
        /// </summary>
        public void DibujarLinea(Graphics g, int x1, int y1, int x2, int y2, Color color, int grosor = 2)
        {
            List<PixelIntensidad> pixeles = CalcularLinea(x1, y1, x2, y2);

            // Dibujar cada píxel con su intensidad
            foreach (PixelIntensidad pixel in pixeles)
            {
                // Calcular el color con alpha basado en la intensidad
                int alpha = (int)(pixel.Intensidad * 255);
                Color colorPixel = Color.FromArgb(alpha, color);

                using (Brush brush = new SolidBrush(colorPixel))
                {
                    g.FillRectangle(brush, pixel.X - grosor / 2, pixel.Y - grosor / 2, grosor, grosor);
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

        /// <summary>
        /// Intercambia dos valores
        /// </summary>
        private void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }
    }
}
