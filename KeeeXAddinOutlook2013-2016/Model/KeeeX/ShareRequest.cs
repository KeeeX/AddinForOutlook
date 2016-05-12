using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeeeXAddinOutlook2013_2016.Model.KeeeX
{
    class ShareRequest
    {
        public string idx { get; set; }
        public string hash { get; set; }
        public string state { get; set; }
        public string[] participants { get; set; }
        public string[] recipients { get; set; }
        public string[] shared { get; set; }
        public string link { get; set; }
        public string docType { get; set; }

        public ShareRequest(string idx, string hash, string state, string[] participants, string[] recipients, string[] shared, string link, string docType)
        {
            this.idx = idx;
            this.hash = hash;
            this.state = state;
            this.participants = participants;
            this.recipients = recipients;
            this.shared = shared;
            this.link = link;
            this.docType = docType;
        }

        public ShareRequest(string idx, string hash, List<Contact> recipientsList)
        {
            this.idx = idx;
            this.hash = hash;
            this.state = null;
            this.participants = null;
            this.recipients = new string[recipientsList.Count];
            for (int i = 0; i < recipientsList.Count; i++)
                this.recipients[i] = recipientsList.ElementAt(i).profileIdx;
            SharedList list = LocalApi.getShared(idx);
            if (list != null && list.shared != null)
                this.shared = list.shared ;
            else
                this.shared = null;
            this.link = null;
            this.docType = null;
        }
    }
}
