using SQLite;

namespace Ratio.Infrastructure.Repositories.Models
{
    [Table("Faction")]
    public class FactionDataModel
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
