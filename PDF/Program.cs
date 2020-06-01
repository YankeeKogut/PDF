using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using Spire.Pdf;
using Spire.Pdf.Graphics;
using Spire.Pdf.Widget;

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

            var start = DateTime.Now;

            var docs = new List<PdfDocument>();

            var merged = new PdfDocument();

            fileList.ForEach(file => docs.Add(new PdfDocument(file)));

            docs.ForEach(doc => merged.AppendPage(doc));

            var unitCvtr = new PdfUnitConvertor();
            var verticalMargin = unitCvtr.ConvertUnits(2.54f, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point);
            var horizontalMargin = unitCvtr.ConvertUnits(3.17f, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point);
            var margin = new PdfMargins()
            {
                Top = verticalMargin,
                Bottom = verticalMargin,
                Left = horizontalMargin,
                Right = horizontalMargin
            };

            DrawPageNumber(merged.Pages, margin, 1, merged.Pages.Count);

            merged.SaveToFile("C:\\!Files\\merged.pdf");
            var finished = DateTime.Now - start;
            //write
            Console.WriteLine($@"Merged total of {fileList.Count} files in {finished.TotalSeconds} seconds");
        }

        private static void DrawPageNumber(PdfPageCollection pages, PdfMargins margin, int startNumber, int pageCount)
        {
            var brush = PdfBrushes.Black;
            var pen = new PdfPen(brush, 2f);
            var font = new PdfTrueTypeFont(new Font("Arial", 9f, System.Drawing.FontStyle.Italic), true);
            var format = new PdfStringFormat(PdfTextAlignment.Right)
            {
                MeasureTrailingSpaces = true
            };
            var space = font.Height * 0.75f;
            var x = margin.Left;

            foreach (PdfPageBase page in pages)
            {
                page.Canvas.SetTransparency(1f);
                var width = page.Canvas.ClientSize.Width - margin.Left - margin.Right;
                var y = page.Canvas.ClientSize.Height - margin.Bottom + space;
                page.Canvas.DrawLine(pen, x, y, x + width, y);
                y += 1;
                var numberLabel = $"{startNumber++} of {pageCount}";
                page.Canvas.DrawString(numberLabel, font, brush, x + width, y, format);
                page.Canvas.SetTransparency(1);
            }
        }

    }
}
