namespace DigitalPersonalization.Service
{
    public interface IAdjustedAmountService
    {
        public Task<List<double>> AdjustedAmount(List<string> amountList);
    }
    public class AdjustedAmountService : IAdjustedAmountService
    {
        public async Task<List<double>> AdjustedAmount(List<string> amountList)
        {
            //API 回傳"金額資訊"
            //利率 為 0.33
            //金額資訊應為 金額 + 金額 * 利率 0.33;
            double rate = 1 + 0.33;

            return amountList
                .Select(s => parseDouble(s) * rate)
                .OrderByDescending(o => o)
                .ToList();
        }

        private double parseDouble(string amount)
        {
            //- 視為 0，但-0.005在信用卡上視為退款，不該歸0
            //理論上回傳時不該將負數加上利率，會變成高利活存，但此題沒有明說，僅做-歸0校正
            return double.TryParse(amount, out double doubleValue) ? doubleValue : 0;
        }
    }
}
