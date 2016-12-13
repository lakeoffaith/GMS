using System;
using System.Collections;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using GMS.Framework.DAL;
using GMS.Framework.DAL.Impl;
namespace GMS.Framework.BLL.Impl
{
    public abstract class BaseServiceImpl<T> where T:class
    {
       

         //约束
         public abstract BaseRepositoryImpl GetCurrentRepository();  //子类必须实现

         public T Insert(T entity)
         {
            //调用T对应的仓储来做添加工作
             var CurrentRepository = GetCurrentRepository();
                return CurrentRepository.Insert<T>(entity);
         }
        
        public void Update(T entity)
        {
            //调用T对应的仓储来做添加工作
            var CurrentRepository = GetCurrentRepository();
                CurrentRepository.Update<T>(entity);
        }
     

        public void Delete(T entity)
        {
            var CurrentRepository = GetCurrentRepository();
                CurrentRepository.Delete(entity);
        }

        public IQueryable<T> Load(Expression<Func<T, bool>> whereLambda)
        {
            var CurrentRepository = GetCurrentRepository();
                return CurrentRepository.Load(whereLambda);
            
               
            
           
        }
        public IQueryable<T> LoadWithInclude(string includeName, Expression<Func<T, bool>> whereLambda)
        {
            var CurrentRepository = GetCurrentRepository();
            return CurrentRepository.LoadWithInclude(includeName,whereLambda);
        }

        public IQueryable<T> LoadPage<S>(int pageIndex, int pageSize, out int total, Expression<Func<T, bool>> whereLambda,
            bool isAsc, Expression<Func<T, S>> orderByLambda)
        {
            var CurrentRepository = GetCurrentRepository();
                return CurrentRepository.LoadPage(pageIndex, pageSize, out total, whereLambda, isAsc, orderByLambda);
        }
    }
}
