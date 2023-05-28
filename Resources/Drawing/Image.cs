using System.IO;
using SixLabors.ImageSharp.PixelFormats;

namespace System.Drawing;

public class Image : IDisposable
{
    public Bitmap Bitmap { get; init; }

    public void Dispose()
    {
    }

    public static implicit operator Bitmap(Image image)
    {
        return image.Bitmap;
    }

    public static implicit operator Image(Bitmap bitmap)
    {
        return new() { Bitmap = bitmap };
    }
    
    public static Bitmap FromStream(Stream stream)
    {
        return SixLabors.ImageSharp.Image.Load<Argb32>(stream);
    }

    public static Bitmap FromFile(string fullFileName)
    {
        return SixLabors.ImageSharp.Image.Load<Argb32>(fullFileName);
    }
}
