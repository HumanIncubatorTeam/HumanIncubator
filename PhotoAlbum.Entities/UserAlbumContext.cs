namespace PhotoAlbum.Entities
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class UserAlbumContext : DbContext
    {
        public UserAlbumContext()
            : base("name=UserAlbumsDbContext")
        {
        }

        public virtual DbSet<Hashtags> Hashtags { get; set; }
        public virtual DbSet<ImageDescriptions> ImageDescriptions { get; set; }
        public virtual DbSet<Images> Images { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Statuses> Statuses { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hashtags>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Hashtags>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Hashtags>()
                .HasMany(e => e.ImageDescriptions)
                .WithMany(e => e.Hashtags)
                .Map(m => m.ToTable("ImagesDescriptionsHashtags").MapLeftKey("IdHashtag").MapRightKey("IdDescription"));

            modelBuilder.Entity<Images>()
                .Property(e => e.NameWithExtension)
                .IsUnicode(false);

            modelBuilder.Entity<Images>()
                .Property(e => e.UniqueName)
                .IsUnicode(false);

            modelBuilder.Entity<Images>()
                .HasMany(e => e.ImageDescriptions)
                .WithRequired(e => e.Images)
                .HasForeignKey(e => e.ImageId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Roles>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Roles>()
                .HasMany(e => e.Users)
                .WithMany(e => e.Roles)
                .Map(m => m.ToTable("UsersRoles").MapLeftKey("RoleId").MapRightKey("UserId"));

            modelBuilder.Entity<Statuses>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Statuses>()
                .HasMany(e => e.Images)
                .WithRequired(e => e.Statuses)
                .HasForeignKey(e => e.StatusId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Statuses>()
                .HasMany(e => e.Users)
                .WithRequired(e => e.Statuses)
                .HasForeignKey(e => e.StatusId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.Login)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.PasswordHash)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.PasswordSalt)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.E_mail)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.Skype)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.Images)
                .WithRequired(e => e.Users)
                .HasForeignKey(e => e.UserId)
                .WillCascadeOnDelete(false);
        }
    }
}
