namespace Ratio.Application.Mappers
{
    public static class ActionTypeMapper
    {
        public static Application.Enums.ActionType ToDto(Domain.Enums.ActionType domainType) => domainType switch
        {
            Domain.Enums.ActionType.Fight => Application.Enums.ActionType.Fight,
            Domain.Enums.ActionType.Shoot => Application.Enums.ActionType.Shoot,
            _ => throw new ArgumentOutOfRangeException(nameof(domainType), $"Unhandled action type {domainType}")
        };

        public static Domain.Enums.ActionType ToDomain(Application.Enums.ActionType applicationType) => applicationType switch
        {
            Application.Enums.ActionType.Fight => Domain.Enums.ActionType.Fight,
            Application.Enums.ActionType.Shoot => Domain.Enums.ActionType.Shoot,
            _ => throw new ArgumentOutOfRangeException(nameof(applicationType), $"Unhandled action type {applicationType}")
        };
    }

}
