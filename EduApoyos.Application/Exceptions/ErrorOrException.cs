using ErrorOr;

namespace EduApoyos.Application.Exceptions
{
    public class ErrorOrException : Exception
    {
        public Dictionary<string, string[]> Errors { get; }
        public ErrorOrException(): base("Se han producido uno o más errores de validación.") 
        {
            Errors = new Dictionary<string, string[]>();
        }

        public ErrorOrException(List<Error> errors) : this()
        {
            Errors = errors
                .GroupBy(gb => gb.Type, gb => gb.Description)
                .ToDictionary(e => e.Key.ToString(), e => e.ToArray());
        }
    }
}
