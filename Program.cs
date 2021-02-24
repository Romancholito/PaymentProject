using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
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
            // success process
            /*
            SuccessProcess();
            */

            // failure process
            FailureProcess();
        }

        public static void SuccessProcess()
        {
            IWebDriver driver = new ChromeDriver();
            var uri = PaymentLink.PaymentUrlBuilder("36e35e47-1fc8-44db-bf57-63efb3f99e91", 90f);
            string url = uri.ToString();
            var jsonString = PaymentLink.HttpGet(url);
            var payres = PaymentResponse.SplitJsonStringIntoClasses(jsonString);

            var responseRedirectUrl = PaymentLink.InsertCreditCardDetails(payres, "30005555", driver);

            var SuccessResponse = PaymentLink.CheckFormSuccess(responseRedirectUrl);

            if (SuccessResponse == true)
            {
                Console.WriteLine("Form ended seccessfuly!");
            }
            else
            {
                Console.WriteLine("Payment Form aborted!");
            }

            // failure process

        }

        public static void FailureProcess()
        {
            IWebDriver driver = new ChromeDriver();
            var uri = PaymentLink.PaymentUrlBuilder("36e35e47-1fc8-44db-bf57-63efb3f99e91", 90f);
            string url = uri.ToString();
            var jsonString = PaymentLink.HttpGet(url);
            var payres = PaymentResponse.SplitJsonStringIntoClasses(jsonString);

            var responseRedirectUrl = PaymentLink.InsertCreditCardDetails(payres, "30005554", driver);

            var failureResponse = PaymentLink.CheckFormFailure(responseRedirectUrl);

            if (failureResponse == true)
            {
                Console.WriteLine("Form ended with a failed process!");
            }
            else
            {
                Console.WriteLine("Payment Form didn't ends properly!");
            }
        }

    }
}
