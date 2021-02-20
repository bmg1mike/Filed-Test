using API.Data.Repository;

namespace API.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public IProcessPaymentRepository processPayment { get; set; }
        private readonly DataContext _db;
        public UnitOfWork(DataContext db)
        {
            _db = db;

        }

        public void Complete()
        {
            _db.SaveChanges();
        }
    }
}