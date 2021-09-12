﻿using RestauranteSaborDoBrasil.Domain.Core.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace RestauranteSaborDoBrasil.Domain.Interfaces.Repositories.Base
{
    public interface IBaseRepository<TEntity> : IDisposable where TEntity : Entity
    {
        Task<TEntity> AddAsync(TEntity entity);

        Task<TEntity> GetByIdAsync(Guid id);

        IQueryable<TEntity> GetAllQuery { get; }
        IQueryable<TEntity> GetAllQueryNoTracking { get; }
    }
}