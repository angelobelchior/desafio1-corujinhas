using System;

namespace RestauranteSaborDoBrasil.Domain.Core.Interfaces
{
    public interface IDomainEvent
    {
        int Version { get; }

        DateTime OccurrenceDate { get; }
    }
}
