using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace McTours.DataAccess.Migrations
{
    public partial class BusTripMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BusTrip",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2(0)", nullable: false),
                    VehicleId = table.Column<int>(type: "int", nullable: false),
                    DepartureCityId = table.Column<int>(type: "int", nullable: false),
                    ArrivalCityId = table.Column<int>(type: "int", nullable: false),
                    EstimatedDuration = table.Column<int>(type: "int", nullable: false),
                    TicketPrice = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusTrip", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BusTrip_City_ArrivalCityId",
                        column: x => x.ArrivalCityId,
                        principalTable: "City",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BusTrip_City_DepartureCityId",
                        column: x => x.DepartureCityId,
                        principalTable: "City",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BusTrip_Vehicle_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicle",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Ağrı");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "Amasya");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 6,
                column: "Name",
                value: "Ankara");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 7,
                column: "Name",
                value: "Antalya");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 8,
                column: "Name",
                value: "Artvin");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 9,
                column: "Name",
                value: "Aydın");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 10,
                column: "Name",
                value: "Balıkesir");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 11,
                column: "Name",
                value: "Bilecik");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 12,
                column: "Name",
                value: "Bingöl");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 13,
                column: "Name",
                value: "Bitlis");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 14,
                column: "Name",
                value: "Bolu");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 15,
                column: "Name",
                value: "Burdur");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 16,
                column: "Name",
                value: "Bursa");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 17,
                column: "Name",
                value: "Çanakkale");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 18,
                column: "Name",
                value: "Çankırı");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 19,
                column: "Name",
                value: "Çorum");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 20,
                column: "Name",
                value: "Denizli");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 21,
                column: "Name",
                value: "Diyarbakır");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 22,
                column: "Name",
                value: "Edirne");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 23,
                column: "Name",
                value: "Elazığ");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 24,
                column: "Name",
                value: "Erzincan");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 25,
                column: "Name",
                value: "Erzurum");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 26,
                column: "Name",
                value: "Eskişehir");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 27,
                column: "Name",
                value: "Gaziantep");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 28,
                column: "Name",
                value: "Giresun");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 29,
                column: "Name",
                value: "Gümüşhane");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 30,
                column: "Name",
                value: "Hakkari");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 31,
                column: "Name",
                value: "Hatay");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 32,
                column: "Name",
                value: "Isparta");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 33,
                column: "Name",
                value: "Mersin");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 34,
                column: "Name",
                value: "İstanbul");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 35,
                column: "Name",
                value: "İzmir");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 36,
                column: "Name",
                value: "Kars");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 37,
                column: "Name",
                value: "Kastamonu");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 38,
                column: "Name",
                value: "Kayseri");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 39,
                column: "Name",
                value: "Kırklareli");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 40,
                column: "Name",
                value: "Kırşehir");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 41,
                column: "Name",
                value: "Kocaeli");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 42,
                column: "Name",
                value: "Konya");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 43,
                column: "Name",
                value: "Kütahya");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 44,
                column: "Name",
                value: "Malatya");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 45,
                column: "Name",
                value: "Manisa");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 46,
                column: "Name",
                value: "Kahramanmaraş");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 47,
                column: "Name",
                value: "Mardin");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 48,
                column: "Name",
                value: "Muğla");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 49,
                column: "Name",
                value: "Muş");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 50,
                column: "Name",
                value: "Nevşehir");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 51,
                column: "Name",
                value: "Niğde");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 52,
                column: "Name",
                value: "Ordu");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 53,
                column: "Name",
                value: "Rize");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 54,
                column: "Name",
                value: "Sakarya");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 55,
                column: "Name",
                value: "Samsun");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 56,
                column: "Name",
                value: "Siirt");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 57,
                column: "Name",
                value: "Sinop");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 58,
                column: "Name",
                value: "Sivas");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 59,
                column: "Name",
                value: "Tekirdağ");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 60,
                column: "Name",
                value: "Tokat");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 61,
                column: "Name",
                value: "Trabzon");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 62,
                column: "Name",
                value: "Tunceli");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 63,
                column: "Name",
                value: "Şanlıurfa");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 64,
                column: "Name",
                value: "Uşak");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 65,
                column: "Name",
                value: "Van");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 66,
                column: "Name",
                value: "Yozgat");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 67,
                column: "Name",
                value: "Zonguldak");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 68,
                column: "Name",
                value: "Aksaray");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 69,
                column: "Name",
                value: "Bayburt");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 70,
                column: "Name",
                value: "Karaman");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 71,
                column: "Name",
                value: "Kırıkkale");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 72,
                column: "Name",
                value: "Batman");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 73,
                column: "Name",
                value: "Şırnak");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 74,
                column: "Name",
                value: "Bartın");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 75,
                column: "Name",
                value: "Ardahan");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 76,
                column: "Name",
                value: "Iğdır");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 77,
                column: "Name",
                value: "Yalova");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 78,
                column: "Name",
                value: "Karabük");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 79,
                column: "Name",
                value: "Kilis");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 80,
                column: "Name",
                value: "Osmaniye");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 81,
                column: "Name",
                value: "Düzce");

            migrationBuilder.CreateIndex(
                name: "IX_BusTrip_ArrivalCityId",
                table: "BusTrip",
                column: "ArrivalCityId");

            migrationBuilder.CreateIndex(
                name: "IX_BusTrip_DepartureCityId",
                table: "BusTrip",
                column: "DepartureCityId");

            migrationBuilder.CreateIndex(
                name: "IX_BusTrip_VehicleId",
                table: "BusTrip",
                column: "VehicleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BusTrip");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Ağrı	");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "Amasya	");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 6,
                column: "Name",
                value: "Ankara	");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 7,
                column: "Name",
                value: "Antalya	");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 8,
                column: "Name",
                value: "Artvin	");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 9,
                column: "Name",
                value: "Aydın	");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 10,
                column: "Name",
                value: "Balıkesir	");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 11,
                column: "Name",
                value: "Bilecik	");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 12,
                column: "Name",
                value: "Bingöl	");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 13,
                column: "Name",
                value: "Bitlis	");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 14,
                column: "Name",
                value: "Bolu	");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 15,
                column: "Name",
                value: "Burdur	");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 16,
                column: "Name",
                value: "Bursa	");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 17,
                column: "Name",
                value: "Çanakkale	");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 18,
                column: "Name",
                value: "Çankırı	");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 19,
                column: "Name",
                value: "Çorum	");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 20,
                column: "Name",
                value: "Denizli	");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 21,
                column: "Name",
                value: "Diyarbakır	");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 22,
                column: "Name",
                value: "Edirne	");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 23,
                column: "Name",
                value: "Elazığ	");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 24,
                column: "Name",
                value: "Erzincan	");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 25,
                column: "Name",
                value: "Erzurum	");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 26,
                column: "Name",
                value: "Eskişehir	");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 27,
                column: "Name",
                value: "Gaziantep	");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 28,
                column: "Name",
                value: "Giresun	");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 29,
                column: "Name",
                value: "Gümüşhane	");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 30,
                column: "Name",
                value: "Hakkari	");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 31,
                column: "Name",
                value: "Hatay	");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 32,
                column: "Name",
                value: "Isparta	");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 33,
                column: "Name",
                value: "Mersin	");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 34,
                column: "Name",
                value: "İstanbul	");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 35,
                column: "Name",
                value: "İzmir	");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 36,
                column: "Name",
                value: "Kars	");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 37,
                column: "Name",
                value: "Kastamonu	");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 38,
                column: "Name",
                value: "Kayseri	");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 39,
                column: "Name",
                value: "Kırklareli	");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 40,
                column: "Name",
                value: "Kırşehir	");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 41,
                column: "Name",
                value: "Kocaeli	");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 42,
                column: "Name",
                value: "Konya	");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 43,
                column: "Name",
                value: "Kütahya	");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 44,
                column: "Name",
                value: "Malatya	");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 45,
                column: "Name",
                value: "Manisa	");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 46,
                column: "Name",
                value: "Kahramanmaraş	");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 47,
                column: "Name",
                value: "Mardin	");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 48,
                column: "Name",
                value: "Muğla	");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 49,
                column: "Name",
                value: "Muş	");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 50,
                column: "Name",
                value: "Nevşehir	");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 51,
                column: "Name",
                value: "Niğde	");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 52,
                column: "Name",
                value: "Ordu	");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 53,
                column: "Name",
                value: "Rize	");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 54,
                column: "Name",
                value: "Sakarya	");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 55,
                column: "Name",
                value: "Samsun	");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 56,
                column: "Name",
                value: "Siirt	");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 57,
                column: "Name",
                value: "Sinop	");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 58,
                column: "Name",
                value: "Sivas	");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 59,
                column: "Name",
                value: "Tekirdağ	");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 60,
                column: "Name",
                value: "Tokat	");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 61,
                column: "Name",
                value: "Trabzon	");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 62,
                column: "Name",
                value: "Tunceli	");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 63,
                column: "Name",
                value: "Şanlıurfa	");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 64,
                column: "Name",
                value: "Uşak	");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 65,
                column: "Name",
                value: "Van	");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 66,
                column: "Name",
                value: "Yozgat	");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 67,
                column: "Name",
                value: "Zonguldak	");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 68,
                column: "Name",
                value: "Aksaray	");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 69,
                column: "Name",
                value: "Bayburt	");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 70,
                column: "Name",
                value: "Karaman	");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 71,
                column: "Name",
                value: "Kırıkkale	");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 72,
                column: "Name",
                value: "Batman	");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 73,
                column: "Name",
                value: "Şırnak	");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 74,
                column: "Name",
                value: "Bartın	");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 75,
                column: "Name",
                value: "Ardahan	");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 76,
                column: "Name",
                value: "Iğdır	");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 77,
                column: "Name",
                value: "Yalova	");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 78,
                column: "Name",
                value: "Karabük	");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 79,
                column: "Name",
                value: "Kilis	");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 80,
                column: "Name",
                value: "Osmaniye	");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 81,
                column: "Name",
                value: "Düzce	");
        }
    }
}
