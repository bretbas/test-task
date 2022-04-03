using AutoMapper;
using SomeService2.DAL.CQRS.ValueObjects;

namespace SomeService2.Mappings.Converters;

public class PaginationConverter<TSource, TDestination> : ITypeConverter<Pagination<TSource>, Pagination<TDestination>>
{
    public Pagination<TDestination> Convert(Pagination<TSource> source, Pagination<TDestination> destination, ResolutionContext context)
    {
        destination ??= new Pagination<TDestination>();
        destination.Entities = context.Mapper.Map<IEnumerable<TDestination>>(source.Entities);
        destination.CurrentPage = source.CurrentPage;
        destination.PerPage = source.PerPage;
        destination.TotalEntities = source.TotalEntities;

        return destination;
    }
}