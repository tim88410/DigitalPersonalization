using DigitalPersonalization.Service;
using MediatR;

namespace DigitalPersonalization.Application.Queries
{
    public class GenericTypeHandler : IRequestHandler<GenericTypeRequest, GenericTypeResponse>
    {
        private readonly IGenericTypeService _genericTypeService;
        public GenericTypeHandler(IGenericTypeService genericTypeService)
        {
            _genericTypeService = genericTypeService;
        }
        public Task<GenericTypeResponse> Handle(GenericTypeRequest request, CancellationToken cancellationToken)
        {
            var result = _genericTypeService.Translate(request);

            return Task.FromResult(new GenericTypeResponse
            {
                Result = result
            });
        }
    }
}
