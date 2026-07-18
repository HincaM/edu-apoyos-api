using ErrorOr;

namespace EduApoyos.Application.Common.Exceptions
{
    public class ErrorOrException : Exception
    {
        public Dictionary<ErrorType, string[]> Errors { get; }
        public ErrorOrException(): base("Se han producido uno o más errores de validación.") 
        {
            Errors = new Dictionary<ErrorType, string[]>();
        }

        public ErrorOrException(List<Error> errors) : this()
        {
            Errors = errors
                .GroupBy(gb => gb.Type, gb => gb.Description)
                .ToDictionary(e => e.Key, e => e.ToArray());
        }
    }
}
