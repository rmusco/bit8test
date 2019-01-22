using JsonDataInterfaces;
using JsonDataRepository.Interfaces;
using JsonDataModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonDataRepository
{
    public class FriendRepository : BaseRepository<Friend>, IFriendRepository
    {
        public FriendRepository(JsonDataContext entityContext) : base(entityContext)
        {
        }

        protected override IDbSet<Friend> GetDbSet() { return _entityContext.Friends; }
        
    }
}
