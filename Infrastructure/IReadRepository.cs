using Ardalis.Specification;

namespace OrderService.Infrastructure
{
    public interface IReadRepository<T> : IReadRepositoryBase<T> where T : class
    {
    }
}
