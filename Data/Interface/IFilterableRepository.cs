﻿using AspBoot.Data.Model;
using AspBoot.Data.Request;

namespace AspBoot.Data.Interface;

public interface IFilterableRepository<TEntity, TKey> : IRepository<TEntity, TKey>
{
    PageSortedFiltered<TEntity> GetFiltered(RequestPageSortedFiltered request,
        Func<IQueryable<TEntity>, IQueryable<TEntity>>? query = null);
}
