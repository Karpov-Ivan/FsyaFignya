﻿// <auto-generated />
using FsyaFignya.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FsyaFignya.DataBase.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("FsyaFignya.DataBase.Models.Models.AgeByNameOrCountry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Age")
                        .HasColumnType("integer");

                    b.Property<string>("Country")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("AgeByNameOrCountry");
                });

            modelBuilder.Entity("FsyaFignya.DataBase.Models.Models.CountryNato", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("CountryName")
                        .HasColumnType("text");

                    b.Property<int>("DateOfEntry")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("CountryNato");
                });

            modelBuilder.Entity("FsyaFignya.DataBase.Models.Models.FactsAboutDogs", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("FactAboutDogs")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("FactsAboutDogs");
                });

            modelBuilder.Entity("FsyaFignya.DataBase.Models.Models.InformationAboutBitcoin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<double>("Price")
                        .HasColumnType("double precision");

                    b.Property<string>("RequestDate")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("InformationAboutBitcoin");
                });

            modelBuilder.Entity("FsyaFignya.DataBase.Models.Models.ListOfSeriesTitlesOfTheBigBangTheory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("SeriesName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("ListOfSeriesTitlesOfTheBigBangTheory");
                });
#pragma warning restore 612, 618
        }
    }
}
