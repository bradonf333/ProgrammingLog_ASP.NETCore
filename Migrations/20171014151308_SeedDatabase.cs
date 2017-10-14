using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ProgrammingLog.Migrations
{
    public partial class SeedDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO ProgrammingLanguages (Language) VALUES ('C#')");
            migrationBuilder.Sql("INSERT INTO ProgrammingLanguages (Language) VALUES ('Angular 2')");
            migrationBuilder.Sql("INSERT INTO ProgrammingLanguages (Language) VALUES ('ASP.NET Core')");
            migrationBuilder.Sql("INSERT INTO ProgrammingLanguages (Language) VALUES ('JavaScript')");
            migrationBuilder.Sql("INSERT INTO ProgrammingLanguages (Language) VALUES ('HTML')");
            migrationBuilder.Sql("INSERT INTO ProgrammingLanguages (Language) VALUES ('CSS')");
            migrationBuilder.Sql("INSERT INTO ProgrammingLanguages (Language) VALUES ('Python')");

            migrationBuilder.Sql("INSERT INTO Tasks (Description, Hours, Summary, TaskDate) " + 
                "VALUES ('Worked on module 11 from Angular 2 PluralSight course.', 1.00, 'PluralSight Module', '08/01/2017')");
            migrationBuilder.Sql("INSERT INTO Tasks (Description, Hours, Summary, TaskDate) " + 
                "VALUES ('Completed 3/4 module on Navigation & Routing from PluralSight Angular 2 course.', 2.00, 'PluralSight Module', '08/02/2017')");
            migrationBuilder.Sql("INSERT INTO Tasks (Description, Hours, Summary, TaskDate) " + 
                "VALUES ('Completed 1 video from module. Summary and Checklist.', .50, 'PluralSight Module', '08/03/2017')");
            migrationBuilder.Sql("INSERT INTO Tasks (Description, Hours, Summary, TaskDate) " + 
                "VALUES ('Completed the Tribonacci sequence from CodeWars.', 1.00, 'Completed the Tribonacci sequence from CodeWars.', '08/04/2017')");
            migrationBuilder.Sql("INSERT INTO Tasks (Description, Hours, Summary, TaskDate) " + 
                "VALUES ('Created the product-detail component of Angular 2 App. Copied most of it. Deleted it so I could do it w/o copying most of it.', 3.00, 'Created Component in Angular 2', '08/05/2017')");
            migrationBuilder.Sql("INSERT INTO Tasks (Description, Hours, Summary, TaskDate) " + 
                "VALUES ('Started Module 13 in PluralSight Angular 2 course. - Angular Modules ', 1.00, 'PluralSight Module', '08/06/2017')");
            migrationBuilder.Sql("INSERT INTO Tasks (Description, Hours, Summary, TaskDate) " + 
                "VALUES ('Worked on Module 13, about 3/4 of the way done. Got the main part of my task scheduler app working in Angular 2.', 2.50, 'PluralSight Module. Started working on my first Angular App', '08/07/2017')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM ProgrammingLanguages WHERE Language IN ('C#','Angular 2','ASP.NET Core','JavaScript','HTML','CSS','Python'");
            migrationBuilder.Sql("DELETE FROM Tasks WHERE TaskDate BETWEEN '08/01/2017' AND '08/07/2017'");
        }
    }
}
