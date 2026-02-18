using System;
using DesignPatternChallenge.Models;

namespace DesignPatternChallenge.States
{
    public class ReturnedState : IOrderState
    {
        public void ProcessPayment(Order order)
        {
            Console.WriteLine($"\n[{order.OrderId}] Processing payment...");
            Console.WriteLine($"❌ Invalid operation for Returned state");
        }

        public void Ship(Order order, string trackingCode)
        {
            Console.WriteLine($"\n[{order.OrderId}] Trying to ship order...");
            Console.WriteLine($"❌ Invalid operation for Returned state");
        }

        public void Deliver(Order order)
        {
            Console.WriteLine($"\n[{order.OrderId}] Registering delivery...");
            Console.WriteLine($"❌ Invalid operation for Returned state");
        }

        public void Cancel(Order order)
        {
            Console.WriteLine($"\n[{order.OrderId}] Trying to cancel order...");
            Console.WriteLine($"❌ Invalid operation for Returned state");
        }

        public void RequestReturn(Order order)
        {
            Console.WriteLine($"\n[{order.OrderId}] Requesting return...");
            Console.WriteLine($"❌ Return already processed!");
        }

        public override string ToString() => "Returned";
    }
}
