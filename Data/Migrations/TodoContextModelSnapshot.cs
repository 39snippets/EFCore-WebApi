﻿// <auto-generated />
using System;
using EFCore_WebApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EFCore_WebApi.Data.Migrations
{
    [DbContext(typeof(TodoContext))]
    partial class TodoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.12");

            modelBuilder.Entity("EFCore_WebApi.Models.Task", b =>
                {
                    b.Property<long>("TaskId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("ID");

                    b.Property<bool>("Done")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasDefaultValue(false)
                        .HasColumnName("DONE");

                    b.Property<DateTime>("DueDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasColumnName("DUE_DATE")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("Name")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasDefaultValue("(Nueva tarea sin nombre)")
                        .HasColumnName("NAME");

                    b.Property<long>("TaskPriorityId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("TASK_PRIORITY_ID");

                    b.HasKey("TaskId");

                    b.HasIndex("TaskPriorityId");

                    b.ToTable("TASK");
                });

            modelBuilder.Entity("EFCore_WebApi.Models.TaskPriority", b =>
                {
                    b.Property<long>("TaskPriorityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("ID");

                    b.Property<string>("Name")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasDefaultValue("(Nueva prioridad de tarea sin nombre)")
                        .HasColumnName("NAME");

                    b.HasKey("TaskPriorityId");

                    b.ToTable("TASK_PRIORITY");
                });

            modelBuilder.Entity("EFCore_WebApi.Models.Task", b =>
                {
                    b.HasOne("EFCore_WebApi.Models.TaskPriority", "TaskPriority")
                        .WithMany("Tasks")
                        .HasForeignKey("TaskPriorityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TaskPriority");
                });

            modelBuilder.Entity("EFCore_WebApi.Models.TaskPriority", b =>
                {
                    b.Navigation("Tasks");
                });
#pragma warning restore 612, 618
        }
    }
}
