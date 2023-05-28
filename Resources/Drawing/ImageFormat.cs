using SixLabors.ImageSharp.Formats;
using SixLabors.ImageSharp.Formats.Png;

namespace System.Drawing;

public static class ImageFormat
{
    public static IImageEncoder Png { get; } = new PngEncoder();
}
