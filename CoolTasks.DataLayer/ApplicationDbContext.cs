using CoolTasks.DataLayer.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace CoolTasks.DataLayer
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public virtual DbSet<CoolTask> CoolTasks { get; set; }

        public virtual DbSet<Goal> Goals { get; set; }

        public virtual DbSet<CoolTaskPicture> CoolTaskPictures { get; set; }

        public virtual DbSet<TypeIcon> TypeIcons { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Entity<CoolTask>()
                .HasMany(b => b.Pictures)
                .WithRequired(bd => bd.CoolTask)
                .WillCascadeOnDelete();

            modelBuilder.Entity<CoolTask>()
                .Property(ct => ct.Caption).HasMaxLength(256);
            modelBuilder.Entity<Goal>()
                .Property(ct => ct.Caption).HasMaxLength(256);
            modelBuilder.Entity<CoolTaskPicture>()
                .Property(ct => ct.Url).HasMaxLength(256);
            modelBuilder.Entity<TypeIcon>()
                .Property(ct => ct.Url).HasMaxLength(256);
            modelBuilder.Entity<User>()
                .Property(ct => ct.PhotoUrl).HasMaxLength(256);

            modelBuilder.Entity<User>()
                .Property(ct => ct.Id).HasMaxLength(36);
            modelBuilder.Entity<IdentityRole>()
                .Property(ct => ct.Id).HasMaxLength(36);
            modelBuilder.Entity<IdentityUserRole>()
                .Property(ct => ct.RoleId).HasMaxLength(36);
            modelBuilder.Entity<IdentityUserRole>()
                .Property(ct => ct.UserId).HasMaxLength(36);
            modelBuilder.Entity<IdentityUserClaim>()
                .Property(ct => ct.UserId).HasMaxLength(36);
            modelBuilder.Entity<IdentityUserLogin>()
                .Property(ct => ct.UserId).HasMaxLength(36);

            modelBuilder.Entity<User>()
                .Ignore(ct => ct.PhoneNumber)
                .Ignore(ct => ct.PhoneNumberConfirmed)
                .Ignore(ct => ct.TwoFactorEnabled)
                .Ignore(ct => ct.LockoutEnabled)
                .Ignore(ct => ct.LockoutEndDateUtc)
                .Ignore(ct => ct.AccessFailedCount);

            base.OnModelCreating(modelBuilder);
        }
    }
}