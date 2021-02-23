using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PaymentProject
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var uri = PaymentLink.PaymentUrlBuilder("f20f96ad-0892-4a8a-94ac-ac0580331ded", 75f);
            string url = uri.ToString();
            var getUrl = PaymentLink.HttpGet(url);



        }

        
    }
}
