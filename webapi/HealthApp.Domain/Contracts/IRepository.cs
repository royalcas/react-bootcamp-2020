﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HealthApp.Domain.Contracts
{
	public interface IRepository<TEntity>: IDisposable where TEntity: Entity
	{
        void Add(TEntity obj);
        TEntity GetById(string id);
        IQueryable<TEntity> GetAll();
        void Update(TEntity obj);
        void Remove(string id);
        int SaveChanges();
    }
}
