using JsonDataService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonDataService.Interfaces
{
    public interface IPersonService
    {
        List<PersonModel> GetAll();

        List<PersonModel> GetAll(int skip, int take, out int total);

        PersonModel GetByID(int id);

        PersonModel Insert(PersonModel obj);

        PersonModel Update(PersonModel obj);

        void Delete(int id);

        void LoadDatabase();
    }
}
