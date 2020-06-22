using System.Collections.Generic;
using ManageUsersAPI.Data.Entities;

namespace ManageUsers.API.Interfaces
{
    public interface IUserServices
    {
        IEnumerable<UserEntity> GetUsers();

        UserEntity GetUser(UserEntity model);

        UserEntity AddUser(UserEntity model);

        UserEntity DeleteUser(int id);

        UserEntity UpdateUser(int id, UserEntity model);

        UserEntity UpdateUserDetails(int id, UserEntity model);
    }
}