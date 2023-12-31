﻿// <auto-generated />
using System;
using EngineeringServices.DataAccess.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EngineeringServices.DataAccess.Migrations
{
    [DbContext(typeof(EngineeringServicesDataContext))]
    partial class EngineeringServicesDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EngineeringServices.Model.Entities.Admin", b =>
                {
                    b.Property<int>("AdminId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AdminId"), 1L, 1);

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhotoPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AdminId");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("EngineeringServices.Model.Entities.Engineering", b =>
                {
                    b.Property<int>("EngineeringId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EngineeringId"), 1L, 1);

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EngineeringId");

                    b.ToTable("Engineerings");
                });

            modelBuilder.Entity("EngineeringServices.Model.Entities.Message", b =>
                {
                    b.Property<int>("MessageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MessageId"), 1L, 1);

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Subject")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MessageId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("EngineeringServices.Model.Entities.Note", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AdminId")
                        .HasColumnType("int");

                    b.Property<string>("Subject")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AdminId");

                    b.ToTable("Notes");
                });

            modelBuilder.Entity("EngineeringServices.Model.Entities.Person", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PersonId"), 1L, 1);

                    b.Property<int>("EngineeringId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhotoPath")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PersonId");

                    b.HasIndex("EngineeringId");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("EngineeringServices.Model.Entities.PersonalInformation", b =>
                {
                    b.Property<int>("PersonalInformationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PersonalInformationId"), 1L, 1);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("OpenAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhotoPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("University")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PersonalInformationId");

                    b.HasIndex("PersonId")
                        .IsUnique();

                    b.ToTable("PersonalInformations");
                });

            modelBuilder.Entity("EngineeringServices.Model.Entities.WorkInformation", b =>
                {
                    b.Property<int>("WorkInformationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WorkInformationId"), 1L, 1);

                    b.Property<int>("Day")
                        .HasColumnType("int");

                    b.Property<int>("Hour")
                        .HasColumnType("int");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<string>("Rank")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Wage")
                        .HasColumnType("int");

                    b.HasKey("WorkInformationId");

                    b.HasIndex("PersonId")
                        .IsUnique();

                    b.ToTable("WorkInformations");
                });

            modelBuilder.Entity("EngineeringServices.Model.Entities.Note", b =>
                {
                    b.HasOne("EngineeringServices.Model.Entities.Admin", "Admin")
                        .WithMany("Note")
                        .HasForeignKey("AdminId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Admin");
                });

            modelBuilder.Entity("EngineeringServices.Model.Entities.Person", b =>
                {
                    b.HasOne("EngineeringServices.Model.Entities.Engineering", "Engineering")
                        .WithMany("Person")
                        .HasForeignKey("EngineeringId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Engineering");
                });

            modelBuilder.Entity("EngineeringServices.Model.Entities.PersonalInformation", b =>
                {
                    b.HasOne("EngineeringServices.Model.Entities.Person", "Person")
                        .WithOne("PersonalInformation")
                        .HasForeignKey("EngineeringServices.Model.Entities.PersonalInformation", "PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("EngineeringServices.Model.Entities.WorkInformation", b =>
                {
                    b.HasOne("EngineeringServices.Model.Entities.Person", "Person")
                        .WithOne("WorkInformation")
                        .HasForeignKey("EngineeringServices.Model.Entities.WorkInformation", "PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("EngineeringServices.Model.Entities.Admin", b =>
                {
                    b.Navigation("Note");
                });

            modelBuilder.Entity("EngineeringServices.Model.Entities.Engineering", b =>
                {
                    b.Navigation("Person");
                });

            modelBuilder.Entity("EngineeringServices.Model.Entities.Person", b =>
                {
                    b.Navigation("PersonalInformation");

                    b.Navigation("WorkInformation");
                });
#pragma warning restore 612, 618
        }
    }
}
