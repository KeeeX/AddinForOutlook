using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeeeXAddinOutlook2013_2016.Model.KeeeX
{
    class KeeeX_File_Treated
    {
        public string path { get; set; }
        public Topic topic { get; set; }

        public class Topic {
            public string idx { get; set; }
            public string name { get; set; }
            public string description { get; set; }
            public string creationDate { get; set; }
            public string lastModify { get; set; }
            public string[] references { get; set; }
        }
    }
}
