using System;
using System.IO;

namespace LSCode.Arquivos.Geral
{
    /// <summary>Helper que auxilia na manipulações de arquivos.</summary>
    public class ArquivosHelper
    {
        /// <summary>Construtor da classe ArquivosHelper.</summary>
        /// <returns>Cria uma instância da classe ArquivosHelper.</returns>
        public ArquivosHelper(){ }

        /// <summary>Verifica se um arquivo existe no caminho parametrizado.</summary>
        /// <param name="arquivoPath">Caminho do arquivo que será verificado.</param>
        /// <returns>True caso exista ou False caso não exista.</returns>
        public bool VerificarExistencia(string arquivoPath)
        {
            try
            {
                return File.Exists(arquivoPath);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>Copia arquivo sem a possibilidade de sobreescrever se já exitir.</summary>
        /// <param name="arquivoPath">Caminho do arquivo que será copiado.</param>
        /// <param name="destinoPath">Caminho de destino da cópia do arquivo.</param>
        /// <exception cref="Exception">Erro ao copiar o arquivo.</exception>
        public void CopiarSemSobreescrever(string arquivoPath, string destinoPath)
        {
            try
            {
                File.Copy(arquivoPath, destinoPath);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>Copia arquivo com a possibilidade de sobreescrever se já existir.</summary>
        /// <param name="arquivoPath">Caminho do arquivo que será copiado.</param>
        /// <param name="destinoPath">Caminho de destino da cópia do arquivo.</param>
        /// <exception cref="Exception">Erro ao copiar o arquivo.</exception>
        public void CopiarSobreescrever(string arquivoPath, string destinoPath)
        {
            try
            {
                File.Copy(arquivoPath, destinoPath, true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>Move arquivo sem a possibilidade de sobreescrever se já exitir.</summary>
        /// <param name="arquivoPath">Caminho do arquivo que será movido.</param>
        /// <param name="destinoPath">Caminho de destino do arquivo que será movido.</param>
        /// <exception cref="Exception">Erro ao mover o arquivo.</exception>
        public void MoverSemSobreescrever(string arquivoPath, string destinoPath)
        {
            try
            {
                File.Move(arquivoPath, destinoPath);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>Apaga arquivo no caminho parametrizado.</summary>
        /// <param name="arquivoPath">Caminho do arquivo que será apagado.</param>
        /// <exception cref="Exception">Erro ao apagar o arquivo.</exception>
        public void Apagar(string arquivoPath)
        {
            try
            {
                File.Delete(arquivoPath);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>Salva arquivo no caminho parametrizado a partir de um array de bytes.</summary>
        /// <param name="arquivoEmBytes">Array de bytes com o conteúdo do arquivo.</param>
        /// <param name="arquivoPath">Caminho onde o arquivo será salvo.</param>
        /// <exception cref="Exception">Erro ao salvar o arquivo.</exception>
        public void Salvar(byte[] arquivoEmBytes, string arquivoPath)
        {
            try
            {
                File.WriteAllBytes(arquivoPath, arquivoEmBytes);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>Salva arquivo no caminho parametrizado a partir de um base64String.</summary>
        /// <param name="arquivoEmBase64String">Base64String com o conteúdo do arquivo.</param>
        /// <param name="arquivoPath">Caminho onde o arquivo será salvo.</param>
        /// <exception cref="Exception">Erro ao salvar o arquivo.</exception>
        public void Salvar(string arquivoEmBase64String, string arquivoPath)
        {
            try
            {
                var arquivoEmBytes = Convert.FromBase64String(arquivoEmBase64String);
                File.WriteAllBytes(arquivoPath, arquivoEmBytes);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>Obtém arquivo no caminho parametrizado em um array de bytes.</summary>
        /// <param name="arquivoPath">Caminho do arquivo que será obtido.</param>
        /// <returns>Array de bytes com o conteúdo do arquivo.</returns>
        /// <exception cref="Exception">Erro ao obter o arquivo.</exception>
        public byte[] ObterEmBytes(string arquivoPath)
        {
            try
            {
                return File.ReadAllBytes(arquivoPath);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>Obtém arquivo no caminho parametrizado em um base64String.</summary>
        /// <param name="arquivoPath">Caminho do arquivo que será obtido.</param>
        /// <returns>Base64String com o conteúdo do arquivo.</returns>
        /// <exception cref="Exception">Erro ao obter o arquivo.</exception>
        public string ObterEmBase64String(string arquivoPath)
        {
            try
            {
                var bytes = File.ReadAllBytes(arquivoPath);
                var base64String = Convert.ToBase64String(bytes);
                return base64String;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>Converte arquivo em base64String no caminho parametrizado em um array de bytes.</summary>
        /// <param name="arquivoPath">Caminho do arquivo que será convertido.</param>
        /// <returns>Array de bytes com o conteúdo do arquivo.</returns>
        /// <exception cref="Exception">Erro ao converter o arquivo.</exception>
        public byte[] ConverterBase64StringParaBytes(string arquivoPath)
        {
            try
            {
                return Convert.FromBase64String(arquivoPath);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>Converte arquivo em array de bytes no caminho parametrizado em um base64String.</summary>
        /// <param name="arquivoPath">Caminho do arquivo que será convertido.</param>
        /// <returns>Base64String com o conteúdo do arquivo.</returns>
        /// <exception cref="Exception">Erro ao converter o arquivo.</exception>
        public string ConverterBytesParaBase64String(byte[] arquivoPath)
        {
            try
            {
                return Convert.ToBase64String(arquivoPath);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}