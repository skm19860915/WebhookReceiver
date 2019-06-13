using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebHooker.Models
{
    public class ReqDataModel
    {
        public CredentialModel credentials { get; set; }
        public string verify_url { get; set; }
        public string callback_data { get; set; }
    }
}