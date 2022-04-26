using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventInfoApi.Helper
{
    public class Util
    {
        public static IConfiguration configuration;
       
        public static string GetConncetionStringValue(string key)
        {
            if (!string.IsNullOrEmpty(key))
            {
                return configuration.GetSection("ConnectionStrings")[key];

            }//if
            return string.Empty;
        }//GetConncetionStringValue
        public static string GetAppSetting(string key)
        {
            if (!string.IsNullOrEmpty(key))
            {
                string Value = configuration.GetSection("AppSettings")[key];
                return Value;
            }//if
            return string.Empty;
        }

    }
}
