using AutoMapper;
using JsonDataModels;
using JsonDataRepository.Interfaces;
using JsonDataService.Interfaces;
using JsonDataService.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonDataService
{
    public class PersonService : IPersonService
    {
        private readonly IMapper _mapper;
        private readonly IPersonRepository _personRepository;
        public PersonService(IPersonRepository personRepository, IMapper mapper)
        {
            _personRepository = personRepository;
            _mapper = mapper;
        }

        public void Delete(int id)
        {
            _personRepository.Delete(id);
        }

        public List<PersonModel> GetAll()
        {
            var list = _personRepository.GetAll();
            return _mapper.Map<List<PersonModel>>(list);
        }

        public List<PersonModel> GetAll(int skip, int take, out int total)
        {
            var list = _personRepository.GetAll(skip, take, out total);
            return _mapper.Map<List<PersonModel>>(list);
        }

        public PersonModel GetByID(int id)
        {
            var entity = _personRepository.GetByID(id);
            var model = _mapper.Map<PersonModel>(entity);

            model.TagsString = String.Join(",", model.Tags);
            return model;
        }

        public PersonModel Insert(PersonModel obj)
        {
            obj.Tags = obj.TagsString.Split(',').ToList();
            var entity = _mapper.Map<Person>(obj);
            entity = _personRepository.Insert(entity);
            return _mapper.Map<PersonModel>(entity);
        }

        public void LoadDatabase()
        {
            var total = _personRepository.GetTotalRecords();
            if (total > 0)
                throw new Exception("Database is already loaded.");

            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore,
                Formatting = Formatting.None,
                DateFormatHandling = DateFormatHandling.IsoDateFormat,
                Converters = new List<JsonConverter> { new DecimalConverter() }
            };

            var filepath = $"{AppDomain.CurrentDomain.BaseDirectory}JSON_DATA.js";
            var file = System.IO.File.ReadAllText(filepath);

            var list = JsonConvert.DeserializeObject<List<PersonModel>>(file, settings);

            _personRepository.BulkInsert(_mapper.Map<List<Person>>(list));
        }

        public PersonModel Update(PersonModel obj)
        {
            obj.Tags = obj.TagsString.Split(',').ToList();
            var entity = _mapper.Map<Person>(obj);
            entity = _personRepository.Update(entity);
            return _mapper.Map<PersonModel>(entity);
        }
    }
}
