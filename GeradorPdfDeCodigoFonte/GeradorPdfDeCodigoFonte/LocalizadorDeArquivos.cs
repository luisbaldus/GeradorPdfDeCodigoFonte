using System.Collections.Generic;
using System.IO;

namespace GeradorPdfDeCodigoFonte
{
    public class LocalizadorDeArquivos
    {
        public List<FileInfo> LocalizaArquivosDoDiretorioRecursivamente(string pathDiretorio, List<string> extensõesParaLeitura)
        {
            var diretorio = new DirectoryInfo(pathDiretorio);
            var listaArquivos = new List<FileInfo>();

            listaArquivos.AddRange(LocalizaArquivosSubDiretorios(pathDiretorio, extensõesParaLeitura, diretorio));
            listaArquivos.AddRange(LocalizaArquivoDiretorioAtual(extensõesParaLeitura, diretorio));

            return listaArquivos;
        }

        private IEnumerable<FileInfo> LocalizaArquivoDiretorioAtual(IEnumerable<string> extensõesParaLeitura,
            DirectoryInfo diretorio)
        {
            var listaArquivosDiretorioAtual = new List<FileInfo>();
            foreach (var extensãoParaLeitura in extensõesParaLeitura)
            {
                listaArquivosDiretorioAtual.AddRange(diretorio.GetFiles(extensãoParaLeitura));
            }
            return listaArquivosDiretorioAtual;
        }

        private IEnumerable<FileInfo> LocalizaArquivosSubDiretorios(string pathDiretorio, List<string> extensõesParaLeitura, DirectoryInfo diretorio)
        {
            var listaArquivosSubDiretorios = new List<FileInfo>();
            foreach (var subdiretorios in diretorio.GetDirectories())
            {
                listaArquivosSubDiretorios.AddRange(LocalizaArquivosDoDiretorioRecursivamente(pathDiretorio + @"\" + subdiretorios, extensõesParaLeitura));
            }
            return listaArquivosSubDiretorios;
        }
    }
}
