namespace System.Drawing;

public struct Pen
{
    public Pen(System.Color color)
    {
        Value = new(color, 1f);
    }
    
    public Pen(System.Color color, long width)
    {
        Value = new(color, width);
    }

    public SixLabors.ImageSharp.Drawing.Processing.Pen Value { get; }
}