﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TalentHub.Data;

#nullable disable

namespace TalentHub.Migrations
{
    [DbContext(typeof(TalentHubContext))]
    [Migration("20240418234733_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TalentHub.Models.Anotacao", b =>
                {
                    b.Property<int>("IdAnotacao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdAnotacao"));

                    b.Property<int>("IdProjeto")
                        .HasColumnType("int");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.Property<int>("ProjetoIdProjeto")
                        .HasColumnType("int");

                    b.Property<string>("TextoAnotacao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UsuarioIdUsuario")
                        .HasColumnType("int");

                    b.HasKey("IdAnotacao");

                    b.HasIndex("ProjetoIdProjeto");

                    b.HasIndex("UsuarioIdUsuario");

                    b.ToTable("Anotacoes");
                });

            modelBuilder.Entity("TalentHub.Models.Avaliacao", b =>
                {
                    b.Property<int>("IdAvaliacao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdAvaliacao"));

                    b.Property<string>("Comentario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdProjeto")
                        .HasColumnType("int");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.Property<int>("Nota")
                        .HasColumnType("int");

                    b.Property<int>("ProjetoIdProjeto")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioIdUsuario")
                        .HasColumnType("int");

                    b.HasKey("IdAvaliacao");

                    b.HasIndex("ProjetoIdProjeto");

                    b.HasIndex("UsuarioIdUsuario");

                    b.ToTable("Avaliacoes");
                });

            modelBuilder.Entity("TalentHub.Models.Projeto", b =>
                {
                    b.Property<int>("IdProjeto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdProjeto"));

                    b.Property<string>("Integrantes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomeProjeto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("NotaMedia")
                        .HasColumnType("real");

                    b.Property<int>("QtdVisualizacoes")
                        .HasColumnType("int");

                    b.Property<string>("UrlAplicacao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UrlRepositorio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UsuarioIdUsuario")
                        .HasColumnType("int");

                    b.HasKey("IdProjeto");

                    b.HasIndex("UsuarioIdUsuario");

                    b.ToTable("Projetos");
                });

            modelBuilder.Entity("TalentHub.Models.Usuario", b =>
                {
                    b.Property<int>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdUsuario"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomeUsuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdUsuario");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("TalentHub.Models.Anotacao", b =>
                {
                    b.HasOne("TalentHub.Models.Projeto", "Projeto")
                        .WithMany("Anotacoes")
                        .HasForeignKey("ProjetoIdProjeto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TalentHub.Models.Usuario", "Usuario")
                        .WithMany("Anotacoes")
                        .HasForeignKey("UsuarioIdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Projeto");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("TalentHub.Models.Avaliacao", b =>
                {
                    b.HasOne("TalentHub.Models.Projeto", "Projeto")
                        .WithMany("Avaliacoes")
                        .HasForeignKey("ProjetoIdProjeto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TalentHub.Models.Usuario", "Usuario")
                        .WithMany("Avaliacoes")
                        .HasForeignKey("UsuarioIdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Projeto");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("TalentHub.Models.Projeto", b =>
                {
                    b.HasOne("TalentHub.Models.Usuario", null)
                        .WithMany("Projetos")
                        .HasForeignKey("UsuarioIdUsuario");
                });

            modelBuilder.Entity("TalentHub.Models.Projeto", b =>
                {
                    b.Navigation("Anotacoes");

                    b.Navigation("Avaliacoes");
                });

            modelBuilder.Entity("TalentHub.Models.Usuario", b =>
                {
                    b.Navigation("Anotacoes");

                    b.Navigation("Avaliacoes");

                    b.Navigation("Projetos");
                });
#pragma warning restore 612, 618
        }
    }
}