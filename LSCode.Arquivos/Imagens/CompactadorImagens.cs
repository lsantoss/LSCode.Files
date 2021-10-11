using ImageMagick;
using System;

namespace LSCode.Arquivos.Imagens
{
    /// <summary>Classe que auxilia na compactação de imagens.</summary>
    public static class CompactadorImagens
    {
        /// <summary>Compacta imagem do caminho parametrizado.</summary>
        /// <param name="pathImagem">Caminho da imagem que será compactada.</param>
        /// <exception cref="Exception">Erro ao compactar a imagem.</exception>
        public static void Compactar(string pathImagem)
        {
            using (var imageMagick = new MagickImage(pathImagem))
            {
                imageMagick.Transparent(MagickColor.FromRgb(0, 0, 0));
                imageMagick.FilterType = FilterType.Quadratic;
                imageMagick.Resize(2520, 3500);
                imageMagick.ColorType = ColorType.TrueColor;
                imageMagick.Format = MagickFormat.Png8;
                imageMagick.Write(pathImagem);
            }
        }
    }
}