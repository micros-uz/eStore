using eStore.Domain;

namespace eStore.Interfaces.Repositories
{
    public interface IUnitOfWork
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
