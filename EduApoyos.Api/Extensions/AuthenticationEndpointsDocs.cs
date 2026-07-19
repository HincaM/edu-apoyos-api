namespace EduApoyos.Api.Extensions
{
    internal static class AuthenticationEndpointsDocs
    {
        public static RouteHandlerBuilder WithLoginDocs(this RouteHandlerBuilder builder) =>
            builder
                .WithName("Login")
                .WithSummary("Autentica un usuario")
                .WithDescription("Publico. Retorna el token JWT si las credenciales son validas.")
                .Produces<string>(StatusCodes.Status200OK)
                .ProducesProblem(StatusCodes.Status400BadRequest);

        public static RouteHandlerBuilder WithRegisterDocs(this RouteHandlerBuilder builder) =>
            builder
                .WithName("Register")
                .WithSummary("Registra un usuario")
                .WithDescription("Publico.")
                .Produces<bool>(StatusCodes.Status200OK)
                .ProducesValidationProblem();
    }
}
