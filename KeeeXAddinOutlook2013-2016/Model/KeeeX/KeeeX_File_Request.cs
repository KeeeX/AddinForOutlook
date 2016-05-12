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
