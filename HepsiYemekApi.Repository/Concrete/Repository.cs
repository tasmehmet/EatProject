using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using HepsiYemekApi.Common.ResponsesModel;
using HepsiYemekApi.Data;
using HepsiYemekApi.Entitiy;
using HepsiYemekApi.Repository.Abstract;
using MongoDB.Driver;

namespace HepsiYemekApi.Repository.Concrete
{
    public abstract class Repository<T> : IRepository<T,string> where T : Document, new()
    {
        private readonly IMongoDatabase _mongoDatabase;
        private readonly string collectionName = typeof(T).Name.ToLowerInvariant();
        
        protected readonly IMongoCollection<T> _collection;

        protected Repository(IMongoDbConnector mongoDbConnector)
        {
            _mongoDatabase = mongoDbConnector.MongoDatabase;
            _collection = _mongoDatabase.GetCollection<T>(collectionName);
        }

        public virtual IQueryable<T> Get(Expression<Func<T, bool>> predicate = null)
        {
            return _collection.AsQueryable();
        }

        public virtual async Task<T> GetAsync(Expression<Func<T, bool>> predicate,
            CancellationToken cancellationToken = default)
        {
            var data = await _collection.FindAsync(predicate, cancellationToken: cancellationToken);
            var response = await data.SingleOrDefaultAsync(cancellationToken);
            return response;
        }
        
        public virtual async Task<T> GetByIdAsync(string id, CancellationToken cancellationToken = default)
        {
            var predicate = Builders<T>.Filter.Where(x => x.Id.Equals(id));
            var data = await _collection.FindAsync(predicate, cancellationToken: cancellationToken);
            var response = await data.FirstOrDefaultAsync(cancellationToken);
            return response;
        }
        
        public virtual async Task<int> GetCountAsync(Expression<Func<T, bool>> predicate,
            CancellationToken cancellationToken = default)
        {
            return (int) await _collection.CountDocumentsAsync(predicate, cancellationToken: cancellationToken);
        }
        
        public virtual async Task<IResponse> AddAsync(T model, CancellationToken cancellationToken = default)
        {
            try
            {
                await _collection.InsertOneAsync(model, new InsertOneOptions
                {
                    BypassDocumentValidation = false
                }, cancellationToken);
                return new SuccessResponse(HttpStatusCode.Created);
            }
            catch (Exception e)
            {
                return new ErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public virtual async Task<IResponse> UpdateAsync(string id, T model)
        {
            model.Id = id;
            var result = await _collection.FindOneAndReplaceAsync(x => x.Id == id,model);

            if (result is null)
            {
                return new ErrorResponse(HttpStatusCode.NotFound);
            }

            return new SuccessDataResponse<T>(result, HttpStatusCode.NoContent);
        }

        public virtual async Task<IResponse> DeleteAsync(string id)
        {
            var result = await _collection.FindOneAndDeleteAsync(x => x.Id == id);
            
            if (result is null)
            {
                return new ErrorResponse(HttpStatusCode.NotFound);
            }

            return new SuccessDataResponse<T>(result, HttpStatusCode.NoContent);
        }
        

    }
}
