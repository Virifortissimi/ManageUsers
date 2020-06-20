using System;
using System.Collections.Generic;
using ManageUsers.API.Interfaces;
using ManageUsersAPI.Data.DatabaseContext;
using ManageUsersAPI.Data.Entities;
using System.Linq;

namespace ManageUsers.API.Services
{
    public class UserServices : IUserServices
    {

        private UserDbContext db = null;

        public UserServices(UserDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<UserEntity> GetUsers()
        {
            List<UserEntity> model = (from e in db.UserEntities orderby e.UserId select e).ToList();
            return model;
        }

        public UserEntity AddUser(UserEntity model)
        {
            if (model is null) throw new ArgumentNullException(message: "User cannot be null", null);

            db.UserEntities.Add(model);
            db.SaveChanges();

            return model;
        }
    }
}