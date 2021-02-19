﻿// <auto-generated />
using System;
using Cinema.Shows.Booking;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Cinema.Shows.Booking.Migrations
{
    [DbContext(typeof(CinemaDbContext))]
    [Migration("20210121204556_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("Cinema.Shows.Booking.Models.Booking", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<long?>("SeatId")
                        .HasColumnType("bigint");

                    b.Property<long?>("ShowId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("SeatId");

                    b.HasIndex("ShowId");

                    b.ToTable("Booking");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            SeatId = 1L,
                            ShowId = 1L
                        },
                        new
                        {
                            Id = 2L,
                            SeatId = 12L,
                            ShowId = 2L
                        },
                        new
                        {
                            Id = 3L,
                            SeatId = 21L,
                            ShowId = 3L
                        });
                });

            modelBuilder.Entity("Cinema.Shows.Booking.Models.Movie", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Movie");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Name = "Interstallar"
                        },
                        new
                        {
                            Id = 2L,
                            Name = "Lord Of the Rings (I, II, III)"
                        },
                        new
                        {
                            Id = 3L,
                            Name = "Harry Potter"
                        });
                });

            modelBuilder.Entity("Cinema.Shows.Booking.Models.Room", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Room");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Name = "ROOM I"
                        },
                        new
                        {
                            Id = 2L,
                            Name = "ROOM II"
                        },
                        new
                        {
                            Id = 3L,
                            Name = "ROOM III"
                        });
                });

            modelBuilder.Entity("Cinema.Shows.Booking.Models.Seat", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<long>("RoomId")
                        .HasColumnType("bigint");

                    b.Property<long>("RowNumber")
                        .HasColumnType("bigint");

                    b.Property<long>("SeatNumber")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("RoomId");

                    b.ToTable("Seat");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            RoomId = 1L,
                            RowNumber = 1L,
                            SeatNumber = 1L
                        },
                        new
                        {
                            Id = 2L,
                            RoomId = 1L,
                            RowNumber = 1L,
                            SeatNumber = 2L
                        },
                        new
                        {
                            Id = 3L,
                            RoomId = 1L,
                            RowNumber = 1L,
                            SeatNumber = 3L
                        },
                        new
                        {
                            Id = 4L,
                            RoomId = 1L,
                            RowNumber = 1L,
                            SeatNumber = 4L
                        },
                        new
                        {
                            Id = 5L,
                            RoomId = 1L,
                            RowNumber = 1L,
                            SeatNumber = 5L
                        },
                        new
                        {
                            Id = 6L,
                            RoomId = 1L,
                            RowNumber = 2L,
                            SeatNumber = 1L
                        },
                        new
                        {
                            Id = 7L,
                            RoomId = 1L,
                            RowNumber = 2L,
                            SeatNumber = 2L
                        },
                        new
                        {
                            Id = 8L,
                            RoomId = 1L,
                            RowNumber = 2L,
                            SeatNumber = 3L
                        },
                        new
                        {
                            Id = 9L,
                            RoomId = 1L,
                            RowNumber = 2L,
                            SeatNumber = 4L
                        },
                        new
                        {
                            Id = 10L,
                            RoomId = 1L,
                            RowNumber = 2L,
                            SeatNumber = 5L
                        },
                        new
                        {
                            Id = 11L,
                            RoomId = 2L,
                            RowNumber = 1L,
                            SeatNumber = 1L
                        },
                        new
                        {
                            Id = 12L,
                            RoomId = 2L,
                            RowNumber = 1L,
                            SeatNumber = 2L
                        },
                        new
                        {
                            Id = 13L,
                            RoomId = 2L,
                            RowNumber = 1L,
                            SeatNumber = 3L
                        },
                        new
                        {
                            Id = 14L,
                            RoomId = 2L,
                            RowNumber = 1L,
                            SeatNumber = 4L
                        },
                        new
                        {
                            Id = 15L,
                            RoomId = 2L,
                            RowNumber = 1L,
                            SeatNumber = 5L
                        },
                        new
                        {
                            Id = 16L,
                            RoomId = 2L,
                            RowNumber = 2L,
                            SeatNumber = 1L
                        },
                        new
                        {
                            Id = 17L,
                            RoomId = 2L,
                            RowNumber = 2L,
                            SeatNumber = 2L
                        },
                        new
                        {
                            Id = 18L,
                            RoomId = 2L,
                            RowNumber = 2L,
                            SeatNumber = 3L
                        },
                        new
                        {
                            Id = 19L,
                            RoomId = 2L,
                            RowNumber = 2L,
                            SeatNumber = 4L
                        },
                        new
                        {
                            Id = 20L,
                            RoomId = 2L,
                            RowNumber = 2L,
                            SeatNumber = 5L
                        },
                        new
                        {
                            Id = 21L,
                            RoomId = 3L,
                            RowNumber = 1L,
                            SeatNumber = 1L
                        },
                        new
                        {
                            Id = 22L,
                            RoomId = 3L,
                            RowNumber = 1L,
                            SeatNumber = 2L
                        },
                        new
                        {
                            Id = 23L,
                            RoomId = 3L,
                            RowNumber = 1L,
                            SeatNumber = 3L
                        },
                        new
                        {
                            Id = 24L,
                            RoomId = 3L,
                            RowNumber = 1L,
                            SeatNumber = 4L
                        },
                        new
                        {
                            Id = 25L,
                            RoomId = 3L,
                            RowNumber = 1L,
                            SeatNumber = 5L
                        },
                        new
                        {
                            Id = 26L,
                            RoomId = 3L,
                            RowNumber = 2L,
                            SeatNumber = 1L
                        },
                        new
                        {
                            Id = 27L,
                            RoomId = 3L,
                            RowNumber = 2L,
                            SeatNumber = 2L
                        },
                        new
                        {
                            Id = 28L,
                            RoomId = 3L,
                            RowNumber = 2L,
                            SeatNumber = 3L
                        },
                        new
                        {
                            Id = 29L,
                            RoomId = 3L,
                            RowNumber = 2L,
                            SeatNumber = 4L
                        },
                        new
                        {
                            Id = 30L,
                            RoomId = 3L,
                            RowNumber = 2L,
                            SeatNumber = 5L
                        });
                });

            modelBuilder.Entity("Cinema.Shows.Booking.Models.Show", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<long>("MovieId")
                        .HasColumnType("bigint");

                    b.Property<long>("RoomId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("MovieId");

                    b.HasIndex("RoomId");

                    b.ToTable("Show");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            EndTime = new DateTime(2021, 1, 21, 23, 45, 56, 245, DateTimeKind.Local).AddTicks(7516),
                            MovieId = 1L,
                            RoomId = 1L,
                            StartTime = new DateTime(2021, 1, 21, 21, 45, 56, 243, DateTimeKind.Local).AddTicks(6231)
                        },
                        new
                        {
                            Id = 2L,
                            EndTime = new DateTime(2021, 1, 22, 7, 45, 56, 245, DateTimeKind.Local).AddTicks(8053),
                            MovieId = 2L,
                            RoomId = 2L,
                            StartTime = new DateTime(2021, 1, 21, 21, 45, 56, 245, DateTimeKind.Local).AddTicks(8033)
                        },
                        new
                        {
                            Id = 3L,
                            EndTime = new DateTime(2021, 1, 22, 7, 45, 56, 245, DateTimeKind.Local).AddTicks(8066),
                            MovieId = 3L,
                            RoomId = 3L,
                            StartTime = new DateTime(2021, 1, 21, 21, 45, 56, 245, DateTimeKind.Local).AddTicks(8063)
                        });
                });

            modelBuilder.Entity("Cinema.Shows.Booking.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            Id = new Guid("efe8ef95-b030-452b-925f-7c2f69ce5c05"),
                            Name = "User 1"
                        },
                        new
                        {
                            Id = new Guid("8da6675b-c1de-4520-8e9c-b5678430883e"),
                            Name = "User 2"
                        },
                        new
                        {
                            Id = new Guid("91b63266-9e79-45a1-bd57-74a08ba621b7"),
                            Name = "User 3"
                        });
                });

            modelBuilder.Entity("Cinema.Shows.Booking.Models.UserBooking", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<long>("BookingId")
                        .HasColumnType("bigint");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("BookingId");

                    b.HasIndex("UserId");

                    b.ToTable("UserBooking");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            BookingId = 1L,
                            UserId = new Guid("efe8ef95-b030-452b-925f-7c2f69ce5c05")
                        },
                        new
                        {
                            Id = 2L,
                            BookingId = 2L,
                            UserId = new Guid("8da6675b-c1de-4520-8e9c-b5678430883e")
                        },
                        new
                        {
                            Id = 3L,
                            BookingId = 3L,
                            UserId = new Guid("91b63266-9e79-45a1-bd57-74a08ba621b7")
                        });
                });

            modelBuilder.Entity("Cinema.Shows.Booking.Models.Booking", b =>
                {
                    b.HasOne("Cinema.Shows.Booking.Models.Seat", "Seat")
                        .WithMany()
                        .HasForeignKey("SeatId");

                    b.HasOne("Cinema.Shows.Booking.Models.Show", "Show")
                        .WithMany()
                        .HasForeignKey("ShowId");

                    b.Navigation("Seat");

                    b.Navigation("Show");
                });

            modelBuilder.Entity("Cinema.Shows.Booking.Models.Seat", b =>
                {
                    b.HasOne("Cinema.Shows.Booking.Models.Room", "Room")
                        .WithMany("Seats")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Room");
                });

            modelBuilder.Entity("Cinema.Shows.Booking.Models.Show", b =>
                {
                    b.HasOne("Cinema.Shows.Booking.Models.Movie", "Movie")
                        .WithMany("Shows")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cinema.Shows.Booking.Models.Room", "Room")
                        .WithMany("Shows")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("Cinema.Shows.Booking.Models.UserBooking", b =>
                {
                    b.HasOne("Cinema.Shows.Booking.Models.Booking", "Booking")
                        .WithMany("UserBookings")
                        .HasForeignKey("BookingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cinema.Shows.Booking.Models.User", "User")
                        .WithMany("UserBookings")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Booking");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Cinema.Shows.Booking.Models.Booking", b =>
                {
                    b.Navigation("UserBookings");
                });

            modelBuilder.Entity("Cinema.Shows.Booking.Models.Movie", b =>
                {
                    b.Navigation("Shows");
                });

            modelBuilder.Entity("Cinema.Shows.Booking.Models.Room", b =>
                {
                    b.Navigation("Seats");

                    b.Navigation("Shows");
                });

            modelBuilder.Entity("Cinema.Shows.Booking.Models.User", b =>
                {
                    b.Navigation("UserBookings");
                });
#pragma warning restore 612, 618
        }
    }
}