using AutoMapper;
using JsonDataService.Interfaces;
using JsonDataService.Models;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonDataService
{
    public class RegistryService : Registry
    {
        /// <summary>Initializes a new instance of the Clarity.Ecommerce.Models.ModelsRegistry class.</summary>
        public RegistryService()
        {
            var mapperConfiguration = CreateConfiguration();
            var mapper = mapperConfiguration.CreateMapper();
            For<IConfigurationProvider>().Use(mapperConfiguration);
            For<IMapper>().Use(mapper);

            For<IPersonService>().Use<PersonService>();
        }

        private MapperConfiguration CreateConfiguration()
        {
            var config = new MapperConfiguration(cfg =>
            {
                // Add all profiles in current assembly
                cfg.AddProfiles(GetType().Assembly);
                cfg.IgnoreUnmapped();
            });

            return config;
        }
    }
}
