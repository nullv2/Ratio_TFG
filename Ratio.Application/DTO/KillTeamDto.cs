namespace Ratio.Application.DTO
{
    public class KillTeamDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int FactionId { get; set; } // Foreign Key to Faction
    }
}
