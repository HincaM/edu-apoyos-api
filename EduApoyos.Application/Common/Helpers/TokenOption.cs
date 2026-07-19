namespace EduApoyos.Application.Common.Helpers
{
    public record TokenOption(
        int ExpireMinutes,
        string Issuer,
        string Audience,
        string Key
        );
}
