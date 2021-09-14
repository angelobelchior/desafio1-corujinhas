using FluentValidation.Results;
using MediatR;
using System;
using System.Text.Json.Serialization;

namespace RestauranteSaborDoBrasil.Domain.Core.Messages
{
    public abstract class CommandRequest<TResponse> : RequestBase, IRequest<TResponse>
    {
        [JsonIgnore]
        public ValidationResult? ValidationResult { get; set; }

        public virtual bool IsValid()
        {
            throw new NotImplementedException();
        }
    }
}
