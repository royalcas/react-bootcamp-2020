using HealthApp.Domain;
using HealthApp.Domain.Contracts;
using Mapster;
using System;
using System.Collections.Generic;

namespace HealthApi.Application.Services
{
    public abstract class ApplicationRepositoryService<TRepository, TModel, TEntity> : IApplicationRepositoryService<TModel> 
        where TEntity : Entity
        where TModel : class
        where TRepository: IRepository<TEntity>
    {
        protected readonly TRepository _repository;
        protected readonly IUnitOfWork _unitOfWork;

        public ApplicationRepositoryService(TRepository repository, IUnitOfWork unitOfWork)
        {
            this._repository = repository;
            this._unitOfWork = unitOfWork;
        }

        public IEnumerable<TModel> GetAll()
        {
            return _repository.GetAll().ProjectToType<TModel>();
        }

        public TModel GetById(string id)
        {
            return _repository.GetById(id).Adapt<TModel>();
        }

        public void Add(TModel model)
        {
            var entity = model.Adapt<TEntity>();
            _repository.Add(entity);
            _unitOfWork.Commit();
        }

        public void Update(TModel model)
        {
            var entity = model.Adapt<TEntity>();
            _repository.Update(entity);
            _unitOfWork.Commit();
        }
    }
}
