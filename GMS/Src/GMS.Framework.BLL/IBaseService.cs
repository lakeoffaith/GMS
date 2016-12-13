using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
namespace GMS.Framework.BLL
{
    public interface IBaseService<T> where T:class
    {
       T Insert(T entity);

        void Update(T entity);

        void Delete(T entity);

        IQueryable<T> Load(Expression<Func<T, bool>> whereLambda);

        IQueryable<T> LoadWithInclude(string includeName, Expression<Func<T, bool>> whereLambda); 

        IQueryable<T> LoadPage<S>(int pageIndex,int pageSize,out int total,Expression<Func<T,bool>> whereLambda,
            bool isAsc,Expression<Func<T,S>> orderByLambda);
    }
}
