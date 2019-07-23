using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TechAndTools.Data.Migrations
{
    public partial class ChangeCategoryAndDescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Categories_CategoryId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryAddresses_AspNetUsers_UserId",
                table: "DeliveryAddresses");

            migrationBuilder.DropForeignKey(
                name: "FK_DescriptionAttributes_Descriptions_DescriptionId",
                table: "DescriptionAttributes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DescriptionAttributes",
                table: "DescriptionAttributes");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "DescriptionAttributes",
                newName: "DescriptionProperties");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "DeliveryAddresses",
                newName: "TechAndToolsUserId");

            migrationBuilder.RenameIndex(
                name: "IX_DeliveryAddresses_UserId",
                table: "DeliveryAddresses",
                newName: "IX_DeliveryAddresses_TechAndToolsUserId");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Categories",
                newName: "ParentCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Categories_CategoryId",
                table: "Categories",
                newName: "IX_Categories_ParentCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_DescriptionAttributes_DescriptionId",
                table: "DescriptionProperties",
                newName: "IX_DescriptionProperties_DescriptionId");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Suppliers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "Suppliers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Quarter",
                table: "DeliveryAddresses",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_DescriptionProperties",
                table: "DescriptionProperties",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Categories_ParentCategoryId",
                table: "Categories",
                column: "ParentCategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryAddresses_AspNetUsers_TechAndToolsUserId",
                table: "DeliveryAddresses",
                column: "TechAndToolsUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DescriptionProperties_Descriptions_DescriptionId",
                table: "DescriptionProperties",
                column: "DescriptionId",
                principalTable: "Descriptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Categories_ParentCategoryId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryAddresses_AspNetUsers_TechAndToolsUserId",
                table: "DeliveryAddresses");

            migrationBuilder.DropForeignKey(
                name: "FK_DescriptionProperties_Descriptions_DescriptionId",
                table: "DescriptionProperties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DescriptionProperties",
                table: "DescriptionProperties");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "Quarter",
                table: "DeliveryAddresses");

            migrationBuilder.RenameTable(
                name: "DescriptionProperties",
                newName: "DescriptionAttributes");

            migrationBuilder.RenameColumn(
                name: "TechAndToolsUserId",
                table: "DeliveryAddresses",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_DeliveryAddresses_TechAndToolsUserId",
                table: "DeliveryAddresses",
                newName: "IX_DeliveryAddresses_UserId");

            migrationBuilder.RenameColumn(
                name: "ParentCategoryId",
                table: "Categories",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Categories_ParentCategoryId",
                table: "Categories",
                newName: "IX_Categories_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_DescriptionProperties_DescriptionId",
                table: "DescriptionAttributes",
                newName: "IX_DescriptionAttributes_DescriptionId");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_DescriptionAttributes",
                table: "DescriptionAttributes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Categories_CategoryId",
                table: "Categories",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryAddresses_AspNetUsers_UserId",
                table: "DeliveryAddresses",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DescriptionAttributes_Descriptions_DescriptionId",
                table: "DescriptionAttributes",
                column: "DescriptionId",
                principalTable: "Descriptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
