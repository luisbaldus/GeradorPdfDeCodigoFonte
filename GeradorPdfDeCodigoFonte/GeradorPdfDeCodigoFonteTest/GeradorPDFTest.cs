using System.Collections.Generic;
using GeradorPdfDeCodigoFonte;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GeradorPdfDeCodigoFonteTest
{
    [TestClass]
    public class GeradorPDFTest
    {
        [TestMethod]
        public void GeradorPDFGeraPDFDeArquivoTest()
        {
            var gerador = new GeradorPDF();
            var localizador = new LocalizadorDeArquivos();
            var listaDeArquivosAtual = localizador.LocalizaArquivosDoDiretorioRecursivamente(@"C:\Projetos\arq", new List<string>() { "*.txt" });
            foreach (var fileInfo in listaDeArquivosAtual)
            {
                gerador.GeraPDFDeArquivo(fileInfo, "Projetos", "INPI");
            }
        }
    }
}
