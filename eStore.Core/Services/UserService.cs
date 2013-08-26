using eStore.Domain;
using System.Linq;
using eStore.Interfaces.Repositories;
using eStore.Interfaces.Services;
using System.Collections.ObjectModel;

namespace eStore.Core.Services
{
    internal class UserService : BaseUoWService, IUserService
    {
        public UserService(IUnitOfWork uow) : base(uow)
        {
        }
        
        #region IUserService

        ReadOnlyCollection<User> IUserService.Users
        {
            get 
            {
                return UoW.UserRepository.GetAll().ToList().AsReadOnly();
            }
        }

        ReadOnlyCollection<Role> IUserService.Roles
        {
            get
            {
                return UoW.RoleRepository.GetAll().ToList().AsReadOnly();
            }
        }

        void IUserService.AddUser(User user)
        {
            // todo - handle unique and other exceptions
            UoW.UserRepository.Add(user);
            UoW.Save();
        }

        #endregion
    }
}
