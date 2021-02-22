using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentProject
{
    public class StringBuilder
    {
        const string url = "https://webapi.mishloha.co.il/api/orders/getPaymentLink";
        const string paymentType = "11";
        const string restID = "617055";
        const string uniqueID = "sn6exm";
        const string uuid = "cd54fdae-3f33-4927-86fd-addecf3b320a";
        const string apiKey = "564AF609-EE87-47D3-9743-119C959AD463";
        const string culture = "culture=he_IL";
        const string sessionID = "cd0a9ab5-43d4-45f9-82fa-ef644e7974c4";
        const string sessionID2 = "sessionID=cd0a9ab5-43d4-45f9-82fa-ef644e7974c4";
        public static Uri Builder(string orderIdentifier, float sum)
        {
            var param = new Dictionary<string, string>()
            {
                { "orderIdentifier", orderIdentifier },
                { "paymentType", paymentType },
                {"sum",sum.ToString() },
                {"restID",restID },
                {"sessionID",sessionID},
                {"uniqueID",uniqueID},
                {"uuid",uuid},
                {"apiKey",apiKey }
            };

            var newUrl = new Uri(QueryHelpers.AddQueryString(url, param));
            var addSessionIDToQuery = "&"+sessionID2 + "&";
            var addCultureToQuery = culture;
            Uri completeUrl = new Uri( newUrl + addSessionIDToQuery + addCultureToQuery);
            return completeUrl;
        }

        //var sb = new System.Text.StringBuilder();

        //sb.Append("a=" + HttpUtility.UrlEncode("TheValueOfA") + "&");
        //sb.Append("b=" + HttpUtility.UrlEncode("TheValueOfB") + "&");
        //sb.Append("c=" + HttpUtility.UrlEncode("TheValueOfC") + "&");
        //sb.Append("d=" + HttpUtility.UrlEncode("TheValueOfD") + "&");

        //sb.Remove(sb.Length - 1, 1); // Remove the final '&'

        //string result = sb.ToString();
    }
}
