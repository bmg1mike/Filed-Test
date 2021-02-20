using API.DTOs;
using API.Entities;
using AutoMapper;

namespace API.Utilities
{
    public class PaymentMapper : Profile
    {
        public PaymentMapper()
        {
            CreateMap<Payment,PaymentDto>().ReverseMap();
        }
    }
}