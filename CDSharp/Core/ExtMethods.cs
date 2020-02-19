using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMW.Models
{
    public static class ExtMethods
    {
        public static string ToQueryString(this NameValueCollection nvc, bool isEscaped)
        {
            StringBuilder sb = new StringBuilder();

            foreach (string key in nvc.Keys)
            {
                if (string.IsNullOrEmpty(key)) continue;

                string[] values = nvc.GetValues(key);
                if (values == null) continue;

                foreach (string value in values)
                {
                    sb.Append(sb.Length == 0 ? "" : "&");

                    if (isEscaped)
                    {
                        sb.AppendFormat("{0}={1}", Uri.EscapeDataString(key), Uri.EscapeDataString(value));
                    }
                    else
                    {
                        sb.AppendFormat("{0}={1}", key, value);
                    }
                    
                    
                }
            }

            return sb.ToString();
        }

        public static String ToBase64String(this String source)
        {
            return Convert.ToBase64String(Encoding.ASCII.GetBytes(source));
        }
    }
}
