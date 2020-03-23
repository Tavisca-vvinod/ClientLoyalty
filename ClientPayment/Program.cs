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
            PaymentInterface.BusinessComponents.AuthorizeCreditCardResponse response = (client.AuthorizeCreditCardAsync(new PaymentInterface.BusinessComponents.AuthorizeCreditCardRequest(), "")).Result;
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
                },
                Currency = "USD",
                AssociatedOrderDetails = new PaymentInterface.AssociatedOrderDetails()
                {
                    RegionDetails= new PaymentInterface.RegionDetails()
                    {
                        CountryCode="",
                        StateCode=""
                    }
                }
            };
        }
    }
}
