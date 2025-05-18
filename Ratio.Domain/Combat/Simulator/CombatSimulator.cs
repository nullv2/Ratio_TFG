using Ratio.Domain.Entities;
using Ratio.Domain.Enums;

namespace Ratio.Domain.Combat.Simulator
{
    public enum CombatantRole
    {
        Attacker,
        Defender
    }

    public class CombatSimulator
    {
        public static CombatContext Simulate(Operative attacker, Operative defender, ActionType actionType)
        {
            CombatLog.WriteHeader($"Simulating {actionType} between {attacker.Name} and {defender.Name}");
            if (actionType == ActionType.Fight)
                return FightSimulator.Simulate(attacker, defender);

            return ShootingSimulator.Simulate(attacker, defender);
        }
    }
}
