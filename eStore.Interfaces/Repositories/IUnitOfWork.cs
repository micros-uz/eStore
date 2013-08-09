using eStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eStore.Interfaces.Repositories
{
    public interface IUnitOfWork
    {
        IGenericRepository<Genre> GenreRepository
        {
            get;
        }

        void Save();
    }
}
