using MediatR;
using System;

namespace RestauranteSaborDoBrasil.Domain.Core.Messages
{
    public abstract class EventRequest : RequestBase, INotification
    {
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}
