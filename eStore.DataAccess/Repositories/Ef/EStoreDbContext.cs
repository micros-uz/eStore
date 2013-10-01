using System.Data.Entity;
using eStore.Domain;
using eStore.DataAccess.Configurations;
using eStore.DataAccess.Configurations.Security;

namespace eStore.DataAccess.Repositories.Ef
{
    internal class EStoreDbContext : DbContext
    {
        public EStoreDbContext()
            : base(new ConnectionStringProvider().ConnectionString)
        {
        }

        public EStoreDbContext(string connStr)
            : base(connStr)
        {
        }

        public DbSet<Genre> Genres
        {
            get;
            set;
        }

        public DbSet<Author> Authors
        {
            get;
            set;
        }

        public DbSet<Book> Books
        {
            get;
            set;
        }

        public DbSet<Series> Series
        {
            get;
            set;
        }

        public DbSet<User> Users
        {
            get;
            set;
        }

        public DbSet<Role> Roles
        {
            get;
            set;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new RoleConfiguration());
            modelBuilder.Configurations.Add(new MembershipConfiguration());
            modelBuilder.Configurations.Add(new OAuthMembershipConfiguration());

            modelBuilder.Configurations.Add(new AuthorConfiguration());
            modelBuilder.Configurations.Add(new BookConfiguration());
            modelBuilder.Configurations.Add(new GenreConfiguration());
            modelBuilder.Configurations.Add(new SeriesConfiguration());
            modelBuilder.Configurations.Add(new UserConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
