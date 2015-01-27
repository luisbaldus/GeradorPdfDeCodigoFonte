using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;


namespace GeradorPdfDeCodigoFonte
{
    public class GeradorPDF
    {
        public void GeraPDFDeArquivo(FileInfo arquivo, string antigoDiretorioRaiz, string novoDiretorioRaiz)
        {
            var texto = LeArquivoOrigem(arquivo);
            if (arquivo.DirectoryName == null) return;
            var novoCaminhoCompleto = CriaDiretorioNecessarios(arquivo, antigoDiretorioRaiz, novoDiretorioRaiz);
            EscrevePDF(novoCaminhoCompleto, texto);
            MudaExtensão(arquivo);
        }

        private static void MudaExtensão(FileInfo arquivo)
        {
            var extensãoAtual = Path.GetExtension(arquivo.FullName);
            arquivo.Replace(extensãoAtual, ".pdf");
        }

        private static string LeArquivoOrigem(FileInfo arquivo)
        {
            var texto = File.ReadAllText(arquivo.FullName);
            return texto;
        }


        private static string CriaDiretorioNecessarios(FileInfo arquivo, string antigoDiretorioRaiz, string novoDiretorioRaiz)
        {
            var diretorioNovo = arquivo.DirectoryName.Replace(antigoDiretorioRaiz, novoDiretorioRaiz);
            if (!Directory.Exists(diretorioNovo))
            {
                Directory.CreateDirectory(diretorioNovo);
            }
            var novoCaminhoCompleto = Path.Combine(diretorioNovo, arquivo.Name);
            return novoCaminhoCompleto;
        }

        private static void EscrevePDF(string novoCaminhoCompleto, string texto)
        {
            var fs = new FileStream(novoCaminhoCompleto, FileMode.Create);
            var document = new Document(PageSize.A4, 25, 25, 30, 30);
            var writer = PdfWriter.GetInstance(document, fs);
            document.AddAuthor("Cba Tecnologia");
            document.AddCreator("Cbanet");
            document.AddKeywords("Cbanet");
            document.AddTitle("Cbanet");
            document.Open();
            document.Add(new Paragraph(texto));
            document.Close();
            writer.Close();
            fs.Close();
            //File.WriteAllText(novoCaminhoCompleto, texto);
        }

    }
}
