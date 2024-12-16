﻿// <auto-generated />
using System;
using InternshipPlatform.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace InternshipPlatform.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20231118092447_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("InternshipPlatform.Models.Evaluation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("InternID")
                        .HasColumnType("int");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<int>("SupervisorID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("InternID");

                    b.HasIndex("SupervisorID");

                    b.ToTable("Evaluations");
                });

            modelBuilder.Entity("InternshipPlatform.Models.Intern", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("InternshipID")
                        .HasColumnType("int");

                    b.Property<string>("InternshipStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("InternshipsId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<int>("SupervisorID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("InternshipsId");

                    b.HasIndex("Number")
                        .IsUnique();

                    b.HasIndex("SupervisorID");

                    b.ToTable("Interns");
                });

            modelBuilder.Entity("InternshipPlatform.Models.InternshipCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("InternshipCategories");
                });

            modelBuilder.Entity("InternshipPlatform.Models.InternshipDocument", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Accessibility")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("InternshipsId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("InternshipsId");

                    b.ToTable("InternshipDocuments");
                });

            modelBuilder.Entity("InternshipPlatform.Models.InternshipProgress", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CompletedTasks")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("InternID")
                        .HasColumnType("int");

                    b.Property<int>("InternshipID")
                        .HasColumnType("int");

                    b.Property<string>("SkillsDeveloped")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("InternID")
                        .IsUnique();

                    b.HasIndex("InternshipID")
                        .IsUnique();

                    b.ToTable("InternshipProgress");
                });

            modelBuilder.Entity("InternshipPlatform.Models.Internships", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Duration")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberInterns")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Description")
                        .IsUnique();

                    b.HasIndex("Title")
                        .IsUnique();

                    b.ToTable("Internships");
                });

            modelBuilder.Entity("InternshipPlatform.Models.Supervisor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Department")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("InternsAssigned")
                        .HasColumnType("int");

                    b.Property<string>("JobTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<string>("SupervisorStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("Number")
                        .IsUnique();

                    b.ToTable("Supervisors");
                });

            modelBuilder.Entity("InternshipPlatform.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("RefreshTokenExpireTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ResetPasswordExpiry")
                        .HasColumnType("datetime2");

                    b.Property<string>("ResetPasswordToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Token")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasFilter("[Email] IS NOT NULL");

                    b.HasIndex("Username")
                        .IsUnique()
                        .HasFilter("[Username] IS NOT NULL");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("InternshipPlatform.Models.Evaluation", b =>
                {
                    b.HasOne("InternshipPlatform.Models.Intern", "Intern")
                        .WithMany("Evaluations")
                        .HasForeignKey("InternID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InternshipPlatform.Models.Supervisor", "Supervisor")
                        .WithMany("Evaluations")
                        .HasForeignKey("SupervisorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Intern");

                    b.Navigation("Supervisor");
                });

            modelBuilder.Entity("InternshipPlatform.Models.Intern", b =>
                {
                    b.HasOne("InternshipPlatform.Models.Internships", "Internships")
                        .WithMany("Interns")
                        .HasForeignKey("InternshipsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InternshipPlatform.Models.Supervisor", "Supervisor")
                        .WithMany("Interns")
                        .HasForeignKey("SupervisorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Internships");

                    b.Navigation("Supervisor");
                });

            modelBuilder.Entity("InternshipPlatform.Models.InternshipDocument", b =>
                {
                    b.HasOne("InternshipPlatform.Models.Internships", "Internships")
                        .WithMany("InternshipDocuments")
                        .HasForeignKey("InternshipsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Internships");
                });

            modelBuilder.Entity("InternshipPlatform.Models.InternshipProgress", b =>
                {
                    b.HasOne("InternshipPlatform.Models.Intern", "Intern")
                        .WithOne("InternshipProg")
                        .HasForeignKey("InternshipPlatform.Models.InternshipProgress", "InternID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InternshipPlatform.Models.Internships", "Internship")
                        .WithOne("InternshipProg")
                        .HasForeignKey("InternshipPlatform.Models.InternshipProgress", "InternshipID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Intern");

                    b.Navigation("Internship");
                });

            modelBuilder.Entity("InternshipPlatform.Models.Intern", b =>
                {
                    b.Navigation("Evaluations");

                    b.Navigation("InternshipProg")
                        .IsRequired();
                });

            modelBuilder.Entity("InternshipPlatform.Models.Internships", b =>
                {
                    b.Navigation("Interns");

                    b.Navigation("InternshipDocuments");

                    b.Navigation("InternshipProg")
                        .IsRequired();
                });

            modelBuilder.Entity("InternshipPlatform.Models.Supervisor", b =>
                {
                    b.Navigation("Evaluations");

                    b.Navigation("Interns");
                });
#pragma warning restore 612, 618
        }
    }
}
