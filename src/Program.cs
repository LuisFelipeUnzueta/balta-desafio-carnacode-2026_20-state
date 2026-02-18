using System;
using DesignPatternChallenge.Models;

namespace DesignPatternChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Order Management System (State Pattern) ===");

            var order1 = new Order("ORD-001", 250.00m);
            // Initial state already printed in constructor

            // Normal flow
            order1.ProcessPayment();
            order1.Ship("BR123456789");
            order1.Deliver();
            order1.RequestReturn();

            Console.WriteLine("\n" + new string('=', 60));

            var order2 = new Order("ORD-002", 150.00m);

            // Invalid attempts
            order2.Ship("BR987654321");  // Not paid yet
            order2.ProcessPayment();
            order2.ProcessPayment();     // Already paid
            order2.Cancel();             // Cancel after payment

            Console.WriteLine("\n=== SOLUTIONS WITH STATE PATTERN ===");
            Console.WriteLine("✓ Specific behavior of each state encapsulated in separate classes");
            Console.WriteLine("✓ Ease of adding new states (just create new IOrderState class)");
            Console.WriteLine("✓ State transitions are explicit (TransitionTo)");
            Console.WriteLine("✓ Giant conditionals eliminated from Order class");
            Console.WriteLine("✓ Adheres to Open/Closed Principle");
            Console.WriteLine("✓ More modular and easier to test in isolation");
            Console.WriteLine("\n=== End of State Pattern Challenge ===");

            //"\n=== Answers for Reflection ==="
            //"1. How to encapsulate specific behavior? Creating concrete state classes."
            //"2. How to facilitate adding new states? Implementing the IOrderState interface and defining transitions."
            //"3. How to make transitions explicit? Through the TransitionTo method in the context (Order)."
            //"4. How to eliminate conditionals? Delegating execution to the current state object."
        }
    }
}