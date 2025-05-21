using Ratio.Domain.Effects.Abstraction;
using Ratio.Domain.Entities;
using Ratio.Domain.Enums;

namespace Ratio.Domain.Combat.Simulator
{
    /// <summary>
    /// Base class for combat simulation logic.
    /// Provides utility methods for handling combat phases, dice rolls, and hit classification.
    /// </summary>
    public abstract class BaseSimulator
    {
        /// <summary>
        /// Executes a combat phase for a single operative, applying all active effects of the specified type.
        /// </summary>
        /// <typeparam name="TEffect">The type of combat effect to apply.</typeparam>
        /// <param name="context">The combat context containing relevant combat data.</param>
        /// <param name="operative">The operative whose effects will be applied.</param>
        protected static void RunPhase<TEffect>(CombatContext context, Operative operative) where TEffect : ICombatEffect
        {
            foreach (var effect in operative.ActiveEffects.OfType<TEffect>())
            {
                CombatLog.Write($"Applying {effect.GetType().Name} to {operative.Name}");
                effect.ApplyEffect(context);
                context.RegisterEffectUsage(effect.GetType().Name);
            }
        }

        /// <summary>
        /// Executes a combat phase for both attacker and defender, applying all active effects of the specified type.
        /// </summary>
        /// <typeparam name="TEffect">The type of combat effect to apply.</typeparam>
        /// <param name="context">The combat context containing relevant combat data.</param>
        /// <param name="attacker">The attacking operative whose effects will be applied.</param>
        /// <param name="defender">The defending operative whose effects will be applied.</param>
        protected static void RunPhase<TEffect>(CombatContext context, Operative attacker, Operative defender) where TEffect : ICombatEffect
        {
            foreach (var effect in attacker.ActiveEffects.OfType<TEffect>())
            {
                CombatLog.Write($"Applying {effect.GetType().Name} to {attacker.Name}");
                effect.ApplyEffect(context);
                context.RegisterEffectUsage(effect.GetType().Name);
            }

            foreach (var effect in defender.ActiveEffects.OfType<TEffect>())
            {
                CombatLog.Write($"Applying {effect.GetType().Name} to {defender.Name}");
                effect.ApplyEffect(context);
                context.RegisterEffectUsage(effect.GetType().Name);
            }
        }

        /// <summary>
        /// Classifies a list of dice rolls into critical and normal hits based on weapon thresholds.
        /// </summary>
        /// <param name="rolls">The list of dice rolls to classify.</param>
        /// <param name="weapon">The weapon used to determine hit and critical thresholds.</param>
        /// <returns>A tuple containing the number of critical hits and normal hits.</returns>
        protected static HitPool ClassifyHits(List<int> rolls, Weapon weapon)
        {
            int hitThreshold = weapon.HitThreshold;
            int lethalThreshold = weapon.GetTraitValue(TraitType.Lethal) ?? 6;

            int crits = 0;
            int normals = 0;

            foreach (var roll in rolls)
            {
                if (roll >= hitThreshold)
                {
                    if (roll >= lethalThreshold)
                        crits++;
                    else
                        normals++;
                }
            }

            return new HitPool(crits, normals);
        }

        /// <summary>
        /// Rolls attack dice for the specified role and adds the results to the combat context.
        /// </summary>
        /// <param name="context">The combat context containing relevant combat data.</param>
        /// <param name="weapon">The weapon used to determine the number of attack dice.</param>
        /// <param name="role">The role (attacker or defender) for which the dice are rolled.</param>
        protected static void RollAttackDice(CombatContext context, Weapon weapon, CombatantRole role)
        {
            CombatLog.WriteHeader($"{role} Rolling Attack Dice for {weapon.Name}");

            for (int i = 0; i < weapon.Attacks; i++)
            {
                int roll = context.RollDie();
                CombatLog.Write($"Rolled: {roll}");

                if (role == CombatantRole.Attacker)
                    context.AttackerAttackRolls.Add(roll);
                else
                    context.DefenderAttackRolls.Add(roll);
            }
        }

        /// <summary>
        /// Rolls defense dice for the defender and adds the results to the combat context.
        /// </summary>
        /// <param name="context">The combat context containing relevant combat data.</param>
        protected static void RollDefenseDice(CombatContext context)
        {

            CombatLog.WriteHeader("Defender Rolling Defense Dice");

            for (int i = 0; i < context.DefenderDefenseDiceCount; i++)
            {
                int roll = context.RollDie();
                context.DefenderDefenseRolls.Add(roll);
                CombatLog.Write($"Rolled: {roll}");
            }
        }
    }
}
