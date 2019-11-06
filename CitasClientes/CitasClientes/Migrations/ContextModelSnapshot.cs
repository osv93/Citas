﻿// <auto-generated />
using System;
using CitasClientes.DA;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CitasClientes.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CitasClientes.Model.Cita", b =>
                {
                    b.Property<int>("CitaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("FechaCita")
                        .HasColumnType("datetime2");

                    b.Property<string>("PacienteID")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("TipoCitaID")
                        .HasColumnType("int");

                    b.HasKey("CitaID");

                    b.HasIndex("PacienteID");

                    b.HasIndex("TipoCitaID");

                    b.ToTable("Citas");
                });

            modelBuilder.Entity("CitasClientes.Model.Paciente", b =>
                {
                    b.Property<string>("PacienteID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PacienteFullName")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("PacienteID");

                    b.ToTable("Pacientes");

                    b.HasData(
                        new
                        {
                            PacienteID = "1111",
                            PacienteFullName = "Paciente 1"
                        },
                        new
                        {
                            PacienteID = "2222",
                            PacienteFullName = "Paciente 2"
                        },
                        new
                        {
                            PacienteID = "3333",
                            PacienteFullName = "Paciente 3"
                        },
                        new
                        {
                            PacienteID = "4444",
                            PacienteFullName = "Paciente 4"
                        });
                });

            modelBuilder.Entity("CitasClientes.Model.TipoCita", b =>
                {
                    b.Property<int>("TipoCitaID")
                        .HasColumnType("int");

                    b.Property<string>("TipoCitaNombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TipoCitaID");

                    b.ToTable("TiposCitas");

                    b.HasData(
                        new
                        {
                            TipoCitaID = 1,
                            TipoCitaNombre = "Medicina General"
                        },
                        new
                        {
                            TipoCitaID = 2,
                            TipoCitaNombre = "Odontología"
                        },
                        new
                        {
                            TipoCitaID = 3,
                            TipoCitaNombre = "Pediatría"
                        },
                        new
                        {
                            TipoCitaID = 4,
                            TipoCitaNombre = "Neurología"
                        });
                });

            modelBuilder.Entity("CitasClientes.Model.Cita", b =>
                {
                    b.HasOne("CitasClientes.Model.Paciente", "Paciente")
                        .WithMany()
                        .HasForeignKey("PacienteID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CitasClientes.Model.TipoCita", "TipoCita")
                        .WithMany()
                        .HasForeignKey("TipoCitaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
