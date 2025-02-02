﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PokemonCadastro.Context;

#nullable disable

namespace PokemonCadastro.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240702165146_AjusteDeColunaOwnerNOVAMENTE")]
    partial class AjusteDeColunaOwnerNOVAMENTE
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PokemonCadastro.Model.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("PokemonCadastro.Model.Country", b =>
                {
                    b.Property<int>("CountryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CountryId"));

                    b.Property<string>("CountryName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CountryId");

                    b.ToTable("Country");
                });

            modelBuilder.Entity("PokemonCadastro.Model.Owner", b =>
                {
                    b.Property<int>("OwnerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OwnerId"));

                    b.Property<int?>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gym")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OwnerId");

                    b.HasIndex("CountryId");

                    b.ToTable("Owners");
                });

            modelBuilder.Entity("PokemonCadastro.Model.PokemonCategoryJoin", b =>
                {
                    b.Property<int>("PokemonId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.HasKey("PokemonId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("PokemonCategories");
                });

            modelBuilder.Entity("PokemonCadastro.Model.PokemonModel", b =>
                {
                    b.Property<int>("PokemonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PokemonId"));

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PokemonDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PokemonName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PokemonId");

                    b.ToTable("Pokemons");
                });

            modelBuilder.Entity("PokemonCadastro.Model.PokemonOwnerJoin", b =>
                {
                    b.Property<int>("PokemonId")
                        .HasColumnType("int");

                    b.Property<int>("OwnerId")
                        .HasColumnType("int");

                    b.Property<int>("OwnersOwnerId")
                        .HasColumnType("int");

                    b.HasKey("PokemonId", "OwnerId");

                    b.HasIndex("OwnerId");

                    b.HasIndex("OwnersOwnerId");

                    b.ToTable("PokemonOwners");
                });

            modelBuilder.Entity("PokemonCadastro.Model.Review", b =>
                {
                    b.Property<int>("ReviewId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReviewId"));

                    b.Property<int?>("PokemonsPokemonId")
                        .HasColumnType("int");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<string>("ReviewText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReviewTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ReviewerId")
                        .HasColumnType("int");

                    b.HasKey("ReviewId");

                    b.HasIndex("PokemonsPokemonId");

                    b.HasIndex("ReviewerId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("PokemonCadastro.Model.Reviewer", b =>
                {
                    b.Property<int>("ReviewerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReviewerId"));

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ReviewerId");

                    b.ToTable("Reviewers");
                });

            modelBuilder.Entity("PokemonCadastro.Model.Owner", b =>
                {
                    b.HasOne("PokemonCadastro.Model.Country", "Country")
                        .WithMany("Owners")
                        .HasForeignKey("CountryId");

                    b.Navigation("Country");
                });

            modelBuilder.Entity("PokemonCadastro.Model.PokemonCategoryJoin", b =>
                {
                    b.HasOne("PokemonCadastro.Model.Category", "Category")
                        .WithMany("PokemonCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PokemonCadastro.Model.PokemonModel", "Pokemon")
                        .WithMany("PokemonCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Pokemon");
                });

            modelBuilder.Entity("PokemonCadastro.Model.PokemonOwnerJoin", b =>
                {
                    b.HasOne("PokemonCadastro.Model.PokemonModel", "Pokemon")
                        .WithMany("PokemonOwners")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PokemonCadastro.Model.Owner", "Owners")
                        .WithMany("PokemonOwner")
                        .HasForeignKey("OwnersOwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owners");

                    b.Navigation("Pokemon");
                });

            modelBuilder.Entity("PokemonCadastro.Model.Review", b =>
                {
                    b.HasOne("PokemonCadastro.Model.PokemonModel", "Pokemons")
                        .WithMany("Reviews")
                        .HasForeignKey("PokemonsPokemonId");

                    b.HasOne("PokemonCadastro.Model.Reviewer", "Reviewer")
                        .WithMany("Reviews")
                        .HasForeignKey("ReviewerId");

                    b.Navigation("Pokemons");

                    b.Navigation("Reviewer");
                });

            modelBuilder.Entity("PokemonCadastro.Model.Category", b =>
                {
                    b.Navigation("PokemonCategories");
                });

            modelBuilder.Entity("PokemonCadastro.Model.Country", b =>
                {
                    b.Navigation("Owners");
                });

            modelBuilder.Entity("PokemonCadastro.Model.Owner", b =>
                {
                    b.Navigation("PokemonOwner");
                });

            modelBuilder.Entity("PokemonCadastro.Model.PokemonModel", b =>
                {
                    b.Navigation("PokemonCategories");

                    b.Navigation("PokemonOwners");

                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("PokemonCadastro.Model.Reviewer", b =>
                {
                    b.Navigation("Reviews");
                });
#pragma warning restore 612, 618
        }
    }
}
