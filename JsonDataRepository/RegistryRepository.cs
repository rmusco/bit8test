using JsonDataRepository.Interfaces;
using JsonDataModels;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonDataRepository
{
    public class RegistryRepository : Registry
    {
        /// <summary>Initializes a new instance of the Clarity.Ecommerce.Models.ModelsRegistry class.</summary>
        public RegistryRepository()
        {
            For<IPersonRepository>().Use<PersonRepository>();
            For<IFriendRepository>().Use<FriendRepository>();
        }
    }
}
