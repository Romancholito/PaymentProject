using Microsoft.AspNetCore.WebUtilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PaymentProject
{
    class PaymentLink 
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
        public static Uri PaymentUrlBuilder(string orderIdentifier, float sum)
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
            var addSessionIDToQuery = "&" + sessionID2 + "&";
            var addCultureToQuery = culture;
            Uri completeUrl = new Uri(newUrl + addSessionIDToQuery + addCultureToQuery);
            return completeUrl;
        }

        public static string HttpGet(string uri)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }

        public static string  InsertCreditCardDetails(PaymentResponse paymentRes)
        {
            IWebDriver driver = new ChromeDriver();
            var UrlPaymentForm = paymentRes.payment.url;
            driver.Navigate().GoToUrl(UrlPaymentForm);
            IWebElement cardNumber = driver.FindElement(By.Name("cardNumber"));
            cardNumber.SendKeys("5105105105105100");
            Thread.Sleep(3 * 1000);
            IWebElement cardExpDate = driver.FindElement(By.Name("expDate"));
            cardExpDate.SendKeys("06/26");
            Thread.Sleep(3 * 1000);
            IWebElement cardCvvNumber = driver.FindElement(By.Id("cvv"));
            cardCvvNumber.SendKeys("123");
            Thread.Sleep(3 * 1000);
            IWebElement cardPersonalIdNumber = driver.FindElement(By.Id("personalId"));
            cardPersonalIdNumber.SendKeys("300055555");
            Thread.Sleep(3 * 1000);
            IWebElement creditCardForm = driver.FindElement(By.Id("creditForm"));
            creditCardForm.Submit();

            var responseFromRedirectPage = driver.Url;
            return responseFromRedirectPage;
        }

        public static string CheckFormSuccess(string url)
        {
            if (url.Contains("success"))
            {
                return"Form ended seccessfuly!";
            }
            else
            {
                return "Payment Form aborted!";
            }
        }

        public static string CheckFormFailure(string url)
        {
            if (url.Contains("failure"))
            {
                return "Form ended with a fail process!";
            }
            else
            {
                return "Payment Form ended with a problem!";
            }
        }
    }
}
