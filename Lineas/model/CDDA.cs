using System;
using System.Collections.Generic;
using System.Drawing;

namespace Algoritmo_de_lineas
{
    internal class CDDA
    {
        #region Estructura para pasos de simulación

        /// <summary>
        /// Estructura que almacena información de cada paso del algoritmo
        /// </summary>
        public struct PasoDDA
        {
            public int Iteracion;
            public float XActual;
            public float YActual;
            public int XRedondeado;
            public int YRedondeado;
            public float XIncremento;
            public float YIncremento;
            public string Descripcion;

            public PasoDDA(int iteracion, float xActual, float yActual, int xRound, int yRound, 
                          float xInc, float yInc, string descripcion)
            {
                Iteracion = iteracion;
                XActual = xActual;
                YActual = yActual;
                XRedondeado = xRound;
                YRedondeado = yRound;
                XIncremento = xInc;
                YIncremento = yInc;
                Descripcion = descripcion;
            }
        }

        #endregion

        #region Propiedades para simulación

        public List<PasoDDA> PasosSimulacion { get; private set; }
        public int TotalPasos { get; private set; }
        public float XIncremento { get; private set; }
        public float YIncremento { get; private set; }

        #endregion

        public CDDA()
        {
            PasosSimulacion = new List<PasoDDA>();
        }

        /// <summary>
        /// Calcula los puntos de una línea usando el algoritmo DDA
        /// </summary>
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
        /// Calcula la línea y genera los pasos detallados para simulación
        /// </summary>
        public List<Point> CalcularLineaConPasos(int x1, int y1, int x2, int y2)
        {
            List<Point> puntos = new List<Point>();
            PasosSimulacion = new List<PasoDDA>();

            int dx = x2 - x1;
            int dy = y2 - y1;

            TotalPasos = Math.Max(Math.Abs(dx), Math.Abs(dy));
            XIncremento = (float)dx / TotalPasos;
            YIncremento = (float)dy / TotalPasos;

            float x = x1;
            float y = y1;

            // Paso inicial
            PasosSimulacion.Add(new PasoDDA(
                0, x, y, (int)Math.Round(x), (int)Math.Round(y),
                XIncremento, YIncremento,
                $"INICIO: dx={dx}, dy={dy}, pasos={TotalPasos}\n" +
                $"Xinc={XIncremento:F3}, Yinc={YIncremento:F3}"
            ));

            for (int i = 0; i <= TotalPasos; i++)
            {
                int xRound = (int)Math.Round(x);
                int yRound = (int)Math.Round(y);
                puntos.Add(new Point(xRound, yRound));

                string desc = $"Paso {i}: X={x:F3} → {xRound}, Y={y:F3} → {yRound}";
                
                if (i < TotalPasos)
                {
                    desc += $"\nSiguiente: X+={XIncremento:F3}, Y+={YIncremento:F3}";
                }
                else
                {
                    desc += "\n¡LÍNEA COMPLETADA!";
                }

                PasosSimulacion.Add(new PasoDDA(
                    i + 1, x, y, xRound, yRound,
                    XIncremento, YIncremento, desc
                ));

                x += XIncremento;
                y += YIncremento;
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
        /// Dibuja un píxel específico durante la simulación
        /// </summary>
        public void DibujarPixel(Graphics g, int x, int y, Color color, int tamaño = 8)
        {
            using (Brush brush = new SolidBrush(color))
            {
                g.FillRectangle(brush, x - tamaño / 2, y - tamaño / 2, tamaño, tamaño);
            }
            // Borde del píxel
            using (Pen pen = new Pen(Color.Black, 1))
            {
                g.DrawRectangle(pen, x - tamaño / 2, y - tamaño / 2, tamaño, tamaño);
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
                return double.PositiveInfinity; // Línea vertical
            
            return (double)dy / dx;
        }
        
        /// <summary>
        /// Valida que la pendiente no sea cero
        /// </summary>
        public bool ValidarPendiente(int x1, int y1, int x2, int y2)
        {
            return y2 != y1;
        }
    }
}
