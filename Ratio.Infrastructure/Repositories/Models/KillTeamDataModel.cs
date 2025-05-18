using SQLite;

namespace Ratio.Infrastructure.Repositories.Models
{
    [Table("KillTeam")]
    public class KillTeamDataModel
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string Name { get; set; }
        public int FactionId { get; set; } // Foreign Key to Faction
    }
}
