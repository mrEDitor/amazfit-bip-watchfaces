using System.Linq;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Drawing;
using SixLabors.ImageSharp.Drawing.Processing;
using SixLabors.ImageSharp.Formats;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace System.Drawing;

public static class ImageExtensions
{
    public static Graphics<TPixel> CreateUnsafeContext<TPixel>(this Image<TPixel> source)
        where TPixel : unmanaged, IPixel<TPixel>
    {
        return new Graphics<TPixel>(source);
    }

    public static void DrawImage(this Graphics drawer, Bitmap image, Rectangle rectangle)
    {
        drawer.DrawImage(image, new SixLabors.ImageSharp.Rectangle(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height), 1f);
    }

    public static void DrawImage(this Graphics drawer, Bitmap image, Point location)
    {
        drawer.DrawImage(image, new SixLabors.ImageSharp.Point((int)location.X, (int)location.Y), 1f);
    }

    public static void DrawImage(this Graphics drawer, Bitmap image, long x, long y)
    {
        drawer.DrawImage(image, new SixLabors.ImageSharp.Point((int)x, (int)y), 1f);
    }

    public static void DrawArc(this Graphics drawer, Pen pen, Rectangle rectangle, long fromAngle, long angle)
    {
        throw new NotImplementedException();
    }

    public static void DrawPolygon(this Graphics drawer, Pen pen, params Point[] points)
    {
        drawer.DrawPolygon(
            pen.Value,
            points.Select(p => new SixLabors.ImageSharp.PointF(p.X, p.Y)).ToArray()
        );
    }

    public static void FillPolygon(this Graphics drawer, SolidBrush brush, Point[] points, object fillMode)
    {
        var options = new DrawingOptions()
        {
            ShapeOptions =
            {
                IntersectionRule =
                    fillMode == FillMode.Alternate ? IntersectionRule.NonZero : IntersectionRule.EvenOdd,
            }, 
        };
        drawer.FillPolygon(
            options,
            brush.Value,
            points.Select(p => new SixLabors.ImageSharp.PointF(p.X, p.Y)).ToArray()
        );
    }

    public static void Save(this Bitmap bitmap, string path, IImageEncoder encoder)
    {
        SixLabors.ImageSharp.ImageExtensions.Save(bitmap, path, encoder);
    }

    public static void Save(this Image bitmap, string path, IImageEncoder encoder)
    {
        SixLabors.ImageSharp.ImageExtensions.Save(bitmap.Bitmap, path, encoder);
    }
}
