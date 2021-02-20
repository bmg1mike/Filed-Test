using System;
using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class PaymentDto
    {
        public int Id { get; set; }
        [Required]
        [CreditCard]
        public string CreditCardNumber { get; set; }
        [Required]
        public string CardHolder { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime ExpirationDate { get; set; }
        [StringLength(3)]
        public string SecurityCode { get; set; }
        [Range(1,Double.MaxValue,ErrorMessage="Amount Can only Contain Positive Values")]
        public decimal Amount { get; set; }
        public int PaymentStateId { get; set; }
    }
}