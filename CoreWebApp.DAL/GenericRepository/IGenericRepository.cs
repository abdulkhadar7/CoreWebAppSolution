using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreWebApp.DAL.GenericRepository
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> Get();
        TEntity GetByID(object id);
        IEnumerable<TEntity> GetAll();
        TEntity Insert(TEntity entity);
        void Delete(object id);
        void Delete(TEntity entityToDelete);
        TEntity GetFirst(Func<TEntity, bool> predicate);
        void Update(TEntity entityToUpdate);
        IEnumerable<TEntity> GetMany(Func<TEntity, bool> where);
        IQueryable<TEntity> GetManyQueryable(Func<TEntity, bool> where);
        void Delete(Func<TEntity, Boolean> where);
        IQueryable<TEntity> GetWithInclude(
            System.Linq.Expressions.Expression<Func<TEntity,
            bool>> predicate, params string[] include);
        bool Exists(object primaryKey);
        TEntity GetSingle(Func<TEntity, bool> predicate);

        IEnumerable<TEntity> ExecSqlQueryWithResults(string query, params object[] parameters);
        int ExecuteSqlQuery(string query, params object[] parameters);

    }
}
