
namespace SomeService2.DAL.CQRS.ValueObjects;

public class Pagination<T>
{
    public IEnumerable<T> Entities { get; set; }

    public int CurrentPage { get; set; }

    public int PerPage { get; set; }

    public int TotalEntities { get; set; }
}