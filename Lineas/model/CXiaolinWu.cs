using System;
using System.Collections.Generic;
using System.Drawing;

namespace Algoritmo_de_lineas
{
    internal class CXiaolinWu
    {
        #region Estructura para píxel con intensidad

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

        #endregion

        #region Estructura para pasos de simulación

        public struct PasoXiaolin
        {
            public int Iteracion;
            public int X;
            public float YReal;
            public int YEntero;
            public float Fraccion;
            public float IntensidadPrincipal;
            public float IntensidadSecundario;
            public string Descripcion;

            public PasoXiaolin(int iteracion, int x, float yReal, int yEntero, float fraccion,
                              float intPrincipal, float intSecundario, string descripcion)
            {
                Iteracion = iteracion;
                X = x;
                YReal = yReal;
                YEntero = yEntero;
                Fraccion = fraccion;
                IntensidadPrincipal = intPrincipal;
                IntensidadSecundario = intSecundario;
                Descripcion = descripcion;
            }
        }

        #endregion

        #region Propiedades para simulación

        public List<PasoXiaolin> PasosSimulacion { get; private set; }
        public float Gradiente { get; private set; }
        public bool EsVertical { get; private set; }

        #endregion

        public CXiaolinWu()
        {
            PasosSimulacion = new List<PasoXiaolin>();
        }

        /// <summary>
        /// Calcula los puntos de una línea usando el algoritmo de Xiaolin Wu
        /// </summary>
        public List<PixelIntensidad> CalcularLinea(int x1, int y1, int x2, int y2)
        {
            List<PixelIntensidad> pixeles = new List<PixelIntensidad>();

            float dx = x2 - x1;
            float dy = y2 - y1;

            bool steep = Math.Abs(dy) > Math.Abs(dx);

            if (steep)
            {
                Swap(ref x1, ref y1);
                Swap(ref x2, ref y2);
                Swap(ref dx, ref dy);
            }

            if (x1 > x2)
            {
                Swap(ref x1, ref x2);
                Swap(ref y1, ref y2);
                dx = -dx;
                dy = -dy;
            }

            float gradient = dy / dx;
            float y = y1;

            for (int x = x1; x <= x2; x++)
            {
                float fraccionY = y - (int)y;

                if (steep)
                    pixeles.Add(new PixelIntensidad((int)y, x, 1 - fraccionY));
                else
                    pixeles.Add(new PixelIntensidad(x, (int)y, 1 - fraccionY));

                if (steep)
                    pixeles.Add(new PixelIntensidad((int)y + 1, x, fraccionY));
                else
                    pixeles.Add(new PixelIntensidad(x, (int)y + 1, fraccionY));

                y += gradient;
            }

            return pixeles;
        }

        /// <summary>
        /// Calcula la línea y genera los pasos detallados para simulación
        /// </summary>
        public List<PixelIntensidad> CalcularLineaConPasos(int x1, int y1, int x2, int y2)
        {
            List<PixelIntensidad> pixeles = new List<PixelIntensidad>();
            PasosSimulacion = new List<PasoXiaolin>();

            float dx = x2 - x1;
            float dy = y2 - y1;

            EsVertical = Math.Abs(dy) > Math.Abs(dx);

            if (EsVertical)
            {
                Swap(ref x1, ref y1);
                Swap(ref x2, ref y2);
                Swap(ref dx, ref dy);
            }

            if (x1 > x2)
            {
                Swap(ref x1, ref x2);
                Swap(ref y1, ref y2);
                dx = -dx;
                dy = -dy;
            }

            Gradiente = dy / dx;
            float y = y1;

            // Paso inicial
            PasosSimulacion.Add(new PasoXiaolin(
                0, 0, 0, 0, 0, 0, 0,
                $"INICIO Anti-aliasing\ndx={dx:F1}, dy={dy:F1}\n" +
                $"Gradiente={Gradiente:F3}\n" +
                (EsVertical ? "Línea más vertical" : "Línea más horizontal")
            ));

            int iteracion = 0;
            for (int x = x1; x <= x2; x++)
            {
                iteracion++;
                int yEntero = (int)y;
                float fraccion = y - yEntero;
                float intPrincipal = 1 - fraccion;
                float intSecundario = fraccion;

                if (EsVertical)
                {
                    pixeles.Add(new PixelIntensidad(yEntero, x, intPrincipal));
                    pixeles.Add(new PixelIntensidad(yEntero + 1, x, intSecundario));
                }
                else
                {
                    pixeles.Add(new PixelIntensidad(x, yEntero, intPrincipal));
                    pixeles.Add(new PixelIntensidad(x, yEntero + 1, intSecundario));
                }

                string desc = $"X={x}, Y real={y:F3}\n" +
                             $"Fracción={fraccion:F3}\n" +
                             $"Píxel principal ({(EsVertical ? yEntero : x)},{(EsVertical ? x : yEntero)}): {intPrincipal * 100:F0}%\n" +
                             $"Píxel secundario: {intSecundario * 100:F0}%";

                PasosSimulacion.Add(new PasoXiaolin(
                    iteracion, x, y, yEntero, fraccion,
                    intPrincipal, intSecundario, desc
                ));

                y += Gradiente;
            }

            // Paso final
            PasosSimulacion.Add(new PasoXiaolin(
                iteracion + 1, 0, 0, 0, 0, 0, 0,
                $"¡LÍNEA COMPLETADA!\nTotal píxeles: {pixeles.Count}\n" +
                $"Pasos de cálculo: {iteracion}"
            ));

            return pixeles;
        }

        /// <summary>
        /// Dibuja una línea con anti-aliasing
        /// </summary>
        public void DibujarLinea(Graphics g, int x1, int y1, int x2, int y2, Color color, int grosor = 2)
        {
            List<PixelIntensidad> pixeles = CalcularLinea(x1, y1, x2, y2);

            foreach (PixelIntensidad pixel in pixeles)
            {
                int alpha = (int)(pixel.Intensidad * 255);
                Color colorPixel = Color.FromArgb(alpha, color);

                using (Brush brush = new SolidBrush(colorPixel))
                {
                    g.FillRectangle(brush, pixel.X - grosor / 2, pixel.Y - grosor / 2, grosor, grosor);
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
        /// Dibuja un píxel con intensidad específica durante la simulación
        /// </summary>
        public void DibujarPixelConIntensidad(Graphics g, int x, int y, Color color, float intensidad, int tamaño = 8)
        {
            int alpha = Math.Max(30, (int)(intensidad * 255));
            Color colorPixel = Color.FromArgb(alpha, color);

            using (Brush brush = new SolidBrush(colorPixel))
            {
                g.FillRectangle(brush, x - tamaño / 2, y - tamaño / 2, tamaño, tamaño);
            }
            using (Pen pen = new Pen(Color.Gray, 1))
            {
                g.DrawRectangle(pen, x - tamaño / 2, y - tamaño / 2, tamaño, tamaño);
            }
        }

        public double CalcularPendiente(int x1, int y1, int x2, int y2)
        {
            int dx = x2 - x1;
            int dy = y2 - y1;

            if (dx == 0)
                return double.PositiveInfinity;

            return (double)dy / dx;
        }

        public bool ValidarPendiente(int x1, int y1, int x2, int y2)
        {
            return y2 != y1;
        }

        private void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }
    }
}
