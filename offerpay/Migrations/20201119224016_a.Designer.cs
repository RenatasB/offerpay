﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using offerpay.Models;

namespace offerpay.Migrations
{
    [DbContext(typeof(offerpaydbContext))]
    [Migration("20201119224016_a")]
    partial class a
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("offerpay.Models.Offer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nchar(100)")
                        .IsFixedLength(true)
                        .HasMaxLength(100);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nchar(100)")
                        .IsFixedLength(true)
                        .HasMaxLength(100);

                    b.Property<string>("Link")
                        .IsRequired()
                        .HasColumnType("nchar(100)")
                        .IsFixedLength(true)
                        .HasMaxLength(100);

                    b.Property<string>("LogoLocation")
                        .IsRequired()
                        .HasColumnType("nchar(100)")
                        .IsFixedLength(true)
                        .HasMaxLength(100);

                    b.Property<double>("Payout")
                        .HasColumnType("float");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nchar(100)")
                        .IsFixedLength(true)
                        .HasMaxLength(100);

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Offer");
                });

            modelBuilder.Entity("offerpay.Models.Reward", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Cost")
                        .HasColumnType("float");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nchar(100)")
                        .IsFixedLength(true)
                        .HasMaxLength(100);

                    b.Property<string>("PictureLocation")
                        .IsRequired()
                        .HasColumnType("nchar(100)")
                        .IsFixedLength(true)
                        .HasMaxLength(100);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nchar(100)")
                        .IsFixedLength(true)
                        .HasMaxLength(100);

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Reward");
                });

            modelBuilder.Entity("offerpay.Models.Transaction", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<double>("BalanceChange")
                        .HasColumnType("float");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Transaction");
                });

            modelBuilder.Entity("offerpay.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Balance")
                        .HasColumnType("float");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nchar(10)")
                        .IsFixedLength(true)
                        .HasMaxLength(10);

                    b.Property<string>("Last")
                        .IsRequired()
                        .HasColumnType("nchar(30)")
                        .IsFixedLength(true)
                        .HasMaxLength(30);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nchar(30)")
                        .IsFixedLength(true)
                        .HasMaxLength(30);

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("offerpay.Models.Offer", b =>
                {
                    b.HasOne("offerpay.Models.User", "User")
                        .WithMany("Offer")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_Offer_User")
                        .IsRequired();
                });

            modelBuilder.Entity("offerpay.Models.Reward", b =>
                {
                    b.HasOne("offerpay.Models.User", "User")
                        .WithMany("Reward")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_Reward_User")
                        .IsRequired();
                });

            modelBuilder.Entity("offerpay.Models.Transaction", b =>
                {
                    b.HasOne("offerpay.Models.User", "User")
                        .WithMany("Transaction")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_Transaction_User")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
