namespace System.Drawing;

public struct SolidBrush
{
    public SolidBrush(System.Color color)
    {
        Value = new(color);
    }

    public SixLabors.ImageSharp.Drawing.Processing.SolidBrush Value { get; }
}