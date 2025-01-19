using MediatR;

namespace DigitalPersonalization.Application.Queries
{
    /// <summary>
    /// 金額調整的陣列資料
    /// </summary>
    public class AdjustedAmountRequest :IRequest<AdjustedAmountResponse>
    {
        public List<string> amountList { get; set; } = new List<string>();
    }
}
