using JsonDataWEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using JsonDataService.Interfaces;
using JsonDataService.Models;

namespace JsonDataWEB.Controllers
{
    public class PersonController : ApiController
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        // GET: api/Person

        public ActionResponse<List<PersonModel>> Get()
        {
            var response = new ActionResponse<List<PersonModel>>(true);

            try { response.Result = _personService.GetAll(); }
            catch (Exception ex)
            {
                response.ActionSucceeded = false;
                response.Messages.Add(ex.Message);
            }

            return response;
        }

        [HttpGet]
        public ActionResponse<PagedResult<PersonModel>> Get(int skip, int take)
        {
            var response = new ActionResponse<PagedResult<PersonModel>>(true);

            try
            {
                PagedResult<PersonModel> result = new PagedResult<PersonModel>();
                result.Result = _personService.GetAll(skip, take, out int total);
                result.TotalCount = total;
                response.Result = result;
            }
            catch (Exception ex)
            {
                response.ActionSucceeded = false;
                response.Messages.Add(ex.Message);
            }

            return response;
        }

        // GET: api/Person/5
        public ActionResponse<PersonModel> Get(int id)
        {
            var response = new ActionResponse<PersonModel>(true);
            try { response.Result = _personService.GetByID(id); }
            catch (Exception ex)
            {
                response.ActionSucceeded = false;
                response.Messages.Add(ex.Message);
            }

            return response;
        }

        // POST: api/Person
        public ActionResponse Post([FromBody]PersonModel value)
        {
            var response = new ActionResponse(true);
            try { _personService.Insert(value); }
            catch (Exception ex)
            {
                response.ActionSucceeded = false;
                response.Messages.Add(ex.Message);
            }
            return response;
        }

        // PUT: api/Person/5
        public ActionResponse Put(int id, [FromBody]PersonModel value)
        {
            var response = new ActionResponse(true);
            try { _personService.Update(value); }
            catch (Exception ex)
            {
                response.ActionSucceeded = false;
                response.Messages.Add(ex.Message);
            }
            return response;
        }

        // DELETE: api/Person/5
        public ActionResponse Delete(int id)
        {
            var response = new ActionResponse(true);
            try { _personService.Delete(id); }
            catch (Exception ex)
            {
                response.ActionSucceeded = false;
                response.Messages.Add(ex.Message);
            }
            return response;
        }
    }
}
