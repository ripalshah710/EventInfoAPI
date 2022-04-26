using Newtonsoft.Json;
using EventInfoApi.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace EventInfoApi.Helper
{
    public class JsonSerializer
    {
        public  string ConvertToJson(DataSet dataSet)
        {
            var eventBasicDetails = CommonMethod.ConvertToList<EventBasicDetails>(dataSet.Tables[0]);
            var eventAudiences = CommonMethod.ConvertToList<EventAudience>(dataSet.Tables[1]);
            var eventSubjects = CommonMethod.ConvertToList<EventSubject>(dataSet.Tables[2]);
            EventInfo eventInfo = new EventInfo();
            eventInfo.basicDetails = eventBasicDetails.FirstOrDefault();
            eventInfo.eventAudiences = eventAudiences;
            eventInfo.eventSubjects = eventSubjects;
            var data= JsonConvert.SerializeObject(eventInfo);
            return data;

        }
        public static class CommonMethod
        {
            public static List<T> ConvertToList<T>(DataTable dt)
            {
                var columnNames = dt.Columns.Cast<DataColumn>().Select(c => c.ColumnName.ToLower()).ToList();
                var properties = typeof(T).GetProperties();
                return dt.AsEnumerable().Select(row => {
                    var objT = Activator.CreateInstance<T>();
                    foreach (var pro in properties)
                    {
                        if (columnNames.Contains(pro.Name.ToLower()))
                        {
                            try
                            {
                                pro.SetValue(objT, row[pro.Name]);
                            }
                            catch (Exception) { }
                        }
                    }
                    return objT;
                }).ToList();
            }
        }
    }
}
