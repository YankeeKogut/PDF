using System;
using Spire.Pdf;

namespace PDF.Core
{
    public static class PageGuru
    {
        public static void AlignPages(PdfDocument document)
        {
            //if (IsOdd(document.PageCount))
            //{
            //    AddPage(document);
            //}
        }

        private static void AddPage(PdfDocument document)
        {
            throw new NotImplementedException();
        }

        private static bool IsOdd(int value)
        {
            return value % 2 != 0;
        }
    }
}
