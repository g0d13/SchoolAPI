﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SchoolAPI;

namespace SchoolAPI.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    partial class RepositoryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("SchoolAPI.Models.Boleta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("Asistencias")
                        .HasColumnType("integer");

                    b.Property<int>("CalificacionId")
                        .HasColumnType("integer");

                    b.Property<int>("Faltas")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CalificacionId");

                    b.ToTable("Boletas");
                });

            modelBuilder.Entity("SchoolAPI.Models.Calificacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("MateriaId")
                        .HasColumnType("integer");

                    b.Property<int>("Unidad")
                        .HasColumnType("integer");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("MateriaId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Calificacions");
                });

            modelBuilder.Entity("SchoolAPI.Models.Grado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Grupo")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Grados");
                });

            modelBuilder.Entity("SchoolAPI.Models.GradoUsuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("UsuarioId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("GradoUsuarios");
                });

            modelBuilder.Entity("SchoolAPI.Models.Materia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("GradoId")
                        .HasColumnType("integer");

                    b.Property<string>("Nombre")
                        .HasColumnType("text");

                    b.Property<int>("Unidades")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("GradoId");

                    b.ToTable("Materias");
                });

            modelBuilder.Entity("SchoolAPI.Models.Rol", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Nombre")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("SchoolAPI.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Apemat")
                        .HasColumnType("text");

                    b.Property<string>("Apepat")
                        .HasColumnType("text");

                    b.Property<string>("Correo")
                        .HasColumnType("text");

                    b.Property<string>("Direccion")
                        .HasColumnType("text");

                    b.Property<string>("Iae")
                        .HasColumnType("text");

                    b.Property<string>("Nombre")
                        .HasColumnType("text");

                    b.Property<string>("Pass")
                        .HasColumnType("text");

                    b.Property<int>("RolId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("RolId");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("SchoolAPI.Models.Boleta", b =>
                {
                    b.HasOne("SchoolAPI.Models.Calificacion", "Calificacion")
                        .WithMany()
                        .HasForeignKey("CalificacionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Calificacion");
                });

            modelBuilder.Entity("SchoolAPI.Models.Calificacion", b =>
                {
                    b.HasOne("SchoolAPI.Models.Materia", "Materia")
                        .WithMany()
                        .HasForeignKey("MateriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolAPI.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Materia");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("SchoolAPI.Models.GradoUsuario", b =>
                {
                    b.HasOne("SchoolAPI.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("SchoolAPI.Models.Materia", b =>
                {
                    b.HasOne("SchoolAPI.Models.Grado", "Grado")
                        .WithMany()
                        .HasForeignKey("GradoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Grado");
                });

            modelBuilder.Entity("SchoolAPI.Models.Usuario", b =>
                {
                    b.HasOne("SchoolAPI.Models.Rol", "Rol")
                        .WithMany()
                        .HasForeignKey("RolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Rol");
                });
#pragma warning restore 612, 618
        }
    }
}
