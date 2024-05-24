﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Booking.Commerce.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Booking.Commerce.Infrastructure.Migrations
{
    [DbContext(typeof(CommerceDbContext))]
    [Migration("20240419134220_AddPaymentType")]
    partial class AddPaymentType
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("commerce")
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Booking.Commerce.Domain.Entities.Payer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Payer", "commerce");
                });

            modelBuilder.Entity("Booking.Commerce.Domain.Entities.Payment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ExecutonTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("Method")
                        .HasColumnType("int");

                    b.Property<int>("PaymentType")
                        .HasColumnType("int");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.ComplexProperty<Dictionary<string, object>>("Amount", "Booking.Commerce.Domain.Entities.Payment.Amount#Money", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<double>("Ammount")
                                .HasColumnType("float");

                            b1.Property<int>("Currency")
                                .HasColumnType("int");
                        });

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Payment", "commerce");
                });

            modelBuilder.Entity("Booking.Commerce.Domain.Entities.Reservation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Reservation", "commerce");
                });

            modelBuilder.Entity("Booking.Commerce.Domain.Entities.ReservationInvoice", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("PayerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PaymentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ReservationId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PayerId");

                    b.HasIndex("PaymentId");

                    b.HasIndex("ReservationId")
                        .IsUnique();

                    b.ToTable("ReservationInvoice", "commerce");
                });

            modelBuilder.Entity("Booking.Commerce.Domain.Entities.Subscriber", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Subscriber", "commerce");
                });

            modelBuilder.Entity("Booking.Commerce.Domain.Entities.Subscription", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PlanId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<Guid>("SubscriberId")
                        .HasColumnType("uniqueidentifier");

                    b.ComplexProperty<Dictionary<string, object>>("SubscriptionPeriod", "Booking.Commerce.Domain.Entities.Subscription.SubscriptionPeriod#DateTimeSlot", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<DateTime>("End")
                                .HasColumnType("datetime2");

                            b1.Property<DateTime>("Start")
                                .HasColumnType("datetime2");
                        });

                    b.HasKey("Id");

                    b.HasIndex("PlanId");

                    b.HasIndex("SubscriberId");

                    b.ToTable("Subscription", "commerce");
                });

            modelBuilder.Entity("Booking.Commerce.Domain.Entities.SubscriptionInvoice", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("PaymentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("SubscriberId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SubscriptionId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PaymentId");

                    b.HasIndex("SubscriberId");

                    b.ToTable("SubscriptionInvoice", "commerce");
                });

            modelBuilder.Entity("Booking.Commerce.Domain.Entities.SubscriptionPlan", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccomodationLimit")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DurationInMonths")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SubscriptionPlan", "commerce");
                });

            modelBuilder.Entity("Booking.Commerce.Domain.Entities.Payment", b =>
                {
                    b.HasOne("Booking.Commerce.Domain.Entities.Subscription", null)
                        .WithMany("Payments")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Booking.Commerce.Domain.Entities.ReservationInvoice", b =>
                {
                    b.HasOne("Booking.Commerce.Domain.Entities.Payer", null)
                        .WithMany("Invoices")
                        .HasForeignKey("PayerId");

                    b.HasOne("Booking.Commerce.Domain.Entities.Payment", "Payment")
                        .WithMany()
                        .HasForeignKey("PaymentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Booking.BuildingBlocks.Domain.SharedKernel.ValueObjects.Money", "Price", b1 =>
                        {
                            b1.Property<Guid>("ReservationInvoiceId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<double>("Ammount")
                                .HasColumnType("float");

                            b1.Property<int>("Currency")
                                .HasColumnType("int");

                            b1.HasKey("ReservationInvoiceId");

                            b1.ToTable("ReservationInvoice", "commerce");

                            b1.WithOwner()
                                .HasForeignKey("ReservationInvoiceId");
                        });

                    b.OwnsOne("Booking.Commerce.Domain.ValueObjects.BookingFee", "BookingFee", b1 =>
                        {
                            b1.Property<Guid>("ReservationInvoiceId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<double>("BookingFeePercent")
                                .HasColumnType("float");

                            b1.Property<string>("MoneyToKeepByPlatfomr")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("ReservationInvoiceId");

                            b1.ToTable("ReservationInvoice", "commerce");

                            b1.WithOwner()
                                .HasForeignKey("ReservationInvoiceId");
                        });

                    b.Navigation("BookingFee")
                        .IsRequired();

                    b.Navigation("Payment");

                    b.Navigation("Price")
                        .IsRequired();
                });

            modelBuilder.Entity("Booking.Commerce.Domain.Entities.Subscription", b =>
                {
                    b.HasOne("Booking.Commerce.Domain.Entities.SubscriptionPlan", "Plan")
                        .WithMany()
                        .HasForeignKey("PlanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Booking.Commerce.Domain.Entities.Subscriber", null)
                        .WithMany("Subscriptions")
                        .HasForeignKey("SubscriberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Plan");
                });

            modelBuilder.Entity("Booking.Commerce.Domain.Entities.SubscriptionInvoice", b =>
                {
                    b.HasOne("Booking.Commerce.Domain.Entities.Payment", "Payment")
                        .WithMany()
                        .HasForeignKey("PaymentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Booking.Commerce.Domain.Entities.Subscriber", null)
                        .WithMany("Invoices")
                        .HasForeignKey("SubscriberId");

                    b.OwnsOne("Booking.BuildingBlocks.Domain.SharedKernel.ValueObjects.Money", "Price", b1 =>
                        {
                            b1.Property<Guid>("SubscriptionInvoiceId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<double>("Ammount")
                                .HasColumnType("float");

                            b1.Property<int>("Currency")
                                .HasColumnType("int");

                            b1.HasKey("SubscriptionInvoiceId");

                            b1.ToTable("SubscriptionInvoice", "commerce");

                            b1.WithOwner()
                                .HasForeignKey("SubscriptionInvoiceId");
                        });

                    b.Navigation("Payment");

                    b.Navigation("Price")
                        .IsRequired();
                });

            modelBuilder.Entity("Booking.Commerce.Domain.Entities.SubscriptionPlan", b =>
                {
                    b.OwnsOne("Booking.BuildingBlocks.Domain.SharedKernel.ValueObjects.Money", "Price", b1 =>
                        {
                            b1.Property<Guid>("SubscriptionPlanId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<double>("Ammount")
                                .HasColumnType("float");

                            b1.Property<int>("Currency")
                                .HasColumnType("int");

                            b1.HasKey("SubscriptionPlanId");

                            b1.ToTable("SubscriptionPlan", "commerce");

                            b1.WithOwner()
                                .HasForeignKey("SubscriptionPlanId");
                        });

                    b.Navigation("Price")
                        .IsRequired();
                });

            modelBuilder.Entity("Booking.Commerce.Domain.Entities.Payer", b =>
                {
                    b.Navigation("Invoices");
                });

            modelBuilder.Entity("Booking.Commerce.Domain.Entities.Subscriber", b =>
                {
                    b.Navigation("Invoices");

                    b.Navigation("Subscriptions");
                });

            modelBuilder.Entity("Booking.Commerce.Domain.Entities.Subscription", b =>
                {
                    b.Navigation("Payments");
                });
#pragma warning restore 612, 618
        }
    }
}
