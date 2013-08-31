using System.Collections.ObjectModel;
using System.Linq;
using eStore.Domain;
using eStore.Interfaces.Repositories;
using eStore.Interfaces.Services;

namespace eStore.Core.Services
{
    internal class UserService : BaseUoWService, IUserService
    {
        public UserService(IUnitOfWork uow)
            : base(uow)
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

        void IUserService.DeleteUser(int userId)
        {
            var user = UoW.UserRepository.Find(x => x.UserId == userId).FirstOrDefault();

            if (user != null)
            {
                UoW.UserRepository.Delete(user);
                UoW.Save();
            }
        }

        #endregion
    }
}
