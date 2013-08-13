using eStore.Domain;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace eStore.Interfaces.Services
{
    public interface IUserService
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
