using System;
using DesignPatternChallenge.States;

namespace DesignPatternChallenge.Models
{
    /// <summary>
    /// The Context class represents an Order. 
    /// It maintains a reference to an instance of a State subclass, which represents the current state of the Order.
    /// </summary>
    public class Order
    {
        private IOrderState _state;

        public string OrderId { get; set; }
        public decimal TotalAmount { get; set; }
        public string? TrackingCode { get; set; }
        public DateTime? ShippedDate { get; set; }
        public DateTime? DeliveredDate { get; set; }

        public Order(string orderId, decimal totalAmount)
        {
            OrderId = orderId;
            TotalAmount = totalAmount;
            // Initial state is Pending
            _state = new PendingState();
            Console.WriteLine($"\n=== Order {OrderId} created ===");
            Console.WriteLine($"Initial status: {_state}");
        }

        /// <summary>
        /// Allows changing the state object at runtime.
        /// </summary>
        /// <param name="state">The new state.</param>
        public void TransitionTo(IOrderState state)
        {
            _state = state;
            Console.WriteLine($"Status: {_state}");
        }

        public void ProcessPayment()
        {
            _state.ProcessPayment(this);
        }

        public void Ship(string trackingCode)
        {
            _state.Ship(this, trackingCode);
        }

        public void Deliver()
        {
            _state.Deliver(this);
        }

        public void Cancel()
        {
            _state.Cancel(this);
        }

        public void RequestReturn()
        {
            _state.RequestReturn(this);
        }
    }
}
