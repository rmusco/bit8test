﻿using JsonDataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonDataInterfaces.Repository
{
    public interface IPersonRepository : IBaseRepository<Person>
    {
        void BulkInsert(List<Person> entity);
    }
}