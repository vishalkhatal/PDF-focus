using SautinSoft;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDF_focus_demo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Extract all images with width and height more than 200px
            SautinSoft.PdfFocus f = new SautinSoft.PdfFocus();

            string pdfFile = @"D:\Personal_GitHub\ExtractimagesFromPDF\PdfUtils\ReadPdfImage\Data\dipak.pdf";
            string imageDir = Path.GetDirectoryName(pdfFile);

            List<PdfFocus.PdfImage> pdfImages = null;

            f.OpenPdf(pdfFile);

            if (f.PageCount > 0)
            {
                // Specify to extract only images which have width and height
                // more than 200px
                f.ImageExtractionOptions.MinSize = new System.Drawing.Size(200, 200);

                pdfImages = f.ExtractImages();

                // Show all extracted images.
                if (pdfImages != null && pdfImages.Count > 0)
                {

                    for (int i = 0; i < pdfImages.Count; i++)
                    {
                        string imageFile = Path.Combine(imageDir, String.Format("img{0}.png", i + 1));
                        pdfImages[i].Picture.Save(imageFile);
                        System.Diagnostics.Process.Start(imageFile);
                    }
                }
            }
        }
    }
}
