using SixLabors.ImageSharp.PixelFormats;

namespace System;

public struct Color
{
    private Argb32 _rgba;

    public static implicit operator Argb32(Color color)
    {
        return color._rgba;
    }

    public static implicit operator SixLabors.ImageSharp.Color(Color color)
    {
        return new SixLabors.ImageSharp.Color(new Abgr32(unchecked((uint)color.ToArgb())));
    }

    public static implicit operator Color(Argb32 color)
    {
        return new Color { _rgba = color };
    }

    public byte A => _rgba.A;
    public byte R => _rgba.R;
    public byte G => _rgba.G;
    public byte B => _rgba.B;

    public static Color FromArgb(int a, int r, int g, int b)
    {
        return new Argb32(r, g, b, a);
    }

    public static Color FromArgb(int argb)
    {
        return new Argb32(unchecked((uint)argb));
    }

    public int ToArgb()
    {
        return unchecked((int)_rgba.Argb);
    }

    public static Color FromArgb(int a, Color rgb)
    {
        return new() { _rgba = new(rgb.R, rgb.G, rgb.B, a) };
    }
}