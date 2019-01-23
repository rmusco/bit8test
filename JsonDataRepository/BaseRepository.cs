using JsonDataRepository.Interfaces;
using JsonDataModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonDataRepository
{
    public abstract class BaseRepository<T> : IBaseRepository<T>
         where T : Base
    {
        protected readonly JsonDataContext _entityContext;

        protected BaseRepository(JsonDataContext entityContext)
        {
            _entityContext = entityContext;
        }

        protected abstract IDbSet<T> GetDbSet();

        public virtual int GetTotalRecords()
        {
            return this.GetDbSet().Count();
        }

        public virtual List<T> GetAll(int skip, int take, out int total)
        {
            total = this.GetTotalRecords();
            return this.GetDbSet().OrderBy(x=> x.Id).Skip(skip).Take(take).ToList();
        }

        public virtual List<T> GetAll()
        {
            return this.GetDbSet().ToList();
        }

        public virtual T GetByID(int id)
        {
            return this.GetDbSet().FirstOrDefault(x => x.Id == id);
        }

        public virtual T Insert(T obj)
        {
            this.GetDbSet().Add(obj);
            _entityContext.SaveChanges();

            return obj;
        }

        public virtual T Update(T obj)
        {
            var entity = this.GetByID(obj.Id);
            if (entity == null) throw new InvalidOperationException($"Object not found for id {obj.Id}");

            entity.Name = obj.Name;

            _entityContext.SaveChanges();
            return obj;
        }

        public virtual void Delete(int id)
        {
            var entity = this.GetByID(id);

            this.GetDbSet().Remove(entity);
            _entityContext.SaveChanges();
        }
    }
}
