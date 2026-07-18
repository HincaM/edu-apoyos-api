namespace EduApoyos.Domain.Common.Helpers
{
    public class PaginatedList<T>
    {
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public int PagesCount => (int)Math.Ceiling(TotalCount / (double)PageSize);
        public bool HasNextPage => CurrentPage < PagesCount;
        public List<T> Results { get; set; } = new List<T>();
    }
}
