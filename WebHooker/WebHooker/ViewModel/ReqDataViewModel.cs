using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebHooker.ViewModel
{
    public class ReqDataViewModel
    {
        public string Secret { get; set; }
        public string Id { get; set; }
        public string Url { get; set; }
        public string Callback { get; set; }
    }
}