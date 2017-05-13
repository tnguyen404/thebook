using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using TheBook.models;

namespace TheBook.Migrations
{
    [DbContext(typeof(BookContext))]
    [Migration("20170501065008_InitialDatabase")]
    partial class InitialDatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TheBook.models.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("AvailableUntil");

                    b.Property<string>("CarName")
                        .IsRequired();

                    b.Property<string>("CarNumber")
                        .IsRequired();

                    b.Property<bool>("IsAvailable");

                    b.Property<string>("Note");

                    b.Property<int>("SeatNumber");

                    b.Property<int?>("TripId");

                    b.HasKey("Id");

                    b.HasIndex("TripId");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("TheBook.models.RoleMember", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("RoleName")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("RoleMembers");
                });

            modelBuilder.Entity("TheBook.models.Stop", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("ArrivalDate");

                    b.Property<bool>("IsClosed");

                    b.Property<double>("Latitude");

                    b.Property<double>("Longitude");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Note");

                    b.Property<int>("Order");

                    b.Property<string>("StopStatus");

                    b.Property<int?>("TripId");

                    b.HasKey("Id");

                    b.HasIndex("TripId");

                    b.ToTable("Stops");
                });

            modelBuilder.Entity("TheBook.models.TeamMember", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AnotherContact");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("IdentityCardNumber")
                        .IsRequired();

                    b.Property<string>("MobileNumber")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Note");

                    b.Property<int?>("TripId");

                    b.Property<int?>("roleId");

                    b.HasKey("Id");

                    b.HasIndex("TripId");

                    b.HasIndex("roleId");

                    b.ToTable("TeamMembers");
                });

            modelBuilder.Entity("TheBook.models.Tracking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("CostsIncurred");

                    b.Property<DateTime>("DateCreated");

                    b.Property<int?>("FromStopId");

                    b.Property<double>("KilometerTotal");

                    b.Property<string>("Note");

                    b.Property<string>("TaskDescription");

                    b.Property<int?>("ToStopId");

                    b.HasKey("Id");

                    b.HasIndex("FromStopId");

                    b.HasIndex("ToStopId");

                    b.ToTable("Trackings");
                });

            modelBuilder.Entity("TheBook.models.Trip", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateCreadted");

                    b.Property<string>("Name");

                    b.Property<int>("Order");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.ToTable("Trips");
                });

            modelBuilder.Entity("TheBook.models.Car", b =>
                {
                    b.HasOne("TheBook.models.Trip")
                        .WithMany("Cars")
                        .HasForeignKey("TripId");
                });

            modelBuilder.Entity("TheBook.models.Stop", b =>
                {
                    b.HasOne("TheBook.models.Trip")
                        .WithMany("Stops")
                        .HasForeignKey("TripId");
                });

            modelBuilder.Entity("TheBook.models.TeamMember", b =>
                {
                    b.HasOne("TheBook.models.Trip")
                        .WithMany("TeamMembers")
                        .HasForeignKey("TripId");

                    b.HasOne("TheBook.models.RoleMember", "role")
                        .WithMany()
                        .HasForeignKey("roleId");
                });

            modelBuilder.Entity("TheBook.models.Tracking", b =>
                {
                    b.HasOne("TheBook.models.Stop", "FromStop")
                        .WithMany()
                        .HasForeignKey("FromStopId");

                    b.HasOne("TheBook.models.Stop", "ToStop")
                        .WithMany()
                        .HasForeignKey("ToStopId");
                });
        }
    }
}
