﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RSS.DAL.Context;

namespace RSS.DAL.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20181120153044_m02")]
    partial class m02
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RSS.Data.Model.RssFeed", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<bool>("IsRead");

                    b.Property<DateTime?>("PubDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title");

                    b.Property<int>("URLID");

                    b.HasKey("ID");

                    b.HasIndex("URLID");

                    b.ToTable("RssFeed");
                });

            modelBuilder.Entity("RSS.Data.Model.URL", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("Link");

                    b.Property<string>("Title");

                    b.HasKey("ID");

                    b.ToTable("URL");
                });

            modelBuilder.Entity("RSS.Data.Model.RssFeed", b =>
                {
                    b.HasOne("RSS.Data.Model.URL", "URL")
                        .WithMany("RSSFeeds")
                        .HasForeignKey("URLID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
