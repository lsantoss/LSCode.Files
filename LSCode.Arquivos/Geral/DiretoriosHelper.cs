using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LSCode.Arquivos.Geral
{
    /// <summary>Helper que auxilia na manipulações de diretórios.</summary>
    public class DiretoriosHelper
    {
        /// <summary>Construtor da classe DiretoriosHelper.</summary>
        /// <returns>Cria uma instância da classe DiretoriosHelper.</returns>
        public DiretoriosHelper() { }

        /// <summary>Verifica se um diretório existe no caminho parametrizado.</summary>
        /// <param name="diretorioPath">Caminho do diretório que será verificado.</param>
        /// <returns>True caso exista ou False caso não exista.</returns>
        public bool VerificarExistencia(string diretorioPath)
        {
            try
            {
                return Directory.Exists(diretorioPath);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>Cria diretório no caminho parametrizado.</summary>
        /// <param name="diretorioPath">Caminho onde o diretório que será criado.</param>
        /// <exception cref="Exception">Erro ao criar o diretório.</exception>
        public void Criar(string diretorioPath)
        {
            try
            {
                Directory.CreateDirectory(diretorioPath);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>Apaga diretório vazio no caminho parametrizado.</summary>
        /// <param name="diretorioPath">Caminho do diretório que será apagado.</param>
        /// <exception cref="Exception">Erro ao apagar o diretório.</exception>
        public void ApagarVazio(string diretorioPath)
        {
            try
            {
                Directory.Delete(diretorioPath);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>Apaga diretório e todo seu conteúdo no caminho parametrizado.</summary>
        /// <param name="diretorioPath">Caminho do diretório que será apagado.</param>
        /// <exception cref="Exception">Erro ao apagar o diretório.</exception>
        public void Apagar(string diretorioPath)
        {
            try
            {
                Directory.Delete(diretorioPath, true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>Move diretório e todo seu conteúdo no caminho parametrizado.</summary>
        /// <remarks>Observação: O caminho de destino não pode existir.</remarks>
        /// <param name="origemPath">Caminho do diretório que será movido.</param>
        /// <param name="destinoPath">Caminho para onde o diretório será movido.</param>
        /// <exception cref="Exception">Erro ao mover o diretório.</exception>
        public void Mover(string origemPath, string destinoPath)
        {
            try
            {
                Directory.Move(origemPath, destinoPath);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>Obtém lista de diretórios filhos no caminho parametrizado.</summary>
        /// <param name="diretorioPath">Caminho do diretório.</param>
        /// <returns>Lista de caminhos dos diretórios filhos.</returns>
        /// <exception cref="Exception">Erro ao obter os diretórios filhos.</exception>
        public List<string> ObterDiretoriosFilhos(string diretorioPath)
        {
            try
            {
                return Directory.GetDirectories(diretorioPath).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>Obtém lista de arquivos filhos no caminho parametrizado.</summary>
        /// <param name="diretorioPath">Caminho do diretório.</param>
        /// <returns>Lista de caminhos dos arquivos filhos.</returns>
        /// <exception cref="Exception">Erro ao obter os arquivos filhos.</exception>
        public List<string> ObterArquivosFilhos(string diretorioPath)
        {
            try
            {
                return Directory.GetFiles(diretorioPath).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>Obtém lista de diretórios e arquivos filhos no caminho parametrizado.</summary>
        /// <param name="diretorioPath">Caminho do diretório.</param>
        /// <returns>Lista de caminhos dos diretórios e arquivos filhos.</returns>
        /// <exception cref="Exception">Erro ao obter os diretórios e arquivos filhos.</exception>
        public List<string> ObterTodosConteudosFilhos(string diretorioPath)
        {
            try
            {
                var conteudo = Directory.GetDirectories(diretorioPath).ToList();

                foreach (var item in Directory.GetFiles(diretorioPath))
                {
                    conteudo.Add(item);
                }

                return conteudo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>Apaga lista de diretórios filhos no caminho parametrizado.</summary>
        /// <param name="diretorioPath">Caminho do diretório.</param>
        /// <exception cref="Exception">Erro ao apagar os diretórios filhos.</exception>
        public void ApagarDiretoriosFilhos(string diretorioPath)
        {
            try
            {
                var diretorios = Directory.GetDirectories(diretorioPath).ToList();

                foreach (var item in diretorios)
                {
                    Directory.Delete(item);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>Apaga lista de arquivos filhos no caminho parametrizado.</summary>
        /// <param name="diretorioPath">Caminho do diretório.</param>
        /// <exception cref="Exception">Erro ao apagar os arquivos filhos.</exception>
        public void ApagarArquivosFilhos(string diretorioPath)
        {
            try
            {
                var arquivos = Directory.GetFiles(diretorioPath).ToList();

                foreach (var item in arquivos)
                {
                    File.Delete(item);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>Apaga lista de diretórios e arquivos filhos no caminho parametrizado.</summary>
        /// <param name="diretorioPath"> Caminho do diretório.</param>
        /// <exception cref="Exception">Erro ao apagar os diretórios e arquivos filhos.</exception>
        public void ApagarArquivosEDiretoriosFilhos(string diretorioPath)
        {
            try
            {
                var diretorios = Directory.GetDirectories(diretorioPath).ToList();
                var arquivos = Directory.GetFiles(diretorioPath).ToList();

                foreach (var item in diretorios)
                {
                    Directory.Delete(item);
                }

                foreach (var item in arquivos)
                {
                    File.Delete(item);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}