using EduApoyos.Application.Interfaces.Services;
using EduApoyos.Domain.Common.Enums;
using EduApoyos.Domain.Entities;
using EduApoyos.Domain.Models;
using EduApoyos.Domain.Repositories;
using EduApoyos.Domain.Specifications.RequestsSupports;
using Mapster;

namespace EduApoyos.Infrastructure.Services
{
    public sealed class RequestSupportService(IRequestSupportRepository _requestSupportRepository) : IRequestSupportService
    {
        public async Task<ErrorOr<bool>> ChangeStatusRequestSupport(int requestSupportId, Status status, CancellationToken cancellationToken) 
            => await _requestSupportRepository.ChangeStatus(requestSupportId, status, cancellationToken);

        public async Task<ErrorOr<int>> CreateSupport(CreateRequestSupportRequest request, CancellationToken cancellationToken)
        {
            return await _requestSupportRepository.Create(RequestSupport.Create(
                request.StudentId,
                request.TypeSupport,
                request.RequestedAmount,
                request.Description,
                request.AdvisorId
                ), cancellationToken);
        }

        public async Task<ErrorOr<PaginatedList<GetRequestsSupportResult>>> GetRequests(GetRequestsSupportRequest request, CancellationToken cancellationToken)
        {
            return (await _requestSupportRepository.GetRequests(new GetRequestSupportSpecification(
                request.Status,
                request.Type,
                request.CurrentPage,
                request.PageSize
            ), cancellationToken)).Adapt<PaginatedList<GetRequestsSupportResult>>();
        }

        public async Task<ErrorOr<PaginatedList<GetRequestsSupportResult>>> GetRequestsSupportByStudentId(GetRequestsSupportByStudentIdSpecification specification, CancellationToken cancellationToken) => (await _requestSupportRepository.GetByStudentId(specification, cancellationToken)).Adapt<PaginatedList<GetRequestsSupportResult>>();

        public async Task<ErrorOr<GetRequestsSupportResult?>> GetRequestSupportById(int id, string? email, CancellationToken cancellationToken) 
            => (await _requestSupportRepository.GetRequestById(new GetRequestSupportByIdSpecification(id, email), cancellationToken)).Adapt<GetRequestsSupportResult?>();

    }
}
