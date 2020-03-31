using HealthApp.Domain;
using System;
using System.Collections.Generic;

namespace HealthApi.Application.Services
{
	public interface IApplicationRepositoryService<TModel>
		where TModel: class
	{
		void Add(TModel profile);
		IEnumerable<TModel> GetAll();
		TModel GetById(string id);
		void Update(TModel entity);
	}
}