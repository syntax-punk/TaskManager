﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TaskManager.Db;

#nullable disable

namespace TaskManager.Migrations
{
    [DbContext(typeof(TaskContext))]
    partial class TaskContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.11");

            modelBuilder.Entity("TaskManager.Models.TaskItemDto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("TaskItems");

                    b.HasData(
                        new
                        {
                            Id = new Guid("df8a9bd9-10b2-429f-b41c-9b7873ba32d6"),
                            CreatedAt = new DateTime(2024, 12, 29, 17, 15, 28, 795, DateTimeKind.Local).AddTicks(2620),
                            Description = "This is a dummy task",
                            DueDate = new DateTime(2025, 1, 5, 17, 15, 28, 795, DateTimeKind.Local).AddTicks(2640),
                            IsCompleted = false,
                            Name = "Test task"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
