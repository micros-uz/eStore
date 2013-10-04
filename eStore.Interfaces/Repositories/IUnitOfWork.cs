using System;
using eStore.Domain;

namespace eStore.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<T> GetRepository<T>() where T : class;

        /*
        IGenericRepository<Genre> GenreRepository
        {
            get;
        }

        IGenericRepository<Author> AuthorRepository
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
        }*/

        void Save();
    }
}
