namespace API.Services
{
    public class ExpensivePaymentGateway : IExpensivePaymentGateway
    {
        public string Pay()
        {
            return "Processed";
        }
    }
}