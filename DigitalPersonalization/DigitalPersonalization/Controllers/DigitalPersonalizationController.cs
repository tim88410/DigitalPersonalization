using DigitalPersonalization.Application.Queries;
using DigitalPersonalization.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static DigitalPersonalization.Application.Queries.CreditCardMaskingRequest;

namespace DigitalPersonalization.Controllers
{
    [APIError]
    [ApiResult]
    [ApiController]
    public class DigitalPersonalizationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DigitalPersonalizationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <remarks>
        /// <code>
        /// 透過 ReturnCode 判斷狀態:<br/>
        /// ParamError(2) 參數錯誤<br/>
        /// OperationSuccessful(5) 回傳成功<br/>
        /// </code>
        /// </remarks>
        [Route("v1/AdjustedAmount")]
        [HttpGet]
        public async Task<IActionResult> GetAdjustedAmount([FromQuery]List<string> amountList)
        {
            if (!ModelState.IsValid)
            {
                throw new APIError.ParamError();
            }
            var result = await _mediator.Send(new AdjustedAmountRequest() { amountList  = amountList });
            return Ok(result);
        }

        /// <remarks>
        /// <code>
        /// 透過 ReturnCode 判斷狀態:<br/>
        /// ParamError(2) 參數錯誤<br/>
        /// OperationFailed(4) 回傳失敗<br/>
        /// OperationSuccessful(5) 回傳成功<br/>
        /// </code>
        /// </remarks>
        [Route("v1/MaskCreditCard")]
        [HttpGet]
        public async Task<IActionResult> GetCreditCardNumber([FromQuery] string cardNumber)
        {
            var cardNumberTrim = cardNumber.Trim();
            if (!ModelState.IsValid)
            {
                throw new APIError.ParamError("Input Valid");
            }
            //Valid Length
            if (!(cardNumberTrim.Length == (int)CreditCardLength.Twelve || cardNumberTrim.Length == (int)CreditCardLength.Sixteen))
            {
                throw new APIError.ParamError("Credit card number must be either 16 or 12 digits long.");
            }
            var result = await _mediator.Send(new CreditCardMaskingRequest() { CreditCardNumber = cardNumberTrim });
            if (result == null)
            {
                throw new APIError.OperationFailed("Each character in the credit card number must be a digit between 0 and 9.");
            }
            return Ok(result);
        }

        /// <remarks>
        /// <code>
        /// 透過 ReturnCode 判斷狀態:<br/>
        /// ParamError(2) 參數錯誤<br/>
        /// OperationSuccessful(5) 回傳成功<br/>
        /// </code>
        /// </remarks>
        [Route("v1/GenericTypeToString")]
        [HttpGet]
        public async Task<IActionResult> GetGenericTypeToString([FromQuery] GenericTypeRequest request)
        {
            if (!ModelState.IsValid)
            {
                throw new APIError.ParamError();
            }
            var result = await _mediator.Send(request);
            return Ok(result);
        }
    }
}
