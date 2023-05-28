using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace System.Drawing;

public class Graphics<TPixel> : IDisposable
    where TPixel : unmanaged, IPixel<TPixel>
{
    private readonly Image<TPixel> _source;

    public Graphics(Image<TPixel> source)
    {
        _source = source ?? throw new ArgumentNullException(nameof(source));
    }

    public int Width => _source.Width;

    public int Height => _source.Height;

    public System.Color GetPixel(int x, int y)
    {
        Rgba32 argb32 = default;
        _source[x, y].ToRgba32(ref argb32);
        return System.Color.FromArgb(unchecked((int)argb32.Rgba));
    }

    public void SetPixel(int x, int y, TPixel value)
    {
        _source[x, y] = value;
    }

    public void Dispose()
    {
    }
}