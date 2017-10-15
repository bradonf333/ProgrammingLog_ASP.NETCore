using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ProgrammingLog.Migrations
{
    public partial class SeedTaskLanguages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO TaskLanguages (TaskId, LanguageId) VALUES (1, 2)");
            migrationBuilder.Sql("INSERT INTO TaskLanguages (TaskId, LanguageId) VALUES (2, 2)");
            migrationBuilder.Sql("INSERT INTO TaskLanguages (TaskId, LanguageId) VALUES (3, 2)");
            migrationBuilder.Sql("INSERT INTO TaskLanguages (TaskId, LanguageId) VALUES (4, 1)");
            migrationBuilder.Sql("INSERT INTO TaskLanguages (TaskId, LanguageId) VALUES (5, 2)");
            migrationBuilder.Sql("INSERT INTO TaskLanguages (TaskId, LanguageId) VALUES (6, 2)");
            migrationBuilder.Sql("INSERT INTO TaskLanguages (TaskId, LanguageId) VALUES (7, 2)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM TaskLanguages WHERE TaskId IN (1, 2, 3, 4, 5, 6, 7)");
        }
    }
}
