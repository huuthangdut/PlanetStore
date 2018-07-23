using Planet.Data.Core;
using Planet.Data.Core.Repositories;
using Planet.Data.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Planet.Data.Persistence.Repositories
{
    public abstract class RepositoryBase<T> : IRepository<T> where T : class
    {
        private PlanetContext _context;
        private readonly IDbSet<T> _dbSet;

        protected IDbFactory DbFactory { get; }

        protected PlanetContext DbContext
        {
            get
            {
                return _context ?? (_context = DbFactory.Init());
            }
        }

        protected RepositoryBase(IDbFactory dbFactory)
        {
            DbFactory = dbFactory;
            _dbSet = DbContext.Set<T>();
        }

        public virtual T Add(T entity)
        {
            return _dbSet.Add(entity);
        }

        public virtual void Update(T entity)
        {
            _dbSet.Attach(entity);
            DbContext.Entry(entity).State = EntityState.Modified;
        }

        public virtual T Delete(T entity)
        {
            return _dbSet.Remove(entity);
        }

        public virtual T Delete(params object[] keys)
        {
            var entity = _dbSet.Find(keys);
            return _dbSet.Remove(entity);
        }

        public virtual void Delete(Expression<Func<T, bool>> predicate)
        {
            IEnumerable<T> objects = _dbSet.Where(predicate).AsEnumerable();
            foreach (T obj in objects)
                _dbSet.Remove(obj);
        }

        public virtual T Find(params object[] keys)
        {
            return _dbSet.Find(keys);
        }

        public virtual T Find(Expression<Func<T, bool>> predicate, params string[] includes)
        {
            IQueryable<T> query = _dbSet;

            foreach (var child in includes)
            {
                query = query.Include(child);
            }

            return query.FirstOrDefault(predicate);
        }

        public virtual int Count(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Count(predicate);
        }

        public virtual int Count()
        {
            return _dbSet.Count();
        }

        public virtual IEnumerable<T> GetAll(params string[] includes)
        {
            IQueryable<T> query = _dbSet;
            foreach (var child in includes)
            {
                query = query.Include(child);
            }

            return query.AsEnumerable();
        }

        public virtual IEnumerable<T> Filter(Expression<Func<T, bool>> predicate, params string[] includes)
        {
            IQueryable<T> query = _dbSet;
            foreach (var child in includes)
            {
                query = query.Include(child);
            }

            return query.Where(predicate).AsEnumerable();
        }

        public virtual IEnumerable<T> Filter<TOrder>(Expression<Func<T, bool>> predicate, Expression<Func<T, TOrder>> orderBy, ListSortDirection sortOrder = ListSortDirection.Ascending, params string[] includes)
        {
            IQueryable<T> query = _dbSet;
            foreach (var child in includes)
            {
                query = query.Include(child);
            }

            if (predicate != null)
                query = query.Where(predicate);

            query = sortOrder == ListSortDirection.Ascending
                ? query.OrderBy(orderBy)
                : query.OrderByDescending(orderBy);


            return query.AsEnumerable();
        }

        public virtual IEnumerable<T> Filter<TOrder>(Expression<Func<T, bool>> predicate, Expression<Func<T, TOrder>> orderBy, ListSortDirection sortOrder, out int totalItems, int pageIndex = 1, int pageSize = 50, params string[] includes)
        {
            IQueryable<T> query = _dbSet;

            foreach (var child in includes)
            {
                query = query.Include(child);
            }

            if (predicate != null)
                query = query.Where(predicate);

            if (orderBy != null)
                query = sortOrder == ListSortDirection.Ascending
                    ? query.OrderBy(orderBy)
                    : query.OrderByDescending(orderBy);

            totalItems = query.Count();
            query = query.Skip((pageIndex - 1) * pageSize).Take(pageSize);

            return query.AsEnumerable();
        }


        public virtual IEnumerable<T> Filter(Expression<Func<T, bool>> predicate, string orderBy, bool ascending, out int totalItems, int pageIndex = 1, int pageSize = 50, params string[] includes)
        {
            IQueryable<T> query = _dbSet;

            foreach (var child in includes)
            {
                query = query.Include(child);
            }

            if (predicate != null)
                query = query.Where(predicate);

            query = query.OrderByPropertyOrField(orderBy, ascending);
            totalItems = query.Count();
            query = query.Skip((pageIndex - 1) * pageSize).Take(pageSize);

            return query.AsEnumerable();
        }

        public bool Contains(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Count<T>(predicate) > 0;
        }

    }
}
