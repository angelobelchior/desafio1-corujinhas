using FluentValidation.Results;
using MediatR;
using System;

namespace RestauranteSaborDoBrasil.Domain.Core.Messages
{
    public abstract class CommandRequest<TResponse> : RequestBase, IRequest<TResponse>
    {
        public ValidationResult? ValidationResult { get; set; }

        public virtual bool IsValid()
        {
            throw new NotImplementedException();
        }
    }
}
