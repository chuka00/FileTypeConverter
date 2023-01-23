using System;
using System.IO;
using System.Xml.Linq;

namespace WriteToPdf
{
    public class CreatePdfFile
    {
        public static void CreateFile(string textContent, string fileName)
        {

            using (var document = new Document())
            {
                PdfWriter.GetInstance(document, new FileStream("mydocument.pdf", FileMode.Create));
                document.Open();

                var font = FontFactory.GetFont(FontFactory.HELVETICA, 14);
                var paragraph = new Paragraph("Hello, this is my first PDF document!", font);
                document.Add(paragraph);

                document.Close();
            }


            /* // Create a new PDF document
             Document document = new Document();

             // Set the page size and margins
             document.SetPageSize(PageSize.A4);
             document.SetMargins(50, 50, 50, 50);

             // Create a new PdfWriter object
             PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(fileName, FileMode.Create));

             // Open the document for writing
             document.Open();

             // Create a new font and add it to the document
             Font font = new Font(Font.FontFamily.TIMES_ROMAN, 12, Font.NORMAL);
             document.Add(new Paragraph(textContent, font));

             // Close the document
             document.Close();*/
        }
    }
}

