using System;
using System.Collections.Generic;
using System.IO;
using IronPdf;

namespace PDF
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            // read
            var fileList = new List<string>();

            fileList.AddRange(Directory.GetFiles("C:\\!Files"));
            //merge


            // Join Multiple Existing PDFs into a single document
            var PDFs = new List<PdfDocument>();
            var start = DateTime.Now;

            fileList.ForEach(file=> PDFs.Add(PdfDocument.FromFile(file)));

            var PDF = PdfDocument.Merge(PDFs);
            PDF.SaveAs("C:\\!Files\\merged.pdf");

            var finished = DateTime.Now - start;
            //write
            Console.WriteLine($@"Merged total of {fileList.Count} files in {finished.TotalSeconds} seconds");

        }

    }
}
