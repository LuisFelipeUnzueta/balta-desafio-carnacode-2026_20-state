using System;
using DesignPatternChallenge.Models;

namespace DesignPatternChallenge.States
{
    public class PendingState : IOrderState
    {
        public void ProcessPayment(Order order)
        {
            Console.WriteLine($"\n[{order.OrderId}] Processing payment...");
            Console.WriteLine($"✅ Payment confirmed! Total: R$ {order.TotalAmount:N2}");
            order.TransitionTo(new PaidState());
        }

        public void Ship(Order order, string trackingCode)
        {
            Console.WriteLine($"\n[{order.OrderId}] Trying to ship order...");
            Console.WriteLine($"❌ Order is not Paid!");
        }

        public void Deliver(Order order)
        {
            Console.WriteLine($"\n[{order.OrderId}] Registering delivery...");
            Console.WriteLine($"❌ Order is not Shipped!");
        }

        public void Cancel(Order order)
        {
            Console.WriteLine($"\n[{order.OrderId}] Trying to cancel order...");
            Console.WriteLine($"✅ Order cancelled. No refund processed.");
            order.TransitionTo(new CancelledState());
        }

        public void RequestReturn(Order order)
        {
            Console.WriteLine($"\n[{order.OrderId}] Requesting return...");
            Console.WriteLine($"❌ Order is not Delivered. Use cancel process.");
        }

        public override string ToString() => "Pending";
    }
}
