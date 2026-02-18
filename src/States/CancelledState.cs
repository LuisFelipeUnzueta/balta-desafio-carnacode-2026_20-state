using System;
using DesignPatternChallenge.Models;

namespace DesignPatternChallenge.States
{
    public class CancelledState : IOrderState
    {
        public void ProcessPayment(Order order)
        {
            Console.WriteLine($"\n[{order.OrderId}] Processing payment...");
            Console.WriteLine($"❌ Order was cancelled. Create new order.");
        }

        public void Ship(Order order, string trackingCode)
        {
            Console.WriteLine($"\n[{order.OrderId}] Trying to ship order...");
            Console.WriteLine($"❌ Cannot ship cancelled order");
        }

        public void Deliver(Order order)
        {
            Console.WriteLine($"\n[{order.OrderId}] Registering delivery...");
            Console.WriteLine($"❌ Cancelled order cannot be delivered");
        }

        public void Cancel(Order order)
        {
            Console.WriteLine($"\n[{order.OrderId}] Trying to cancel order...");
            Console.WriteLine($"❌ Order is already cancelled!");
        }

        public void RequestReturn(Order order)
        {
            Console.WriteLine($"\n[{order.OrderId}] Requesting return...");
            Console.WriteLine($"❌ Cancelled order cannot be returned.");
        }

        public override string ToString() => "Cancelled";
    }
}
