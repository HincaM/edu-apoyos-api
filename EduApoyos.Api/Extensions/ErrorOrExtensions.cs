using ErrorOr;

namespace EduApoyos.Api.Extensions
{
    public static class ErrorOrExtensions
    {
        public static IResult Problem(List<Error> errors)
        {
            if(errors.All(a => a.Type == ErrorType.Validation))
                return Results.ValidationProblem(errors.GroupBy(gb => gb.Type, gb => gb.Description).ToDictionary(e => e.Key.ToString(), e => e.ToArray()));

            var error = errors.FirstOrDefault();
            var messages = errors.Select(e => e.Description).ToArray();

            return error.Type switch
            {
                ErrorType.NotFound => Results.NotFound(messages),
                ErrorType.Conflict => Results.Conflict(messages),
                _ => Results.BadRequest(messages),
            };
        }
    }
}
