using CSharp_SDK.Documents;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CSharp_SDK
{
    class RunExamples
    {
        public static string APP_SID = "";
        public static string APP_KEY = "";
        public static string STORAGE = "";
        

        [STAThread]
        public static void Main()
        {
            Console.WriteLine("Open RunExamples.cs. In Main() method, Un-comment the example that you want to run");
            Console.WriteLine("=====================================================");
            // Un-comment the one you want to try out

            
            PdfToOtherFormat.Run();
                        

            // Stop before exiting
            Console.WriteLine("\n\nProgram Finished. Press any key to exit....");
            Console.ReadKey();
        }

        public static String GetDataDir()
        {
            return Path.GetFullPath("../../Data/");
        }

    }
}