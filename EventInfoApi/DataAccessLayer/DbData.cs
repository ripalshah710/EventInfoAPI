using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using EventInfoApi.Helper;

namespace EventInfoApi.DataAccessLayer
{
    public class DbData
    {
        public string GetEventData(int eventId)
        {
            JsonSerializer jsonSerializer = new JsonSerializer();
            DataSet ds = new DataSet();            
            SqlCommand cmd = new SqlCommand("[p.objectModel.Event.LoadAll]", DbConnection.GetInstance);
            cmd.CommandType = CommandType.StoredProcedure;         
            cmd.Parameters.AddWithValue("@event_id", eventId);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            sqlDataAdapter.Fill(ds);
           return jsonSerializer.ConvertToJson(ds);
        }
    }
}
