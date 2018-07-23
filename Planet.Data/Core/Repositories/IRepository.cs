using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;

namespace Planet.Data.Core.Repositories
{
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Creates the specified object.
        /// </summary>
        /// <param name="entity">The object.</param>
        /// <returns></returns>
        T Add(T entity);

        /// <summary>
        /// Updates the specified object.
        /// </summary>
        /// <param name="entity">The object.</param>
        void Update(T entity);

        /// <summary>
        ///  Delete the specified object.
        /// </summary>
        /// <param name="entity">The object.</param>
        /// <returns></returns>
        T Delete(T entity);

        /// <summary>
        /// Finds the specified keys.
        /// </summary>
        /// <param name="keys">The keys.</param>
        /// <returns></returns>
        T Delete(params object[] keys);

        /// <summary>
        /// Deletes the specified predicate.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        void Delete(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Finds the specified keys.
        /// </summary>
        /// <param name="keys">The keys.</param>
        /// <returns></returns>
        T Find(params object[] keys);

        /// <summary>
        /// Finds the specified predicate.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <param name="includes">The includes.</param>
        /// <returns></returns>
        T Find(Expression<Func<T, bool>> predicate, params string[] includes);

        /// <summary>
        /// Counts the specified predicate.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns></returns>
        int Count(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Counts this instance.
        /// </summary>
        /// <returns></returns>
        int Count();

        /// <summary>
        /// Alls the specified includes.
        /// </summary>
        /// <param name="includes">The includes.</param>
        /// <returns></returns>
        IEnumerable<T> GetAll(params string[] includes);

        /// <summary>
        /// Filters the specified predicate.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <param name="includes">The includes.</param>
        /// <returns></returns>
        IEnumerable<T> Filter(Expression<Func<T, bool>> predicate, params string[] includes);


        /// <summary>
        /// Filters the specified predicate with sort order.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="sortOrder">The sort order.</param>
        /// <param name="includes">The includes.</param>
        /// <returns></returns>
        IEnumerable<T> Filter<TOrder>(Expression<Func<T, bool>> predicate, Expression<Func<T, TOrder>> orderBy, ListSortDirection sortOrder = ListSortDirection.Ascending, params string[] includes);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="sortOrder">The sort order.</param>
        /// <param name="totalItems">The total items.</param>
        /// <param name="pageIndex">The index of current page.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="includes">The includes.</param>
        /// <returns></returns>
        IEnumerable<T> Filter<TOrder>(Expression<Func<T, bool>> predicate, Expression<Func<T, TOrder>> orderBy, ListSortDirection sortOrder, out int totalItems, int pageIndex = 1, int pageSize = 50, params string[] includes);


        /// <summary>
        /// Determines whether [contains] [the specified predicate].
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns></returns>
        bool Contains(Expression<Func<T, bool>> predicate);
    }
}
