using System.ComponentModel.DataAnnotations;

namespace API.Entities
{
    public class PaymentState
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string State { get; set; }
    }
}