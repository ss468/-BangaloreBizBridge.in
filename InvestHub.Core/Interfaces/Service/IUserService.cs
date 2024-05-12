using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvestHub.Core.Dto;
using InvestHub.Core.Entities;

namespace InvestHub.Core.Interfaces.Service
{
    public interface IUserService
    {
        void CreateUser(CreateUserDto userDto);
        IEnumerable<GetUserDto> GetUsers(UserType userType);
        GetUserDto GetUserById(string userId);
        void UpdateUser(string userId, string newUsername);
        void DeleteUser(string userId);
    }
}
