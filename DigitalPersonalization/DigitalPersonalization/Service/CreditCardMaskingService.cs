using System.Text;

namespace DigitalPersonalization.Service
{
    public interface ICreditCardMaskingService
    {
        public bool IsAllDigits(string cardNumber);
        public string MaskedCardNumber(string cardNumber);
    }
    public class CreditCardMaskingService : ICreditCardMaskingService
    {
        public bool IsAllDigits(string cardNumber)
        {
            // 確認字串是否僅包含數字
            foreach (char c in cardNumber)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }
            return true;
        }

        public string MaskedCardNumber(string cardNumber)
        {
            string visibleNumber = cardNumber.Substring(cardNumber.Length - 4);
            string formattedMaskedNumber = FormatMaskedNumber(new string('*', cardNumber.Length - 4));

            return formattedMaskedNumber + "-" + visibleNumber;
        }

        private string FormatMaskedNumber(string maskedPart)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < maskedPart.Length; i++)
            {
                if (i > 0 && i % 4 == 0)
                {
                    sb.Append("-");
                }
                sb.Append(maskedPart[i]);
            }
            return sb.ToString();
        }
    }
}
