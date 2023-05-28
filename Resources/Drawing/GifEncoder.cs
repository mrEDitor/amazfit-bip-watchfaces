using System.IO;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Gif;
using SixLabors.ImageSharp.PixelFormats;

namespace System.Drawing;

public class GifEncoder : IDisposable
{
    private readonly FileStream _stream;
    private Bitmap? _image;

    public GifEncoder(FileStream stream)
    {
        _stream = stream ?? throw new ArgumentNullException(nameof(stream));
    }

    public void AddFrame(Bitmap bitmap, TimeSpan frameDelay)
    {
        foreach (var frame in bitmap.Frames)
        {
            _image ??= new Bitmap(bitmap.Width, bitmap.Height);
            var addedFrame = _image.Frames.AddFrame(frame);
            var gifFrameMetadata = addedFrame.Metadata.GetGifMetadata();
            gifFrameMetadata.FrameDelay = (int)frameDelay.TotalMilliseconds / 10;
            gifFrameMetadata.DisposalMethod = GifDisposalMethod.RestoreToBackground;
        }
    }

    public void Dispose()
    {
        if (_image is not null)
        {
            _image.Metadata.GetGifMetadata().RepeatCount = 0;
            _image.Frames.RemoveFrame(0);

            var encoder = new SixLabors.ImageSharp.Formats.Gif.GifEncoder();
            encoder.Encode(_image, _stream);
            _image.Dispose();
        }

        _stream.Dispose();
    }
}