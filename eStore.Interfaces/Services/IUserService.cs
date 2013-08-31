using System;
using System.Collections.ObjectModel;
using eStore.Domain;

namespace eStore.Interfaces.Services
{
    public interface IUserService : IDisposable
    {
        ReadOnlyCollection<Role> Roles
        {
            get;
        }
        ReadOnlyCollection<User> Users
        {
            get;
        }

        void AddUser(User user);
        void DeleteUser(int userId);
    }
}
