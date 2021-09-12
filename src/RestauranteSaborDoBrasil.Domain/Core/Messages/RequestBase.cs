using System;

namespace RestauranteSaborDoBrasil.Domain.Core.Messages
{
    public abstract class RequestBase
    {
        public DateTime Timestamp { get; private set; } = DateTime.UtcNow;
    }
}
