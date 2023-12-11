namespace ECommerceDotNet.Common.Services
{
    public interface IValidateTokenService
    {
        string? ValidateToken(string? token);
    }

}