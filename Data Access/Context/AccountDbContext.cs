using Microsoft.EntityFrameworkCore;
using Models;
using System;

namespace Data_Access.Context
{
    public class AccountDbContext : DbContext
    {
        public string DbPath { get; }

        public AccountDbContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "accounts.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var ConnexionString = $"Data Source={DbPath}";
            options.UseSqlite(ConnexionString);
        }
     
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // default schema
            modelBuilder.HasDefaultSchema("data");

            // Account Table Specification
            modelBuilder.Entity<Account>()
                .ToTable("accounts");

            modelBuilder.Entity<Account>()
                .HasKey(account => account.Id)
                .HasName("pk_accounts");

            modelBuilder.Entity<Account>()
                .Property(account => account.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Account>()
                .Property(account => account.CreationDate)
                .HasDefaultValueSql("date('now')");

            modelBuilder.Entity<Account>()
                .Property(account => account.Balance)
                .HasDefaultValue(0);

            modelBuilder.Entity<Account>()
                .Property(account => account.IsLocked)
                .HasDefaultValue(false);

            modelBuilder.Entity<Account>()
                .Property(account => account.Rib)
                .IsRequired();

            modelBuilder.Entity<Account>()
                .HasData(new Account { Id = 1,Balance= 9800, Rib = 546987536 }
                , new Account { Id= 2, Balance= 1500, Rib= 125489639 }
                );

        }

        public DbSet<Account> Accounts { get; set; }

    }
}
