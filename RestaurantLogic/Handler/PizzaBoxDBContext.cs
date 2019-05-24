using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PizzaBox.Data.Model
{
    public partial class PizzaBoxDBContext : DbContext
    {
        public PizzaBoxDBContext()
        {
        }

        public PizzaBoxDBContext(DbContextOptions<PizzaBoxDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Pizza> Pizza { get; set; }
        public virtual DbSet<PizzaToppings> PizzaToppings { get; set; }
        public virtual DbSet<Plocation> Plocation { get; set; }
        public virtual DbSet<Porder> Porder { get; set; }
        public virtual DbSet<Puser> Puser { get; set; }
        public virtual DbSet<Toppings> Toppings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=utageeks.database.windows.net;Database=PizzaBox;user id=FredBrume;Password=password;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.CUserId)
                    .HasName("PK__Customer__0FCEB2289C30CE9D");

                entity.Property(e => e.CUserId).HasColumnName("c_user_id");

                entity.Property(e => e.PUserId).HasColumnName("p_user_id");

                entity.HasOne(d => d.PUser)
                    .WithMany(p => p.Customer)
                    .HasForeignKey(d => d.PUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Customer__p_user__59FA5E80");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EUserId)
                    .HasName("PK__Employee__616961966DE8B29D");

                entity.Property(e => e.EUserId).HasColumnName("e_user_id");

                entity.Property(e => e.PUserId).HasColumnName("p_user_id");

                entity.Property(e => e.Position)
                    .IsRequired()
                    .HasColumnName("position")
                    .HasColumnType("text");

                entity.HasOne(d => d.PUser)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.PUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Employee__p_user__5CD6CB2B");
            });

            modelBuilder.Entity<Pizza>(entity =>
            {
                entity.Property(e => e.PizzaId).HasColumnName("pizza_id");

                entity.Property(e => e.Crust)
                    .IsRequired()
                    .HasColumnName("crust")
                    .HasColumnType("text");

                entity.Property(e => e.PPrice)
                    .IsRequired()
                    .HasColumnName("p_price")
                    .HasColumnType("text");

                entity.Property(e => e.PSize)
                    .IsRequired()
                    .HasColumnName("p_size")
                    .HasColumnType("text");

                entity.Property(e => e.PType)
                    .IsRequired()
                    .HasColumnName("p_type")
                    .HasColumnType("text");

                entity.Property(e => e.SLocationId).HasColumnName("S_location_id");

                entity.HasOne(d => d.SLocation)
                    .WithMany(p => p.Pizza)
                    .HasForeignKey(d => d.SLocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Pizza__S_locatio__52593CB8");
            });

            modelBuilder.Entity<PizzaToppings>(entity =>
            {
                entity.HasKey(e => e.PTopId)
                    .HasName("PK__Pizza_To__74D8129273CA71A1");

                entity.ToTable("Pizza_Toppings");

                entity.Property(e => e.PTopId).HasColumnName("p_top_id");

                entity.Property(e => e.PizzaId).HasColumnName("pizza_id");

                entity.Property(e => e.TopId).HasColumnName("top_id");

                entity.HasOne(d => d.Pizza)
                    .WithMany(p => p.PizzaToppings)
                    .HasForeignKey(d => d.PizzaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Pizza_Top__pizza__68487DD7");

                entity.HasOne(d => d.Top)
                    .WithMany(p => p.PizzaToppings)
                    .HasForeignKey(d => d.TopId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Pizza_Top__top_i__6754599E");
            });

            modelBuilder.Entity<Plocation>(entity =>
            {
                entity.HasKey(e => e.LocationId)
                    .HasName("PK__PLocatio__771831EA0A72653F");

                entity.ToTable("PLocation");

                entity.Property(e => e.LocationId).HasColumnName("location_id");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasColumnName("city")
                    .HasColumnType("text");

                entity.Property(e => e.PState)
                    .IsRequired()
                    .HasColumnName("p_state")
                    .HasColumnType("text");

                entity.Property(e => e.Street)
                    .IsRequired()
                    .HasColumnName("street")
                    .HasColumnType("text");

                entity.Property(e => e.Zipcode)
                    .IsRequired()
                    .HasColumnName("zipcode")
                    .HasColumnType("text");
            });

            modelBuilder.Entity<Porder>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("PK__POrder__46596229259A3C84");

                entity.ToTable("POrder");

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.CLocationId).HasColumnName("C_location_id");

                entity.Property(e => e.PDate)
                    .IsRequired()
                    .HasColumnName("p_date")
                    .HasColumnType("text");

                entity.Property(e => e.PTime)
                    .IsRequired()
                    .HasColumnName("p_time")
                    .HasColumnType("text");

                entity.Property(e => e.PUserId).HasColumnName("p_user_id");

                entity.Property(e => e.PizzaId).HasColumnName("pizza_id");

                entity.HasOne(d => d.CLocation)
                    .WithMany(p => p.Porder)
                    .HasForeignKey(d => d.CLocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__POrder__C_locati__571DF1D5");

                entity.HasOne(d => d.PUser)
                    .WithMany(p => p.Porder)
                    .HasForeignKey(d => d.PUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__POrder__p_user_i__5629CD9C");

                entity.HasOne(d => d.Pizza)
                    .WithMany(p => p.Porder)
                    .HasForeignKey(d => d.PizzaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__POrder__pizza_id__5535A963");
            });

            modelBuilder.Entity<Puser>(entity =>
            {
                entity.ToTable("PUser");

                entity.Property(e => e.PUserId).HasColumnName("p_user_id");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasColumnType("text");

                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasColumnName("firstname")
                    .HasColumnType("text");

                entity.Property(e => e.Lastname)
                    .IsRequired()
                    .HasColumnName("lastname")
                    .HasColumnType("text");

                entity.Property(e => e.LocationId).HasColumnName("location_Id");

                entity.Property(e => e.PPassword)
                    .IsRequired()
                    .HasColumnName("p_password")
                    .HasColumnType("text");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasColumnType("text");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Puser)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PUser__location___4BAC3F29");
            });

            modelBuilder.Entity<Toppings>(entity =>
            {
                entity.HasKey(e => e.TopId)
                    .HasName("PK__Toppings__B582A63D13BD9CCD");

                entity.Property(e => e.TopId).HasColumnName("top_id");

                entity.Property(e => e.Cost)
                    .IsRequired()
                    .HasColumnName("cost")
                    .HasColumnType("text");

                entity.Property(e => e.PizzaId).HasColumnName("pizza_id");

                entity.Property(e => e.TName)
                    .IsRequired()
                    .HasColumnName("t_name")
                    .HasColumnType("text");

                entity.HasOne(d => d.Pizza)
                    .WithMany(p => p.Toppings)
                    .HasForeignKey(d => d.PizzaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Toppings__pizza___6477ECF3");
            });
        }
    }
}
