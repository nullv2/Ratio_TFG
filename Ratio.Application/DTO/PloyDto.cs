namespace Ratio.Application.DTO
{
    public class PloyDto
    {
        public int Id { get; set; }
        public int KillTeamId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; } // Strategy, Firefight, FactionRule
        public string EffectType { get; set; } // Effect class identifier
        public string Description { get; set; }
    }
}
