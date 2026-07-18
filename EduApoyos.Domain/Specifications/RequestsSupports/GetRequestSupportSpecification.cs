using EduApoyos.Domain.Common.Enums;
using EduApoyos.Domain.Entities;
using System.Linq.Expressions;

namespace EduApoyos.Domain.Specifications.RequestsSupports
{
    public class GetRequestSupportSpecification : ISpecification<RequestSupport>
    {
        public Expression<Func<RequestSupport, bool>> Criteria {  get; internal set; }
        public Expression<Func<RequestSupport, object>> OrderByDesc { get; internal set; }

        public int CurrentPage { get; internal set; }
        public int PageSize { get; internal set; }

        public GetRequestSupportSpecification(Status? status, TypeSupport? type, int currentPage, int pageSize)
        {
            Criteria = x => 
                status.HasValue ? x.Status == status.Value : true && 
                type.HasValue ? x.TypeSupport == type.Value : true;
            CurrentPage = currentPage;
            PageSize = pageSize;
            OrderByDesc = x => x.ApplicationDate;
        }
    }
}
