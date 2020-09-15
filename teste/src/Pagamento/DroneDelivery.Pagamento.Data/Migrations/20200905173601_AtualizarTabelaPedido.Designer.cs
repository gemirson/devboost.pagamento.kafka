﻿// <auto-generated />
using System;
using DroneDelivery.Pagamento.Data.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DroneDelivery.Pagamento.Data.Migrations
{
    [DbContext(typeof(DronePgtoDbContext))]
    [Migration("20200905173601_AtualizarTabelaPedido")]
    partial class AtualizarTabelaPedido
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DroneDelivery.Pagamento.Domain.Models.Pedido", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PedidoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<double>("Valor")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Pedidos");
                });

            modelBuilder.Entity("DroneDelivery.Pagamento.Domain.Models.PedidoPagamento", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CodigoSeguranca")
                        .HasColumnType("int");

                    b.Property<string>("NumeroCartao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("PedidoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<double>("ValorPago")
                        .HasColumnType("float");

                    b.Property<DateTime>("VencimentoCartao")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("PedidoId");

                    b.ToTable("Pagamentos");
                });

            modelBuilder.Entity("DroneDelivery.Pagamento.Domain.Models.PedidoPagamento", b =>
                {
                    b.HasOne("DroneDelivery.Pagamento.Domain.Models.Pedido", "Pedido")
                        .WithMany("Pagamentos")
                        .HasForeignKey("PedidoId");
                });
#pragma warning restore 612, 618
        }
    }
}
