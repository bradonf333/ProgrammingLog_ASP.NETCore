using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ProgrammingLog.Models;

namespace ProgrammingLog.Extensions {
    public static class IQueryableExtensions {

        public static IQueryable<ProgrammingTask> ApplyFiltering (this IQueryable<ProgrammingTask> query, TaskQuery queryObj) {
            if (queryObj.LanguageId.HasValue) {
                query = query.Where (pt => pt.ProgrammingLanguages.Any (pl => pl.LanguageId == queryObj.LanguageId));
            }

            if (queryObj.TaskSummary != null) {
                query = query.Where(pt => pt.Summary.Contains(queryObj.TaskSummary));
            }

            /*
             * If we ever want to add more filter options other than Language we can add them here.
             */

            return query;
        }

        public static IQueryable<T> ApplyOrdering<T> (
            this IQueryable<T> query,
            IQueryObject queryObj,
            Dictionary<string, Expression<Func<T, object>> > columnsMap) {
            if (String.IsNullOrWhiteSpace (queryObj.SortBy) || !columnsMap.ContainsKey (queryObj.SortBy)) {
                return query;
            }
            if (queryObj.IsSortAscending) {
                return query.OrderBy (columnsMap[queryObj.SortBy]);
            } else {
                return query.OrderByDescending (columnsMap[queryObj.SortBy]);
            }
        }

        public static IQueryable<T> ApplyPaging<T> (this IQueryable<T> query, IQueryObject queryObj) {
            if (queryObj.Page <= 0) {
                queryObj.Page = 1;
            }
            if (queryObj.PageSize <= 0) {
                queryObj.PageSize = 10;
            }

            return query.Skip ((queryObj.Page - 1) * queryObj.PageSize).Take (queryObj.PageSize);
        }
    }
}