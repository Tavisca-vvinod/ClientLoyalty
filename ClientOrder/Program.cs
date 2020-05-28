using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using ClientOrder.ServiceReference2;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ClientOrder
{
    class Program
    {
        static void Main(string[] args)
        {
            OrderClient client = new OrderClient();
            ((IContextChannel)client.InnerChannel).OperationTimeout = new TimeSpan(0, 30, 0);
            var response = client.ProcessOrderAsync(GetTripFolder());
        }

        public static TripFolder GetTripFolder()
        {
            return new TripFolder()
            {
                Cities = "",
                Pos = new PointOfSale()
                {
                    AdditionalInfo = new System.Collections.Generic.List<StateBag>()
                    {
                        new StateBag()
                        {
                            Name = "TransitCode",
                            Value = "B77494E4-F6F8-408F-B016-000152BCDA18"
                        }
                    }
                },
                Products = new System.Collections.Generic.List<TripProduct>()
                {
                    new HotelTripProduct()
                    {
                        HotelItinerary = new HotelItinerary()
                        {
                            Fare = new HotelFare()
                            {
                                FareRestrictionTypes = new System.Collections.Generic.List<FareRestrictionType>()
                                {
                                    FareRestrictionType.NonRefundableFares
                                },
                                SupplierSideData = new List<StateBag>()
                                {
                                    new StateBag()
                                    {
                                        Name = "PaymentBreakup",
                                        Value = HttpUtility.HtmlDecode(@"&lt;SelectedPaymentOptions&gt;
                                                  &lt;PaymentOption&gt;
                                                    &lt;RuleGroupId&gt;637&lt;/RuleGroupId&gt;
                                                    &lt;RuleGroupType&gt;Purchase&lt;/RuleGroupType&gt;
                                                    &lt;RuleGroupTypeId&gt;7&lt;/RuleGroupTypeId&gt;
                                                    &lt;PointsRedeemed&gt;0.00&lt;/PointsRedeemed&gt;
                                                    &lt;RedemptionCashCost&gt;487.7&lt;/RedemptionCashCost&gt;
                                                    &lt;ProgramCurrencyRequired&gt;0.00&lt;/ProgramCurrencyRequired&gt;
                                                    &lt;ProgramCurrencyLabel&gt;Points&lt;/ProgramCurrencyLabel&gt;
                                                    &lt;UnitPointsPrice&gt;0.00&lt;/UnitPointsPrice&gt;
                                                    &lt;MaxValue&gt;0&lt;/MaxValue&gt;
                                                    &lt;ClientPrice&gt;0&lt;/ClientPrice&gt;
                                                    &lt;RewardQuantity&gt;0&lt;/RewardQuantity&gt;
                                                    &lt;Attributes /&gt;
                                                    &lt;Fees /&gt;
                                                  &lt;/PaymentOption&gt;
                                                &lt;/SelectedPaymentOptions&gt;")
                                    }
                                }
                            },
                            Rooms = new List<Room>()
                            {
                                new Room()
                                {
                                    DisplayRoomRate = new RoomRate()
                                    {
                                        Taxes = new List<Tax>()
                                        {
                                            new Tax()
                                            { 
                                             Amount = 12.55M,
                                             BaseEquivAmount = 12.55M,
                                             BaseEquivCurrency = "USD",
                                             Currency ="USD",
                                             DisplayAmount=12.55M,
                                             DisplayCurrency = "CAD",
                                             UsdEquivAmount=12.55M,
                                             Code ="tax_and_service_fee",
                                             Description  ="tax_and_service_fee"
                                            }
                                        }
                                    }
                                }
                            }                           
                        },
                        PassengerSegments = new System.Collections.Generic.List<PassengerSegment>()
                        {
                            new PassengerSegment()
                            {
                                BookingStatus = TripProductStatus.Purchased
                            }
                        }
                    }
                },
                Passengers = new System.Collections.Generic.List<Passenger>()
                {
                    new Passenger()
                    {
                        FirstName = "Albert",
                        LastName = "Einstein"
                    }
                }
            };
        }
    }
}
