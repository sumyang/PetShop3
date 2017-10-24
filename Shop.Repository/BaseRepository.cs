using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Shop.IRepository;
using Shop.Model;
using System.Data.Entity;
namespace Shop.Repository
{
    /// <summary>
    /// 这是一个通用的类
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class, new()
    {
        //实例化上下文对象 从工厂中获取对象
        //PestShow ps = new PestShow();
        private readonly PestShow dbcontext= DbContextFactory.CreateDbContext();//获取上下文对象
        //2；设置实体集DbSet
        public DbSet<TEntity> dbSet;
        ////声明一个接口类型的变量
        //IBaseRepository<TEntity> _ibaseRepository;
        //public BaseRepository(IBaseRepository<TEntity> ibaseRepository)
        //{
        //    this._ibaseRepository = ibaseRepository;
        //}
        public BaseRepository()
        {
            dbSet = dbcontext.Set<TEntity>();//构造一个实体集
        }
        public void Delete(TEntity tEntity)
        {
            //1:删除指定的实体，先从集合中查找到该实体，然后再删除
            dbSet.Attach(tEntity);
            dbSet.Remove(tEntity);
        }

        public void Insert(TEntity tEntity)
        {
            dbSet.Add(tEntity);
        }

        public IEnumerable<TEntity> SelectEntities(Func<TEntity, bool> wherelambda)
        {
            return dbSet.Where(wherelambda);
        }

        public IEnumerable<TEntity> SelectEntitiesByPage<Ttype>(int pageSize, int pageIndex, bool isAsc, Expression<Func<TEntity, Ttype>> OrderByLambda, Expression<Func<TEntity, bool>> WhereLambda)
        {
            var result = dbSet.Where(WhereLambda);
            result = isAsc ? result.OrderBy(OrderByLambda) : result.OrderByDescending(OrderByLambda);
            result = result.Skip((pageIndex - 1) * pageSize).Take(pageSize);
            return result.ToList();
        }

        public TEntity SelectEntity(Func<TEntity, bool> wherelambda)
        {
            return dbSet.FirstOrDefault(wherelambda);
        }

        public void Update(TEntity entit)
        {
            //更新：先查找到要更新的实体，然后在覆盖原有的
            dbSet.Attach(entit);
            //需要修改状态
            dbcontext.Entry(entit).State = EntityState.Modified;
        }
        public bool SaveChanges()
        {
            return dbcontext.SaveChanges() > 0;
        }
    }
}
