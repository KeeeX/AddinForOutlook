/*
Copyright (c) 2016 KeeeX SAS 

This is an open source project available under the MIT license.
Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:
The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.
*/

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

keeex self xubos-degin-rydal-duryd-myhek-kekir-dogus-vehas-vasyd-repyn-syrud-pepab-rinyv-vipel-hirur-kezul-zexex , {main} xeeek
keeex self 1u3gm1h68nmbyvjfRAz8xXLKTQyHUUvvsoB7icL , {alg:sha224,enc:b58,recursive:1} xeeek
keeex name "LocalApi.cs" , {main} xeeek
keeex prop "kx.author", "rerom-tumit-fucuz-vicur-tiluc-hotec-vuses-cafoz-cazyr-nitaf-vuhyf-dunal-fygob-levom-vevor-korap-loxyr" xeeek
keeex ref "ruvog-lalyc-pyhos-tetun-lyten-furym-zymec-benot-buhit-sivad-cedot-hogak-zapig-filag-lytav-kyhef-hyxyr" , {mine} xeeek
keeex signer rerom-cityz-bivyc-ralav-bumon-mudyh-hocyr-pikyv-sysyz-cunat-gesiz-lipig-cozof-harif-sapor-gacaf-nixer xeeek
keeex prop "kx.time", "Thu, 12 May 2016 14:16:03 GMT" xeeek
keeex prop "kx.pattern", "-%f" xeeek
keeex prop "kx.folder", "LocalApi" xeeek
keeex ref "rodok-fapab-sokeh-zesyr-lyvyt-catev-lycip-samuv-difen-dufoc-lagyk-zilur-hybap-fegan-rutig-lekov-lexer" xeeek
keeex ref "rezop-peced-terip-vivap-debal-mutyz-pahan-motod-pavan-vynuc-keboh-kofav-mupek-dycur-benyh-vyduk-kyxur" xeeek
keeex ref "rozip-vovis-cocuh-putyv-vufad-zuruh-benen-ketop-zezyt-zetug-hacel-coher-vedyk-zumud-cevep-tives-vixir" xeeek
keeex ref "roled-tymyz-hizoc-gehaf-fazom-fizyd-forar-pozyh-bibad-zicah-vigiv-kameh-nyvan-loteg-lusil-pynod-kexyr" xeeek
keeex ref "rehev-cycyz-deboc-cukoz-geliv-vyked-lysys-buzyr-fufif-bycyk-gafic-puhef-rybyl-puhed-hinic-toziz-fexer" xeeek
keeex ref "rorop-kelys-zanyz-gyfig-vuzig-cisit-malur-zamav-tinus-rapur-nebin-zosit-parac-locig-lypud-kytil-naxyr" xeeek

