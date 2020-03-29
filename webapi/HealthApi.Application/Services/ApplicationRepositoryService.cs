using HealthApp.Domain;
using HealthApp.Domain.Contracts;
using System;
using System.Collections.Generic;

namespace HealthApi.Application.Services
{
    public abstract class ApplicationRepositoryService<TRepository, TEntity> : IApplicationRepositoryService<TEntity> 
        where TEntity : Entity 
        where TRepository: IRepository<TEntity>
    {
        protected readonly TRepository _repository;
        protected readonly IUnitOfWork _unitOfWork;

        public ApplicationRepositoryService(TRepository repository, IUnitOfWork unitOfWork)
        {
            this._repository = repository;
            this._unitOfWork = unitOfWork;
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public TEntity GetById(string id)
        {
            return _repository.GetById(id);
        }

        public void Add(TEntity profile)
        {
            _repository.Add(profile);
            _unitOfWork.Commit();
        }
    }
}
