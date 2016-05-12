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
