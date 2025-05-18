
using Ratio.Application.DTO;

namespace Ratio.Application.Repositories
{
    public interface IKillTeamRepository
    {
        // Factions
        Task<IEnumerable<FactionDto>> GetAllFactionsAsync();
        Task<FactionDto> GetFactionByIdAsync(int id);


        // Kill Teams
        Task<IEnumerable<KillTeamDto>> GetAllKillTeamsAsync();
        Task<KillTeamDto> GetKillTeamByIdAsync(int id);

        // Operatives
        Task<IEnumerable<OperativeDto>> GetAllOperativesAsync();
        Task<IEnumerable<OperativeDto>> GetOperativesByKillTeamIdAsync(int killTeamId);
        Task<OperativeDto> GetOperativeByIdAsync(int id);
        Task<OperativeDto> FilterByNameAsync(string name);

        // Weapons
        Task<IEnumerable<WeaponDto>> GetAllWeaponsAsync();
        Task<IEnumerable<WeaponDto>> GetWeaponsByOperativeIdAsync(int operativeId);
        Task<WeaponDto> GetWeaponByIdAsync(int id);

        // Weapon Traits
        Task<IEnumerable<WeaponTraitDto>> GetAllWeaponTraitsAsync();
        Task<IEnumerable<WeaponTraitDto>> GetWeaponTraitsByWeaponIdAsync(int weaponId);
        Task<WeaponTraitDto> GetWeaponTraitByIdAsync(int id);

        // Ploys
        Task<IEnumerable<PloyDto>> GetAllPloysAsync();
        Task<IEnumerable<PloyDto>> GetPloysByKillTeamIdAsync(int killTeamId);
        Task<PloyDto> GetPloyByIdAsync(int id);

        // Operative Weapons (Loadout)
        Task<IEnumerable<OperativeWeaponDto>> GetAllOperativeWeaponsAsync();
        Task<IEnumerable<OperativeWeaponDto>> GetOperativeWeaponsByOperativeIdAsync(int operativeId);
    }

}
