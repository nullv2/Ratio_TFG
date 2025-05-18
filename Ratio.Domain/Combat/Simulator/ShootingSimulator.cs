using Ratio.Domain.Combat.Simulator.Abstraction;
using Ratio.Domain.Effects.Abstraction;
using Ratio.Domain.Entities;
using Ratio.Domain.Enums;

namespace Ratio.Domain.Combat.Simulator
{
    /// <summary>
    /// Simulates a shooting combat scenario between an attacker and a defender.
    /// Handles all phases of the shooting combat, including attack rolls, defense rolls, and damage resolution.
    /// </summary>
    public class ShootingSimulator : BaseSimulator, ISimulator
    {
        /// <summary>
        /// Simulates a shooting combat scenario between the specified attacker and defender.
        /// </summary>
        /// <param name="attacker">The operative initiating the attack.</param>
        /// <param name="defender">The operative defending against the attack.</param>
        /// <returns>A <see cref="CombatContext"/> object containing the results of the simulation.</returns>
        public static CombatContext Simulate(Operative attacker, Operative defender)
        {
            var context = CombatContext.Create(attacker, defender, ActionType.Shoot);

            RunPhase<IBeforeAttackRoll>(context, attacker, defender);
            RollAttackDice(context, context.AttackerWeapon, CombatantRole.Attacker);
            RunPhase<IAfterAttackRoll>(context, attacker, defender);

            var attackerHits = ClassifyHits(context.AttackerAttackRolls, context.AttackerWeapon);
            context.AttackerRetainedCriticalHits = attackerHits.Crits;
            context.AttackerRetainedNormalHits = attackerHits.Normals;

            RunPhase<IBeforeDefenseRoll>(context, attacker, defender);
            RollDefenseDice(context);

            RunPhase<IAfterDefenseRoll>(context, attacker, defender);

            ApplyDefenseBlocking(context);

            RunPhase<IBeforeDamageResolution>(context, attacker, defender);

            ResolveDamage(context);

            RunPhase<IAfterDamageResolution>(context, attacker, defender);

            // Set the result type based on the combat context
            if (context.Defender.Wounds <= 0)
            {
                context.ResultType = SimulationResultType.AttackerWins;
            }

            return context;
        }

        /// <summary>
        /// Applies the defender's defense rolls to block the attacker's hits.
        /// Critical hits are blocked first, followed by normal hits.
        /// </summary>
        /// <param name="context">The combat context containing the attack and defense rolls.</param>
        private static void ApplyDefenseBlocking(CombatContext context)
        {
            CombatLog.WriteHeader("Applying Defense Blocking");

            // Collect defense results
            var defenseSaves = context.DefenderDefenseRolls.Where(r => r >= context.Defender.Save).ToList();
            int critSaves = defenseSaves.Count(r => r == 6);
            int normalSaves = defenseSaves.Count - critSaves;

            CombatLog.Write($"Defense Rolls: {string.Join(", ", context.DefenderDefenseRolls)}");
            CombatLog.Write($"Successful Saves - Critical: {critSaves}, Normal: {normalSaves}");

            int blockedCrits = 0;
            int blockedNormals = 0;

            // 1. Block critical hits with critical saves first
            while (context.AttackerRetainedCriticalHits > 0 && critSaves > 0)
            {
                context.AttackerRetainedCriticalHits--;
                critSaves--;
                blockedCrits++;
                CombatLog.Write($"Blocked Critical Hit with Critical Save");
            }

            // 2. Block critical hits with two normal saves
            while (context.AttackerRetainedCriticalHits > 0 && normalSaves >= 2)
            {
                context.AttackerRetainedCriticalHits--;
                normalSaves -= 2;
                blockedCrits++;
                CombatLog.Write($"Blocked Critical Hit with Two Normal Saves");
            }

            // 3. Block normal hits with critical saves
            while (context.AttackerRetainedNormalHits > 0 && critSaves > 0)
            {
                context.AttackerRetainedNormalHits--;
                critSaves--;
                blockedNormals++;
                CombatLog.Write($"Blocked Normal Hit with Critical Save");
            }

            // 4. Block normal hits with normal saves
            while (context.AttackerRetainedNormalHits > 0 && normalSaves > 0)
            {
                context.AttackerRetainedNormalHits--;
                normalSaves--;
                blockedNormals++;
                CombatLog.Write($"Blocked Normal Hit with Normal Save");
            }

            CombatLog.Write($"Blocked {blockedCrits} Critical Hits and {blockedNormals} Normal Hits");
        }


        /// <summary>
        /// Resolves the damage dealt by the attacker based on retained hits in a Shoot action.
        /// Only the attacker deals damage in Shoot.
        /// </summary>
        private static void ResolveDamage(CombatContext context)
        {
            CombatLog.WriteHeader("Resolving Attacker's Damage (Shoot)");

            int normalHits = context.AttackerRetainedNormalHits;
            int critHits = context.AttackerRetainedCriticalHits;

            CombatLog.Write($"Normal Hits: {normalHits}, Critical Hits: {critHits}");

            Weapon weapon = context.AttackerWeapon;

            context.TotalDamage = normalHits * weapon.NormalDamage + critHits * weapon.CriticalDamage;

            context.Defender.TakeDamage(context.TotalDamage);
            CombatLog.Write($"Dealt {context.TotalDamage} Damage to {context.Defender.Name}");

            if (context.Defender.Wounds <= 0)
            {
                CombatLog.Write($"{context.Defender.Name} is incapacitated!");
                context.Defender.Kaput();
            }
        }

    }
}
