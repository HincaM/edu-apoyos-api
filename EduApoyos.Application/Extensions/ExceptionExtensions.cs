namespace EduApoyos.Application.Extensions
{
    public static class ExceptionExtensions
    {
        public static string GetInnerException(this Exception ex)
        {
            if (ex.InnerException is not null)
                return ex.InnerException.GetInnerException();
            else
                return ex.Message;
        }
    }
}
