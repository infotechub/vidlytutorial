using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Vidly.Data.Migrations
{
     public partial class AddBirthdate : Migration
     {
         protected override void Up(MigrationBuilder migrationBuilder)
         {
             migrationBuilder.AddColumn<DateTime>(
                 name: "BirthDate",
                 table: "Customers",
                 nullable: false);
                
         }

         protected override void Down(MigrationBuilder migrationBuilder)
         {
             migrationBuilder.DropColumn(
                 name: "BirthDate",
                 table: "Customers");
         }
}
}
