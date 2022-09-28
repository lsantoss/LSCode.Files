using ImageMagick;
using System;

namespace LSCode.Files.Images
{
    /// <summary>Class that helps in image compression.</summary>
    public static class ImageHelper
    {
        /// <summary>Compact image of the parameterized path.</summary>
        /// <remarks>Note: The original image will be replaced by the compressed image. There may be a loss of quality.</remarks>
        /// <param name="imagePath">Path of the image to be compressed.</param>
        /// <exception cref="Exception">Error compressing image.</exception>
        public static void Compress(string imagePath)
        {
            using (var imageMagick = new MagickImage(imagePath))
            {
                imageMagick.Transparent(MagickColor.FromRgb(0, 0, 0));
                imageMagick.FilterType = FilterType.Spline;
                imageMagick.Resize(2520, 3500);
                imageMagick.ColorType = ColorType.Palette;
                imageMagick.Format = MagickFormat.Png8;
                imageMagick.Write(imagePath);
            }
        }
    }
}