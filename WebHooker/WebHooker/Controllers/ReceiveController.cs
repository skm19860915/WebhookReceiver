using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WebHooker.Models;
using WebHooker.ViewModel;

namespace WebHooker.Controllers
{
    public class ReceiveController : ApiController
    {
        DataRepository _repo = null;
        public ReceiveController()
        {
            _repo = new DataRepository();
        }
        [HttpPost]
        public RespDataModel Post(ReqDataModel data)
        {
            var secret = data.credentials.client_secret;
            var id = data.credentials.client_id;
            var url = data.verify_url;
            var callback = data.callback_data;

            var received_data = new ReqDataViewModel()
            {
                Secret = secret,
                Id = id,
                Url = url,
                Callback = callback
            };

            var success = _repo.SaveRegistrationDataDriven(received_data);
            var current_date = DateTime.UtcNow;
            if (success)
            {
                var resp = new RespDataModel()
                {
                    callback_result = "200",
                    message = "SUCCESS",
                    time = current_date.ToString("yyyy-MM-dd'T'HH:mm:ss.fffK", CultureInfo.InvariantCulture)
                };
                return resp;
            }
            return new RespDataModel()
            {
                callback_result = "404",
                message = "FAILED",
                time = current_date.ToString("yyyy-MM-dd'T'HH:mm:ss.fffK", CultureInfo.InvariantCulture)
            };
        }
    }
}
