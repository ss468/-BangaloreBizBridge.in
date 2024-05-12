using InvestHub.Core.Entities;
using InvestHub.Core.Interfaces.Repository;
using MongoDB.Bson;
using MongoDB.Driver;

namespace InvestHub.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IMongoCollection<UserEntity> _collection;

        public UserRepository(IMongoCollection<UserEntity> collection)
        {
            _collection = collection;
        }

        public void Insert(UserEntity user)
        {
            _collection.InsertOne(user);
        }

        public IEnumerable<UserEntity> GetUsers(UserType usertype)
        {
            return _collection.Find(u => u.UserType == usertype).ToList();
        }
        public UserEntity GetById(Guid id)
        {
            return _collection.Find(u => u.Id == id).FirstOrDefault();
        }

        public void Update(UserEntity user)
        {
            _collection.ReplaceOne(u => u.Id == user.Id, user);
        }

        public void Delete(Guid id)
        {
            _collection.DeleteOne(u => u.Id == id);
        }
    }
}
