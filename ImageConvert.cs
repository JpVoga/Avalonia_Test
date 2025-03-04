using System;
using System.IO;
using SkiaSharp;
using Svg.Skia;

namespace Avalonia_Test;

public static class ImageConvert {
    public static void SvgToPng(string inputPath, string? outputPath = null, float resolutionMultiplier = 1) {
        if (outputPath is null) { // Just change file extension if no output file is passed
            const string originalExtension = ".svg";

            int extensionIndex = inputPath.LastIndexOf(originalExtension);
            outputPath = inputPath.Remove(extensionIndex, originalExtension.Length).Insert(extensionIndex, ".png");
        }

        SKSvg svg = new();
        svg.Load(inputPath);

        if (svg.Picture is null) throw new InvalidOperationException($"Unable to retrieve data from \"{inputPath}\"");

        float inputWidth  = svg.Picture.CullRect.Width ;
        float inputHeight = svg.Picture.CullRect.Height;

        float outputWidth  = inputWidth  * resolutionMultiplier;
        float outputHeight = inputHeight * resolutionMultiplier;

        SKBitmap bitmap = new((int)outputWidth, (int)outputHeight);

        using (SKCanvas canvas = new(bitmap)) {
            canvas.DrawPicture(svg.Picture);

            using (SKImage image = SKImage.FromBitmap(bitmap))
            using (SKData data = image.Encode(SKEncodedImageFormat.Png, 80)) {
                data.SaveTo(File.OpenWrite(outputPath));
            }
        }
    }
}