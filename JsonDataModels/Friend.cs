using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonDataModels
{
    public class Friend : Base
    {
        public int PersonId { get; set; }
        public Person Person { get; set; }
    }
}
