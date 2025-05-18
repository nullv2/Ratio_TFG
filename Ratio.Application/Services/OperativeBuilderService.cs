using Ratio.Application.DTO;
using Ratio.Application.Enums;
using Ratio.Domain.Enums;
using Ratio.Application.Repositories;
using Ratio.Domain.Entities;
using Ratio.Domain.ValueObjects;

namespace Ratio.Application.Services
{
    public class OperativeBuilderService
    {
        private readonly IKillTeamRepository _killteamRepo;

        public OperativeBuilderService(IKillTeamRepository killteamRepo)
        {
            _killteamRepo = killteamRepo ?? throw new ArgumentNullException(nameof(killteamRepo));
        }

        public async Task<Operative> BuildOperativeAsync(OperativeToSim dto, Application.Enums.ActionType actionType, OperativeType operativeType)
        {
            // Fetch kill team and validate
            var killTeam = await _killteamRepo.GetKillTeamByIdAsync(dto.KillTeamId);
            if (killTeam == null)
            {
                throw new InvalidOperationException($"Kill Team '{dto.KillTeam}' not found.");
            }

            // Fetch operative from kill team by operative ID
            var operativeData = await _killteamRepo.GetOperativeByIdAsync(dto.Id);
            if (operativeData == null)
            {
                throw new InvalidOperationException($"No operative found with ID {dto.Id}");
            }

            // Create the operative entity
            var operative = Operative.Create(
                operativeData.Id,
                operativeData.Name,
                operativeData.Movement,
                operativeData.ActionPointLimit,
                operativeData.Wounds,
                operativeData.Save
            );

            // Set the weapon for the operative based on the action type
            switch (actionType)
            {
                case Application.Enums.ActionType.Fight:
                    Weapon meleeWeapon = await BuildWeapon(dto.SelectedMeleeWeaponId);
                    operative.AddWeapon(meleeWeapon);
                    break;
                case Application.Enums.ActionType.Shoot:
                    if (operativeType == OperativeType.Defender)
                    {
                        // Defender's ranged weapon is not used in the simulation
                        break;
                    }
                    Weapon rangedWeapon = await BuildWeapon(dto.SelectedRangedWeaponId);
                    operative.AddWeapon(rangedWeapon);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(actionType), actionType, null);
            }

            // Auto-select the first weapon if any are available
            if (operative.Weapons.Any())
            {
                operative.SelectWeapon(operative.Weapons.First());

                // Fetch and assign weapon traits
                var weaponTraits = await GetWeaponTraitsAsync(operative.SelectedWeapon.Id);
                foreach (var trait in weaponTraits)
                {
                    operative.SelectedWeapon.AddTrait(trait);
                }

            }

            // Future: Map ploys or faction-specific effects here

            return operative;
        }


        private async Task<IEnumerable<WeaponTrait>> GetWeaponTraitsAsync(int weaponId)
        {
            var traits = await _killteamRepo.GetWeaponTraitsByWeaponIdAsync(weaponId);
            return traits.Select(t => WeaponTrait.Create(
                t.TraitType,
                t.TraitValue)
            ).ToList();
        }

        private async Task<Weapon> BuildWeapon(int weaponId)
        {
            var weaponDto = await _killteamRepo.GetWeaponByIdAsync(weaponId);
            if (weaponDto == null)
            {
                throw new InvalidOperationException($"No weapon found with ID {weaponId}");
            }
            if (!Enum.TryParse<WeaponType>(weaponDto.Type, true, out var weaponType))
            {
                throw new InvalidOperationException($"Invalid weapon type '{weaponDto.Type}' for weapon ID {weaponDto.Id}");
            }
            // Create the weapon entity
            var weapon = Weapon.Create(
                weaponDto.Id,
                weaponDto.Name,
                weaponType,
                weaponDto.Attacks,
                weaponDto.HitThreshold,
                weaponDto.NormalDamage,
                weaponDto.CriticalDamage
            );
            return weapon;
        }



    }

}
