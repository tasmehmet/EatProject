using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using HepsiYemekApi.Common.ResponsesModel;
using HepsiYemekApi.Entitiy;

namespace HepsiYemekApi.Repository.Abstract
{
    public interface IRepository<T, TKey> where T : class, IDocument, new() where TKey : IEquatable<TKey>
    {
        IQueryable<T> Get(Expression<Func<T, bool>> predicate = null);
         
        Task<T> GetAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);
        
        Task<T> GetByIdAsync(TKey id, CancellationToken cancellationToken = default);
        
        Task<int> GetCountAsync(Expression<Func<T, bool>> predicate,
            CancellationToken cancellationToken = default);
        
        Task<IResponse> AddAsync(T model, CancellationToken cancellationToken = default);
        
        Task<IResponse> UpdateAsync(TKey id, T entity);
        
        Task<IResponse> DeleteAsync(TKey id);
    }
}