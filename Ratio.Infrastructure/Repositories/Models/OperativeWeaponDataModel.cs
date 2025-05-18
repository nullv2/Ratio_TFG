using SQLite;

namespace Ratio.Infrastructure.Repositories.Models
{
    [Table("OperativeWeapon")]
    public class OperativeWeaponDataModel
    {
        [PrimaryKey]
        public int Id { get; set; }
        public int OperativeId { get; set; }
        public int WeaponId { get; set; }
    }
}
