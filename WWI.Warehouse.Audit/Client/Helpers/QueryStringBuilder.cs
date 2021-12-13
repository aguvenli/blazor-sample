using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace WWI.Warehouse.Audit.Client.Helpers
{
    public static class QueryStringBuilder
    {
        public static string GenerateUrlWithQueryString<T>(string baseUrl, T model) where T : class
        {
            var properties = from p in model.GetType().GetProperties()
                             where p.GetValue(model, null) != null
                             select p.Name + "=" + HttpUtility.UrlEncode(p.GetValue(model, null).ToString());
               
            string queryString = String.Join("&", properties.ToArray());
            return baseUrl + "?" + queryString;
        }
    }
}
