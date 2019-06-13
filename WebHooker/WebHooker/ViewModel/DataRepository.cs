using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebHooker.ViewModel
{
    public class DataRepository
    {
        public bool SaveRegistrationDataDriven(ReqDataViewModel data)
        {
            var conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["PowerAppSQLConnection"].ConnectionString;
            var cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "insert into dbo.Credentials (ClientSecret, ClientId, VerifyUrl, CallbackData) " +
                            "values (@ClientSecret, @ClientId, @VerifyUrl, @CallbackData)";
            cmd.Connection = conn;
            cmd.Parameters.AddWithValue("@ClientSecret", data.Secret);
            cmd.Parameters.AddWithValue("@ClientId", data.Id);
            cmd.Parameters.AddWithValue("@VerifyUrl", data.Url);
            cmd.Parameters.AddWithValue("@CallbackData", data.Callback);

            conn.Open();
            int id = cmd.ExecuteNonQuery();
            conn.Close();
            if (id > 0)
                return true;
            else
                return false;
        }
    }
}