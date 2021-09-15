using AutoMapper;
using RestauranteSaborDoBrasil.Application.Events.Base;
using RestauranteSaborDoBrasil.Domain.Core.Interfaces;
using RestauranteSaborDoBrasil.Domain.Core.Notifications;
using RestauranteSaborDoBrasil.Domain.Interfaces.Repositories;
using RestauranteSaborDoBrasil.Domain.Interfaces.Repositories.Base;
using System.Threading;
using System.Threading.Tasks;

namespace RestauranteSaborDoBrasil.Application.Events.LogApp
{
    public class RegisterLogEventHandler : EventHandlerBase<LogEvent>
    {
        private readonly IMapper _mapper;
        private readonly IBaseRepository<Domain.Models.Log> _baseRepository;

        public RegisterLogEventHandler(
            IBaseRepository<Domain.Models.Log> baseRepository,
            IHandler<DomainNotification> notifications, 
            IUnitOfWork unitOfWork) : base(notifications, unitOfWork)
        {
            _baseRepository = baseRepository;
        }

        public override async Task Handle(LogEvent notification, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Domain.Models.Log>(notification);
            
            await _baseRepository.AddAsync(entity);
            await CommitAsync();
        }
    }
}
