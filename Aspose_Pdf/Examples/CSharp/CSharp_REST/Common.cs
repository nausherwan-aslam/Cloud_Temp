using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Web;
using System.Text.RegularExpressions;
using System.Security.Cryptography;


namespace CSharp_REST
{
    public class Common
    {

        private static string Sign(string url)
        {
            // Add AppSid parameter.
            UriBuilder uriBuilder = new UriBuilder(url);

            if (uriBuilder.Query != null && uriBuilder.Query.Length > 1)
                uriBuilder.Query = uriBuilder.Query.Substring(1) + "&appSID=" + RunExamples.APP_SID;
            else
                uriBuilder.Query = "appSID=" + RunExamples.APP_SID;

            // Remove final slash here as it can be added automatically.
            uriBuilder.Path = uriBuilder.Path.TrimEnd('/');

            // Compute the hash.
            byte[] privateKey = Encoding.UTF8.GetBytes(RunExamples.APP_KEY);
            HMACSHA1 algorithm = new HMACSHA1(privateKey);

            byte[] sequence = ASCIIEncoding.ASCII.GetBytes(uriBuilder.Uri.AbsoluteUri);
            byte[] hash = algorithm.ComputeHash(sequence);
            string signature = Convert.ToBase64String(hash);

            // Remove invalid symbols.
            signature = signature.TrimEnd('=');
            signature = System.Web.HttpUtility.UrlEncode(signature);

            // Convert codes to upper case as they can be updated automatically.
            signature = Regex.Replace(signature, "%[0-9a-f]{2}", e => e.Value.ToUpper());

            // Add the signature to query string.
            return string.Format("{0}&signature={1}", uriBuilder.Uri.AbsoluteUri, signature);
        }

        public static Stream GetResultStream(string apiUrl, string requestType, byte[] byteArray = null)
        {
           
                apiUrl = RunExamples.BASE_PATH + apiUrl;
                Uri uri = new Uri(Sign(apiUrl));
                WebRequest request = WebRequest.Create(uri);
                request.Method = requestType;
                request.ContentType = "application/json";
                request.ContentLength = 0;
                request.Headers.Add("x-aspose-client", ".NETSDK/v2.0");

                if (byteArray != null)
                {
                    request.ContentLength = byteArray.Length;
                    using (Stream stream = request.GetRequestStream())
                    {
                        stream.Write(byteArray, 0, byteArray.Length);
                    }
                }

                WebResponse response = request.GetResponse();
                return response.GetResponseStream();
           
        }

       

        public static void CopyStream(Stream input, Stream output)
        {
            byte[] buffer = new byte[8 * 1024];
            int length;
            while ((length = input.Read(buffer, 0, buffer.Length)) > 0)
            {
                output.Write(buffer, 0, length);
            }
        }
    }
}
