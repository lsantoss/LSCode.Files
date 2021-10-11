using ImageMagick;
using System;

namespace LSCode.Arquivos.Imagens
{
    /// <summary>Classe que auxilia na compactação de imagens.</summary>
    public static class CompactadorImagens
    {
        /// <summary>Compacta imagem do caminho parametrizado.</summary>
        /// <remarks>Observação: A imagem original será substituída pela imagem compactada. Pode existir perda de qualidade.</remarks>
        /// <param name="pathImagem">Caminho da imagem que será compactada.</param>
        /// <exception cref="Exception">Erro ao compactar a imagem.</exception>
        public static void Compactar(string pathImagem)
        {
            using (var imageMagick = new MagickImage(pathImagem))
            {
                imageMagick.Transparent(MagickColor.FromRgb(0, 0, 0));
                imageMagick.FilterType = FilterType.Spline;
                imageMagick.Resize(2520, 3500);
                imageMagick.ColorType = ColorType.Palette;
                imageMagick.Format = MagickFormat.Png8;
                imageMagick.Write(pathImagem);
            }
        }
    }
}