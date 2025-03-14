﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence.Context;

namespace Persistence.Migrations
{
    [DbContext(typeof(CommoditiesDbContext))]
    partial class CommoditiesDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Entities.Commodity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Commodity");
                });

            modelBuilder.Entity("Domain.Entities.DailyMetrics", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Contract")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<long?>("ModelCommodityId")
                        .HasColumnType("bigint");

                    b.Property<int>("NewTradeAction")
                        .HasColumnType("int");

                    b.Property<decimal>("PnlDaily")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("ModelCommodityId");

                    b.ToTable("DailyMetrics");
                });

            modelBuilder.Entity("Domain.Entities.Model", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Model");
                });

            modelBuilder.Entity("Domain.Entities.ModelCommodity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("CommodityId")
                        .HasColumnType("bigint");

                    b.Property<int?>("ModelId")
                        .HasColumnType("int");

                    b.Property<decimal>("VarAllocation")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CommodityId");

                    b.HasIndex("ModelId");

                    b.ToTable("ModelCommodities");
                });

            modelBuilder.Entity("Domain.Entities.DailyMetrics", b =>
                {
                    b.HasOne("Domain.Entities.ModelCommodity", "ModelCommodity")
                        .WithMany("DailyMetrics")
                        .HasForeignKey("ModelCommodityId");
                });

            modelBuilder.Entity("Domain.Entities.ModelCommodity", b =>
                {
                    b.HasOne("Domain.Entities.Commodity", "Commodity")
                        .WithMany()
                        .HasForeignKey("CommodityId");

                    b.HasOne("Domain.Entities.Model", "Model")
                        .WithMany()
                        .HasForeignKey("ModelId");
                });
#pragma warning restore 612, 618
        }
    }
}
