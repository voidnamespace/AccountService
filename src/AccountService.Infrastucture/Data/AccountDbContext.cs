using Microsoft.EntityFrameworkCore;
using AccountService.Domain.Entity;
namespace AccountService.Infrastucture.Data;

public class AccountDbContext : DbContext
{
    public AccountDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Account> Accounts { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);



        modelBuilder.Entity<Account>(entity =>
        {

            entity.HasKey(u => u.Id);

            entity.Property(u => u.UserId)
            .IsRequired();

            entity.HasIndex(u => u.AccountNumber)
            .IsUnique();
            entity.Property(u => u.AccountNumber)
            .IsRequired()
            .HasMaxLength(12);

            entity.Property(u => u.Balance)
            .HasDefaultValue(0);

            entity.Property(u => u.CreatedAt)
            .IsRequired();

            entity.Property(u => u.UpdatedAt)
            .IsRequired();

            entity.Property(u => u.IsActive)
            .HasDefaultValue(true);

        });


    }


    }
