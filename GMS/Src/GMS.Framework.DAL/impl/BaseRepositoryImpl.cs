using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Data;
using System.ComponentModel.DataAnnotations.Schema;
using GMS.Framework.Contract;
using System.Threading.Tasks;
using Webdiyer.WebControls.Mvc;

namespace GMS.Framework.DAL.Impl
{
    /// <summary>
    /// 实现对数据库的操作(增删改查)的基类
    /// </summary>
    /// <typeparam name="T">定义泛型,约束其是一个类</typeparam>
    public class BaseRepositoryImpl:DbContext,IBaseRepository,IDisposable
    {

        public BaseRepositoryImpl(string connectString)
        {
            this.Database.Connection.ConnectionString=connectString;
            this.Configuration.LazyLoadingEnabled=false;
            this.Configuration.ProxyCreationEnabled=false;
        }
        

        //实现对数据库的添加功能，添加实现EF框架的引用
        public T Insert<T>(T entity)  where T:class
        {
            this.Set<T>().Add(entity);
            this.SaveChanges();
            return entity;
        }

       

        //实现对数据库的修改功能
        public T Update<T>(T entity) where T:class
        {
            var set = this.Set<T>();
            set.Attach(entity);
            this.Entry<T>(entity).State = EntityState.Modified;
            this.SaveChanges();
            return entity;

        }

        


        //实现对数据库的删除功能
        public void Delete<T>(T entity) where T : class
        {
            this.Set<T>().Attach(entity);
            this.Entry<T>(entity).State = EntityState.Deleted;
        }



        //实现对数据库的查询 --简单查询.Where<T>(whereLambda)

        public IQueryable<T> Load<T>(Expression<Func<T, bool>> whereLambda) where T:class
        {
            return this.Set<T>().Where<T>(whereLambda).AsQueryable();
        }

        public IQueryable<T> LoadWithInclude<T>(String includeName,Expression<Func<T, bool>> whereLambda) where T : class
        {
            return this.Set<T>().Include(includeName).Where<T>(whereLambda).AsQueryable();
        }

        public IQueryable<T> LoadPage<T,S>(int pageIndex, int pageSize, out int total,
            Expression<Func<T, bool>> whereLambda, bool isAsc, Expression<Func<T, S>> orderByLambda) where T : class
        {
            var temp = this.Set<T>().Where<T>(whereLambda);
            total = temp.Count();
            //排序，获取当前页的数据
            if (isAsc)
            {
                temp = temp.OrderBy<T, S>(orderByLambda)
                    .Skip<T>(pageSize * (pageIndex - 1)) //越过多少条
                    .Take<T>(pageSize).AsQueryable();
            }
            else
            {
                temp = temp.OrderByDescending<T, S>(orderByLambda)
                    .Skip<T>(pageSize * (pageIndex - 1)) //越过多少条
                    .Take<T>(pageSize).AsQueryable();  //取出多少条
            }

            return temp.AsQueryable();
        }
    }
}
