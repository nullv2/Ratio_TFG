using Ratio.Application.DTO;
using Ratio.Application.Repositories;
using Ratio.Infrastructure.Repositories.Models;
using SQLite;

namespace Ratio.Infrastructure.Repositories
{
    public class KillTeamRepository : IKillTeamRepository
    {
        private readonly SQLiteAsyncConnection _db;

        public KillTeamRepository(SQLiteAsyncConnection db)
        {
            _db = db;
        }

        // Factions
        public async Task<IEnumerable<FactionDto>> GetAllFactionsAsync()
        {
            var models = await _db.Table<FactionDataModel>().ToListAsync();
            return models.Select(m => new FactionDto { Id = m.Id, Name = m.Name });
        }

        public async Task<FactionDto?> GetFactionByIdAsync(int id)
        {
            var model = await _db.Table<FactionDataModel>().FirstOrDefaultAsync(x => x.Id == id);
            return model == null ? null : new FactionDto { Id = model.Id, Name = model.Name };
        }

        // Kill Teams
        public async Task<IEnumerable<KillTeamDto>> GetAllKillTeamsAsync()
        {
            var models = await _db.Table<KillTeamDataModel>().ToListAsync();
            return models.Select(m => new KillTeamDto { Id = m.Id, Name = m.Name, FactionId = m.FactionId });
        }

        public async Task<KillTeamDto?> GetKillTeamByIdAsync(int id)
        {
            var model = await _db.Table<KillTeamDataModel>().FirstOrDefaultAsync(x => x.Id == id);
            return model == null ? null : new KillTeamDto { Id = model.Id, Name = model.Name, FactionId = model.FactionId };
        }

        // Operatives
        private static OperativeDto MapOperative(OperativeDataModel m) => new OperativeDto
        {
            Id = m.Id,
            Name = m.Name,
            Movement = m.Movement,
            ActionPointLimit = m.ActionPointLimit,
            Wounds = m.Wounds,
            Save = m.Save,
            KillTeamId = m.KillTeamId,
            Image = m.Image
        };

        public async Task<IEnumerable<OperativeDto>> GetAllOperativesAsync()
        {
            var models = await _db.Table<OperativeDataModel>().ToListAsync();
            return models.Select(MapOperative);
        }

        public async Task<IEnumerable<OperativeDto>> GetOperativesByKillTeamIdAsync(int killTeamId)
        {
            var models = await _db.Table<OperativeDataModel>().Where(x => x.KillTeamId == killTeamId).ToListAsync();
            return models.Select(MapOperative);
        }

        public async Task<OperativeDto?> GetOperativeByIdAsync(int id)
        {
            var model = await _db.Table<OperativeDataModel>().FirstOrDefaultAsync(x => x.Id == id);
            return model == null ? null : MapOperative(model);
        }

        public async Task<OperativeDto?> FilterByNameAsync(string name)
        {
            var model = await _db.Table<OperativeDataModel>().FirstOrDefaultAsync(x => x.Name.Contains(name));
            return model == null ? null : MapOperative(model);
        }

        // Weapons
        private static WeaponDto MapWeapon(WeaponDataModel m) => new WeaponDto
        {
            Id = m.Id,
            Name = m.Name,
            Type = m.Type,
            Attacks = m.Attacks,
            HitThreshold = m.HitThreshold,
            NormalDamage = m.NormalDamage,
            CriticalDamage = m.CriticalDamage
        };

        public async Task<IEnumerable<WeaponDto>> GetAllWeaponsAsync()
        {
            var models = await _db.Table<WeaponDataModel>().ToListAsync();
            return models.Select(MapWeapon);
        }

        public async Task<IEnumerable<WeaponDto>> GetWeaponsByOperativeIdAsync(int operativeId)
        {
            var mappings = await _db.Table<OperativeWeaponDataModel>()
                                    .Where(x => x.OperativeId == operativeId)
                                    .ToListAsync();

            if (mappings.Count == 0)
                return Enumerable.Empty<WeaponDto>();

            var weaponIds = mappings.Select(m => m.WeaponId).Distinct().ToList();

            var weaponModels = await _db.Table<WeaponDataModel>()
                                        .Where(w => weaponIds.Contains(w.Id))
                                        .ToListAsync();

            return weaponModels.Select(MapWeapon);
        }

        public async Task<WeaponDto?> GetWeaponByIdAsync(int id)
        {
            var model = await _db.Table<WeaponDataModel>().FirstOrDefaultAsync(x => x.Id == id);
            return model == null ? null : MapWeapon(model);
        }

        // Weapon Traits
        private static WeaponTraitDto MapWeaponTrait(WeaponTraitDataModel m) => new WeaponTraitDto
        {
            Id = m.Id,
            WeaponId = m.WeaponId,
            TraitType = m.TraitType,
            TraitValue = m.TraitValue
        };

        public async Task<IEnumerable<WeaponTraitDto>> GetAllWeaponTraitsAsync()
        {
            var models = await _db.Table<WeaponTraitDataModel>().ToListAsync();
            return models.Select(MapWeaponTrait);
        }

        public async Task<IEnumerable<WeaponTraitDto>> GetWeaponTraitsByWeaponIdAsync(int weaponId)
        {
            var models = await _db.Table<WeaponTraitDataModel>().Where(x => x.WeaponId == weaponId).ToListAsync();
            return models.Select(MapWeaponTrait);
        }

        public async Task<WeaponTraitDto?> GetWeaponTraitByIdAsync(int id)
        {
            var model = await _db.Table<WeaponTraitDataModel>().FirstOrDefaultAsync(x => x.Id == id);
            return model == null ? null : MapWeaponTrait(model);
        }

        // Ploys
        private static PloyDto MapPloy(PloyDataModel m) => new PloyDto
        {
            Id = m.Id,
            Name = m.Name,
            KillTeamId = m.KillTeamId,
            Type = m.Type,
            EffectType = m.EffectType,
            Description = m.Description
        };

        public async Task<IEnumerable<PloyDto>> GetAllPloysAsync()
        {
            var models = await _db.Table<PloyDataModel>().ToListAsync();
            return models.Select(MapPloy);
        }

        public async Task<IEnumerable<PloyDto>> GetPloysByKillTeamIdAsync(int killTeamId)
        {
            var models = await _db.Table<PloyDataModel>().Where(x => x.KillTeamId == killTeamId).ToListAsync();
            return models.Select(MapPloy);
        }

        public async Task<PloyDto?> GetPloyByIdAsync(int id)
        {
            var model = await _db.Table<PloyDataModel>().FirstOrDefaultAsync(x => x.Id == id);
            return model == null ? null : MapPloy(model);
        }

        // Operative Weapons
        private static OperativeWeaponDto MapOperativeWeapon(OperativeWeaponDataModel m) => new OperativeWeaponDto
        {
            Id = m.Id,
            OperativeId = m.OperativeId,
            WeaponId = m.WeaponId
        };

        public async Task<IEnumerable<OperativeWeaponDto>> GetAllOperativeWeaponsAsync()
        {
            var models = await _db.Table<OperativeWeaponDataModel>().ToListAsync();
            return models.Select(MapOperativeWeapon);
        }

        public async Task<IEnumerable<OperativeWeaponDto>> GetOperativeWeaponsByOperativeIdAsync(int operativeId)
        {
            var models = await _db.Table<OperativeWeaponDataModel>().Where(x => x.OperativeId == operativeId).ToListAsync();
            return models.Select(MapOperativeWeapon);
        }
    }
}
