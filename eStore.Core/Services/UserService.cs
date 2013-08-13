using eStore.Domain;
using System.Linq;
using eStore.Interfaces.Repositories;
using eStore.Interfaces.Services;
using System.Collections.ObjectModel;

namespace eStore.Core.Services
{
    internal class UserService : IUserService
    {
        private IUnitOfWork _uow;

        public UserService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        #region IUserService

        ReadOnlyCollection<User> IUserService.Users
        {
            get 
            {
                return _uow.UserRepository.GetAll().ToList().AsReadOnly();
            }
        }

        ReadOnlyCollection<Role> IUserService.Roles
        {
            get
            {
                return _uow.RoleRepository.GetAll().ToList().AsReadOnly();
            }
        }

        void IUserService.AddUser(User user)
        {
            // todo - handle unique and other exceptions
            _uow.UserRepository.Add(user);
        }

        #endregion
    }
}
