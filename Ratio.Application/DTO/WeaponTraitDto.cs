namespace Ratio.Application.DTO
{
    public class WeaponTraitDto
    {
        public int Id { get; set; }
        public int WeaponId { get; set; }
        public string TraitType { get; set; }  // Example: "Lethal"
        public int? TraitValue { get; set; }   // Example: 5 (for Lethal 5+), nullable
    }
}
