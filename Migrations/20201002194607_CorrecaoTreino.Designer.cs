﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StrongMuscle.Models;

namespace StrongMuscle.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20201002194607_CorrecaoTreino")]
    partial class CorrecaoTreino
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("StrongMuscle.Models.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Altura")
                        .HasColumnType("float");

                    b.Property<string>("Categoria")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cpf")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Peso")
                        .HasColumnType("float");

                    b.Property<string>("Telefone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TreinoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TreinoId");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("StrongMuscle.Models.Exercicio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Exercicios");
                });

            modelBuilder.Entity("StrongMuscle.Models.Funcionario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cpf")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("datetime2");

                    b.Property<string>("Funcao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Funcionarios");
                });

            modelBuilder.Entity("StrongMuscle.Models.ItemTreino", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ExercicioId")
                        .HasColumnType("int");

                    b.Property<string>("Repeticao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TreinoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ExercicioId");

                    b.HasIndex("TreinoId");

                    b.ToTable("ItensTreino");
                });

            modelBuilder.Entity("StrongMuscle.Models.Treino", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Categoria")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("datetime2");

                    b.Property<string>("SubCategoria")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Treinos");
                });

            modelBuilder.Entity("StrongMuscle.Models.Cliente", b =>
                {
                    b.HasOne("StrongMuscle.Models.Treino", "Treino")
                        .WithMany()
                        .HasForeignKey("TreinoId");
                });

            modelBuilder.Entity("StrongMuscle.Models.ItemTreino", b =>
                {
                    b.HasOne("StrongMuscle.Models.Exercicio", "Exercicio")
                        .WithMany()
                        .HasForeignKey("ExercicioId");

                    b.HasOne("StrongMuscle.Models.Treino", null)
                        .WithMany("ItemExercicios")
                        .HasForeignKey("TreinoId");
                });
#pragma warning restore 612, 618
        }
    }
}
