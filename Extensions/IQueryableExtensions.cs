using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ProgrammingLog.Models;

namespace ProgrammingLog.Extensions {
    public static class IQueryableExtensions {
        public static IQueryable<T> ApplyOrdering<T> (
            this IQueryable<T> query,
            IQueryObject queryObj,
            Dictionary<string, Expression<Func<T, object>> > columnsMap) {
            if (String.IsNullOrWhiteSpace (queryObj.SortyBy) || !columnsMap.ContainsKey (queryObj.SortyBy)) {
                return query;
            }
            if (queryObj.IsSortAscending) {
                return query.OrderBy (columnsMap[queryObj.SortyBy]);
            } else {
                return query.OrderByDescending (columnsMap[queryObj.SortyBy]);
            }
        }
    }
}