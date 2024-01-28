﻿// <auto-generated />
using System;
using Helpdesk.Core.Enums;
using Helpdesk.Infrastructure.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Helpdesk.Infrastructure.Migrations
{
    [DbContext(typeof(HelpdeskDbContext))]
    partial class HelpdeskDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Helpdesk.Core.Entities.Ticket", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<CategoriesEnum?>("Category")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("ClosedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Content")
                        .HasColumnType("text");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("CreatorId")
                        .HasColumnType("uuid");

                    b.Property<StatesEnum?>("State")
                        .HasColumnType("integer");

                    b.Property<StatusesEnum?>("Status")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Tickets");
                });
#pragma warning restore 612, 618
        }
    }
}
