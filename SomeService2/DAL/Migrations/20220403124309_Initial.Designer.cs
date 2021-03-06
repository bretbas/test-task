// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SomeService2.DAL;

#nullable disable

namespace SomeService2.DAL.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20220403124309_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("SomeService2.DAL.Entities.Organization", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.ToTable("organizations", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "ООО Ромашка"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Сбербанк г. Москва"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Рога и копыта"
                        });
                });

            modelBuilder.Entity("SomeService2.DAL.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("MiddleName")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<int?>("OrganizationId")
                        .HasColumnType("integer");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(25)
                        .HasColumnType("character varying(25)");

                    b.Property<string>("Surname")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.HasIndex("OrganizationId");

                    b.ToTable("users", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "bretbas@mail.ru",
                            MiddleName = "Сергеевич",
                            Name = "Максим",
                            OrganizationId = 1,
                            PhoneNumber = "+79997820793",
                            Surname = "Шилов"
                        },
                        new
                        {
                            Id = 2,
                            MiddleName = "Геннадьевич",
                            Name = "Сергей",
                            OrganizationId = 1,
                            Surname = "Петров"
                        },
                        new
                        {
                            Id = 3,
                            MiddleName = "Петрович",
                            Name = "Николай",
                            OrganizationId = 1,
                            PhoneNumber = "+79111211122",
                            Surname = "Жуков"
                        },
                        new
                        {
                            Id = 4,
                            Email = "petrov@mail.ru",
                            MiddleName = "Аркадьевич",
                            Name = "Максим",
                            OrganizationId = 1,
                            PhoneNumber = "+79922321122",
                            Surname = "Бахур"
                        },
                        new
                        {
                            Id = 5,
                            MiddleName = "Сергеевич",
                            Name = "Геннадий",
                            OrganizationId = 1
                        },
                        new
                        {
                            Id = 6,
                            Name = "Петр",
                            OrganizationId = 2,
                            Surname = "Демченко"
                        },
                        new
                        {
                            Id = 7,
                            MiddleName = "Семеновна",
                            Name = "Алиса",
                            OrganizationId = 1,
                            PhoneNumber = "+79201239393",
                            Surname = "Грибоедова"
                        },
                        new
                        {
                            Id = 8,
                            MiddleName = "Семеновна",
                            Name = "Галина",
                            OrganizationId = 2
                        },
                        new
                        {
                            Id = 9,
                            Email = "elena@yandex.ru",
                            MiddleName = "Семеновна",
                            Name = "Галина",
                            OrganizationId = 3
                        });
                });

            modelBuilder.Entity("SomeService2.DAL.Entities.User", b =>
                {
                    b.HasOne("SomeService2.DAL.Entities.Organization", "Organization")
                        .WithMany()
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Organization");
                });
#pragma warning restore 612, 618
        }
    }
}
