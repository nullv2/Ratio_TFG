namespace Ratio.Domain.Combat.Simulator
{
    public class HitPool
    {
        public int Crits { get; set; }
        public int Normals { get; set; }

        public HitPool(int crits, int normals)
        {
            Crits = crits;
            Normals = normals;
        }
        public bool HasHits() => Crits > 0 || Normals > 0;
    }

}
