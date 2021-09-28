using Microsoft.EntityFrameworkCore;
using RestauranteSaborDoBrasil.Domain.Core.Models;
using RestauranteSaborDoBrasil.Domain.Interfaces.Repositories.Base;
using RestauranteSaborDoBrasil.Infra.Data.Context;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace RestauranteSaborDoBrasil.Infra.Data.Repositories.Base
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity>, IDisposable where TEntity : Entity
    {
        protected DbSet<TEntity> ReadingDbSet { get; }
        protected DbSet<TEntity> WritingDbSet { get; }
        protected ReadingDbContext ReadingDb { get; }
        protected WritingDbContext WritingDb { get; }

        public BaseRepository(ReadingDbContext readingDbContext, WritingDbContext writingDbContext)
        {
            ReadingDb = readingDbContext;
            WritingDb = writingDbContext;
            ReadingDbSet = ReadingDb.Set<TEntity>();
            WritingDbSet = WritingDb.Set<TEntity>();
        }

        public virtual IQueryable<TEntity> GetAllQuery
        {
            get
            {
                return ReadingDbSet;
            }
        }

        public virtual IQueryable<TEntity> GetAllQueryNoTracking
        {
            get
            {
                return ReadingDbSet.AsNoTracking();
            }
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await WritingDbSet.AddAsync(entity);
            return entity;
        }
 
        public TEntity Update(TEntity entity)
        {
            WritingDbSet.Update(entity);
            return entity;
        }

        public void Delete(TEntity entity)
        {
            WritingDbSet.Remove(entity);
        }
 
        public async Task<TEntity> GetByIdAsync(Guid id)
            => await ReadingDbSet.FirstOrDefaultAsync(x => x.Id == id);

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            ReadingDb.Dispose();
            WritingDb.Dispose();
        }
    }
}