using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonDataModels
{
    public class JsonDataContext : DbContext
    {
        public JsonDataContext() : base("JsonDataContext")
        {
        }

        public DbSet<Person> People { get; set; }
        public DbSet<Friend> Friends { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Friend>()
            .HasRequired<Person>(s => s.Person)
            .WithMany(g => g.Friends)
            .HasForeignKey<int>(s => s.PersonId);

            modelBuilder.Entity<Person>()
            .HasMany<Friend>(g => g.Friends)
            .WithRequired(s => s.Person)
            .HasForeignKey<int>(s => s.PersonId);
          
        }
    }
}
