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

        public UserEntity GetUser(UserEntity model)
        {
            UserEntity user = db.UserEntities.Find(model.Email);
            return user;
        }

        public UserEntity AddUser(UserEntity model)
        {
            if (model is null) throw new ArgumentNullException(message: "User cannot be null", null);

            db.UserEntities.Add(model);
            db.SaveChanges();

            return model;
        }

        public UserEntity DeleteUser(int id)
        {
            UserEntity user = db.UserEntities.Find(id);

            if (user is null) throw new ArgumentOutOfRangeException(message: "No such user in the database", null);

            db.UserEntities.Remove(user);
            db.SaveChanges();

            return user;
        }

        public UserEntity UpdateUser(int id, UserEntity model)
        {
            UserEntity user = db.UserEntities.Find(id);

            if (user is null) throw new ArgumentOutOfRangeException(message: "No such user in the database", null);


            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Email = model.Email;
            user.Phone = model.Phone;
            db.SaveChanges();

            return user;
        }

        public UserEntity UpdateUserDetails(int id, UserEntity model)

        {
            UserEntity user = db.UserEntities.Find(id);

            if (user is null) throw new ArgumentOutOfRangeException(message: "No such user in the database", null);

            if (model.FirstName != null)
            {
                user.FirstName = model.FirstName;
                db.SaveChanges();
            }

            if (model.LastName != null)
            {
                user.LastName = model.LastName;
                db.SaveChanges();
            }

            if (model.Email != null)
            {
                user.Email = model.Email;
                db.SaveChanges();
            }

            if (model.Phone != null)
            {
                user.Phone = model.Phone;
                db.SaveChanges();
            }

            return user;
        }
    }
}