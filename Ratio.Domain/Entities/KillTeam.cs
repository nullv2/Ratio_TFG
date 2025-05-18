namespace Ratio.Domain.Entities
{
    public class KillTeam
    {
        private readonly List<Operative> _operatives = new();


        public int Id { get; set; }
        public string Name { get; set; }
        public IReadOnlyList<Operative> Operatives => _operatives.AsReadOnly();

        private KillTeam(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public static KillTeam Create(int id, string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name cannot be empty.", nameof(name));
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be greater than zero.");
            return new KillTeam(id, name);
        }
    }
}
