namespace EduApoyos.Domain.Specifications.RequestsSupports
{
    public sealed class GetRequestsSupportByStudentIdSpecification : GetRequestSupportSpecification
    {
        public GetRequestsSupportByStudentIdSpecification(int studentId, int currentPage, int pageSize) : base(null, null, currentPage, pageSize)
        {
            Criteria = x => x.StudentId == studentId;
            CurrentPage = currentPage;
            PageSize = pageSize;
        }
    }
}
