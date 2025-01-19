using MediatR;

namespace DigitalPersonalization.Application.Queries
{
    public class CreditCardMaskingRequest :IRequest<CreditCardMaskingResponse?>
    {
        public string CreditCardNumber { get; set; } = string.Empty;
        internal enum CreditCardLength {
            Twelve = 12,
            Sixteen = 16
        }
    }
}
