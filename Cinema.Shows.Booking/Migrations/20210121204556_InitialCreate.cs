using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cinema.Shows.Booking.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movie",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movie", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Seat",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RowNumber = table.Column<long>(type: "bigint", nullable: false),
                    SeatNumber = table.Column<long>(type: "bigint", nullable: false),
                    RoomId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Seat_Room_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Room",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Show",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomId = table.Column<long>(type: "bigint", nullable: false),
                    MovieId = table.Column<long>(type: "bigint", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Show", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Show_Movie_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Show_Room_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Room",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Booking",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShowId = table.Column<long>(type: "bigint", nullable: true),
                    SeatId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Booking_Seat_SeatId",
                        column: x => x.SeatId,
                        principalTable: "Seat",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Booking_Show_ShowId",
                        column: x => x.ShowId,
                        principalTable: "Show",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserBooking",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BookingId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserBooking", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserBooking_Booking_BookingId",
                        column: x => x.BookingId,
                        principalTable: "Booking",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserBooking_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Movie",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1L, "Interstallar" },
                    { 2L, "Lord Of the Rings (I, II, III)" },
                    { 3L, "Harry Potter" }
                });

            migrationBuilder.InsertData(
                table: "Room",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1L, "ROOM I" },
                    { 2L, "ROOM II" },
                    { 3L, "ROOM III" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("efe8ef95-b030-452b-925f-7c2f69ce5c05"), "User 1" },
                    { new Guid("8da6675b-c1de-4520-8e9c-b5678430883e"), "User 2" },
                    { new Guid("91b63266-9e79-45a1-bd57-74a08ba621b7"), "User 3" }
                });

            migrationBuilder.InsertData(
                table: "Seat",
                columns: new[] { "Id", "RoomId", "RowNumber", "SeatNumber" },
                values: new object[,]
                {
                    { 1L, 1L, 1L, 1L },
                    { 29L, 3L, 2L, 4L },
                    { 28L, 3L, 2L, 3L },
                    { 27L, 3L, 2L, 2L },
                    { 26L, 3L, 2L, 1L },
                    { 25L, 3L, 1L, 5L },
                    { 24L, 3L, 1L, 4L },
                    { 23L, 3L, 1L, 3L },
                    { 22L, 3L, 1L, 2L },
                    { 21L, 3L, 1L, 1L },
                    { 20L, 2L, 2L, 5L },
                    { 19L, 2L, 2L, 4L },
                    { 18L, 2L, 2L, 3L },
                    { 17L, 2L, 2L, 2L },
                    { 30L, 3L, 2L, 5L },
                    { 16L, 2L, 2L, 1L },
                    { 14L, 2L, 1L, 4L },
                    { 2L, 1L, 1L, 2L },
                    { 3L, 1L, 1L, 3L },
                    { 4L, 1L, 1L, 4L },
                    { 5L, 1L, 1L, 5L },
                    { 6L, 1L, 2L, 1L },
                    { 7L, 1L, 2L, 2L },
                    { 15L, 2L, 1L, 5L },
                    { 8L, 1L, 2L, 3L },
                    { 10L, 1L, 2L, 5L },
                    { 11L, 2L, 1L, 1L },
                    { 12L, 2L, 1L, 2L },
                    { 13L, 2L, 1L, 3L },
                    { 9L, 1L, 2L, 4L }
                });

            migrationBuilder.InsertData(
                table: "Show",
                columns: new[] { "Id", "EndTime", "MovieId", "RoomId", "StartTime" },
                values: new object[,]
                {
                    { 2L, new DateTime(2021, 1, 22, 7, 45, 56, 245, DateTimeKind.Local).AddTicks(8053), 2L, 2L, new DateTime(2021, 1, 21, 21, 45, 56, 245, DateTimeKind.Local).AddTicks(8033) },
                    { 1L, new DateTime(2021, 1, 21, 23, 45, 56, 245, DateTimeKind.Local).AddTicks(7516), 1L, 1L, new DateTime(2021, 1, 21, 21, 45, 56, 243, DateTimeKind.Local).AddTicks(6231) },
                    { 3L, new DateTime(2021, 1, 22, 7, 45, 56, 245, DateTimeKind.Local).AddTicks(8066), 3L, 3L, new DateTime(2021, 1, 21, 21, 45, 56, 245, DateTimeKind.Local).AddTicks(8063) }
                });

            migrationBuilder.InsertData(
                table: "Booking",
                columns: new[] { "Id", "SeatId", "ShowId" },
                values: new object[] { 1L, 1L, 1L });

            migrationBuilder.InsertData(
                table: "Booking",
                columns: new[] { "Id", "SeatId", "ShowId" },
                values: new object[] { 2L, 12L, 2L });

            migrationBuilder.InsertData(
                table: "Booking",
                columns: new[] { "Id", "SeatId", "ShowId" },
                values: new object[] { 3L, 21L, 3L });

            migrationBuilder.InsertData(
                table: "UserBooking",
                columns: new[] { "Id", "BookingId", "UserId" },
                values: new object[] { 1L, 1L, new Guid("efe8ef95-b030-452b-925f-7c2f69ce5c05") });

            migrationBuilder.InsertData(
                table: "UserBooking",
                columns: new[] { "Id", "BookingId", "UserId" },
                values: new object[] { 2L, 2L, new Guid("8da6675b-c1de-4520-8e9c-b5678430883e") });

            migrationBuilder.InsertData(
                table: "UserBooking",
                columns: new[] { "Id", "BookingId", "UserId" },
                values: new object[] { 3L, 3L, new Guid("91b63266-9e79-45a1-bd57-74a08ba621b7") });

            migrationBuilder.CreateIndex(
                name: "IX_Booking_SeatId",
                table: "Booking",
                column: "SeatId");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_ShowId",
                table: "Booking",
                column: "ShowId");

            migrationBuilder.CreateIndex(
                name: "IX_Seat_RoomId",
                table: "Seat",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Show_MovieId",
                table: "Show",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Show_RoomId",
                table: "Show",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_UserBooking_BookingId",
                table: "UserBooking",
                column: "BookingId");

            migrationBuilder.CreateIndex(
                name: "IX_UserBooking_UserId",
                table: "UserBooking",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserBooking");

            migrationBuilder.DropTable(
                name: "Booking");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Seat");

            migrationBuilder.DropTable(
                name: "Show");

            migrationBuilder.DropTable(
                name: "Movie");

            migrationBuilder.DropTable(
                name: "Room");
        }
    }
}
