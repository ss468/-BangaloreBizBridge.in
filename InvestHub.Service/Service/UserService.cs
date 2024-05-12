using AutoMapper;
using InvestHub.Core.Dto;
using InvestHub.Core.Entities;
using InvestHub.Core.ExtensionMethod;
using InvestHub.Core.Interfaces.Repository;
using InvestHub.Core.Interfaces.Service;
using InvestHub.Core.Models;
using MongoDB.Bson;

namespace InvestHub.Service.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        public void CreateUser(CreateUserDto userDto)
        {
            var newUser = MapperExtension.ToUserModel(userDto);
            var userEntity = MapperExtension.ToUserEntity(newUser);
            userEntity.Id = new Guid();
            _userRepository.Insert(userEntity);
            Console.WriteLine("User inserted successfully.");
        }

        public IEnumerable<GetUserDto> GetUsers(UserType userType)
        {
           
            var userEntity = _userRepository.GetUsers(userType);
            var userModelList = MapperExtension.ToUserModel(userEntity);
            var userDto = MapperExtension.ToGetUserListDto(userModelList);
            return userDto;
        }
        
        public GetUserDto GetUserById(string userId)
        {
            if (!Guid.TryParse(userId, out Guid objectId))
            {
                throw new ArgumentException("Invalid ObjectId format");
            }

            var userEntity = _userRepository.GetById(objectId);
            var userModel = MapperExtension.ToUserModel(userEntity);
            var userDto = MapperExtension.ToGetUserDto(userModel);
            return userDto;
        }

        public void UpdateUser(string userId, string newUsername)
        {
            if (!Guid.TryParse(userId, out Guid objectId))
            {
                throw new ArgumentException("Invalid ObjectId format");
            }

            var user = _userRepository.GetById(objectId);
            if (user == null)
            {
                throw new ArgumentException("User not found");
            }

            user.FirstName = newUsername;
            user.LastName = newUsername;
            _userRepository.Update(user);
            Console.WriteLine("User updated successfully.");
        }

        public void DeleteUser(string userId)
        {
            if (!Guid.TryParse(userId, out Guid objectId))
            {
                throw new ArgumentException("Invalid ObjectId format");
            }

            _userRepository.Delete(objectId);
            Console.WriteLine("User deleted successfully.");
        }
    }
}
