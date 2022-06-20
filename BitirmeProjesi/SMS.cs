using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace BitirmeProjesi
{
    class SMS
    {

        public static void SendSMS(string Msj)
        {
            string SMSUri = Msj;
            var myWebClient = new WebClient();
            myWebClient.DownloadString(SMSUri);
        }

        

    }
}
