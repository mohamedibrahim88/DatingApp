using API.Entities;
using API.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class DataContext : IdentityDbContext< AppUser, 
    AppRole, int, 
    IdentityUserClaim<int>, AppUserRole,IdentityUserLogin<int>,
    IdentityRoleClaim<int>,IdentityUserToken<int>>

    {
        public DataContext( DbContextOptions options) : base(options)
        {
        }

        public DbSet <Message> Messages { get; set; }

        public DbSet<Group> Groups { get; set;}
        public DbSet<Connection> Connections { get; set; }


       protected override void OnModelCreating (ModelBuilder builder)
       {
           base.OnModelCreating(builder);

           builder.Entity<AppUser>()
           .HasMany(ur=> ur.UserRoles)
           .WithOne(u => u.user)
           .HasForeignKey(ur=> ur.UserId)
           .IsRequired();

           builder.Entity<AppRole>()
           .HasMany(ur=> ur.userRoles)
           .WithOne(u => u.Role)
           .HasForeignKey(ur=> ur.RoleId)
           .IsRequired();

           builder.Entity<Message>()
           .HasOne(u =>u.Recipient)
           .WithMany(m=> m.MessagesRecieved)
           .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Message>()
           .HasOne(u =>u.Sender)
           .WithMany(m=> m.MessagesSent)
           .OnDelete(DeleteBehavior.Restrict);

           
       }

    }
}