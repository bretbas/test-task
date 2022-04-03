using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SomeService2.DAL.Entities;

namespace SomeService2.DAL.Schema;

public class UserTypeConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder
            .Property(x => x.PhoneNumber)
            .HasMaxLength(25);

        builder
            .Property(x => x.Name)
            .HasMaxLength(100);

        builder
            .Property(x => x.Surname)
            .HasMaxLength(100);

        builder
            .Property(x => x.MiddleName)
            .HasMaxLength(100);

        builder
            .Property(x => x.Email)
            .HasMaxLength(100);

        builder
            .HasOne(x => x.Organization)
            .WithMany()
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasData(
            new User()
            {
                Id = 1,
                Name = "Максим", Surname = "Шилов", MiddleName = "Сергеевич", Email = "bretbas@mail.ru", PhoneNumber = "+79997820793", OrganizationId = 1
            },
            new User()
            {
                Id = 2,
                Name = "Сергей", Surname = "Петров", MiddleName = "Геннадьевич", OrganizationId = 1
            },
            new User()
            {
                Id = 3,
                Name = "Николай", Surname = "Жуков", MiddleName = "Петрович", PhoneNumber = "+79111211122", OrganizationId = 1
            },
            new User()
            {
                Id = 4,
                Name = "Максим", Surname = "Бахур", MiddleName = "Аркадьевич", PhoneNumber = "+79922321122", Email = "petrov@mail.ru", OrganizationId = 1
            },
            new User()
            {
                Id = 5,
                Name = "Геннадий", MiddleName = "Сергеевич", OrganizationId = 1
            },
            new User()
            {
                Id = 6,
                Name = "Петр", Surname = "Демченко", OrganizationId = 2
            },
            new User()
            {
                Id = 7,
                Name = "Алиса", Surname = "Грибоедова", MiddleName = "Семеновна", PhoneNumber = "+79201239393", OrganizationId = 1
            },
            new User()
            {
                Id = 8,
                Name = "Галина", MiddleName = "Семеновна", OrganizationId = 2
            },
            new User()
            {
                Id = 9,
                Name = "Галина", MiddleName = "Семеновна", Email = "elena@yandex.ru", OrganizationId = 3
            }
        );
    }
}