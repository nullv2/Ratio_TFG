using Ratio.Domain.Combat.Simulator.Abstraction;
using Ratio.Domain.Effects.Abstraction;
using Ratio.Domain.Entities;
using Ratio.Domain.Enums;

namespace Ratio.Domain.Combat.Simulator
{

    internal enum Role
    {
        Attacker,
        Defender
    }

    /// <summary>
    /// Simulates a fight between two operatives, handling attack rolls, hit classification, and damage resolution.
    /// </summary>
    public class FightSimulator : BaseSimulator, ISimulator
    {
        /// <summary>
        /// Simulates a combat scenario between an attacker and a defender.
        /// </summary>
        /// <param name="attacker">The attacking operative.</param>
        /// <param name="defender">The defending operative.</param>
        /// <returns>A <see cref="CombatContext"/> object containing the results of the simulation.</returns>
        public static CombatContext Simulate(Operative attacker, Operative defender)
        {
            var context = CombatContext.Create(attacker, defender, ActionType.Fight);

            //Attacker
            RunPhase<IBeforeAttackRoll>(context, attacker);
            RollAttackDice(context, context.AttackerWeapon, CombatantRole.Attacker);
            RunPhase<IAfterAttackRoll>(context, attacker);

            var attackerHits = ClassifyHits(context.AttackerAttackRolls, context.AttackerWeapon);
            context.AttackerRetainedCriticalHits = attackerHits.Crits;
            context.AttackerRetainedNormalHits = attackerHits.Normals;

            //Defender
            RunPhase<IBeforeAttackRoll>(context, defender);
            RollAttackDice(context, context.DefenderWeapon, CombatantRole.Defender);
            RunPhase<IAfterAttackRoll>(context, defender);

            var defenderHits = ClassifyHits(context.DefenderAttackRolls, context.DefenderWeapon);
            context.DefenderRetainedCriticalHits = defenderHits.Crits;
            context.DefenderRetainedNormalHits = defenderHits.Normals;

            // Combat
            RunPhase<IBeforeDamageResolution>(context, attacker, defender);
            ResolveFightStrikesAndParries(context, attackerHits, defenderHits);
            RunPhase<IAfterDamageResolution>(context, attacker, defender);

            //See if it's a draw
            if (context.Attacker.Wounds <= 0 && context.Defender.Wounds <= 0)
            {
                context.ResultType = SimulationResultType.Draw;
                CombatLog.Write("Both operatives are incapacitated. It's a draw!");
            }
            else if (context.Attacker.Wounds <= 0)
            {
                context.ResultType = SimulationResultType.DefenderWins;
                CombatLog.Write($"{context.Attacker.Name} is incapacitated. {context.Defender.Name} wins!");
            }
            else if (context.Defender.Wounds <= 0)
            {
                context.ResultType = SimulationResultType.AttackerWins;
                CombatLog.Write($"{context.Defender.Name} is incapacitated. {context.Attacker.Name} wins!");
            }

            return context;
        }

        /// <summary>
        /// Resolves the strikes and parries during a fight, alternating between attacker and defender.
        /// </summary>
        /// <param name="context">The combat context containing relevant combat data.</param>
        /// <param name="attackerHits">The hits scored by the attacker.</param>
        /// <param name="defenderHits">The hits scored by the defender.</param>
        private static void ResolveFightStrikesAndParries(CombatContext context, HitPool attackerHits, HitPool defenderHits)
        {
            bool attackerShockUsed = false;
            bool defenderShockUsed = false;
            bool attackerTurn = true;

            CombatLog.Write($"Attacker: {context.Attacker.Name} ({context.AttackerWeapon.Name})");
            CombatLog.Write($"Defender: {context.Defender.Name} ({context.DefenderWeapon.Name})");
            CombatLog.Write($"Attacker Hits: {attackerHits.Crits} Crits, {attackerHits.Normals} Normals");
            CombatLog.Write($"Defender Hits: {defenderHits.Crits} Crits, {defenderHits.Normals} Normals");
            CombatLog.WriteHeader("Resolving Fight Strikes and Parries");

            while (attackerHits.HasHits() && defenderHits.HasHits())
            {
                if (attackerTurn)
                {
                    CombatLog.Write("Attacker turn");
                    ExecuteStrikeOrParry(context, attackerHits, defenderHits, context.AttackerWeapon, context.Attacker, context.Defender, Role.Attacker, ref attackerShockUsed);
                }
                else
                {
                    CombatLog.Write("Defender turn");
                    ExecuteStrikeOrParry(context, defenderHits, attackerHits, context.DefenderWeapon, context.Defender, context.Attacker, Role.Defender, ref defenderShockUsed);
                }

                if (context.Attacker.Wounds <= 0 || context.Defender.Wounds <= 0)
                    break;

                attackerTurn = !attackerTurn;
            }

            ApplyRemainingHits(context, attackerHits, context.Attacker, context.Defender, context.AttackerWeapon);
            ApplyRemainingHits(context, defenderHits, context.Defender, context.Attacker, context.DefenderWeapon);

        }


