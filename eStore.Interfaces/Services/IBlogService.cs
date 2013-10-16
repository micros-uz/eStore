using System.Collections.Generic;
using eStore.Domain.Blog;

namespace eStore.Interfaces.Services
{
    public interface IBlogService
    {
        IEnumerable<Article> GetArticles();
    }
}
