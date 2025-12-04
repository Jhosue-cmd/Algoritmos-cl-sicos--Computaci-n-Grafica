using System;
using System.Collections.Generic;
using System.Drawing;

namespace Algoritmo_de_lineas
{
    internal class CDDA
    {
        /// <summary>
        /// Calcula los puntos de una línea usando el algoritmo DDA
        /// </summary>
        /// <param name="x1">Coordenada X del punto inicial</param>
        /// <param name="y1">Coordenada Y del punto inicial</param>
        /// <param name="x2">Coordenada X del punto final</param>
        /// <param name="y2">Coordenada Y del punto final</param>
        /// <returns>Lista de puntos que forman la línea</returns>
        public List<Point> CalcularLinea(int x1, int y1, int x2, int y2)
        {
            List<Point> puntos = new List<Point>();
            
            // Calcular diferencias
            int dx = x2 - x1;
            int dy = y2 - y1;
            
            // Determinar el número de pasos (el mayor valor absoluto)
            int pasos = Math.Max(Math.Abs(dx), Math.Abs(dy));
            
            // Calcular incrementos
            float xIncremento = (float)dx / pasos;
            float yIncremento = (float)dy / pasos;
            
            // Valores iniciales
            float x = x1;
            float y = y1;
            
            // Generar puntos
            for (int i = 0; i <= pasos; i++)
            {
                puntos.Add(new Point((int)Math.Round(x), (int)Math.Round(y)));
                x += xIncremento;
                y += yIncremento;
            }
            
            return puntos;
        }
        
        /// <summary>
        /// Dibuja una línea en el gráfico usando el algoritmo DDA
        /// </summary>
        public void DibujarLinea(Graphics g, int x1, int y1, int x2, int y2, Color color, int grosor = 2)
        {
            List<Point> puntos = CalcularLinea(x1, y1, x2, y2);
            
            using (Pen pen = new Pen(color, grosor))
            {
                // Dibujar cada segmento de la línea
                for (int i = 0; i < puntos.Count - 1; i++)
                {
                    g.DrawLine(pen, puntos[i], puntos[i + 1]);
                }
            }
            
            // Dibujar puntos inicial y final
            using (Brush brushInicio = new SolidBrush(Color.Green))
            using (Brush brushFin = new SolidBrush(Color.Red))
            {
                g.FillEllipse(brushInicio, x1 - 3, y1 - 3, 6, 6);
                g.FillEllipse(brushFin, x2 - 3, y2 - 3, 6, 6);
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
            double pendiente = CalcularPendiente(x1, y1, x2, y2);
            
            // La pendiente es 0 cuando la línea es horizontal (y1 == y2)
            return y2 != y1;
        }
    }
}
