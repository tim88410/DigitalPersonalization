using DigitalPersonalization.Service;
using MediatR;

namespace DigitalPersonalization.Application.Queries
{
    public class AdjustedAmountHandler : IRequestHandler<AdjustedAmountRequest, AdjustedAmountResponse>
    {
        private readonly IAdjustedAmountService _adjustedAmountService;
        public AdjustedAmountHandler(IAdjustedAmountService adjustedAmountService)
        {
            _adjustedAmountService = adjustedAmountService;
        }
        public async Task<AdjustedAmountResponse> Handle(AdjustedAmountRequest request, CancellationToken cancellationToken)
        {
            var result = await _adjustedAmountService.AdjustedAmount(request.amountList);

            return new AdjustedAmountResponse
            {
                AmountList = result.ToList(),
            };
        }
    }
}
