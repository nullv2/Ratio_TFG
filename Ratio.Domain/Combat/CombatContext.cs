using Ratio.Domain.DTO;
using Ratio.Domain.Entities;
using Ratio.Domain.Enums;

namespace Ratio.Domain.Combat
{
    public class CombatContext
    {
        public Operative Attacker { get; private set; }
        public Operative Defender { get; private set; }

        public Weapon AttackerWeapon { get; private set; }
        public Weapon DefenderWeapon { get; private set; }

        public ActionType ActionType { get; private set; }

        // Attacker's attack phase (used in both Shoot and Fight)
        public List<int> AttackerAttackRolls { get; private set; } = new();
        public int AttackerRetainedNormalHits { get; set; }
        public int AttackerRetainedCriticalHits { get; set; }

        // Defender's attack phase (only used in Fight)
        public List<int> DefenderAttackRolls { get; private set; } = new();
        public int DefenderRetainedNormalHits { get; set; }
        public int DefenderRetainedCriticalHits { get; set; }

        // Defender's defense phase (only used in Shoot)
        public List<int> DefenderDefenseRolls { get; private set; } = new();
        public int DefenderDefenseDiceCount { get; set; } = 3;

        // Damage phase
        public int TotalDamage { get; set; }
        public int SelfDamageToAttacker { get; set; }

        // Control flags
        public bool TargetPreviouslyShot { get; set; }

        private static readonly Random _random = new();

        // More fight-specific properties
        public int AttackerCriticalHitsParried { get; set; }
        public int DefenderCriticalHitsParried { get; set; }
        public int AttackerNormalHitsParried { get; set; }
        public int DefenderNormalHitsParried { get; set; }

        // Result
        public SimulationResultType ResultType { get; set; } = SimulationResultType.None;

        // Effect usage counts
        public Dictionary<string, int> EffectUsageCounts { get; private set; } = new();

        public void RegisterEffectUsage(string effectName)
        {
            if (EffectUsageCounts.ContainsKey(effectName))
                EffectUsageCounts[effectName]++;
            else
                EffectUsageCounts[effectName] = 1;
        }

        private CombatContext(Operative attacker, Operative defender, Weapon attackerWeapon, Weapon defenderWeapon, ActionType actionType)
        {
            Attacker = attacker;
            Defender = defender;
            AttackerWeapon = attackerWeapon;
            DefenderWeapon = defenderWeapon;
            ActionType = actionType;
        }

        public static CombatContext Create(Operative attacker, Operative defender, ActionType actionType)
        {
            if (attacker == null)
                throw new ArgumentNullException(nameof(attacker));
            if (defender == null)
                throw new ArgumentNullException(nameof(defender));


            //For shooting, defender doesn't need weapon
            //For fight, both need weapon
            if (actionType == ActionType.Shoot)
            {
                if (attacker.SelectedWeapon == null)
                    throw new InvalidOperationException("Attacker must have a selected weapon for shooting.");
                
                return new CombatContext(attacker, defender, attacker.SelectedWeapon, null, actionType);
            }

            if (attacker.SelectedWeapon == null)
                throw new InvalidOperationException("Attacker must have a selected weapon for fighting.");
            if (defender.SelectedWeapon == null)
                throw new InvalidOperationException("Defender must have a selected weapon for fighting.");

            return new CombatContext(attacker, defender, attacker.SelectedWeapon, defender.SelectedWeapon, actionType);
        }

        public int RollDie() => _random.Next(1, 7);

        

    }

}
