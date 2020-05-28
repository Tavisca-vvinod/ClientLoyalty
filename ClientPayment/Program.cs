using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ClientPayment
{
    class Program
    {
        static void Main(string[] args)
        {
            PaymentInterfaceClient client = new PaymentInterfaceClient();
            ((IContextChannel)client.InnerChannel).OperationTimeout = new TimeSpan(0, 30, 0);
            //PaymentInterface.BusinessComponents.AuthorizeCreditCardResponse response = (client.AuthorizeCreditCardAsync(GetAuthorizeCreditCardRequest(), "")).Result;
            //int headerId = (client.GetPaymentHeaderIDAsync(GetPaymentHeaderIdRequest())).Result; RESPONSE = 85004
            var response = (client.ReauthorizeFinalPaymentByProfileIdAsync(GetReauthorizeFinalPaymentByProfileIdRequest())).Result;
            //var response = (client.ReauthorizeCreditCardAsync(GetReAuthFinalPaymentRequest())).Result;
        }
        public static PaymentInterface.BusinessComponents.AuthorizeCreditCardRequest GetAuthorizeCreditCardRequest()
        {
            return new PaymentInterface.BusinessComponents.AuthorizeCreditCardRequest()
            {
                TransitCode = "475C34B0-DD32-45EC-A0E7-00000A0844F9",
                AgentId = "Online",
                Amount = 100,
                CreditCard = new PaymentInterface.CreditCard()
                {
                    CreditCardType = PaymentInterface.CreditCard.BankCardType.MasterCard,
                    Locator = "40273226",
                    avsAddress1 = "3132 West Test Ave",
                    avsAddress2 = "",
                    avsCity = "Minneapolis",
                    avsCountry = "US",
                    avsName = "John Doe",
                    avsState = "MN",
                    avsZip = "55566",
                    ccAccountNum = "5555555555554444",
                    ccCardVerifyNum = "132",
                    ccExp = DateTime.Now.AddYears(12)
                }
                //Currency = "USD",
                //AssociatedOrderDetails = new PaymentInterface.AssociatedOrderDetails()
                //{
                //    RegionDetails = new PaymentInterface.RegionDetails()
                //    {
                //        CountryCode = "pk",
                //        StateCode = "ok"
                //    }
                //}
            };
        }
        public static PaymentInterface.BusinessComponents.ReauthorizeFinalPaymentByProfileIdRequest GetReauthorizeFinalPaymentByProfileIdRequest()
        {
            return new PaymentInterface.BusinessComponents.ReauthorizeFinalPaymentByProfileIdRequest()
            {
                AgentId = "TFSTest",
                Amount = 20.30M,
                Locator = "100000",
                Notes = "Testing payment",
                PaymentActionId = 3,
                PaymentHeaderId = 85004,
                ProfileId = "55381204",
                TransitCode = "FDA159B7-403B-427D-9861-03AB795708EF"
            };
        }
        public static PaymentInterface.BusinessComponents.ReauthorizeFinalPaymentByProfileIdRequest MGetReauthorizeFinalPaymentByProfileIdRequest()
        {
            return new PaymentInterface.BusinessComponents.ReauthorizeFinalPaymentByProfileIdRequest()
            {
                AgentId = "ruraut",
                Amount = 100,
                Locator = "11442970",
                Notes = "Testing payment",
                PaymentActionId = 3,
                PaymentHeaderId = 915604,
                ProfileId = "cybc-A1D3D0A9985C6054E05341588E0A104C",
                TransitCode = "56699e21-b4b1-4934-8192-ab748798f660"
            };
        }
        public static PaymentInterface.BusinessComponents.PaymentHeaderIdRequest GetPaymentHeaderIdRequest()
        {
            return new PaymentInterface.BusinessComponents.PaymentHeaderIdRequest()
            {
                AgentId = "TFSTEST",
                Locator = "100000",
                TransitCode = "475C34B0-DD32-45EC-A0E7-00000A0844F9"
            };
        }
        public static PaymentInterface.BusinessComponents.ReAuthFinalPaymentRequest GetReAuthFinalPaymentRequest()
        {
            return new PaymentInterface.BusinessComponents.ReAuthFinalPaymentRequest()
            {
                TransitCode = "7130DEF2-FE12-4BB6-AD2B-00128EBEE690",
                AgentId = "Online",
                Amount = 100,
                Locator= "40273226",
                AuthorizationId= "5852851351556475304009-387074",
                ZipCode="55566",
                CreditCard = new PaymentInterface.CreditCard()
                {
                    CreditCardType = PaymentInterface.CreditCard.BankCardType.MasterCard,
                    Locator = "40273226",
                    avsAddress1 = "3132 West Test Ave",
                    avsAddress2 = "",
                    avsCity = "Minneapolis",
                    avsCountry = "US",
                    avsName = "John Doe",
                    avsState = "MN",
                    avsZip = "55566",
                    ccAccountNum = "5555555555554444",
                    ccCardVerifyNum = "132",
                    ccExp = DateTime.Now.AddYears(12)
                },
                Currency = "USD",
                AssociatedOrderDetails = new PaymentInterface.AssociatedOrderDetails()
                {
                    RegionDetails = new PaymentInterface.RegionDetails()
                    {
                        CountryCode = "pk",
                        StateCode = "ok"
                    }
                }
            };
        }
    }
}
