﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjectCore.Models;

#nullable disable

namespace ProjectCore.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20220726102743_MyCompanyDB1")]
    partial class MyCompanyDB1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ProjectCore.Models.Admin", b =>
                {
                    b.Property<int>("AdminID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AdminID"), 1L, 1);

                    b.Property<string>("Kullanici")
                        .IsRequired()
                        .HasColumnType("Varchar(20)");

                    b.Property<string>("Sifre")
                        .IsRequired()
                        .HasColumnType("Varchar(10)");

                    b.HasKey("AdminID");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("ProjectCore.Models.Birim", b =>
                {
                    b.Property<int>("BirimID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BirimID"), 1L, 1);

                    b.Property<string>("BirimAd")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BirimID");

                    b.ToTable("Birims");
                });

            modelBuilder.Entity("ProjectCore.Models.Personel", b =>
                {
                    b.Property<int>("PersonelID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PersonelID"), 1L, 1);

                    b.Property<string>("Ad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("BirimID")
                        .HasColumnType("int");

                    b.Property<string>("Sehir")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Soyad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PersonelID");

                    b.HasIndex("BirimID");

                    b.ToTable("Personels");
                });

            modelBuilder.Entity("ProjectCore.Models.Personel", b =>
                {
                    b.HasOne("ProjectCore.Models.Birim", "Birim")
                        .WithMany("Personels")
                        .HasForeignKey("BirimID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Birim");
                });

            modelBuilder.Entity("ProjectCore.Models.Birim", b =>
                {
                    b.Navigation("Personels");
                });
#pragma warning restore 612, 618
        }
    }
}