namespace API.Services
{
    public class CheapPaymentGateway : ICheapPaymentGateway
    {
        public string Pay()
        {
            return "Processed";
        }
    }
}