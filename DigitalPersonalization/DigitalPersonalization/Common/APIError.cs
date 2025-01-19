namespace DigitalPersonalization.Common
{
    public abstract class APIError : Exception
    {
        public abstract ApiResult.Result GetApiResult();
        public class ParamError : APIError
        {
            private object? _data;
            public ParamError(object? data = null) { _data = data; }
            public override ApiResult.Result GetApiResult()
            {
                return new ApiResult.Result
                {
                    ReturnCode = ErrorCode.ReturnCode.ParamError,
                    ReturnData = _data
                };
            }
        }
        public class DBConnectError : APIError
        {
            private object? _data;
            public DBConnectError(object? data = null) { _data = data; }
            public override ApiResult.Result GetApiResult()
            {
                return new ApiResult.Result
                {
                    ReturnCode = ErrorCode.ReturnCode.DBConnectError,
                    ReturnData = _data
                };
            }
        }
        public class OperationFailed : APIError
        {
            private object? _data;
            public OperationFailed(object? data = null) { _data = data; }
            public override ApiResult.Result GetApiResult()
            {
                return new ApiResult.Result
                {
                    ReturnCode = ErrorCode.ReturnCode.OperationFailed,
                    ReturnData = _data
                };
            }
        }
        public class DataNotFound : APIError
        {
            private object? _data;
            public DataNotFound(object? data = null) { _data = data; }
            public override ApiResult.Result GetApiResult()
            {
                return new ApiResult.Result
                {
                    ReturnCode = ErrorCode.ReturnCode.DataNotFound,
                    ReturnData = _data
                };
            }
        }
    }
}
