using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentProject
{
    public class PaymentResponse
    {
        public Payment payment { get; set; }
        public Response response { get; set; }

        public static PaymentResponse SplitJsonStringIntoClasses(string jsonString)
        {
            var result = JsonConvert.DeserializeObject<PaymentResponse>(jsonString);

            return result;
        }
    }

    
}
