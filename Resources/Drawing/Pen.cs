namespace System.Drawing;

public struct Pen
{
    public Pen(System.Color color)
    {
        Value = SixLabors.ImageSharp.Drawing.Processing.Pens.Solid(color, 1f);
    }
    
    public Pen(System.Color color, long width)
    {
        Value = SixLabors.ImageSharp.Drawing.Processing.Pens.Solid(color, width);
    }

    public SixLabors.ImageSharp.Drawing.Processing.Pen Value { get; }
}