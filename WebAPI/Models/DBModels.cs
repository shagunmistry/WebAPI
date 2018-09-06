namespace WebAPI.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DBModels : DbContext
    {
        public DBModels()
            : base("name=DBModel")
        {
        }

        public virtual DbSet<InfoTable> InfoTables { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InfoTable>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<InfoTable>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<InfoTable>()
                .Property(e => e.StreetAddress)
                .IsUnicode(false);

            modelBuilder.Entity<InfoTable>()
                .Property(e => e.City)
                .IsUnicode(false);

            modelBuilder.Entity<InfoTable>()
                .Property(e => e.State)
                .IsUnicode(false);

            modelBuilder.Entity<InfoTable>()
                .Property(e => e.PhoneNumber)
                .IsUnicode(false);
        }
    }
}
