using System;
using System.Collections.Generic;

namespace RestauranteSaborDoBrasil.Domain.Core.Interfaces
{
    public interface IHandler<T> : IDisposable where T : IDomainEvent
    {
        void Handle(T args);
        IEnumerable<T> Notify();
        bool HasNotifications();
        List<T> GetNotifications();
        Dictionary<string, string[]> GetNotificationsByKey();
        string GetNotificationMessages();
        void ClearNotifications();
        void LogInfo(string infoMessage);
        void LogWarning(string warningMessage);
        void LogError(string errorMessage);
        void LogError(Exception ex);
        void LogError(Exception ex, string errorMessage);
        void LogFatal(string errorMessage);
        void LogFatal(Exception ex);
        void LogFatal(Exception ex, string errorMessage);
    }
}
