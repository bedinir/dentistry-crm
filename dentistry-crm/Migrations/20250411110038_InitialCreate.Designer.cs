﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repository;

#nullable disable

namespace dentistry_crm.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    [Migration("20250411110038_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.3");

            modelBuilder.Entity("Entities.Models.Appointment", b =>
                {
                    b.Property<Guid>("AppointmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("AppointmentDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("CancelledReason")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("DentistId")
                        .HasColumnType("TEXT");

                    b.Property<int?>("DurationInMinutes")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsFirstVisit")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.Property<Guid>("PatientId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Room")
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.HasKey("AppointmentId");

                    b.HasIndex("DentistId");

                    b.HasIndex("PatientId");

                    b.ToTable("Appointments", (string)null);
                });

            modelBuilder.Entity("Entities.Models.AppointmentTooth", b =>
                {
                    b.Property<Guid>("AppointmentId")
                        .HasColumnType("TEXT");

                    b.Property<int>("ToothNumber")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ProcedureDescription")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("TEXT");

                    b.HasKey("AppointmentId", "ToothNumber");

                    b.HasIndex("ToothNumber");

                    b.ToTable("AppointmentTooths", (string)null);
                });

            modelBuilder.Entity("Entities.Models.AppointmentTreatment", b =>
                {
                    b.Property<Guid>("AppointmentId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("TreatmentId")
                        .HasColumnType("TEXT");

                    b.HasKey("AppointmentId", "TreatmentId");

                    b.HasIndex("TreatmentId");

                    b.ToTable("AppointmentTreatments", (string)null);
                });

            modelBuilder.Entity("Entities.Models.Dentist", b =>
                {
                    b.Property<Guid>("DentistId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("TEXT");

                    b.Property<string>("Role")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT")
                        .HasDefaultValue("Dentist");

                    b.Property<string>("Specialization")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("DentistId");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Dentists", (string)null);
                });

            modelBuilder.Entity("Entities.Models.DentistTreatment", b =>
                {
                    b.Property<Guid>("DentistId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("TreatmentId")
                        .HasColumnType("TEXT");

                    b.HasKey("DentistId", "TreatmentId");

                    b.HasIndex("TreatmentId");

                    b.ToTable("DentistTreatments", (string)null);
                });

            modelBuilder.Entity("Entities.Models.Patient", b =>
                {
                    b.Property<Guid>("PatientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("TEXT");

                    b.HasKey("PatientId");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Patients", (string)null);
                });

            modelBuilder.Entity("Entities.Models.Tooth", b =>
                {
                    b.Property<int>("ToothNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("ToothNumber");

                    b.ToTable("Teeth");
                });

            modelBuilder.Entity("Entities.Models.Treatment", b =>
                {
                    b.Property<Guid>("TreatmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.Property<int?>("EstimatedDurationInMinutes")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("TreatmentId");

                    b.ToTable("Treatments", (string)null);
                });

            modelBuilder.Entity("Entities.Models.Appointment", b =>
                {
                    b.HasOne("Entities.Models.Dentist", "Dentist")
                        .WithMany("Appointments")
                        .HasForeignKey("DentistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Models.Patient", "Patient")
                        .WithMany("Appointments")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dentist");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("Entities.Models.AppointmentTooth", b =>
                {
                    b.HasOne("Entities.Models.Appointment", "Appointment")
                        .WithMany("TreatedTeeth")
                        .HasForeignKey("AppointmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Models.Tooth", "Tooth")
                        .WithMany()
                        .HasForeignKey("ToothNumber")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Appointment");

                    b.Navigation("Tooth");
                });

            modelBuilder.Entity("Entities.Models.AppointmentTreatment", b =>
                {
                    b.HasOne("Entities.Models.Appointment", "Appointment")
                        .WithMany("AppointmentTreatments")
                        .HasForeignKey("AppointmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Models.Treatment", "Treatment")
                        .WithMany("AppointmentTreatments")
                        .HasForeignKey("TreatmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Appointment");

                    b.Navigation("Treatment");
                });

            modelBuilder.Entity("Entities.Models.DentistTreatment", b =>
                {
                    b.HasOne("Entities.Models.Dentist", "Dentist")
                        .WithMany("DentistTreatments")
                        .HasForeignKey("DentistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Models.Treatment", "Treatment")
                        .WithMany("DentistTreatments")
                        .HasForeignKey("TreatmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dentist");

                    b.Navigation("Treatment");
                });

            modelBuilder.Entity("Entities.Models.Appointment", b =>
                {
                    b.Navigation("AppointmentTreatments");

                    b.Navigation("TreatedTeeth");
                });

            modelBuilder.Entity("Entities.Models.Dentist", b =>
                {
                    b.Navigation("Appointments");

                    b.Navigation("DentistTreatments");
                });

            modelBuilder.Entity("Entities.Models.Patient", b =>
                {
                    b.Navigation("Appointments");
                });

            modelBuilder.Entity("Entities.Models.Treatment", b =>
                {
                    b.Navigation("AppointmentTreatments");

                    b.Navigation("DentistTreatments");
                });
#pragma warning restore 612, 618
        }
    }
}
