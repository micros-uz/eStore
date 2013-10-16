using System.Collections.ObjectModel;
using System.Linq;
using eStore.Domain.Security;
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

        User IUserService.GetUserById(int id)
        {
            return UoW.GetRepository<User>().GetById(id);
        }

        ReadOnlyCollection<User> IUserService.Users
        {
            get
            {
                return UoW.GetRepository<User>().GetAll().ToList().AsReadOnly();
            }
        }

        ReadOnlyCollection<Role> IUserService.Roles
        {
            get
            {
                return UoW.GetRepository<Role>().GetAll().ToList().AsReadOnly();
            }
        }

        void IUserService.AddUser(User user)
        {
            // todo - handle unique and other exceptions
            UoW.GetRepository<User>().Add(user);
            UoW.Save();
        }

        void IUserService.DeleteUser(int userId)
        {
            UoW.GetRepository<User>().Delete(userId);
            UoW.Save();
        }

        #endregion
    }
}
