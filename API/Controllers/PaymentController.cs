using System;
using System.Threading.Tasks;
using API.Data.UnitOfWork;
using API.DTOs;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class PaymentController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICheapPaymentGateway _cheapPayment;
        private readonly IExpensivePaymentGateway _expensivePayment;
        public PaymentController(IUnitOfWork unitOfWork, ICheapPaymentGateway cheapPayment, IExpensivePaymentGateway expensivePayment)
        {
            _expensivePayment = expensivePayment;
            _cheapPayment = cheapPayment;
            _unitOfWork = unitOfWork;

        }

        [HttpPost]
        [Route("ProcessPayment")]
        public async Task<IActionResult> ProcessPayment(PaymentDto payment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (payment.ExpirationDate < DateTime.Now)
            {
                return BadRequest("The Expiration Date Cannot be in the past");
            }

            // Check if the amount and determines the payment Gateway to use

            if (payment.Amount < 20)
            {
               var result = _cheapPayment.Pay();
               CheckPayment(result,payment);
                await _unitOfWork.processPayment.AddPayment(payment);
            }
            else if (payment.Amount >= 21 && payment.Amount < 500)
            {
                var result =_expensivePayment.Pay();
                CheckPayment(result,payment);
                    
                await _unitOfWork.processPayment.AddPayment(payment);
            }
            
             _unitOfWork.Complete();

            if(payment.PaymentStateId == 2) // checks if the payment state is Processed
            {
                return Ok(payment);
            }
            
            return StatusCode(500,payment);
        }

        private void CheckPayment(string result, PaymentDto payment){

            if(result.ToLower() == "processed"){
                    payment.PaymentStateId = 2;
                }
                else if(result.ToLower() == "pending")
                {
                    payment.PaymentStateId = 1;
                }
                else{
                    payment.PaymentStateId = 3;
                }
        }
    }
}