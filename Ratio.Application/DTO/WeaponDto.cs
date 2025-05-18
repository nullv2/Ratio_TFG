namespace Ratio.Application.DTO
{
    public class WeaponDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }  // "Melee" or "Ranged"
        public int Attacks { get; set; }
        public int HitThreshold { get; set; }
        public int NormalDamage { get; set; }
        public int CriticalDamage { get; set; }

        public List<string> Traits { get; set; } = new();
    }
}
