using RaumfahrtBasic;

namespace RaumfahrtMission
{
    // klasse ableiten von Bahnbasic
    public class BahnVisualisierer : BahnBasic
    {
        protected override void DrawEllipseOnCanvas(int breite, int hoehe, double a, double e, char[,] canvas, double skalaX, double skalaY)
        {
            for (double theta = 0; theta < 2 *Math.PI; theta += 0.05 )
            {
                double r = a*(1-e*e) / (1+e*Math.Cos(theta));
                double x = r * Math.Cos(theta) * skalaX + breite /2;
                double y = r * Math.Sin(theta) * skalaY + hoehe /2;

                canvas[(int)y, (int)x] = DrawingGlyph;
            }
        }

        protected override void DrawFocalPoint(int breite, int hoehe, double a, double e, char[,] canvas, double skalaX)
        {
            int focalX = (int) (breite /2 - a*e*skalaX);
            int focalY = hoehe/2;
            canvas[focalY, focalX] = FocalPointSymbol;
        }

    }

}