namespace Ratio.Application.DTO
{
    public class EquipmentDto
    {
        public int Id { get; set; }
        public int KillTeamId { get; set; }  
        public string Name { get; set; }
        public string Type { get; set; } // "Weapon", "Ploy", "Operative"
        public int? WeaponId { get; set; }  // Only if Type == "Weapon"
        public string EffectType { get; set; }  // Only if Type == "Effect"
    }
}
