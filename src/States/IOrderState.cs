using DesignPatternChallenge.Models;

namespace DesignPatternChallenge.States
{
    /// <summary>
    /// The State interface declares the state-specific methods.
    /// These methods should be common to all concrete states.
    /// </summary>
    public interface IOrderState
    {
        void ProcessPayment(Order order);
        void Ship(Order order, string trackingCode);
        void Deliver(Order order);
        void Cancel(Order order);
        void RequestReturn(Order order);
        string ToString();
    }
}
