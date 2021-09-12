using MediatR;
using RestauranteSaborDoBrasil.Domain.Core.Interfaces;
using RestauranteSaborDoBrasil.Domain.Core.Messages;
using RestauranteSaborDoBrasil.Domain.Core.Notifications;
using RestauranteSaborDoBrasil.Domain.Interfaces.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace RestauranteSaborDoBrasil.Application.Events.Base
{
    public abstract class EventHandlerBase<TEvent> : INotificationHandler<TEvent>
        where TEvent : EventRequest, new()
    {
        protected IHandler<DomainNotification> Notifications { get; }
        private readonly IUnitOfWork _unitOfWork;
        
        protected EventHandlerBase(IHandler<DomainNotification> notifications, IUnitOfWork unitOfWork)
        {
            Notifications = notifications;
            _unitOfWork = unitOfWork;
        }

        protected bool Commit()
        {
            if (Notifications.HasNotifications())
                return false;

            return _unitOfWork.Commit();
        }

        protected async Task<bool> CommitAsync()
        {
            if (Notifications.HasNotifications())
                return false;

            return await _unitOfWork.CommitAsync();
        }

        public virtual Task Handle(TEvent notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

    }
}
