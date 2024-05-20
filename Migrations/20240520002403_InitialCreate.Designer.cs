﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RESTAPI.Data;

#nullable disable

namespace RESTAPI.Migrations
{
    [DbContext(typeof(UsersTeachersAPITestDbContext))]
    [Migration("20240520002403_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RESTAPI.Data.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("DESCRIPTION");

                    b.Property<int>("TeacherId")
                        .HasColumnType("int")
                        .HasColumnName("TEACHER_ID");

                    b.HasKey("Id");

                    b.HasIndex("TeacherId");

                    b.ToTable("COURSES", (string)null);
                });

            modelBuilder.Entity("RESTAPI.Data.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("PHONE_NUMBER");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique()
                        .HasFilter("[UserId] IS NOT NULL");

                    b.ToTable("STUDENTS", (string)null);
                });

            modelBuilder.Entity("RESTAPI.Data.Teacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("PHONE_NUMBER");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique()
                        .HasFilter("[UserId] IS NOT NULL");

                    b.ToTable("TEACHERS", (string)null);
                });

            modelBuilder.Entity("RESTAPI.Data.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("EMAIL");

                    b.Property<string>("Firstname")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("FIRTNAME");

                    b.Property<string>("Lastname")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("LASTNAME");

                    b.Property<string>("Password")
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)")
                        .HasColumnName("PASSWORD");

                    b.Property<string>("UserRole")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("USER_ROLE");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Lastname" }, "IX_LASTNAME");

                    b.HasIndex(new[] { "Email" }, "UQ_EMAIL")
                        .IsUnique()
                        .HasFilter("[EMAIL] IS NOT NULL");

                    b.HasIndex(new[] { "Username" }, "UQ_USERNAME")
                        .IsUnique()
                        .HasFilter("[Username] IS NOT NULL");

                    b.ToTable("USERS", (string)null);
                });

            modelBuilder.Entity("STUDENTS_COURSES", b =>
                {
                    b.Property<int>("CoursesId")
                        .HasColumnType("int");

                    b.Property<int>("StudentsId")
                        .HasColumnType("int");

                    b.HasKey("CoursesId", "StudentsId");

                    b.HasIndex("StudentsId");

                    b.ToTable("STUDENTS_COURSES");
                });

            modelBuilder.Entity("RESTAPI.Data.Course", b =>
                {
                    b.HasOne("RESTAPI.Data.Teacher", "Teacher")
                        .WithMany("Courses")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_TEACHERS_COURSES");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("RESTAPI.Data.Student", b =>
                {
                    b.HasOne("RESTAPI.Data.User", "User")
                        .WithOne("Student")
                        .HasForeignKey("RESTAPI.Data.Student", "UserId")
                        .HasConstraintName("FK_STUDENTS_USERS");

                    b.Navigation("User");
                });

            modelBuilder.Entity("RESTAPI.Data.Teacher", b =>
                {
                    b.HasOne("RESTAPI.Data.User", "User")
                        .WithOne("Teacher")
                        .HasForeignKey("RESTAPI.Data.Teacher", "UserId")
                        .HasConstraintName("FK_TEACHERS_USERS");

                    b.Navigation("User");
                });

            modelBuilder.Entity("STUDENTS_COURSES", b =>
                {
                    b.HasOne("RESTAPI.Data.Course", null)
                        .WithMany()
                        .HasForeignKey("CoursesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RESTAPI.Data.Student", null)
                        .WithMany()
                        .HasForeignKey("StudentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RESTAPI.Data.Teacher", b =>
                {
                    b.Navigation("Courses");
                });

            modelBuilder.Entity("RESTAPI.Data.User", b =>
                {
                    b.Navigation("Student");

                    b.Navigation("Teacher");
                });
#pragma warning restore 612, 618
        }
    }
}
