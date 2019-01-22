using JsonDataModels;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonDataInterfaces.DbContext
{
    public class RegistryDbContext : Registry
    {
        /// <summary>Initializes a new instance of the Clarity.Ecommerce.Models.ModelsRegistry class.</summary>
        public RegistryDbContext()
        {
            For<JsonDataContext>().Use(context => CreateNewContext(context));
        }

        public JsonDataContext CreateNewContext(IContext context)
        {
            var myContext = new JsonDataContext();
            myContext.Configuration.ProxyCreationEnabled = false;
            return myContext;
        }
    }
}
