using AZK.AutoAnalytics.DesktopClient.Repository.LocalStorage.DataTypes.DetailAnalysis;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace AZK.AutoAnalytics.DesktopClient.LocalStorage.LocalStorage.Repository
{
    public class LocalStorageDbContext : DbContext
    {
        private string _fileLocation;

        public LocalStorageDbContext(string fileLocation)
        {
            this._fileLocation = fileLocation;
        }

        //DetailAnalysis
        public virtual DbSet<TGroup> TGroups { get; set; }
        public virtual DbSet<TSubgroup> TSubgroups { get; set; }
        public virtual DbSet<TDetail> TDetails { get; set; }

        public virtual DbSet<TAssocRule> TAssocRules { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(
                "FileName=" + _fileLocation,
                (option) =>
                {
                    option.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
                });

            base.OnConfiguring(optionsBuilder);
        }
    }
}
