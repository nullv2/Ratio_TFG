using Ratio.Domain.Combat;

namespace Ratio.Domain.Effects.Abstraction
{
    /// <summary>
    /// Marker interface for combat effects.
    /// </summary>
    public interface ICombatEffect
    {
        void ApplyEffect(CombatContext context);
    }

    /// <summary>
    /// Interface for effects applied before an attack roll.
    /// </summary>
    public interface IBeforeAttackRoll : ICombatEffect
    {
        /// <summary>
        /// Applies the effect before the attack roll is made.
        /// </summary>
        /// <param name="context">The combat context in which the effect is applied.</param>
        new void ApplyEffect(CombatContext context);
    }

    /// <summary>
    /// Interface for effects applied after an attack roll.
    /// </summary>
    public interface IAfterAttackRoll : ICombatEffect
    {
        /// <summary>
        /// Applies the effect after the attack roll is made.
        /// </summary>
        /// <param name="context">The combat context in which the effect is applied.</param>
        new void ApplyEffect(CombatContext context);
    }

    /// <summary>
    /// Interface for effects applied before a defense roll. Only used in shooting.
    /// </summary>
    public interface IBeforeDefenseRoll : ICombatEffect
    {
        /// <summary>
        /// Applies the effect before the defense roll is made.
        /// </summary>
        /// <param name="context">The combat context in which the effect is applied.</param>
        new void ApplyEffect(CombatContext context);
    }

    /// <summary>
    /// Interface for effects applied after a defense roll. Only used in shooting.
    /// </summary>
    public interface IAfterDefenseRoll : ICombatEffect
    {
        /// <summary>
        /// Applies the effect after the defense roll is made.
        /// </summary>
        /// <param name="context">The combat context in which the effect is applied.</param>
        new void ApplyEffect(CombatContext context);
    }

    /// <summary>
    /// Interface for effects applied before damage resolution.
    /// </summary>
    public interface IBeforeDamageResolution : ICombatEffect
    {
        /// <summary>
        /// Applies the effect before damage is resolved.
        /// </summary>
        /// <param name="context">The combat context in which the effect is applied.</param>
        new void ApplyEffect(CombatContext context);
    }

    /// <summary>
    /// Interface for effects applied after damage resolution.
    /// </summary>
    public interface IAfterDamageResolution : ICombatEffect
    {
        /// <summary>
        /// Applies the effect after damage is resolved.
        /// </summary>
        /// <param name="context">The combat context in which the effect is applied.</param>
        new void ApplyEffect(CombatContext context);
    }
}
