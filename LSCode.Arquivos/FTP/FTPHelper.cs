using System;
using System.IO;
using System.Net;

namespace LSCode.Arquivos.FTP
{
    /// <summary>Helper que auxilia na manipulação de diretórios e arquivos através de FTP.</summary>
    public class FTPHelper
    {
        /// <value>Usuário utilizado para a conexão.</value>
        public string Usuario { get; private set; }

        /// <value>Senha utilizada para a conexão.</value>
        public string Senha { get; private set; }

        /// <summary>Construtor da classe FTPHelper.</summary>
        /// <param name="usuario">Usuário utilizado para a conexão.</param>
        /// <param name="senha">Senha utilizada para a conexão.</param>
        /// <returns>Cria uma instância da classe FTPHelper.</returns>
        public FTPHelper(string usuario, string senha)
        {
            Usuario = usuario;
            Senha = senha;
        }

        /// <summary>Verifica se um diretório existe no caminho indicado.</summary>
        /// <param name="diretorioPath">Caminho do diretório que será verificado.</param>
        /// <returns>True caso exista ou False caso não exista.</returns>
        public bool VerificarExistenciaDiretorio(string diretorioPath)
        {
            var ftpRequest = (FtpWebRequest)FtpWebRequest.Create(diretorioPath);
            ftpRequest.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
            ftpRequest.Credentials = new NetworkCredential(Usuario, Senha);

            try
            {
                var ftpResponse = ftpRequest.GetResponse();
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>Cria diretório no caminho parametrizado.</summary>
        /// <param name="diretorioPath">Caminho do diretório que será criado.</param>
        /// <exception cref="Exception">Erro ao criar o diretório.</exception>
        public void CriarDiretorio(string diretorioPath)
        {
            try
            {
                var ftpRequest = (FtpWebRequest)FtpWebRequest.Create(diretorioPath);
                ftpRequest.Method = WebRequestMethods.Ftp.MakeDirectory;
                ftpRequest.Credentials = new NetworkCredential(Usuario, Senha);

                var ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>Apaga diretório no caminho parametrizado.</summary>
        /// <param name="diretorioPath">Caminho do diretório que será apagado.</param>
        /// <exception cref="Exception">Erro ao apagar o diretório.</exception>
        public void ApagarDiretorio(string diretorioPath)
        {
            try
            {
                var ftpRequest = (FtpWebRequest)FtpWebRequest.Create(diretorioPath);
                ftpRequest.Method = WebRequestMethods.Ftp.RemoveDirectory;
                ftpRequest.Credentials = new NetworkCredential(Usuario, Senha);

                var ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>Verifica se um arquivo existe no caminho parametrizado.</summary>
        /// <param name="diretorioPath">Caminho do arquivo.</param>
        /// <param name="nomeArquivo">Nome do arquivo que será verificado.</param>
        /// <returns>True caso exista ou False caso não exista.</returns>
        public bool VerificarExistenciaArquivo(string diretorioPath, string nomeArquivo)
        {
            try
            {
                var ftpRequest = (FtpWebRequest)FtpWebRequest.Create(diretorioPath);
                ftpRequest.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
                ftpRequest.Credentials = new NetworkCredential(Usuario, Senha);

                var ftpResponse = ftpRequest.GetResponse();

                var reader = new StreamReader(ftpResponse.GetResponseStream());
                bool existeArquivo = reader.ReadToEnd().Contains(nomeArquivo);
                return existeArquivo;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>Faz upload de um arquivo de qualquer extensão para o destino parametrizado.</summary>
        /// <param name="arquivoPath">Caminho do arquivo que será enviado.</param>
        /// <param name="diretorioPath">Caminho do diretório para onde o upload do arquivo será feito.</param>
        /// <exception cref="Exception">Erro ao fazer upload do arquivo.</exception>
        public void FazerUploadArquivo(string arquivoPath, string diretorioPath)
        {
            try
            {
                var stream = File.OpenRead(arquivoPath);

                var buffer = new byte[stream.Length];

                stream.Read(buffer, 0, buffer.Length);

                var uri = new Uri(diretorioPath);

                var request = (FtpWebRequest)FtpWebRequest.Create(uri);
                request.Credentials = new NetworkCredential(Usuario, Senha);
                request.KeepAlive = false;
                request.Method = WebRequestMethods.Ftp.UploadFile;
                request.UseBinary = true;
                request.ContentLength = buffer.Length;

                var strm = request.GetRequestStream();
                strm.Write(buffer, 0, buffer.Length);
                strm.Close();

                stream.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>Apaga arquivo no caminho parametrizado.</summary>
        /// <param name="arquivoPath">Caminho do arquivo que será apagado.</param>
        /// <exception cref="Exception">Erro ao apagar o arquivo.</exception>
        public void ApagarArquivo(string arquivoPath)
        {
            try
            {
                var ftpRequest = (FtpWebRequest)WebRequest.Create(arquivoPath);
                ftpRequest.Credentials = new NetworkCredential(Usuario, Senha);
                ftpRequest.Method = WebRequestMethods.Ftp.DeleteFile;

                var ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }   
    }
}