using eStore.Domain;
using System;

namespace eStore.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Genre> GenreRepository
        {
            get;
        }

        IGenericRepository<Book> BooksRepository
        {
            get;
        }

        IGenericRepository<User> UserRepository
        {
            get;
        }

        IGenericRepository<Role> RoleRepository
        {
            get;
        }

        void Save();
    }
}
