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
    }
}
