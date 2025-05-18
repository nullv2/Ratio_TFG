using Ratio.Application.Enums;

namespace Ratio.Application.DTO
{
    public class OperativeToSim
    {

        //Id's for the sim
        public int Id { get; set; }
        public int KillTeamId { get; set; }
        public int SelectedRangedWeaponId { get; set; }
        public int SelectedMeleeWeaponId { get; set; }

        public int SelectedFirefightPloyId { get; set; }
        public int SelectedStrategicPloyId { get; set; }

        //Info for the simulation 
        public string Faction { get; set; } = string.Empty;
        public string KillTeam { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string RangedWeaponName { get; set; } = string.Empty;
        public string MeleeWeaponName { get; set; } = string.Empty;
        public string Ploys { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
    }

}
