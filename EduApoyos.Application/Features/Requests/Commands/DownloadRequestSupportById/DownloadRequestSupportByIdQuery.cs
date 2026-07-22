namespace EduApoyos.Application.Features.Requests.Commands.DownloadRequestSupportById;

public record DownloadRequestSupportByIdQuery(int RequestSupportId) : IRequest<ErrorOr<byte[]>>;
