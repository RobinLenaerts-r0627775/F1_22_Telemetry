using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace f1Telemetry.Data.Migrations
{
    /// <inheritdoc />
    public partial class HeaderWithProps : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<uint>(
                name: "FrameIdentifier",
                table: "PacketHeaders",
                type: "int unsigned",
                nullable: false,
                defaultValue: 0u);

            migrationBuilder.AddColumn<sbyte>(
                name: "GameMajorVersion",
                table: "PacketHeaders",
                type: "tinyint",
                nullable: false,
                defaultValue: (sbyte)0);

            migrationBuilder.AddColumn<sbyte>(
                name: "GameMinorVersion",
                table: "PacketHeaders",
                type: "tinyint",
                nullable: false,
                defaultValue: (sbyte)0);

            migrationBuilder.AddColumn<ushort>(
                name: "PacketFormat",
                table: "PacketHeaders",
                type: "smallint unsigned",
                nullable: false,
                defaultValue: (ushort)0);

            migrationBuilder.AddColumn<sbyte>(
                name: "PacketId",
                table: "PacketHeaders",
                type: "tinyint",
                nullable: false,
                defaultValue: (sbyte)0);

            migrationBuilder.AddColumn<sbyte>(
                name: "PacketVersion",
                table: "PacketHeaders",
                type: "tinyint",
                nullable: false,
                defaultValue: (sbyte)0);

            migrationBuilder.AddColumn<sbyte>(
                name: "PlayerCarIndex",
                table: "PacketHeaders",
                type: "tinyint",
                nullable: false,
                defaultValue: (sbyte)0);

            migrationBuilder.AddColumn<sbyte>(
                name: "SecondaryPlayerCarIndex",
                table: "PacketHeaders",
                type: "tinyint",
                nullable: false,
                defaultValue: (sbyte)0);

            migrationBuilder.AddColumn<float>(
                name: "SessionTime",
                table: "PacketHeaders",
                type: "float",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<ulong>(
                name: "SessionUID",
                table: "PacketHeaders",
                type: "bigint unsigned",
                nullable: false,
                defaultValue: 0ul);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FrameIdentifier",
                table: "PacketHeaders");

            migrationBuilder.DropColumn(
                name: "GameMajorVersion",
                table: "PacketHeaders");

            migrationBuilder.DropColumn(
                name: "GameMinorVersion",
                table: "PacketHeaders");

            migrationBuilder.DropColumn(
                name: "PacketFormat",
                table: "PacketHeaders");

            migrationBuilder.DropColumn(
                name: "PacketId",
                table: "PacketHeaders");

            migrationBuilder.DropColumn(
                name: "PacketVersion",
                table: "PacketHeaders");

            migrationBuilder.DropColumn(
                name: "PlayerCarIndex",
                table: "PacketHeaders");

            migrationBuilder.DropColumn(
                name: "SecondaryPlayerCarIndex",
                table: "PacketHeaders");

            migrationBuilder.DropColumn(
                name: "SessionTime",
                table: "PacketHeaders");

            migrationBuilder.DropColumn(
                name: "SessionUID",
                table: "PacketHeaders");
        }
    }
}
