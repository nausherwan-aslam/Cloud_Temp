using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharp_REST;
using System.IO;

namespace CSharp_REST.Documents
{
    class PdfToOtherFormat
    {
        public static void Run()
        {

            string inputFile = RunExamples.GetDataDir() + "input.pdf";

            string outputFile = RunExamples.GetDataDir() + "output.tiff";

            // Build URI to perform request. ServiceController is located in Aspose.Cloud.Common in .NET SDK Source code available at http://goo.gl/BftpIi
            string apiUrl = string.Format(@"pdf/convert?format={0}&outPath={1}", "tiff", outputFile);

            if (!string.IsNullOrEmpty(outputFile) && Directory.Exists(Path.GetDirectoryName(outputFile)))
            {
                using (Stream responseStream = Common.GetResultStream(apiUrl, "PUT", File.ReadAllBytes(inputFile)))
                using (Stream file = File.OpenWrite(outputFile))
                {
                    Common.CopyStream(responseStream, file);
                }
            }

        }
    }
}
