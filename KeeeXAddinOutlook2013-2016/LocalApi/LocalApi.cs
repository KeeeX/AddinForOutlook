using KeeeXAddinOutlook2013_2016.Controller;
using KeeeXAddinOutlook2013_2016.Model;
using KeeeXAddinOutlook2013_2016.Model.KeeeX;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace KeeeXAddinOutlook2013_2016
{
    class LocalApi
    {
        public static string getAllContacts()
        {
            WebRequest webRequest = WebRequest.Create("http://localhost:8288/kx/api/user");
            //webRequest.Timeout = 500;
            try
            {
                WebResponse webResp = webRequest.GetResponse();
                if (webResp != null)
                {
                    Stream dataStream = webResp.GetResponseStream();
                    StreamReader reader = new StreamReader(dataStream);
                    return reader.ReadToEnd();
                }
                return "";
            }
            catch (WebException webException)
            {
                return webException.ToString();
            }
            
        }

        public static KeeeX_File_Treated keeexFile(KeeeX_File_Request request)
        {
            KeeeX_File_Treated treated;
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://localhost:8288/kx/api/topic/keeex");
            //httpWebRequest.Timeout = 500;
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = new JavaScriptSerializer().Serialize(request);
                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                treated = JSONParser.jsonToKeeeXTreatedFile(result);
            }

            return treated;
        }

        public static CipherResponse cipherFile(KeeeX_File_Treated treated, List<Contact> recipients)
        {
            // BUILDING THE REQUEST
            CipherRequest request = new CipherRequest();
            request.path = treated.path;
            request.recipients = new string[recipients.Count];
            for (int i = 0; i<recipients.Count; i++)
            {
                request.recipients[i] = recipients.ElementAt(i).profileIdx;
            }

            var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://localhost:8288/kx/api/topic/cipher");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            //httpWebRequest.Timeout = 500;

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = new JavaScriptSerializer().Serialize(request);
                
                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }
            CipherResponse cipherResponse;
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                cipherResponse = JSONParser.jsonToCipherResponse(result);
                if(cipherResponse == null)
                {
                    throw new Exception("KeeeX answered null");
                }
            }

            return cipherResponse ;
        }

        public static SharedList getShared(string idx)
        {
            string response;
            SharedList returnMe = null;

            WebRequest webRequest = WebRequest.Create("http://localhost:8288/kx/api/topic/" + idx + "/shared");
            //webRequest.Timeout = 500;

            WebResponse webResp = webRequest.GetResponse();
            if (webResp != null)
            {
                Stream dataStream = webResp.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                response = reader.ReadToEnd();
                returnMe = JSONParser.jsonToSharedList(response);
            }

            return returnMe;
        }

        public static void sendSharedNotification(ShareRequest shareRequest)
        {
            // BUILDING THE REQUEST

            var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://localhost:8288/kx/api/notification/share");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = new JavaScriptSerializer().Serialize(shareRequest);
                Debug.Print(json);
                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

            return;
        }

    }
}
