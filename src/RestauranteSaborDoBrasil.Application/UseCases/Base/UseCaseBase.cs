using MediatR;
using RestauranteSaborDoBrasil.Domain.Core.Interfaces;
using RestauranteSaborDoBrasil.Domain.Core.Messages;
using RestauranteSaborDoBrasil.Domain.Core.Notifications;
using RestauranteSaborDoBrasil.Domain.Interfaces.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace RestauranteSaborDoBrasil.Application.UseCases.Base
{
    public abstract class UseCaseBase<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
        where TRequest : CommandRequest<TResponse>, new()
        where TResponse : ResponseBase, new()
    {
        protected IHandler<DomainNotification> Notifications { get; }
        private readonly IUnitOfWork _unitOfWork;

        protected UseCaseBase(IHandler<DomainNotification> notifications, IUnitOfWork unitOfWork)
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

        public virtual Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
