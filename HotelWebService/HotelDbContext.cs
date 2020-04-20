namespace HotelWebService
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class HotelDbContext : DbContext
    {
        public HotelDbContext()
            : base("name=HotelDbContext")
        {
            base.Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<Facility> Facilities { get; set; }
        public virtual DbSet<Guest> Guests { get; set; }
        public virtual DbSet<Hotel> Hotels { get; set; }
        public virtual DbSet<HotelFacility> HotelFacilities { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<RoomType> RoomTypes { get; set; }
        public virtual DbSet<HotelView> HotelViews { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Facility>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Guest>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Guest>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<Guest>()
                .HasMany(e => e.Bookings)
                .WithRequired(e => e.Guest)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Hotel>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Hotel>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<Hotel>()
                .HasMany(e => e.Rooms)
                .WithRequired(e => e.Hotel)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Room>()
                .Property(e => e.RoomTypes_fk)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Room>()
                .HasMany(e => e.Bookings)
                .WithRequired(e => e.Room)
                .HasForeignKey(e => new { e.Room_No, e.Hotel_No })
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RoomType>()
                .Property(e => e.RoomType1)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<RoomType>()
                .HasMany(e => e.Rooms)
                .WithOptional(e => e.RoomType)
                .HasForeignKey(e => e.RoomTypes_fk);

            modelBuilder.Entity<HotelView>()
                .Property(e => e.HotelName)
                .IsUnicode(false);

            modelBuilder.Entity<HotelView>()
                .Property(e => e.GuestName)
                .IsUnicode(false);
        }
    }
}
