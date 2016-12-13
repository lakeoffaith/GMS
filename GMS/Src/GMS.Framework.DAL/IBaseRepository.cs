using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

namespace GMS.Framework.DAL
{
    public interface IBaseRepository
    {
        // 实现对数据库的添加功能,添加实现EF框架的引用
        T Insert<T>(T entity)  where T:class;

        T Update<T>(T entity)  where T:class;

        void Delete<T>(T entity)  where T:class;

        IQueryable<T> Load<T>(Expression<Func<T, bool>> whereLambda) where T : class;

        IQueryable<T> LoadWithInclude<T>(string includeName,Expression<Func<T, bool>> whereLambda) where T : class;
        

        IQueryable<T> LoadPage<T,S>(int pageIndex, int pageSize, out int total, Expression<Func<T, bool>> whereLambda,
            bool isAsc, Expression<Func<T, S>> orderByLambda)  where T:class;
    }
}
