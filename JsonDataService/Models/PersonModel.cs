using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JsonDataService.Models
{
    public class PersonModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int Index { get; set; }
        public Guid Guid { get; set; }
        public bool IsActive { get; set; }
        public decimal Balance { get; set; }
        public string Picture { get; set; }
        public int Age { get; set; }
        public string EyeColor { get; set; }
        public string Gender { get; set; }
        public string Company { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string About { get; set; }
        public DateTime Registered { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public List<string> Tags { get; set; }
        public List<FriendModel> Friends { get; set; }
        public string Greeting { get; set; }
        public string FavoriteFruit { get; set; }

        public string TagsString { get; set; }
    }
}