namespace Admin
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class TipographyContext : DbContext
    {
        public TipographyContext()
            : base("name=TipographyString")
        {
        }

        public virtual DbSet<Callback> Callback { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Sketchs> Sketchs { get; set; }
        public virtual DbSet<TypeDelivery> TypeDelivery { get; set; }
        public virtual DbSet<TypesSketch> TypesSketch { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Authorization> Authorization { get; set; }
        public virtual DbSet<Table> Statistic { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Orders>()
                .Property(e => e.Size)
                .IsUnicode(false);

            modelBuilder.Entity<Orders>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Orders>()
                .Property(e => e.Sum)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Orders>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Sketchs>()
                .Property(e => e.Cost)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Sketchs>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.Sketchs)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TypeDelivery>()
                .Property(e => e.CostKm)
                .HasPrecision(19, 4);

            modelBuilder.Entity<TypeDelivery>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.TypeDelivery)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TypesSketch>()
                .HasMany(e => e.Sketchs)
                .WithRequired(e => e.TypesSketch)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.PhoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.Callback)
                .WithRequired(e => e.Users)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.Users)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.Authorization)
                .WithRequired(e => e.Users)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Authorization>()
                .Property(e => e.Login)
                .IsUnicode(false);

            modelBuilder.Entity<Authorization>()
                .Property(e => e.Password)
                .IsUnicode(false);
        }
    }
}
