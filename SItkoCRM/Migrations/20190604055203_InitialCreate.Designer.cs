﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SitkoCRM.Models;

namespace SitkoCRM.Migrations
{
    [DbContext(typeof(CRMContainer))]
    [Migration("20190604055203_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("SitkoCRM.DAL.Bills", b =>
                {
                    b.Property<int>("BillId")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsBilled");

                    b.Property<bool>("IsPayed");

                    b.Property<bool>("IsSended");

                    b.Property<int>("ServiceId");

                    b.Property<int>("Sum");

                    b.Property<DateTime>("created_at");

                    b.Property<DateTime>("updated_at");

                    b.HasKey("BillId");

                    b.HasIndex("ServiceId");

                    b.ToTable("Bills");
                });

            modelBuilder.Entity("SitkoCRM.DAL.ClientContacts", b =>
                {
                    b.Property<int>("ContactId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ClientId");

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.Property<string>("PhoneNum");

                    b.Property<DateTime>("created_at");

                    b.Property<DateTime>("updated_at");

                    b.HasKey("ContactId");

                    b.HasIndex("ClientId");

                    b.ToTable("ClientContacts");
                });

            modelBuilder.Entity("SitkoCRM.DAL.Clients", b =>
                {
                    b.Property<int>("ClientId")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<string>("INN");

                    b.Property<string>("KPP");

                    b.Property<string>("Name");

                    b.Property<string>("Note");

                    b.Property<DateTime>("created_at");

                    b.Property<DateTime>("updated_at");

                    b.HasKey("ClientId");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("SitkoCRM.DAL.Domains", b =>
                {
                    b.Property<int>("DomainId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("HostId");

                    b.Property<string>("Name");

                    b.Property<int>("StatusId");

                    b.Property<DateTime>("created_at");

                    b.Property<DateTime>("updated_at");

                    b.HasKey("DomainId");

                    b.HasIndex("HostId");

                    b.HasIndex("StatusId");

                    b.ToTable("Domains");
                });

            modelBuilder.Entity("SitkoCRM.DAL.DomainsServices", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DomainId");

                    b.Property<int>("ServiceId");

                    b.Property<DateTime>("created_at");

                    b.Property<DateTime>("updated_at");

                    b.HasKey("Id");

                    b.HasIndex("DomainId");

                    b.HasIndex("ServiceId");

                    b.ToTable("DomainsServices");
                });

            modelBuilder.Entity("SitkoCRM.DAL.DomainsStatuses", b =>
                {
                    b.Property<int>("StatusId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<DateTime>("created_at");

                    b.Property<DateTime>("updated_at");

                    b.HasKey("StatusId");

                    b.ToTable("DomainsStatuses");
                });

            modelBuilder.Entity("SitkoCRM.DAL.Hosts", b =>
                {
                    b.Property<int>("HostId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<int>("ServerId");

                    b.Property<int>("ServiceId");

                    b.Property<DateTime>("created_at");

                    b.Property<DateTime>("updated_at");

                    b.HasKey("HostId");

                    b.HasIndex("ServerId");

                    b.HasIndex("ServiceId");

                    b.ToTable("Hosts");
                });

            modelBuilder.Entity("SitkoCRM.DAL.Operations", b =>
                {
                    b.Property<int>("OperationId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Data")
                        .HasColumnType("jsonb");

                    b.Property<DateTime>("created_at");

                    b.Property<DateTime>("updated_at");

                    b.HasKey("OperationId");

                    b.ToTable("Operations");
                });

            modelBuilder.Entity("SitkoCRM.DAL.Servers", b =>
                {
                    b.Property<int>("ServerId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("IPv4");

                    b.Property<string>("IPv6");

                    b.Property<string>("Name");

                    b.Property<DateTime>("created_at");

                    b.Property<DateTime>("updated_at");

                    b.HasKey("ServerId");

                    b.ToTable("Servers");
                });

            modelBuilder.Entity("SitkoCRM.DAL.Services", b =>
                {
                    b.Property<int>("ServiceId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("ActiveTo");

                    b.Property<int>("ClientId");

                    b.Property<int>("PriceId");

                    b.Property<int>("StatusId");

                    b.Property<DateTime>("created_at");

                    b.Property<DateTime>("updated_at");

                    b.HasKey("ServiceId");

                    b.HasIndex("ClientId");

                    b.HasIndex("PriceId");

                    b.HasIndex("StatusId");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("SitkoCRM.DAL.ServicesPrices", b =>
                {
                    b.Property<int>("SerPriceId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.Property<DateTime>("created_at");

                    b.Property<DateTime>("updated_at");

                    b.HasKey("SerPriceId");

                    b.ToTable("Prices");
                });

            modelBuilder.Entity("SitkoCRM.DAL.ServicesStatuses", b =>
                {
                    b.Property<int>("SerStatusId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<DateTime>("created_at");

                    b.Property<DateTime>("updated_at");

                    b.HasKey("SerStatusId");

                    b.ToTable("ServicesStatuses");
                });

            modelBuilder.Entity("SitkoCRM.DAL.Bills", b =>
                {
                    b.HasOne("SitkoCRM.DAL.Services", "Service")
                        .WithMany("Bills")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SitkoCRM.DAL.ClientContacts", b =>
                {
                    b.HasOne("SitkoCRM.DAL.Clients", "Client")
                        .WithMany("ClientContacts")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SitkoCRM.DAL.Domains", b =>
                {
                    b.HasOne("SitkoCRM.DAL.Hosts", "Host")
                        .WithMany("Domains")
                        .HasForeignKey("HostId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SitkoCRM.DAL.DomainsStatuses", "Status")
                        .WithMany("Domains")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SitkoCRM.DAL.DomainsServices", b =>
                {
                    b.HasOne("SitkoCRM.DAL.Domains", "Domain")
                        .WithMany("DomainsServices")
                        .HasForeignKey("DomainId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SitkoCRM.DAL.Services", "Service")
                        .WithMany("DomainsServices")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SitkoCRM.DAL.Hosts", b =>
                {
                    b.HasOne("SitkoCRM.DAL.Servers", "Server")
                        .WithMany("Hosts")
                        .HasForeignKey("ServerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SitkoCRM.DAL.Services", "Service")
                        .WithMany("Hosts")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SitkoCRM.DAL.Services", b =>
                {
                    b.HasOne("SitkoCRM.DAL.Clients", "Client")
                        .WithMany("Services")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SitkoCRM.DAL.ServicesPrices", "Price")
                        .WithMany("Services")
                        .HasForeignKey("PriceId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SitkoCRM.DAL.ServicesStatuses", "Status")
                        .WithMany("Services")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
