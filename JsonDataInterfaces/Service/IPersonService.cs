using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonDataInterfaces.Service
{
    public interface IPersonService
    {
        public virtual List<PersonModel> GetAll()
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
