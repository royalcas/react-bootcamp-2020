﻿// <auto-generated />
using System;
using HealthApi.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HealthApi.Persistence.Migrations
{
    [DbContext(typeof(HealthAppContext))]
    [Migration("20200401021952_AddSuggestionSchemas")]
    partial class AddSuggestionSchemas
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3");

            modelBuilder.Entity("HealthApp.Domain.ActivitySuggestionByRisk", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("ActivityTopicId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("RiskId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ActivityTopicId");

                    b.HasIndex("RiskId");

                    b.ToTable("ActivitySuggestionsByRisk");
                });

            modelBuilder.Entity("HealthApp.Domain.HealthRisk", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.ToTable("HealthRisks");
                });

            modelBuilder.Entity("HealthApp.Domain.MedicalRecordItem", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<string>("Details")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Treatment")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("MedicalRecords");
                });

            modelBuilder.Entity("HealthApp.Domain.Medication", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(256);

                    b.Property<int>("Type")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Medications");
                });

            modelBuilder.Entity("HealthApp.Domain.Prescription", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("MedicalRecordItemId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("MedicationId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<float>("Quantity")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("MedicalRecordItemId");

                    b.HasIndex("MedicationId");

                    b.ToTable("Prescriptions");
                });

            modelBuilder.Entity("HealthApp.Domain.PreventionActivityTopic", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("Benefits")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(256);

                    b.Property<string>("Considerations")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(256);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.ToTable("PreventionActivityTopics");
                });

            modelBuilder.Entity("HealthApp.Domain.PreventionTip", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Tips");
                });

            modelBuilder.Entity("HealthApp.Domain.UserActivitySubscription", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("ActivityTopicId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ActivityTopicId");

                    b.HasIndex("UserId");

                    b.ToTable("UserActivitySubscriptions");
                });

            modelBuilder.Entity("HealthApp.Domain.UserIdentifiedRisk", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("RiskId")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RiskId");

                    b.HasIndex("UserId");

                    b.ToTable("UserIdentifiedRisks");
                });

            modelBuilder.Entity("HealthApp.Domain.UserProfile", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("AvatarUrl")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(256);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(256);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(256);

                    b.Property<int>("Gender")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("HealthApp.Domain.ActivitySuggestionByRisk", b =>
                {
                    b.HasOne("HealthApp.Domain.PreventionActivityTopic", "ActivityTopic")
                        .WithMany("RiskBasedSuggestions")
                        .HasForeignKey("ActivityTopicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HealthApp.Domain.HealthRisk", "Risk")
                        .WithMany("ActivityTopicSuggestions")
                        .HasForeignKey("RiskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HealthApp.Domain.MedicalRecordItem", b =>
                {
                    b.HasOne("HealthApp.Domain.UserProfile", "User")
                        .WithMany("MedicalRecord")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HealthApp.Domain.Prescription", b =>
                {
                    b.HasOne("HealthApp.Domain.MedicalRecordItem", "MedicalRecordItem")
                        .WithMany("Prescriptions")
                        .HasForeignKey("MedicalRecordItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HealthApp.Domain.Medication", "Medication")
                        .WithMany("Prescriptions")
                        .HasForeignKey("MedicationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HealthApp.Domain.UserActivitySubscription", b =>
                {
                    b.HasOne("HealthApp.Domain.PreventionActivityTopic", "ActivityTopic")
                        .WithMany("UserSubscriptions")
                        .HasForeignKey("ActivityTopicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HealthApp.Domain.UserProfile", "User")
                        .WithMany("ActivityTopicSubscriptions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HealthApp.Domain.UserIdentifiedRisk", b =>
                {
                    b.HasOne("HealthApp.Domain.HealthRisk", "Risk")
                        .WithMany()
                        .HasForeignKey("RiskId");

                    b.HasOne("HealthApp.Domain.UserProfile", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}
