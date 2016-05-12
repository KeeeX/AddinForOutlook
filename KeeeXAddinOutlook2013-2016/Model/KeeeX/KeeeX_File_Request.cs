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

namespace KeeeXAddinOutlook2013_2016.Model.KeeeX
{
    class KeeeX_File_Request
    {
        public string path { get; set; }
        public string[] refs { get; set; }
        public string[] prevs { get; set; }
        public string description { get; set; }
        public Options opt { get; set; }

        public class Options {
            public Boolean timestamp { get; set; }
            public Boolean digitalSignature { get; set; }
            public Options(Boolean timestamp, Boolean digitalSignature)
            {
                this.timestamp = timestamp;
                this.digitalSignature = digitalSignature;
            }
        }

    public KeeeX_File_Request(string path, string[] refs, string[] prevs, string desc, Boolean timestamp, Boolean digitalSignature)
        {
            this.path = path;
            if(refs != null && refs.Length > 0)
            {
                this.refs = new string[refs.Length + 1];
                for(int i=1; i<this.refs.Length; i++)
                {
                    this.refs[i] = refs[i - 1];
                }
            }
            else
            {
                this.refs = new String[1];
                
            }
            this.refs[0] = "xiset-pefuv-tuvym-somer-pyvyv-dutil-vinil-lobez-docok-vanic-mebum-tonog-senym-kahoh-sygec-tyras-vuxox";

            this.prevs = prevs;
            this.description = desc;
            this.opt = new Options(timestamp, digitalSignature);
        }
    }
}

keeex self xilag-tifev-daroh-gakyf-midoz-kaseb-zehif-rymed-gesyv-bakev-kunim-mofec-kuvit-cybyc-remub-pahud-coxox , {main} xeeek
keeex self 11YZcrJbcAcJJPgd68kDB9dJjVK8q372BU8JhNp , {alg:sha224,enc:b58,recursive:1} xeeek
keeex name "KeeeX_File_Request.cs" , {main} xeeek
keeex prop "kx.author", "rerom-tumit-fucuz-vicur-tiluc-hotec-vuses-cafoz-cazyr-nitaf-vuhyf-dunal-fygob-levom-vevor-korap-loxyr" xeeek
keeex ref "ruvog-lalyc-pyhos-tetun-lyten-furym-zymec-benot-buhit-sivad-cedot-hogak-zapig-filag-lytav-kyhef-hyxyr" , {mine} xeeek
keeex signer rerom-cityz-bivyc-ralav-bumon-mudyh-hocyr-pikyv-sysyz-cunat-gesiz-lipig-cozof-harif-sapor-gacaf-nixer xeeek
keeex prop "kx.time", "Thu, 12 May 2016 14:17:13 GMT" xeeek
keeex prop "kx.pattern", "-%f" xeeek
keeex prop "kx.folder", "KeeeX" xeeek
keeex ref "ripaf-fubel-rydar-talef-colod-hocib-cusel-ketag-nynoz-kudoc-veteb-lypor-hyteb-pinus-behov-kefil-maxor" xeeek
keeex ref "rodig-hoteg-tobum-sylul-vabov-lorar-bobiz-kicin-ginym-zynag-kised-vutom-pigur-pivaz-fomob-bamaf-cixar" xeeek
keeex ref "rezop-peced-terip-vivap-debal-mutyz-pahan-motod-pavan-vynuc-keboh-kofav-mupek-dycur-benyh-vyduk-kyxur" xeeek
keeex ref "rozip-vovis-cocuh-putyv-vufad-zuruh-benen-ketop-zezyt-zetug-hacel-coher-vedyk-zumud-cevep-tives-vixir" xeeek
keeex ref "roled-tymyz-hizoc-gehaf-fazom-fizyd-forar-pozyh-bibad-zicah-vigiv-kameh-nyvan-loteg-lusil-pynod-kexyr" xeeek
keeex ref "rehev-cycyz-deboc-cukoz-geliv-vyked-lysys-buzyr-fufif-bycyk-gafic-puhef-rybyl-puhed-hinic-toziz-fexer" xeeek
keeex ref "rorop-kelys-zanyz-gyfig-vuzig-cisit-malur-zamav-tinus-rapur-nebin-zosit-parac-locig-lypud-kytil-naxyr" xeeek

