﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Group_Project_Chat_app.Migrations
{
    /// <inheritdoc />
    public partial class roles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Username",
                keyValue: "Admin",
                column: "Role",
                value: "[\"User\",\"Admin\"]");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Username",
                keyValue: "Admin",
                column: "Role",
                value: "Admin");
        }
    }
}
