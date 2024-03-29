﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using RV.Models;

#nullable disable

namespace RV.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("RV.Models.News", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<string>("content")
                        .IsRequired()
                        .HasMaxLength(2048)
                        .HasColumnType("character varying(2048)");

                    b.Property<DateTime>("created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("modified")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.Property<int>("userId")
                        .HasColumnType("integer");

                    b.HasKey("id");

                    b.HasIndex("title")
                        .IsUnique();

                    b.HasIndex("userId");

                    b.ToTable("tbl_News", t =>
                        {
                            t.HasCheckConstraint("len(content) < 4", "LENGTH(\"content\") > 4");

                            t.HasCheckConstraint("len(title) < 2", "LENGTH(\"title\") > 2");
                        });
                });

            modelBuilder.Entity("RV.Models.NewsSticker", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<int>("newsId")
                        .HasColumnType("integer");

                    b.Property<int>("stickerId")
                        .HasColumnType("integer");

                    b.HasKey("id");

                    b.HasIndex("newsId");

                    b.HasIndex("stickerId");

                    b.ToTable("tbl_NewsSticker", (string)null);
                });

            modelBuilder.Entity("RV.Models.Note", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<string>("content")
                        .IsRequired()
                        .HasMaxLength(2048)
                        .HasColumnType("character varying(2048)");

                    b.Property<int>("newsId")
                        .HasColumnType("integer");

                    b.HasKey("id");

                    b.HasIndex("newsId");

                    b.ToTable("tbl_Note", t =>
                        {
                            t.HasCheckConstraint("len(content) < 2", "LENGTH(\"content\") > 2");
                        });
                });

            modelBuilder.Entity("RV.Models.Sticker", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("character varying(32)");

                    b.HasKey("id");

                    b.HasIndex("name")
                        .IsUnique();

                    b.ToTable("tbl_Sticker", t =>
                        {
                            t.HasCheckConstraint("len(name) < 2", "LENGTH(\"name\") > 2");
                        });
                });

            modelBuilder.Entity("RV.Models.User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<string>("firstname")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.Property<string>("lastname")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.Property<string>("login")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.HasKey("id");

                    b.HasIndex("login")
                        .IsUnique();

                    b.ToTable("tbl_User", t =>
                        {
                            t.HasCheckConstraint("len(firstName) < 2", "LENGTH(\"firstName\") > 2");

                            t.HasCheckConstraint("len(lastName) < 2", "LENGTH(\"lastName\") > 2");

                            t.HasCheckConstraint("len(login) < 2", "LENGTH(\"login\") > 2");

                            t.HasCheckConstraint("len(password) < 8", "LENGTH(\"password\") > 8");
                        });
                });

            modelBuilder.Entity("RV.Models.News", b =>
                {
                    b.HasOne("RV.Models.User", "User")
                        .WithMany("News")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("RV.Models.NewsSticker", b =>
                {
                    b.HasOne("RV.Models.News", "News")
                        .WithMany("NewsStickers")
                        .HasForeignKey("newsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RV.Models.Sticker", "Sticker")
                        .WithMany("NewsStickers")
                        .HasForeignKey("stickerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("News");

                    b.Navigation("Sticker");
                });

            modelBuilder.Entity("RV.Models.Note", b =>
                {
                    b.HasOne("RV.Models.News", "New")
                        .WithMany("Notes")
                        .HasForeignKey("newsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("New");
                });

            modelBuilder.Entity("RV.Models.News", b =>
                {
                    b.Navigation("NewsStickers");

                    b.Navigation("Notes");
                });

            modelBuilder.Entity("RV.Models.Sticker", b =>
                {
                    b.Navigation("NewsStickers");
                });

            modelBuilder.Entity("RV.Models.User", b =>
                {
                    b.Navigation("News");
                });
#pragma warning restore 612, 618
        }
    }
}
