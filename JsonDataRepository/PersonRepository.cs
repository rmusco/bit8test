using JsonDataInterfaces;
using JsonDataRepository.Interfaces;
using JsonDataModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonDataRepository
{
    public class PersonRepository : BaseRepository<Person>, IPersonRepository
    {
        public PersonRepository(JsonDataContext entityContext) : base(entityContext)
        {
        }

        protected override IDbSet<Person> GetDbSet() { return _entityContext.People; }

        public override Person Update(Person obj)
        {
            var entity = this.GetDbSet().FirstOrDefault(x => x.Id == obj.Id);
            if (entity == null) throw new InvalidOperationException($"Object not found for id {obj.Id}");

            entity.About = obj.About;
            entity.Address = obj.Address;
            entity.Age = obj.Age;
            entity.Balance  = obj.Balance;
            entity.Company = obj.Company;
            entity.Email = obj.Email;
            entity.EyeColor = obj.EyeColor;
            entity.FavoriteFruit = obj.FavoriteFruit;
            entity.Friends = obj.Friends;
            entity.Gender = obj.Gender;
            entity.Greeting = obj.Greeting;
            entity.IsActive = obj.IsActive;
            entity.Latitude = obj.Latitude;
            entity.Longitude = obj.Longitude;
            entity.Name = obj.Name;
            entity.Phone = obj.Phone;
            entity.Picture = obj.Picture;
            entity.Registered = obj.Registered;
            entity.Tags = obj.Tags;

            _entityContext.SaveChanges();
            return obj;
        }

        public void BulkInsert(List<Person> list)
        {
            _entityContext.Configuration.AutoDetectChangesEnabled = false;
            int total = list.Count;
            int i = 1;
            foreach (var item in list)
            {
                this.GetDbSet().Add(item);
                if (i % 500 == 0)
                    _entityContext.SaveChanges();

                i++;
            }

            _entityContext.SaveChanges();
            _entityContext.Configuration.AutoDetectChangesEnabled = true;
        }
    }
}
