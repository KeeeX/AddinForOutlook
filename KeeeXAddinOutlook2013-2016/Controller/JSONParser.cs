using KeeeXAddinOutlook2013_2016.Model;
using KeeeXAddinOutlook2013_2016.Model.KeeeX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace KeeeXAddinOutlook2013_2016.Controller
{
    class JSONParser
    {
        static public Contact[] jsonToContactArray(string json)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            Contact[] contacts = js.Deserialize<Contact[]>(json);
            return contacts;
        }

        static public KeeeX_File_Treated jsonToKeeeXTreatedFile(string json)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            KeeeX_File_Treated treated = js.Deserialize<KeeeX_File_Treated>(json);
            return treated;
        }

        static public List<Idx> jsonToIdx(string json)
        {
            List<Idx> idxs = new List<Idx>();

            Idx[] temp;
            JavaScriptSerializer js = new JavaScriptSerializer();
            temp = js.Deserialize<Idx[]>(json);

            if(temp != null)
            {
                idxs = new List<Idx>(temp);
            }
            return idxs;
        }

        static public CipherResponse jsonToCipherResponse(string json)
        {
            CipherResponse response;

            JavaScriptSerializer js = new JavaScriptSerializer();
            response = js.Deserialize<CipherResponse>(json);

            return response;
        }

        static public SharedList jsonToSharedList(string json)
        {
            SharedList response;

            JavaScriptSerializer js = new JavaScriptSerializer();
            response = js.Deserialize<SharedList>(json);

            return response;
        }
    }
}
