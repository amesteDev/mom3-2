﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using records.Data;

namespace records.Migrations
{
    [DbContext(typeof(CollectionContext))]
    [Migration("20210228151033_FirstCreate")]
    partial class FirstCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.3");

            modelBuilder.Entity("records.Models.Artist", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Country")
                        .HasColumnType("TEXT");

                    b.HasKey("Name");

                    b.ToTable("Artist");
                });

            modelBuilder.Entity("records.Models.Borrower", b =>
                {
                    b.Property<int>("BorrowerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("BorrowDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("BorrowerName")
                        .HasColumnType("TEXT");

                    b.Property<int>("CollectionId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("BorrowerId");

                    b.ToTable("Borrower");
                });

            modelBuilder.Entity("records.Models.Collection", b =>
                {
                    b.Property<int>("CollectionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ArtistName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("CollectionId");

                    b.HasIndex("ArtistName");

                    b.ToTable("Collection");
                });

            modelBuilder.Entity("records.Models.Collection", b =>
                {
                    b.HasOne("records.Models.Artist", "Artist")
                        .WithMany("Collections")
                        .HasForeignKey("ArtistName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Artist");
                });

            modelBuilder.Entity("records.Models.Artist", b =>
                {
                    b.Navigation("Collections");
                });
#pragma warning restore 612, 618
        }
    }
}
