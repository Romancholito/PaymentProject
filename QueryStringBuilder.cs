using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentProject
{
    class QueryStringBuilder
    {
        private readonly List<KeyValuePair<string, object>> _list;

        public QueryStringBuilder()
        {
            _list = new List<KeyValuePair<string, object>>();
        }

        public void Add(string name, object value)
        {
            _list.Add(new KeyValuePair<string, object>(name, value));
        }

        public override string ToString()
        {
            return String.Join("&", _list.Select(kvp => String.Concat(Uri.EscapeDataString(kvp.Key), "=", Uri.EscapeDataString(kvp.Value.ToString()))));
        }
        public static void Qsb()
        {
            var actual = new QueryStringBuilder();
            actual.Add("foo", 123);
            actual.Add("bar", "val31");
            actual.Add("bar", "val32");

            actual.ToString(); // "foo=123&bar=val31&bar=val32&a%2bb=c%2bd"
        }
    }
}

