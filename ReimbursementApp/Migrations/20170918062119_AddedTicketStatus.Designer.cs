﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using ReimbursementApp.DbContext;
using ReimbursementApp.Model;
using System;

namespace ReimbursementApp.Migrations
{
    [DbContext(typeof(ExpenseReviewDbContext))]
    [Migration("20170918062119_AddedTicketStatus")]
    partial class AddedTicketStatus
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ReimbursementApp.Model.Approver", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ApprovedDate")
                        .IsRequired();

                    b.Property<int>("ApproverId");

                    b.Property<int>("ExpenseId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.Property<string>("Remarks")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("ExpenseId")
                        .IsUnique();

                    b.ToTable("Approvers");
                });

            modelBuilder.Entity("ReimbursementApp.Model.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("EmployeeId");

                    b.Property<string>("EmployeeName")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.HasKey("Id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("ReimbursementApp.Model.Expense", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Amount");

                    b.Property<int?>("EmployeesId");

                    b.Property<string>("ExpenseDate")
                        .IsRequired();

                    b.Property<string>("ExpenseDetails")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.Property<int?>("StatusId");

                    b.Property<string>("SubmitDate")
                        .IsRequired();

                    b.Property<double>("TotalAmount");

                    b.HasKey("Id");

                    b.HasIndex("EmployeesId");

                    b.HasIndex("StatusId");

                    b.ToTable("Expenses");
                });

            modelBuilder.Entity("ReimbursementApp.Model.TicketStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("State");

                    b.HasKey("Id");

                    b.ToTable("TicketStatuses");
                });

            modelBuilder.Entity("ReimbursementApp.Model.Approver", b =>
                {
                    b.HasOne("ReimbursementApp.Model.Expense")
                        .WithOne("Approvers")
                        .HasForeignKey("ReimbursementApp.Model.Approver", "ExpenseId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ReimbursementApp.Model.Expense", b =>
                {
                    b.HasOne("ReimbursementApp.Model.Employee", "Employees")
                        .WithMany()
                        .HasForeignKey("EmployeesId");

                    b.HasOne("ReimbursementApp.Model.TicketStatus", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId");
                });
#pragma warning restore 612, 618
        }
    }
}
