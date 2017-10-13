﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using ProgrammingLog.Models;
using System;

namespace ProgrammingLog.Migrations
{
    [DbContext(typeof(TaskDbContext))]
    partial class TaskDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProgrammingLog.Models.ProgrammingLanguage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Language")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<int?>("TaskId");

                    b.HasKey("Id");

                    b.HasIndex("TaskId");

                    b.ToTable("ProgrammingLanguages");
                });

            modelBuilder.Entity("ProgrammingLog.Models.Task", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<double>("Hours");

                    b.Property<string>("Summary")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<DateTime>("TaskDate");

                    b.HasKey("Id");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("ProgrammingLog.Models.ProgrammingLanguage", b =>
                {
                    b.HasOne("ProgrammingLog.Models.Task")
                        .WithMany("Languages")
                        .HasForeignKey("TaskId");
                });
#pragma warning restore 612, 618
        }
    }
}
