using System;
using DesignPatternChallenge.Models;

namespace DesignPatternChallenge.States
{
    public class PaidState : IOrderState
    {
        public void ProcessPayment(Order order)
        {
            Console.WriteLine($"\n[{order.OrderId}] Processing payment...");
            Console.WriteLine($"❌ Order is already Paid!");
        }

        public void Ship(Order order, string trackingCode)
        {
            Console.WriteLine($"\n[{order.OrderId}] Trying to ship order...");
            order.TrackingCode = trackingCode;
            order.ShippedDate = DateTime.Now;
            Console.WriteLine($"✅ Order shipped!");
            Console.WriteLine($"   Tracking code: {order.TrackingCode}");
            order.TransitionTo(new ShippedState());
        }

        public void Deliver(Order order)
        {
            Console.WriteLine($"\n[{order.OrderId}] Registering delivery...");
            Console.WriteLine($"❌ Order is not Shipped!");
        }

        public void Cancel(Order order)
        {
            Console.WriteLine($"\n[{order.OrderId}] Trying to cancel order...");
            Console.WriteLine($"✅ Order cancelled. Refund will be processed.");
            Console.WriteLine($"   Value: R$ {order.TotalAmount:N2}");
            order.TransitionTo(new CancelledState());
        }

        public void RequestReturn(Order order)
        {
            Console.WriteLine($"\n[{order.OrderId}] Requesting return...");
            Console.WriteLine($"❌ Order is not Delivered. Use cancel process.");
        }

        public override string ToString() => "Paid";
    }
}
