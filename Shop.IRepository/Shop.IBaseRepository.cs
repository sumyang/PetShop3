using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Shop.IRepository
{
    /// <summary>
    /// 因为通用类中的每一个功能都是可以被任何的实体使用，如果参数类型不一致，可以用泛型来解决
    /// 如果有一定的约束条件：where T：class表示必须是引用类型，new（）表示要有一个无参数的构造函数
    /// 
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IBaseRepository<TEntity> where TEntity:class,new()
    {
        //接口中定义方法：
        void Insert(TEntity entity);
        void Delete(TEntity entit);
        void Update(TEntity entit);
        bool SaveChanges();
        //单个查询
        /// <summary>
        /// 
        /// </summary>
        /// <param name="wherelambda">表示输入一个lambda表达式即可</param>
        TEntity SelectEntity(Func<TEntity, bool> wherelambda);
        //查询集合,如果查询带有条件的集合，也要加where，
        IEnumerable<TEntity> SelectEntities(Func<TEntity, bool> wherelambda);
        //带有分页查询的集合，pagesize,pageIndex 
        //Expression<Func<TEntity, type>> OrderByLambda和Func<TEntity, bool> wherelambda
        //Expression 表达式树  优化查询性能
        IEnumerable<TEntity> SelectEntitiesByPage<type>(int pageSize, int pageIndex, bool isAsc,
            Expression<Func<TEntity, type>> OrderByLambda, Expression<Func<TEntity, bool>> WhereLambda);
    }
    public class a
    {
        public void b()
        {
            List<object> list = new List<object>();

            // list.Skip(4).ta

        }
    }

}
