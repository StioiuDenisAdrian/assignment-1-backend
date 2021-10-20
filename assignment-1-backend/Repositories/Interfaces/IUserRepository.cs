using assignment_1_backend.Models;
using assignment_1_backend.Models.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace assignment_1_backend.Repositories.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUsers(UserFilter userFilter);
        User GetUser(Guid ID);
        void SaveUser(User user, bool isAccountCreated);
        void DeleteUser(Guid ID);
        bool IsUserNameUnique(string username);
        void ChangeDefaultPassword(Guid id, string password);
    }
}
