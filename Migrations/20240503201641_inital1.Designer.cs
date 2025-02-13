﻿// <auto-generated />
using MainProgram.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MainProgram.Migrations
{
    [DbContext(typeof(itientities))]
    [Migration("20240503201641_inital1")]
    partial class inital1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MainProgram.Models.CrsResult", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("coure_id")
                        .HasColumnType("int");

                    b.Property<int>("degree")
                        .HasColumnType("int");

                    b.Property<int>("trainee_id")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("coure_id");

                    b.HasIndex("trainee_id");

                    b.ToTable("crsResults");
                });

            modelBuilder.Entity("MainProgram.Models.Department", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("manager")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("departments");
                });

            modelBuilder.Entity("MainProgram.Models.course", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("degree")
                        .HasColumnType("int");

                    b.Property<int>("dep_id")
                        .HasColumnType("int");

                    b.Property<int>("min_degree")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("dep_id");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("MainProgram.Models.instructor", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("course_id")
                        .HasColumnType("int");

                    b.Property<int>("department_id")
                        .HasColumnType("int");

                    b.Property<string>("image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("salary")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("course_id");

                    b.HasIndex("department_id");

                    b.ToTable("instructors");
                });

            modelBuilder.Entity("MainProgram.Models.trainee", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("dept_id")
                        .HasColumnType("int");

                    b.Property<string>("image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("level")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("dept_id");

                    b.ToTable("trainees");
                });

            modelBuilder.Entity("MainProgram.Models.CrsResult", b =>
                {
                    b.HasOne("MainProgram.Models.course", "course")
                        .WithMany("CrsResults")
                        .HasForeignKey("coure_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MainProgram.Models.trainee", "Trainee")
                        .WithMany("CrsResults")
                        .HasForeignKey("trainee_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Trainee");

                    b.Navigation("course");
                });

            modelBuilder.Entity("MainProgram.Models.course", b =>
                {
                    b.HasOne("MainProgram.Models.Department", "department")
                        .WithMany("Courses")
                        .HasForeignKey("dep_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("department");
                });

            modelBuilder.Entity("MainProgram.Models.instructor", b =>
                {
                    b.HasOne("MainProgram.Models.course", "course")
                        .WithMany("instructors")
                        .HasForeignKey("course_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MainProgram.Models.Department", "department")
                        .WithMany("Instructors")
                        .HasForeignKey("department_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("course");

                    b.Navigation("department");
                });

            modelBuilder.Entity("MainProgram.Models.trainee", b =>
                {
                    b.HasOne("MainProgram.Models.Department", "department")
                        .WithMany("Trainees")
                        .HasForeignKey("dept_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("department");
                });

            modelBuilder.Entity("MainProgram.Models.Department", b =>
                {
                    b.Navigation("Courses");

                    b.Navigation("Instructors");

                    b.Navigation("Trainees");
                });

            modelBuilder.Entity("MainProgram.Models.course", b =>
                {
                    b.Navigation("CrsResults");

                    b.Navigation("instructors");
                });

            modelBuilder.Entity("MainProgram.Models.trainee", b =>
                {
                    b.Navigation("CrsResults");
                });
#pragma warning restore 612, 618
        }
    }
}
