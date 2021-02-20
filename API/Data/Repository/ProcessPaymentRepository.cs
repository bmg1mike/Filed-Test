using System;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using AutoMapper;

namespace API.Data.Repository
{
    public class ProcessPaymentRepository : IProcessPaymentRepository
    {
        private readonly DataContext _db;
        private readonly IMapper _mapper;

        public ProcessPaymentRepository(DataContext db,IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task AddPayment(PaymentDto paymentDto)
        {
            var payment = _mapper.Map<Payment>(paymentDto);
            await _db.Payments.AddAsync(payment);
        }
    }
}