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

        void Save();
    }
}
