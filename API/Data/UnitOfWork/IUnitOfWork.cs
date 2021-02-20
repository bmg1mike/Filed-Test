using API.Data.Repository;

namespace API.Data.UnitOfWork
{
    public interface IUnitOfWork
    {
        IProcessPaymentRepository processPayment {get; set;}
        void Complete();
    }
}