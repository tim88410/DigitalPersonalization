using DigitalPersonalization.Service;
using MediatR;

namespace DigitalPersonalization.Application.Queries
{
    public class CreditCardMaskingHandler : IRequestHandler<CreditCardMaskingRequest, CreditCardMaskingResponse?>
    {
        private readonly ICreditCardMaskingService _creditCardMaskingService;
        public CreditCardMaskingHandler(ICreditCardMaskingService creditCardMaskingService)
        {
            _creditCardMaskingService = creditCardMaskingService;
        }
        public async Task<CreditCardMaskingResponse?> Handle(CreditCardMaskingRequest request, CancellationToken cancellationToken)
        {
            //檢查是否所有號碼皆為0-9之間(有英文或符號則回傳非法輸入)
            bool validNumber = _creditCardMaskingService.IsAllDigits(request.CreditCardNumber);
            if (!validNumber) {
                return null;
            }
            var result =  _creditCardMaskingService.MaskedCardNumber(request.CreditCardNumber);

            return new CreditCardMaskingResponse
            {
                MaskedCardNumber = result
            };
        }
    }
}
