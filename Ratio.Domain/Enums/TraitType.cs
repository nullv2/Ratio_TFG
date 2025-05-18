namespace Ratio.Domain.Enums
{
    public enum TraitType
    {
        Accurate, // Retains X attack dice as normal successes without rolling them
        Balanced, // Allows re-rolling one attack die
        Brutal, // Opponent can only block with critical successes
        Ceaseless, // Allows re-rolling any attack dice results of a specific value (e.g., results of 2)
        Devastating, // Each retained critical success inflicts X damage immediately, without being discarded
        Hot, // After use, roll a D6; if the result is less than the weapon's Hit stat, inflict damage on the user equal to the result × 2
        Lethal, // Successes equal to or greater than X are critical successes
        Piercing, // Defender collects X fewer defense dice
        PiercingCrits, // Defender collects X fewer defense dice if any critical successes are retained
        Punishing, // Retain one fail as a normal success if any critical successes are retained
        Relentless, // Allows re-rolling any attack dice
        Rending, // Retain one normal success as a critical success if any critical successes are retained
        Severe, // If no critical successes are retained, change one normal success to a critical success
        Shock // Discard one of the opponent's unresolved normal successes (or critical if no normal ones) the first time a critical success strikes in each sequence
    }
}
