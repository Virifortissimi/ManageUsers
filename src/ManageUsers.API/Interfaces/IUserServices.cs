using System.Collections.Generic;
using ManageUsersAPI.Data.Entities;

namespace ManageUsers.API.Interfaces
{
    public interface IUserServices
    {
        IEnumerable<UserEntity> GetUsers();

        UserEntity AddUser(UserEntity model);
    }
}