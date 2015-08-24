using Aspose.Cloud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharp_SDK;

namespace CSharp_SDK.Documents
{
    class PdfToOtherFormat
    {
        public static void Run()
        {
            
            // Create an object of PDFService
            PDFService pdfService = new PDFService(RunExamples.APP_SID, RunExamples.APP_KEY);

            // Convert PDF to other Formats without using Storage
            pdfService.ConvertDocument(PDFDocumentConvertFormat.Tiff, RunExamples.GetDataDir() + "input.pdf", RunExamples.GetDataDir() + "output.tiff");
        }
    }
}
