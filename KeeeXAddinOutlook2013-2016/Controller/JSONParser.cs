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

keeex self xehez-pifid-hyvug-ririm-vykun-bufem-vegug-gumel-pofam-myfip-mubod-hegul-rifar-cymid-bazyt-latyz-bexax , {main} xeeek
keeex self 2134WDAYciDzPfpGzETVda5zUjHwnF6T5rBCoL9 , {alg:sha224,enc:b58,recursive:1} xeeek
keeex name "JSONParser.cs" , {main} xeeek
keeex prop "kx.author", "rerom-tumit-fucuz-vicur-tiluc-hotec-vuses-cafoz-cazyr-nitaf-vuhyf-dunal-fygob-levom-vevor-korap-loxyr" xeeek
keeex ref "ruvog-lalyc-pyhos-tetun-lyten-furym-zymec-benot-buhit-sivad-cedot-hogak-zapig-filag-lytav-kyhef-hyxyr" , {mine} xeeek
keeex signer rerom-cityz-bivyc-ralav-bumon-mudyh-hocyr-pikyv-sysyz-cunat-gesiz-lipig-cozof-harif-sapor-gacaf-nixer xeeek
keeex prop "kx.time", "Thu, 12 May 2016 14:15:42 GMT" xeeek
keeex prop "kx.pattern", "-%f" xeeek
keeex prop "kx.folder", "Controller" xeeek
keeex ref "rekeg-popil-pezis-hiraz-milyd-hasin-bamad-kegor-tugav-pilen-fotud-pumel-nazis-luryt-nurek-nycih-tixur" xeeek
keeex ref "rezop-peced-terip-vivap-debal-mutyz-pahan-motod-pavan-vynuc-keboh-kofav-mupek-dycur-benyh-vyduk-kyxur" xeeek
keeex ref "rozip-vovis-cocuh-putyv-vufad-zuruh-benen-ketop-zezyt-zetug-hacel-coher-vedyk-zumud-cevep-tives-vixir" xeeek
keeex ref "roled-tymyz-hizoc-gehaf-fazom-fizyd-forar-pozyh-bibad-zicah-vigiv-kameh-nyvan-loteg-lusil-pynod-kexyr" xeeek
keeex ref "rehev-cycyz-deboc-cukoz-geliv-vyked-lysys-buzyr-fufif-bycyk-gafic-puhef-rybyl-puhed-hinic-toziz-fexer" xeeek
keeex ref "rorop-kelys-zanyz-gyfig-vuzig-cisit-malur-zamav-tinus-rapur-nebin-zosit-parac-locig-lypud-kytil-naxyr" xeeek

