using System.Threading.Tasks;
using API.DTOs;
using API.Entities;

namespace API.Data.Repository
{
    public interface IProcessPaymentRepository
    {
        Task AddPayment(PaymentDto paymentDto);
    }
}