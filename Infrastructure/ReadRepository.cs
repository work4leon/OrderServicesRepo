using Ardalis.Specification.EntityFrameworkCore;

namespace OrderService.Infrastructure
{
    public class ReadRepository<T> : RepositoryBase<T>, IReadRepository<T> where T : class
    {
        public ReadRepository(OrderDbContext dbContext) : base(dbContext)
        {
        }
    }
}
