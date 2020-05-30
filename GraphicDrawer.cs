using System.Drawing;

namespace TagsCloudForm
{
    public class GraphicDrawer : IGraphicDrawer
    {
        private readonly Graphics graphics;
        public GraphicDrawer(Image image)
        {
            this.graphics = Graphics.FromImage(image);
        }
        public void DrawRectangle(Pen rectPen, Rectangle rectangle)
        {
            graphics.DrawRectangle(rectPen, rectangle);
        }

        public void FillRectangle(Brush brush, Rectangle rectangle)
        {
            graphics.FillRectangle(brush, rectangle);
        }

        public void FillRectangle(Brush brush, int x, int y, int width, int height)
        {
            graphics.FillRectangle(brush, x, y, width, height);
        }

        public void Dispose()
        {
            graphics.Dispose();
        }

        public void DrawString(string word, Font font, Brush textBrush, PointF point)
        {
            graphics.DrawString(word, font, textBrush, point);
        }

        public void DrawLine(int xStart, int yStart, int xEnd, int yEnd, Pen pen)
        {
            graphics.DrawLine(pen, xStart, yStart, xEnd, yEnd);
        }
        
        public void DrawLine(long xStart, long yStart, long xEnd, long yEnd, Pen pen)
        {
            graphics.DrawLine(pen, xStart, yStart, xEnd, yEnd);
        }
        
        public void DrawLine(Point start, Point end, Pen pen)
        {
            graphics.DrawLine(pen, start, end);
        }

        public void FillPolygon(Brush brush, Point[] points)
        {
            graphics.FillPolygon(brush, points);
        }
        
    }
}
