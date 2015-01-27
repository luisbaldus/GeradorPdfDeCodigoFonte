using System.Collections.Generic;
using GeradorPdfDeCodigoFonte;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GeradorPdfDeCodigoFonteTest
{
    [TestClass]
    public class LocalizadorDeArquivosTest
    {
        [TestMethod]
        public void LocalizaArquivosDoDiretorioTest()
        {
            var localizador = new LocalizadorDeArquivos();
            var listaDeArquivosEsperada = new List<string> { @"C:\Projetos\arq\Teste\3.txt", @"C:\Projetos\arq\Teste\4.txt", @"C:\Projetos\arq\1.txt", @"C:\Projetos\arq\2.txt" };
            var listaDeArquivosAtual = localizador.LocalizaArquivosDoDiretorioRecursivamente(@"C:\Projetos\arq",
                new List<string>() { "*.txt" });
            Assert.AreEqual(listaDeArquivosEsperada[0], listaDeArquivosAtual[0].FullName);
            Assert.AreEqual(listaDeArquivosEsperada[1], listaDeArquivosAtual[1].FullName);
            Assert.AreEqual(listaDeArquivosEsperada[2], listaDeArquivosAtual[2].FullName);
            Assert.AreEqual(listaDeArquivosEsperada[3], listaDeArquivosAtual[3].FullName);
        }
    }
}
