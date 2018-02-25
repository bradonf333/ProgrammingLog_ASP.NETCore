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
    [Migration("20180225034717_AddPhoto")]
    partial class AddPhoto
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProgrammingLog.Models.Photo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<int?>("ProgrammingTaskId");

                    b.HasKey("Id");

                    b.HasIndex("ProgrammingTaskId");

                    b.ToTable("Photo");
                });

            modelBuilder.Entity("ProgrammingLog.Models.ProgrammingLanguage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Language")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("ProgrammingLanguages");
                });

            modelBuilder.Entity("ProgrammingLog.Models.ProgrammingTask", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(850);

                    b.Property<double>("Hours");

                    b.Property<string>("Summary")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<DateTime>("TaskDate");

                    b.HasKey("Id");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("ProgrammingLog.Models.TaskLanguage", b =>
                {
                    b.Property<int>("TaskId");

                    b.Property<int>("LanguageId");

                    b.HasKey("TaskId", "LanguageId");

                    b.HasIndex("LanguageId");

                    b.ToTable("TaskLanguages");
                });

            modelBuilder.Entity("ProgrammingLog.Models.Photo", b =>
                {
                    b.HasOne("ProgrammingLog.Models.ProgrammingTask")
                        .WithMany("Photos")
                        .HasForeignKey("ProgrammingTaskId");
                });

            modelBuilder.Entity("ProgrammingLog.Models.TaskLanguage", b =>
                {
                    b.HasOne("ProgrammingLog.Models.ProgrammingLanguage", "Language")
                        .WithMany()
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ProgrammingLog.Models.ProgrammingTask", "Task")
                        .WithMany("ProgrammingLanguages")
                        .HasForeignKey("TaskId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
