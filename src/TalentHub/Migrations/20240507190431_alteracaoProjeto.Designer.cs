﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using TalentHub.Data;

#nullable disable

namespace TalentHub.Migrations
{
    [DbContext(typeof(TalentHubContext))]
    [Migration("20240507190431_alteracaoProjeto")]
    partial class alteracaoProjeto
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            modelBuilder.Entity("TalentHub.Models.Anotacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdProjeto")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProjetoIdProjeto")
                        .HasColumnType("INTEGER");

                    b.Property<string>("TextoAnotacao")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("UsuarioIdUsuario")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ProjetoIdProjeto");

                    b.HasIndex("UsuarioIdUsuario");

                    b.ToTable("Anotacoes");
                });

            modelBuilder.Entity("TalentHub.Models.Avaliacao", b =>
                {
                    b.Property<int>("IdAvaliacao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Comentario")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("IdProjeto")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Nota")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProjetoIdProjeto")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UsuarioIdUsuario")
                        .HasColumnType("INTEGER");

                    b.HasKey("IdAvaliacao");

                    b.HasIndex("ProjetoIdProjeto");

                    b.HasIndex("UsuarioIdUsuario");

                    b.ToTable("Avaliacoes");
                });

            modelBuilder.Entity("TalentHub.Models.Projeto", b =>
                {
                    b.Property<int>("IdProjeto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Ano")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Categoria")
                        .HasColumnType("INTEGER");

                    b.Property<string>("DescricaoProjeto")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Integrantes")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("NomeProjeto")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<float>("NotaMedia")
                        .HasColumnType("REAL");

                    b.Property<string>("PalavraChave")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Periodo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("QtdVisualizacoes")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UrlAplicacao")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("UrlRepositorio")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("UsuarioIdUsuario")
                        .HasColumnType("INTEGER");

                    b.HasKey("IdProjeto");

                    b.HasIndex("UsuarioIdUsuario");

                    b.ToTable("Projetos");
                });

            modelBuilder.Entity("TalentHub.Models.Usuario", b =>
                {
                    b.Property<int>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("NomeUsuario")
                        .IsRequired()
                        .HasColumnType("TEXT");

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
