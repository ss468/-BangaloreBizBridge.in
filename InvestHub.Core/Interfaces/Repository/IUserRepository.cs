using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvestHub.Core.Entities;
using MongoDB.Bson;

namespace InvestHub.Core.Interfaces.Repository
{
    public interface IUserRepository
    {
        void Insert(UserEntity user);
        IEnumerable<UserEntity> GetUsers(UserType usertype);
        UserEntity GetById(Guid id);
        void Update(UserEntity user);
        void Delete(Guid id);
    }
}
