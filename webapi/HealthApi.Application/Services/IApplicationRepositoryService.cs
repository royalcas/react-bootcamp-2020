using HealthApp.Domain;
using System;
using System.Collections.Generic;

namespace HealthApi.Application.Services
{
	public interface IApplicationRepositoryService<TEntity> where TEntity : Entity
	{
		void Add(TEntity profile);
		IEnumerable<TEntity> GetAll();
		TEntity GetById(string id);

		void Update(TEntity entity);
	}
}