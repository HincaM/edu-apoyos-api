namespace EduApoyos.Domain.Specifications
{
    public class GetStudentsSpecification(int currentPage, int pageSize) 
    {
        public int CurrentPage { get; } = currentPage;
        public int PageSize { get; } = pageSize;
    }
}
