using EduApoyos.Application.Common.Exceptions;

namespace EduApoyos.Application.Common.Behaviours
{
    public sealed class ErrorOrBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest
    {
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var response = await next();

            if (response is IErrorOr errorOr && errorOr.IsError)
            {
                throw new ErrorOrException(errorOr.Errors.ToList());
            }

            return response;
        }
    }
}
