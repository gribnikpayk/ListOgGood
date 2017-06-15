using System;
using System.Linq.Expressions;
using ListOfGoods.Infrastructure.DependencyService;
using SQLite;
using Xamarin.Forms;

namespace ListOfGoods.DataManagers.Local.Base
{
    public class BaseRepository<EntityType> : IBaseRepository<EntityType> where EntityType : BaseEntity, new()
    {
        private static object _locker = new object();

        public BaseRepository()
        {
            App.Database.CreateTable<EntityType>();
        }

        public EntityType GetById(int id)
        {
            lock (_locker)
            {
                return App.Database.Get<EntityType>(id);
            }
        }

        public int DeleteAll()
        {
            lock (_locker)
            {
                return App.Database.DeleteAll<EntityType>();
            }
        }

        public int Update(EntityType entity)
        {
            lock (_locker)
            {
                return App.Database.Update(entity);
            }
        }

        public int Create(EntityType entity)
        {
            lock (_locker)
            {
                return App.Database.Insert(entity);
            }
        }

        public int Delete(int id)
        {
            lock (_locker)
            {
                return App.Database.Delete<EntityType>(id);
            }
        }

        public TableQuery<EntityType> GetQuery(Expression<Func<EntityType, bool>> expression = null)
        {
            lock (_locker)
            {
                return expression == null ? App.Database.Table<EntityType>() : App.Database.Table<EntityType>().Where(expression);
            }
        }
    }
}