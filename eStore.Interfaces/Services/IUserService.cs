using eStore.Domain;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

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
    }
}
