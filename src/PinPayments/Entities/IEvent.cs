using System;

namespace PinPayments.Entities
{
    public interface IEvent
    {
        public string Token { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}