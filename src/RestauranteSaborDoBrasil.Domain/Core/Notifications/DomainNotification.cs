using RestauranteSaborDoBrasil.Domain.Core.Interfaces;
using System;

namespace RestauranteSaborDoBrasil.Domain.Core.Notifications
{
    public class DomainNotification : IDomainEvent
    {
        public string Key { get; }
        public string Value { get; }
        public string Type { get; }
        public DateTime OccurrenceDate { get; }
        public int Version { get; }

        public DomainNotification(string key, string value, string type)
        {
            Version = 1;
            Key = key;
            Value = value;
            OccurrenceDate = DateTime.UtcNow;
            Type = type;
        }

        public static DomainNotification Error(string key, string value)
        {
            return new DomainNotification(key, value, "Error");
        }

        public static DomainNotification ModelValidation(string key, string value)
        {
            return new DomainNotification(key, value, "ModelValidation");
        }
    }
}