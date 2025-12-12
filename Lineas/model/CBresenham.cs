using System;
using System.Collections.Generic;
using System.Drawing;

namespace Algoritmo_de_lineas
{
    internal class CBresenham
    {
        #region Estructura para pasos de simulación

        /// <summary>
        /// Estructura que almacena información de cada paso del algoritmo
        /// </summary>
        public struct PasoBresenham
        {
            public int Iteracion;
            public int X;
            public int Y;
            public int Error;
            public int E2;
            public string Decision;
            public string Descripcion;

            public PasoBresenham(int iteracion, int x, int y, int error, int e2, 
                                string decision, string descripcion)
            {
                Iteracion = iteracion;
                X = x;
                Y = y;
                Error = error;
                E2 = e2;
                Decision = decision;
                Descripcion = descripcion;
            }
        }

        #endregion

        #region Propiedades para simulación

        public List<PasoBresenham> PasosSimulacion { get; private set; }
        public int Dx { get; private set; }
        public int Dy { get; private set; }
        public int Sx { get; private set; }
        public int Sy { get; private set; }

        #endregion

        public CBresenham()
        {
            PasosSimulacion = new List<PasoBresenham>();
        }

        /// <summary>
        /// Calcula los puntos de una línea usando el algoritmo de Bresenham
        /// </summary>
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
        /// Calcula la línea y genera los pasos detallados para simulación
        /// </summary>
        public List<Point> CalcularLineaConPasos(int x1, int y1, int x2, int y2)
        {
            List<Point> puntos = new List<Point>();
            PasosSimulacion = new List<PasoBresenham>();

            Dx = Math.Abs(x2 - x1);
            Dy = Math.Abs(y2 - y1);
            Sx = x1 < x2 ? 1 : -1;
            Sy = y1 < y2 ? 1 : -1;
            int err = Dx - Dy;

            int x = x1;
            int y = y1;
            int iteracion = 0;

            // Paso inicial
            PasosSimulacion.Add(new PasoBresenham(
                0, x, y, err, 0,
                "INICIO",
                $"dx={Dx}, dy={Dy}, sx={Sx}, sy={Sy}\nerr inicial = dx - dy = {err}"
            ));

            while (true)
            {
                puntos.Add(new Point(x, y));
                iteracion++;

                if (x == x2 && y == y2)
                {
                    PasosSimulacion.Add(new PasoBresenham(
                        iteracion, x, y, err, 0,
                        "FIN",
                        $"Píxel ({x}, {y}) - ¡LÍNEA COMPLETADA!"
                    ));
                    break;
                }

                int e2 = 2 * err;
                string decision = "";
                string desc = $"Píxel ({x}, {y})\ne2 = 2 * {err} = {e2}\n";

                bool moveX = e2 > -Dy;
                bool moveY = e2 < Dx;

                if (moveX && moveY)
                {
                    decision = "DIAGONAL";
                    desc += $"e2 > -{Dy} y e2 < {Dx}\n? Mover en X e Y";
                }
                else if (moveX)
                {
                    decision = "HORIZONTAL";
                    desc += $"e2 > -{Dy}\n? Mover solo en X";
                }
                else if (moveY)
                {
                    decision = "VERTICAL";
                    desc += $"e2 < {Dx}\n? Mover solo en Y";
                }

                PasosSimulacion.Add(new PasoBresenham(
                    iteracion, x, y, err, e2, decision, desc
                ));

                if (e2 > -Dy)
                {
                    err -= Dy;
                    x += Sx;
                }

                if (e2 < Dx)
                {
                    err += Dx;
                    y += Sy;
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

            using (Brush brush = new SolidBrush(color))
            {
                foreach (Point p in puntos)
                {
                    g.FillRectangle(brush, p.X - grosor / 2, p.Y - grosor / 2, grosor, grosor);
                }
            }

            using (Brush brushInicio = new SolidBrush(Color.Green))
            using (Brush brushFin = new SolidBrush(Color.Red))
            {
                g.FillEllipse(brushInicio, x1 - 4, y1 - 4, 8, 8);
                g.FillEllipse(brushFin, x2 - 4, y2 - 4, 8, 8);
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
                return double.PositiveInfinity;

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
