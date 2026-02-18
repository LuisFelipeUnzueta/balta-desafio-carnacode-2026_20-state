using System;
using DesignPatternChallenge.Models;

namespace DesignPatternChallenge.States
{
    public class DeliveredState : IOrderState
    {
        public void ProcessPayment(Order order)
        {
            Console.WriteLine($"\n[{order.OrderId}] Proces  sing payment...");
            Console.WriteLine($"❌ Cannot process payment. Order is already Delivered");
        }

        public void Ship(Order order, string trackingCode)
        {
            Console.WriteLine($"\n[{order.OrderId}] Trying to ship order...");
            Console.WriteLine($"❌ Order is already Delivered!");
        }

        public void Deliver(Order order)
        {
            Console.WriteLine($"\n[{order.OrderId}] Registering delivery...");
            Console.WriteLine($"❌ Order is already Delivered!");
        }

        public void Cancel(Order order)
        {
            Console.WriteLine($"\n[{order.OrderId}] Trying to cancel order...");
            Console.WriteLine($"❌ Order is already Delivered. Request return if necessary.");
        }

        public void RequestReturn(Order order)
        {
            Console.WriteLine($"\n[{order.OrderId}] Requesting return...");

            var daysSinceDelivery = (DateTime.Now - order.DeliveredDate!.Value).Days;
            if (daysSinceDelivery <= 7)
            {
                Console.WriteLine($"✅ Return approved! Within 7 days.");
                Console.WriteLine($"   Refund: R$ {order.TotalAmount:N2}");
                order.TransitionTo(new ReturnedState());
            }
            else
            {
                Console.WriteLine($"❌ Return deadline expired ({daysSinceDelivery} days)");
            }
        }

        public override string ToString() => "Delivered";
    }
}
