namespace Ratio.Application.DTO
{
    public class OperativeDto
    {
        public int Id { get; set; }
        public int KillTeamId { get; set; }
        public string Name { get; set; }
        public int Movement { get; set; }
        public int ActionPointLimit { get; set; }
        public int Wounds { get; set; }
        public int Save { get; set; }
        public string Image { get; set; } // URL or path to the image
    }
}
