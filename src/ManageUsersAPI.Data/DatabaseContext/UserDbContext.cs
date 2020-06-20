using ManageUsersAPI.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace ManageUsersAPI.Data.DatabaseContext {
    public class UserDbContext : DbContext {

        public UserDbContext (DbContextOptions<UserDbContext> options) : base (options) { }

        public DbSet<UserEntity> UserEntities { get; set; }
    }
}