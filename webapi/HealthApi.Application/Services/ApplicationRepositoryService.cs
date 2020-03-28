using HealthApp.Domain;
using HealthApp.Domain.Contracts;
using System;
using System.Collections.Generic;

namespace HealthApi.Application.Services
{
    public abstract class ApplicationRepositoryService<TEntity> : IApplicationRepositoryService<TEntity> where TEntity : Entity
    {
        private readonly IRepository<TEntity> _repository;

        public ApplicationRepositoryService(IRepository<TEntity> repository)
        {
            this._repository = repository;
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public TEntity GetById(Guid id)
        {
            return _repository.GetById(id);
        }

        public void Add(TEntity profile)
        {
            _repository.Add(profile);
        }
    }
}
