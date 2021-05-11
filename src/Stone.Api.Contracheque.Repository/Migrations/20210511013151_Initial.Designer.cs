﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Stone.Api.Contracheque.Repository.Context;

namespace Stone.Api.Contracheque.Repository.Migrations
{
    [DbContext(typeof(FuncionarioContext))]
    [Migration("20210511013151_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Stone.Api.Contracheque.Domain.Entities.Funcionario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataDeAdmissao")
                        .HasColumnType("datetime");

                    b.Property<bool>("PossuiDescontoPlanoDeSaude")
                        .HasColumnType("bit");

                    b.Property<bool>("PossuiDescontoPlanoDental")
                        .HasColumnType("bit");

                    b.Property<bool>("PossuiDescontoValeTransporte")
                        .HasColumnType("bit");

                    b.Property<decimal>("SalarioBruto")
                        .HasColumnType("decimal");

                    b.Property<string>("Setor")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("tbFuncionario");
                });

            modelBuilder.Entity("Stone.Api.Contracheque.Domain.Entities.Funcionario", b =>
                {
                    b.OwnsOne("Stone.Api.Contracheque.Domain.ValueObjects.Cpf", "CPF", b1 =>
                        {
                            b1.Property<Guid>("FuncionarioId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Documento")
                                .HasColumnName("CPF")
                                .HasColumnType("VARCHAR(100)");

                            b1.HasKey("FuncionarioId");

                            b1.ToTable("tbFuncionario");

                            b1.WithOwner()
                                .HasForeignKey("FuncionarioId");
                        });

                    b.OwnsOne("Stone.Api.Contracheque.Domain.ValueObjects.NomeFuncionario", "NomeFuncionario", b1 =>
                        {
                            b1.Property<Guid>("FuncionarioId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Nome")
                                .HasColumnName("Nome")
                                .HasColumnType("VARCHAR(100)");

                            b1.Property<string>("SobreNome")
                                .HasColumnName("SobreNome")
                                .HasColumnType("VARCHAR(100)");

                            b1.HasKey("FuncionarioId");

                            b1.ToTable("tbFuncionario");

                            b1.WithOwner()
                                .HasForeignKey("FuncionarioId");
                        });
                });
#pragma warning restore 612, 618
        }
    }
}