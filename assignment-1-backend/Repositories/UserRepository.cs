using assignment_1_backend.Models;
using assignment_1_backend.Models.Filters;
using assignment_1_backend.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace assignment_1_backend.Repositories
{
    public class UserRepository// : IUserRepository
    {
        private readonly Context context;

        public UserRepository(Context context)
        {
            this.context = context;
        }

        //public void ChangeDefaultPassword(Guid id, string password)
        //{
        //    var user = context.Users.AsTracking().FirstOrDefault(u => u.ID == id);

        //    user.Password = password;
        //    user.IsOriginalPasswordChanged = true;

        //    context.SaveChanges();
        //}

        //public void DeleteUser(Guid ID)
        //{
        //    var user = context.Users.FirstOrDefault(u => u.ID == ID);
        //    context.Users.Remove(user);
        //    context.SaveChanges();
        //}

        //public User GetUser(Guid ID)
        //{
        //    return context.Users.FirstOrDefault(u => u.ID == ID);
        //}

        //public IEnumerable<User> GetUsers(UserFilter userFilter)
        //{
        //    var users = context.Users.Include(r => r.Role).Where(u => (string.IsNullOrEmpty(userFilter.Name) || u.Name == userFilter.Name)
        //                                                               && (userFilter.RoleID == null || u.RoleID == userFilter.RoleID.Value));
        //    return users;
        //}

        //public bool IsUserNameUnique(string username)
        //{
        //    return  !context.Users.Any(u => u.Name == username );
        //}

        //public void SaveUser(User user, bool isAccountCreated)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
