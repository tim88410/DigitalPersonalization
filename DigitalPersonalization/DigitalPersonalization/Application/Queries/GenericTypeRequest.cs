using MediatR;

namespace DigitalPersonalization.Application.Queries
{
    public class GenericTypeRequest :IRequest<GenericTypeResponse>
    {
        public string parameter { get; set; } = string.Empty;
        /// <summary>
        /// Type 型別
        /// String = 1
        /// Int = 2
        /// DateTime = 3
        /// Decimal = 4
        /// 若大小寫不符或者文字數字沒有對應上
        /// 則預設為String
        /// </summary>
        public string inputType { get; set; } 
        public enum eType 
        { 
            String = 1,
            Int = 2,
            DateTime = 3,
            Decimal = 4
        }
        internal eType Type
        {
            get
            {
                if (string.IsNullOrEmpty(inputType) ||
                !Enum.TryParse(inputType.Trim(), true, out eType intType) ||
                !Enum.IsDefined(typeof(eType), intType))
                {
                    return eType.String;
                }
                else
                {
                    return intType;
                }
            }
        }
    }
}
