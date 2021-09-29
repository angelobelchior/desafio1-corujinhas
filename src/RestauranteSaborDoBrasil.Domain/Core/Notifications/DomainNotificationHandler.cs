using RestauranteSaborDoBrasil.Domain.Core.Interfaces;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System;

namespace RestauranteSaborDoBrasil.Domain.Core.Notifications
{
    public class DomainNotificationHandler : IHandler<DomainNotification>
    {
        private List<DomainNotification> _notifications;
        private readonly ILogger<DomainNotificationHandler> _logger;

        public DomainNotificationHandler(ILogger<DomainNotificationHandler> logger)
        {
            ClearNotifications();
            _logger = logger;
        }

        public void Handle(DomainNotification message)
        {
            if (!_notifications.Any(x => x.Value.Trim().ToUpper().Equals(message.Value.Trim().ToUpper())))
            {
                _notifications.Add(message);
            }
        }

        public virtual List<DomainNotification> GetNotifications()
        {
            return _notifications;
        }

        public virtual string GetNotificationMessages()
            => _notifications.Any() ? _notifications.Select(x => x.Value)?.Aggregate((current, next) => $"{current} : {next}") : string.Empty;

        public virtual IEnumerable<DomainNotification> Notify()
        {
            return GetNotifications();
        }

        public virtual bool HasNotifications()
        {
            return GetNotifications().Any();
        }

        public void ClearNotifications()
        {
            _notifications = new List<DomainNotification>();
        }

        public void LogInfo(string infoMessage)
        {
            _logger.LogInformation(infoMessage);
        }

        public void LogWarning(string warningMessage)
        {
            _logger.LogWarning(warningMessage);
        }

        public void LogError(string errorMessage)
        {
            _logger.LogError(errorMessage);
        }

        public void LogError(Exception ex)
        {
            _logger.LogError(ex, string.Empty);
        }

        public void LogError(Exception ex, string errorMessage)
        {
            _logger.LogError(ex, errorMessage);
        }

        public void LogFatal(string errorMessage)
        {
            _logger.LogCritical(errorMessage);
        }

        public void LogFatal(Exception ex)
        {
            _logger.LogCritical(ex, string.Empty);
        }

        public void LogFatal(Exception ex, string errorMessage)
        {
            _logger.LogCritical(ex, errorMessage);
        }

        public virtual Dictionary<string, string[]> GetNotificationsByKey()
        {
            var keys = _notifications.Select(s => s.Key).Distinct();
            var problemDetails = new Dictionary<string, string[]>();
            foreach (var key in keys)
            {
                problemDetails[key] = _notifications.Where(w => w.Key.Equals(key)).Select(s => s.Value).ToArray();
            }

            return problemDetails;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            _notifications = null;
            ClearNotifications();
        }
    }
}