using SQLite;

namespace Ratio.Infrastructure.Repositories.Models
{
    [Table("Equipment")]
    public class EquipmentDataModel
    {
        [PrimaryKey]
        public int Id { get; set; }
        public int KillTeamId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }  // "Weapon" or "Effect"
        public int? WeaponId { get; set; }  // Only if Type == "Weapon"
        public string EffectType { get; set; }  // Only if Type == "Effect"
    }
}
