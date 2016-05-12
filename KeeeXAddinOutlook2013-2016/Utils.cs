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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeeeXAddinOutlook2013_2016
{
    class Utils
    {
        static public List<string> GetSMTPAddressForRecipients(Microsoft.Office.Interop.Outlook.MailItem mail)
        {
            List<string> emailAddresses = new List<string>();
            const string PR_SMTP_ADDRESS =
                "http://schemas.microsoft.com/mapi/proptag/0x39FE001E";
            Microsoft.Office.Interop.Outlook.Recipients recips = mail.Recipients;

            foreach (Microsoft.Office.Interop.Outlook.Recipient recip in recips)
            {
                Microsoft.Office.Interop.Outlook.PropertyAccessor pa = recip.PropertyAccessor;
                string smtpAddress =
                    pa.GetProperty(PR_SMTP_ADDRESS).ToString();
                emailAddresses.Add(smtpAddress);
            }
            return emailAddresses;
        }
    }
}

keeex self xetoz-mutur-kopef-zysag-lubov-citum-lydel-hotyt-tapat-zozuf-vacas-gufyf-valym-zytuv-faton-sosab-laxux , {main} xeeek
keeex self 18yZdD45K6rFLWBBxkCE3AuSmqcEqsasL9VMZXH , {alg:sha224,enc:b58,recursive:1} xeeek
keeex name "Utils.cs" , {main} xeeek
keeex prop "kx.author", "rerom-tumit-fucuz-vicur-tiluc-hotec-vuses-cafoz-cazyr-nitaf-vuhyf-dunal-fygob-levom-vevor-korap-loxyr" xeeek
keeex ref "ruvog-lalyc-pyhos-tetun-lyten-furym-zymec-benot-buhit-sivad-cedot-hogak-zapig-filag-lytav-kyhef-hyxyr" , {mine} xeeek
keeex signer rerom-cityz-bivyc-ralav-bumon-mudyh-hocyr-pikyv-sysyz-cunat-gesiz-lipig-cozof-harif-sapor-gacaf-nixer xeeek
keeex prop "kx.time", "Thu, 12 May 2016 14:09:13 GMT" xeeek
keeex prop "kx.pattern", "%f" xeeek
keeex prop "kx.folder", "KeeeXAddinOutlook2013-2016" xeeek
keeex ref "rezop-peced-terip-vivap-debal-mutyz-pahan-motod-pavan-vynuc-keboh-kofav-mupek-dycur-benyh-vyduk-kyxur" xeeek
keeex ref "rozip-vovis-cocuh-putyv-vufad-zuruh-benen-ketop-zezyt-zetug-hacel-coher-vedyk-zumud-cevep-tives-vixir" xeeek
keeex ref "roled-tymyz-hizoc-gehaf-fazom-fizyd-forar-pozyh-bibad-zicah-vigiv-kameh-nyvan-loteg-lusil-pynod-kexyr" xeeek
keeex ref "rehev-cycyz-deboc-cukoz-geliv-vyked-lysys-buzyr-fufif-bycyk-gafic-puhef-rybyl-puhed-hinic-toziz-fexer" xeeek
keeex ref "rorop-kelys-zanyz-gyfig-vuzig-cisit-malur-zamav-tinus-rapur-nebin-zosit-parac-locig-lypud-kytil-naxyr" xeeek

