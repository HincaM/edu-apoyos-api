using EduApoyos.Domain.Common.Enums;
using EduApoyos.Domain.Entities;

namespace EduApoyos.Domain.Specifications.RequestsSupports
{
    public sealed class GetRequestsSupportByStudentIdSpecification : GetRequestSupportSpecification, ISpecification<RequestSupport>
    {
        public GetRequestsSupportByStudentIdSpecification(int studentId, Status? status, TypeSupport? type, int currentPage, int pageSize) : base(status, type, currentPage, pageSize)
        {
            Criteria = x => x.StudentId == studentId && (!status.HasValue || status.Value == x.Status) && (!type.HasValue || type.Value == x.TypeSupport);
        }

    }
}
