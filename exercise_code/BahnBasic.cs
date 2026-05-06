using System;
using RaumfahrtMission;

namespace RaumfahrtBasic
{
    public abstract class BahnBasic
    {
        protected const char DrawingGlyph = '*';
        protected const char FocalPointSymbol = 'O';
        protected const char EmptyCharacter = ' ';

        public void ZeichneBahnAscii(Bahndaten bahndaten, int breite = 60, int hoehe = 30)
        {
            double a = bahndaten.GroßeHalbachse; // Große Halbachse in AE
            double e = bahndaten.Exzentrizität;   // Exzentrizität

            char[,] canvas = CreateEmptyCanvas(breite, hoehe);

            // dynamische Skalierung basierend auf der großen Halbachse und der Exzentrizität
            double maxRadius = a * (1 + e); // Maximaler Abstand zur Sonne
            double skalaX = (breite - 10) / (2 * maxRadius); // 10 = Rand
            double skalaY = (hoehe - 5) / (2 * maxRadius);   // 5 = Rand

            // Zeichne die Ellipse
            DrawEllipseOnCanvas(breite, hoehe, a, e, canvas, skalaX, skalaY);

            // Zeichne den Brennpunkt (Sonne)
            DrawFocalPoint(breite, hoehe, a, e, canvas, skalaX);

            // Ausgabe
            OutputCanvas(bahndaten, breite, hoehe, e, canvas);
        }

        private static char[,] CreateEmptyCanvas(int breite, int hoehe)
        {
            char[,] canvas = new char[hoehe, breite];
            for (int y = 0; y < hoehe; y++)
                for (int x = 0; x < breite; x++)
                    canvas[y, x] = EmptyCharacter;
            return canvas;
        }

        protected abstract void DrawEllipseOnCanvas(int breite, int hoehe, double a, double e, char[,] canvas, double skalaX, double skalaY);

        protected abstract void DrawFocalPoint(int breite, int hoehe, double a, double e, char[,] canvas, double skalaX);

        private static void OutputCanvas(Bahndaten bahndaten, int breite, int hoehe, double e, char[,] canvas)
        {
            Console.WriteLine($"=== Bahn von {bahndaten.Name} (Exzentrizität: {e}) ===");
            for (int y = 0; y < hoehe; y++)
            {
                for (int x = 0; x < breite; x++)
                    Console.Write(canvas[y, x]);
                Console.WriteLine();
            }
            Console.WriteLine("==========================================");
        }
    }

}