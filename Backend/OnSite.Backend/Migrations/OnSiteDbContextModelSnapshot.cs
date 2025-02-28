﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OnSite.Backend.Models;

#nullable disable

namespace OnSite.Backend.Migrations
{
    [DbContext(typeof(OnSiteDbContext))]
    partial class OnSiteDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("OnSite.Backend.Models.Assignment", b =>
                {
                    b.Property<int>("AssignmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AssignmentId"));

                    b.Property<string>("AssignedRole")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EventId")
                        .HasColumnType("int");

                    b.Property<int?>("LaborerId")
                        .HasColumnType("int");

                    b.Property<int?>("LaborerId1")
                        .HasColumnType("int");

                    b.Property<int?>("SubEventId")
                        .HasColumnType("int");

                    b.Property<int?>("SupervisorId")
                        .HasColumnType("int");

                    b.HasKey("AssignmentId");

                    b.HasIndex("EventId");

                    b.HasIndex("LaborerId");

                    b.HasIndex("LaborerId1");

                    b.HasIndex("SubEventId");

                    b.HasIndex("SupervisorId");

                    b.ToTable("Assignment");
                });

            modelBuilder.Entity("OnSite.Backend.Models.Event", b =>
                {
                    b.Property<int>("EventId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EventId"));

                    b.Property<DateTime>("EventDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("QuoteDetails")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EventId");

                    b.ToTable("Event");
                });

            modelBuilder.Entity("OnSite.Backend.Models.Laborer", b =>
                {
                    b.Property<int>("LaborerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LaborerId"));

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LaborerId");

                    b.ToTable("Laborer");
                });

            modelBuilder.Entity("OnSite.Backend.Models.SubEvent", b =>
                {
                    b.Property<int>("SubEventId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SubEventId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SubEventId");

                    b.HasIndex("EventId");

                    b.ToTable("SubEvents");
                });

            modelBuilder.Entity("OnSite.Backend.Models.Supervisor", b =>
                {
                    b.Property<int>("SupervisorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SupervisorId"));

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SupervisorId");

                    b.ToTable("Supervisor");
                });

            modelBuilder.Entity("OnSite.Backend.Models.TimeSheet", b =>
                {
                    b.Property<int>("TimeSheetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TimeSheetId"));

                    b.Property<int>("AssignmentId")
                        .HasColumnType("int");

                    b.Property<decimal>("HoursWorked")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("WorkDate")
                        .HasColumnType("datetime2");

                    b.HasKey("TimeSheetId");

                    b.HasIndex("AssignmentId");

                    b.ToTable("TimeSheet");
                });

            modelBuilder.Entity("OnSite.Backend.Models.Assignment", b =>
                {
                    b.HasOne("OnSite.Backend.Models.Event", "Event")
                        .WithMany()
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("OnSite.Backend.Models.Laborer", "Laborer")
                        .WithMany()
                        .HasForeignKey("LaborerId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("OnSite.Backend.Models.Laborer", null)
                        .WithMany("Assignments")
                        .HasForeignKey("LaborerId1");

                    b.HasOne("OnSite.Backend.Models.SubEvent", "SubEvent")
                        .WithMany()
                        .HasForeignKey("SubEventId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("OnSite.Backend.Models.Supervisor", "Supervisor")
                        .WithMany("Assignments")
                        .HasForeignKey("SupervisorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Event");

                    b.Navigation("Laborer");

                    b.Navigation("SubEvent");

                    b.Navigation("Supervisor");
                });

            modelBuilder.Entity("OnSite.Backend.Models.SubEvent", b =>
                {
                    b.HasOne("OnSite.Backend.Models.Event", "Event")
                        .WithMany("SubEvents")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");
                });

            modelBuilder.Entity("OnSite.Backend.Models.TimeSheet", b =>
                {
                    b.HasOne("OnSite.Backend.Models.Assignment", "Assignment")
                        .WithMany("TimeSheets")
                        .HasForeignKey("AssignmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Assignment");
                });

            modelBuilder.Entity("OnSite.Backend.Models.Assignment", b =>
                {
                    b.Navigation("TimeSheets");
                });

            modelBuilder.Entity("OnSite.Backend.Models.Event", b =>
                {
                    b.Navigation("SubEvents");
                });

            modelBuilder.Entity("OnSite.Backend.Models.Laborer", b =>
                {
                    b.Navigation("Assignments");
                });

            modelBuilder.Entity("OnSite.Backend.Models.Supervisor", b =>
                {
                    b.Navigation("Assignments");
                });
#pragma warning restore 612, 618
        }
    }
}