        private static void ExecuteStrikeOrParry(
            CombatContext context,
            HitPool actingHits,
            HitPool opposingHits,
            Weapon actingWeapon,
            Operative actingOperative,
            Operative opposingOperative,
            Role actingRole,
            ref bool shockUsed)
        {
            if (actingHits.Crits > 0)
            {
                actingHits.Crits--;
                opposingOperative.TakeDamage(actingWeapon.CriticalDamage);
                CombatLog.Write($"{actingOperative.Name}[{actingRole}] critically strikes {opposingOperative.Name} with {actingWeapon.Name} for {actingWeapon.CriticalDamage} damage.");

                if (!shockUsed && actingWeapon.HasTrait(TraitType.Shock))
                {
                    ApplyShock(ref opposingHits);
                    shockUsed = true;
                }
            }
            else if (actingHits.Normals > 0)
            {
                bool opponentCanParry = opposingHits.Crits > 0 ||
                                        (opposingHits.Normals > 0 && !actingWeapon.HasTrait(TraitType.Brutal));

                if (opponentCanParry)
                {
                    if (opposingHits.Crits > 0)
                    {
                        opposingHits.Crits--;
                        switch(actingRole)
                        {
                            case Role.Attacker: 
                                context.DefenderCriticalHitsParried++;
                                break;
                            case Role.Defender:
                                context.AttackerCriticalHitsParried++;
                                break;
                        }
                        CombatLog.Write($"{opposingOperative.Name} parries a critical hit from {actingOperative.Name}[{actingRole}].");
                    }
                    else
                    {
                        opposingHits.Normals--;
                        switch (actingRole)
                        {
                            case Role.Attacker:
                                context.DefenderNormalHitsParried++;
                                break;
                            case Role.Defender:
                                context.AttackerNormalHitsParried++;
                                break;
                        }
                        CombatLog.Write($"{opposingOperative.Name} parries a normal hit from {actingOperative.Name}[{actingRole}].");
                    }
                    actingHits.Normals--;
                }
                else
                {
                    actingHits.Normals--;
                    opposingOperative.TakeDamage(actingWeapon.NormalDamage);
                    CombatLog.Write($"{actingOperative.Name}[{actingRole}] strikes {opposingOperative.Name} with {actingWeapon.Name} for {actingWeapon.NormalDamage} damage.");
                }
            }
        }


        /// <summary>
        /// Applies the shock trait effect, reducing the defender's hits.
        /// </summary>
        /// <param name="hits">The hits to modify.</param>
        private static void ApplyShock(ref HitPool hits)
        {
            if (hits.Normals > 0)
                hits.Normals--;
            else if (hits.Crits > 0)
                hits.Crits--;
        }

        /// <summary>
        /// Applies any remaining hits to the target after all strikes and parries are resolved.
        /// </summary>
        /// <param name="context">The combat context containing relevant combat data.</param>
        /// <param name="hits">The remaining hits to apply.</param>
        /// <param name="target">The target operative to apply damage to.</param>
        /// <param name="weapon">The weapon used to calculate damage.</param>
        private static void ApplyRemainingHits(CombatContext context, HitPool hits, Operative source, Operative target, Weapon weapon)
        {
            while (hits.Crits-- > 0)
            {
                target.TakeDamage(weapon.CriticalDamage);
                CombatLog.Write($"{source.Name} strikes {target.Name} with {weapon.Name} for {weapon.CriticalDamage} damage.");
            }

            while (hits.Normals-- > 0)
            {
                target.TakeDamage(weapon.NormalDamage);
                CombatLog.Write($"{source.Name} strikes {target.Name} with {weapon.Name} for {weapon.NormalDamage} damage.");
            }
        }

    }
}
