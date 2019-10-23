﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RosterMe.Data;

namespace RosterMe.Migrations
{
    [DbContext(typeof(RosterMeContext))]
    [Migration("20191023233014_ForeingKeys_Added")]
    partial class ForeingKeys_Added
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RosterMe.Models.Entities.Availability", b =>
                {
                    b.Property<int>("AvailabilityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AvailableDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("AvailableFromTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("AvailableToTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.HasKey("AvailabilityId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Availability");
                });

            modelBuilder.Entity("RosterMe.Models.Entities.BookedShifts", b =>
                {
                    b.Property<int>("BookingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BookedTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("ShiftId")
                        .HasColumnType("int");

                    b.HasKey("BookingId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("ShiftId");

                    b.ToTable("BookedShifts");
                });

            modelBuilder.Entity("RosterMe.Models.Entities.Department", b =>
                {
                    b.Property<int>("DeptId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DeptName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DeptId");

                    b.ToTable("Department");
                });

            modelBuilder.Entity("RosterMe.Models.Entities.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Contract")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DOB")
                        .HasColumnType("datetime2");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("HourlySalary")
                        .HasColumnType("decimal(18, 0)");

                    b.Property<DateTime>("JoiningDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PhoneNumber")
                        .HasColumnType("int");

                    b.Property<string>("Position")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfilePicture")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ReportingManagerId")
                        .HasColumnType("int");

                    b.Property<string>("UserRole")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmployeeId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("RosterMe.Models.Entities.Login", b =>
                {
                    b.Property<int>("LoginId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LoginId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Login");
                });

            modelBuilder.Entity("RosterMe.Models.Entities.LoginTrail", b =>
                {
                    b.Property<int>("LoginTrailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("LogInId")
                        .HasColumnType("int");

                    b.Property<DateTime>("LogInTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LogOutTime")
                        .HasColumnType("datetime2");

                    b.HasKey("LoginTrailId");

                    b.HasIndex("LogInId");

                    b.ToTable("LoginTrail");
                });

            modelBuilder.Entity("RosterMe.Models.Entities.PasswordRequest", b =>
                {
                    b.Property<int>("RequestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("LoginId")
                        .HasColumnType("int");

                    b.Property<string>("NewPassword")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RequestDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RequestId");

                    b.HasIndex("LoginId");

                    b.ToTable("PasswordRequest");
                });

            modelBuilder.Entity("RosterMe.Models.Entities.Shift", b =>
                {
                    b.Property<int>("ShiftId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("FinishTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ShftCreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ShiftName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.HasKey("ShiftId");

                    b.ToTable("Shift");
                });

            modelBuilder.Entity("RosterMe.Models.Entities.ShiftInvitation", b =>
                {
                    b.Property<int>("InvitationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("InvitationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("InvitationStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NotificationStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ShiftId")
                        .HasColumnType("int");

                    b.HasKey("InvitationId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("ShiftId");

                    b.ToTable("ShiftInvitation");
                });

            modelBuilder.Entity("RosterMe.Models.Entities.Timesheets", b =>
                {
                    b.Property<int>("AttendanceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ApprovalStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("AttendanceDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("ShiftId")
                        .HasColumnType("int");

                    b.Property<DateTime>("TimeIn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("TimeOut")
                        .HasColumnType("datetime2");

                    b.HasKey("AttendanceId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("ShiftId");

                    b.ToTable("Timesheet");
                });

            modelBuilder.Entity("RosterMe.Models.Entities.Availability", b =>
                {
                    b.HasOne("RosterMe.Models.Entities.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RosterMe.Models.Entities.BookedShifts", b =>
                {
                    b.HasOne("RosterMe.Models.Entities.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RosterMe.Models.Entities.Shift", "Shift")
                        .WithMany()
                        .HasForeignKey("ShiftId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RosterMe.Models.Entities.Login", b =>
                {
                    b.HasOne("RosterMe.Models.Entities.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RosterMe.Models.Entities.LoginTrail", b =>
                {
                    b.HasOne("RosterMe.Models.Entities.Login", "LogIn")
                        .WithMany()
                        .HasForeignKey("LogInId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RosterMe.Models.Entities.PasswordRequest", b =>
                {
                    b.HasOne("RosterMe.Models.Entities.Login", "Login")
                        .WithMany()
                        .HasForeignKey("LoginId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RosterMe.Models.Entities.ShiftInvitation", b =>
                {
                    b.HasOne("RosterMe.Models.Entities.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RosterMe.Models.Entities.Shift", "Shift")
                        .WithMany()
                        .HasForeignKey("ShiftId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RosterMe.Models.Entities.Timesheets", b =>
                {
                    b.HasOne("RosterMe.Models.Entities.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RosterMe.Models.Entities.Shift", "Shift")
                        .WithMany()
                        .HasForeignKey("ShiftId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
