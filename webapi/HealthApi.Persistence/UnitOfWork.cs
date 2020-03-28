using HealthApp.Domain.Contracts;

namespace HealthApi.Persistence
{
	public class UnitOfWork: IUnitOfWork
	{
        private readonly HealthAppContext _context;

        public UnitOfWork(HealthAppContext context)
        {
            _context = context;
        }

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
