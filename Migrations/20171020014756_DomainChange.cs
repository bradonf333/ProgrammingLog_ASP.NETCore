﻿using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ProgrammingLog.Migrations
{
    public partial class DomainChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProgrammingTaskId",
                table: "ProgrammingLanguages",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProgrammingLanguages_ProgrammingTaskId",
                table: "ProgrammingLanguages",
                column: "ProgrammingTaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProgrammingLanguages_Tasks_ProgrammingTaskId",
                table: "ProgrammingLanguages",
                column: "ProgrammingTaskId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProgrammingLanguages_Tasks_ProgrammingTaskId",
                table: "ProgrammingLanguages");

            migrationBuilder.DropIndex(
                name: "IX_ProgrammingLanguages_ProgrammingTaskId",
                table: "ProgrammingLanguages");

            migrationBuilder.DropColumn(
                name: "ProgrammingTaskId",
                table: "ProgrammingLanguages");
        }
    }
}
