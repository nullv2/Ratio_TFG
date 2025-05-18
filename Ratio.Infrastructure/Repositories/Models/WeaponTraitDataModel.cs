using SQLite;

namespace Ratio.Infrastructure.Repositories.Models
{
    [Table("WeaponTrait")]
    public class WeaponTraitDataModel
    {
        [PrimaryKey]
        public int Id { get; set; }
        public int WeaponId { get; set; }
        public string TraitType { get; set; }  // Example: "Lethal"
        public int? TraitValue { get; set; }   // Example: 5 (for Lethal 5+), nullable
    }
}
