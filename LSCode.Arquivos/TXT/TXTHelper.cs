using LSCode.Arquivos.Geral;
using System;
using System.IO;

namespace LSCode.Arquivos.TXT
{
    /// <summary>Helper que auxilia na manipulações de arquivos com extensão ".txt".</summary>
    public class TXTHelper : ArquivosHelper
    {
        /// <summary>Construtor da classe TXTHelper.</summary>
        /// <returns>Cria uma instância da classe TXTHelper.</returns>
        public TXTHelper() { }

        /// <summary>Cria arquivo vazio no caminho parametrizado.</summary>
        /// <param name="arquivoPath">Caminho onde o arquivo será criado.</param>
        public void CriarArquivo(string arquivoPath)
        {
            try
            {
                var streamWriter = new StreamWriter(arquivoPath);
                streamWriter.Close();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>Lê arquivo inteiro no caminho parametrizado.</summary>
        /// <param name="arquivoPath">Caminho onde o arquivo que será lido.</param>
        /// <returns>Conteúdo do arquivo.</returns>
        /// <exception cref="Exception">Erro ao ler o arquivo.</exception>
        public string LerArquivoInteiro(string arquivoPath)
        {
            try
            {
                return File.ReadAllText(arquivoPath);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>Lê todas as linhas do arquivo no caminho parametrizado.</summary>
        /// <param name="arquivoPath">Caminho onde o arquivo que será lido.</param>
        /// <returns>Conteúdo do arquivo obtido linha a linha.</returns>
        /// <exception cref="Exception">Erro ao ler o arquivo.</exception>
        public string[] LerArquivoArrayDeLinhas(string arquivoPath)
        {
            try
            {
                return File.ReadAllLines(arquivoPath);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>Salva conteúdo de uma string no arquivo, caso ele não exista será criado no caminho parametrizado.</summary>
        /// <param name="arquivoPath">Caminho onde o arquivo que será salvo.</param>
        /// <param name="conteudo">Conteúdo que será salvo no arquivo.</param>
        /// <exception cref="Exception">Erro ao salvar o arquivo.</exception>
        public void SalvarArquivoStringInteira(string arquivoPath, string conteudo)
        {
            try
            {
                File.WriteAllText(arquivoPath, conteudo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>Salva conteúdo de um array no arquivo linha a linha, caso ele não exista será criado no caminho parametrizado.</summary>
        /// <param name="arquivoPath">Caminho onde o arquivo que será salvo.</param>
        /// <param name="conteudo">Conteúdo que será salvo no arquivo.</param>
        /// <exception cref="Exception">Erro ao salvar o arquivo.</exception>
        public void SalvarArquivoArrayLinhas(string arquivoPath, string[] conteudo)
        {
            try
            {
                File.WriteAllLines(arquivoPath, conteudo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>Salva conteúdo de um array no arquivo linha a linha com StreamWriter, caso ele não exista será criado no caminho parametrizado.</summary>
        /// <param name="arquivoPath">Caminho onde o arquivo que será salvo.</param>
        /// <param name="conteudo">Conteúdo que será salvo no arquivo.</param>
        /// <exception cref="Exception">Erro ao salvar o arquivo.</exception>
        public void SalvarArquivoArrayLinhasStreamWriter(string arquivoPath, string[] conteudo)
        {
            try
            {
                using (var arquivo = new StreamWriter(arquivoPath))
                {
                    foreach (var linha in conteudo)
                    {
                        arquivo.WriteLine(linha);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>Anexa novo conteúdo de uma string ao final de um arquivo existente, caso ele não exista será criado no caminho parametrizado.</summary>
        /// <param name="arquivoPath">Caminho onde o arquivo que será salvo.</param>
        /// <param name="conteudo">Conteúdo que será salvo no arquivo.</param>
        /// <exception cref="Exception">Erro ao salvar o arquivo.</exception>
        public void SalvarArquivoAdicionarConteudo(string arquivoPath, string conteudo)
        {
            try
            {
                using (var arquivo = new StreamWriter(arquivoPath, true))
                {
                    arquivo.WriteLine(conteudo);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>Anexa novo conteúdo de um array a um arquivo existente linha a linha, caso ele não exista será criado no caminho parametrizado.</summary>
        /// <param name="arquivoPath">Caminho onde o arquivo que será salvo.</param>
        /// <param name="conteudo">Conteúdo que será salvo no arquivo.</param>
        /// <exception cref="Exception">Erro ao salvar o arquivo.</exception>
        public void SalvarArquivoAdicionarConteudo(string arquivoPath, string[] conteudo)
        {
            try
            {
                using (var arquivo = new StreamWriter(arquivoPath, true))
                {
                    foreach (var linha in conteudo)
                    {
                        arquivo.WriteLine(linha);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}