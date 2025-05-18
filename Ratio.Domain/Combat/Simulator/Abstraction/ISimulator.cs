using Ratio.Domain.Entities;

namespace Ratio.Domain.Combat.Simulator.Abstraction
{
    public interface ISimulator
    {
        static abstract CombatContext Simulate(Operative attacker, Operative defender);
    }

}
