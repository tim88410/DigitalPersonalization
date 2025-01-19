using DigitalPersonalization.Application.Queries;

namespace DigitalPersonalization.Service
{
    public interface IGenericTypeService
    {
        public string Translate(GenericTypeRequest request);
        public string ConvertToString<T>(T input);
    }
    public class GenericTypeService : IGenericTypeService
    {
        public string Translate(GenericTypeRequest request)
        {
            string result = string.Empty;
            string strValue = string.Empty;
            int intValue = 0;
            DateTime dateTimeValue = DateTime.Now;
            decimal decimalValue = 0;
            switch (request.Type)
            {
                case GenericTypeRequest.eType.String:
                    strValue = !string.IsNullOrEmpty(request.parameter) ? request.parameter : string.Empty;
                    result = ConvertToString<string>(strValue);
                    break;
                case GenericTypeRequest.eType.Int:
                    intValue = int.TryParse(request.parameter, out intValue) ? intValue : 0;
                    result = ConvertToString<int>(intValue);
                    break;
                case GenericTypeRequest.eType.DateTime:
                    dateTimeValue = DateTime.TryParse(request.parameter, out dateTimeValue) ? dateTimeValue : DateTime.Now;
                    result = ConvertToString<DateTime>(dateTimeValue);
                    break;
                case GenericTypeRequest.eType.Decimal:
                    decimalValue = decimal.TryParse(request.parameter, out decimalValue) ? decimalValue : 0;
                    result = ConvertToString<decimal>(decimalValue);
                    break;
                default:
                    break;
            }

            return result;
        }
        public string ConvertToString<T>(T input)
        {
            if (input is DateTime dateTime)
            {
                return dateTime.ToString("yyyy/MM/dd");
            }

            if (input == null)
            { 
                return string.Empty;
            }
#pragma warning disable CS8603 // 可能有 Null 參考傳回。
            return input.ToString();
#pragma warning restore CS8603 // 可能有 Null 參考傳回。
        }
    }
}
