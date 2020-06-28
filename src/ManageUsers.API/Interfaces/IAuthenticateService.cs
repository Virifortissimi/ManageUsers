using ManageUsers.API.Models;

namespace ManageUsers.API.Interfaces
{
    public interface IAuthenticateService
    {
        User Authenticate(string userName, string password);
    }
}