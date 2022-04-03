using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SomeService2.DAL.Entities;

namespace SomeService2.DAL.Schema;

public class OrganizationTypeConfiguration : IEntityTypeConfiguration<Organization>
{
	public void Configure(EntityTypeBuilder<Organization> builder)
	{
		builder
			.Property(x => x.Name)
			.HasMaxLength(100)
			.IsRequired();

		builder.HasData(
			new Organization()
			{
				Id = 1,
				Name = "ООО Ромашка"
			},
			new Organization()
			{
				Id = 2,
				Name = "Сбербанк г. Москва"
			},
			new Organization()
			{
				Id = 3,
				Name = "Рога и копыта"
			}
		);
	}
}