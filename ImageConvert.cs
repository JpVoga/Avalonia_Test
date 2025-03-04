using System;
using System.IO;
using SkiaSharp;
using Svg.Skia;

namespace Avalonia_Test;

public static class ImageConvert {
    public static Stream SvgToPng(string inputPath, int qualityMultiplier = 1) {
        const int baseQuality = 10; // Not sure why, but this value seems to do the trick

        SKSvg svg = new();
        svg.Load(inputPath);

        if (svg.Picture is null) throw new InvalidOperationException($"Unable to retrieve data from \"{inputPath}\"");

        using SKBitmap bitmap = new((int)svg.Picture.CullRect.Width, (int)svg.Picture.CullRect.Height);
        using SKCanvas canvas = new(bitmap);
        canvas.DrawPicture(svg.Picture);

        using SKImage image = SKImage.FromBitmap(bitmap);
        using SKData data = image.Encode(SKEncodedImageFormat.Png, baseQuality * qualityMultiplier);
        MemoryStream outputStream = new();

        data.SaveTo(outputStream);
        outputStream.Position = 0;

        return outputStream;
    }
}