using System;
using DesignPatternChallenge.Models;

namespace DesignPatternChallenge.States
{
    public class ShippedState : IOrderState
    {
        public void ProcessPayment(Order order)
        {
            Console.WriteLine($"\n[{order.OrderId}] Processing payment...");
            Console.WriteLine($"❌ Cannot process payment. Order is already Shipped");
        }

        public void Ship(Order order, string trackingCode)
        {
            Console.WriteLine($"\n[{order.OrderId}] Trying to ship order...");
            Console.WriteLine($"❌ Order is already Shipped");
        }

        public void Deliver(Order order)
        {
            Console.WriteLine($"\n[{order.OrderId}] Registering delivery...");
            order.DeliveredDate = DateTime.Now;
            Console.WriteLine($"✅ Order delivered successfully!");
            Console.WriteLine($"   Date: {order.DeliveredDate:dd/MM/yyyy HH:mm}");
            order.TransitionTo(new DeliveredState());
        }

        public void Cancel(Order order)
        {
            Console.WriteLine($"\n[{order.OrderId}] Trying to cancel order...");
            Console.WriteLine($"❌ Order is already Shipped. Use return process.");
        }

        public void RequestReturn(Order order)
        {
            Console.WriteLine($"\n[{order.OrderId}] Requesting return...");
            Console.WriteLine($"❌ Wait for delivery to request return.");
        }

        public override string ToString() => "Shipped";
    }
}
