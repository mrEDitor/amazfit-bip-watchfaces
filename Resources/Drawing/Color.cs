using SixLabors.ImageSharp.PixelFormats;

namespace System;

public struct Color
{
    private Argb32 _argb32;

    public static implicit operator Argb32(Color color)
    {
        return color._argb32;
    }

    public static implicit operator SixLabors.ImageSharp.Color(Color color)
    {
        return new SixLabors.ImageSharp.Color(new Abgr32(unchecked((uint)color.ToArgb())));
    }

    public static implicit operator Color(Argb32 color)
    {
        return new Color { _argb32 = color };
    }

    public byte A => _argb32.A;
    public byte R => _argb32.R;
    public byte G => _argb32.G;
    public byte B => _argb32.B;

    public static Color FromArgb(int a, int r, int g, int b)
    {
        return new Argb32(r / 255f, g / 255f, b / 255f, a / 255f);
    }

    public static Color FromArgb(int argb)
    {
        return new Argb32(unchecked((uint)argb));
    }

    public int ToArgb()
    {
        return unchecked((int)_argb32.Argb);
    }

    public static Color FromArgb(int a, Color rgb)
    {
        return new() { _argb32 = new(rgb.R / 255f, rgb.G / 255f, rgb.B / 255f, a / 255f) };
    }
}