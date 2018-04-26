using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShopCham.Data.Infrastructure
{
    public abstract class RepositoryBase<T> : IRepository<T> where T : class
    {
        #region Properties
        private ShopChamDbContext dbContext;
        private readonly IDbSet<T> dbSet;

        protected IDbFactory DbFactory
        {
            get;
            private set;
        }

        protected ShopChamDbContext DbContext
        {
            get { return dbContext ?? (dbContext = DbFactory.Init()); }
        }
        #endregion

        #region Constructor
        public RepositoryBase(IDbFactory dbFactory)
        {
            this.DbFactory = dbFactory;
            this.dbSet = DbContext.Set<T>();
        }
        #endregion

        #region Implementation
        public virtual T Add(T entity)
        {
            return dbSet.Add(entity);
        }

        public virtual void Update(T entity)
        {
            dbSet.Attach(entity);
            dbContext.Entry(entity).State = EntityState.Modified;
        }

        public virtual T Delete(T entity)
        {
            return dbSet.Remove(entity);
        }

        public virtual T Delete(int id)
        {
            var entiry = dbSet.Find(id);
            return dbSet.Remove(entiry);
        }        

        public virtual void DeleteMulti(Expression<Func<T, bool>> expression)
        {
            IEnumerable<T> objects = dbSet.Where<T>(expression).AsEnumerable();
            foreach (T obj in objects)
            {
                dbSet.Remove(obj);
            }
        }

        public virtual T GetSingleById(int id)
        {
            return dbSet.Find(id);
        }

        public virtual T GetSingleByCondition(Expression<Func<T, bool>> expression, string[] includes = null)
        {
            if (includes != null && includes.Count() > 0)
            {
                var query = dbContext.Set<T>().Include(includes.First());
                foreach (var include in includes.Skip(1))
                {
                    query = query.Include(include);
                }

                return query.FirstOrDefault(expression);
            }

            return dbContext.Set<T>().FirstOrDefault(expression);
        }

        public virtual IEnumerable<T> GetAll(string[] includes = null)
        {
            if (includes != null && includes.Count() > 0)
            {
                var query = dbContext.Set<T>().Include(includes.First());
                foreach (var include in includes.Skip(1))
                {
                    query = query.Include(include);
                }

                return query.AsQueryable();
            }

            return dbContext.Set<T>().AsQueryable();
        }

        public virtual IEnumerable<T> GetMulti(Expression<Func<T, bool>> expression, string[] includes = null)
        {
            if (includes != null && includes.Count() > 0)
            {
                var query = dbContext.Set<T>().Include(includes.First());
                foreach (var include in includes.Skip(1))
                {
                    query = query.Include(include);
                }

                return query.Where<T>(expression).AsQueryable();
            }

            return dbContext.Set<T>().Where<T>(expression).AsQueryable();
        }

        public virtual IEnumerable<T> GetMultiPaging(Expression<Func<T, bool>> expression, out int total, int index = 0, int size = 50, string[] includes = null)
        {
            int skipCount = index * size;
            IQueryable<T> resultQuery;

            if (includes != null && includes.Count() > 0)
            {
                var query = dbContext.Set<T>().Include(includes.First());
                foreach (var include in includes.Skip(1))
                {
                    query = query.Include(include);
                }

                resultQuery = expression != null ? query.Where<T>(expression).AsQueryable() : query.AsQueryable();
            }
            else
            {
                resultQuery = expression != null ? dbContext.Set<T>().Where<T>(expression).AsQueryable() : dbContext.Set<T>().AsQueryable();
            }

            resultQuery = skipCount == 0 ? resultQuery.Take(size) : resultQuery.Skip(skipCount).Take(size);
            total = resultQuery.Count();
            return resultQuery.AsQueryable();
        }

        public virtual int Count(Expression<Func<T, bool>> expression)
        {
            return dbSet.Count(expression);
        }

        public virtual bool CheckContains(Expression<Func<T, bool>> expression)
        {
            return dbContext.Set<T>().Count(expression) > 0;
        }
        #endregion
    }
}
