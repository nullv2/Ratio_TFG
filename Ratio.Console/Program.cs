using Ratio.Application.Repositories;
using Ratio.Application.Services;
using Ratio.Domain;
using Ratio.Domain.Entities;
using Ratio.Domain.Enums;
using Ratio.Domain.ValueObjects;
using System.Data;

Console.WriteLine("Piercing Shotgun Simulation...");

var proctor = Operative.Create(1, "Proctor-Exactant", 6, 2, 9, 4);
var shotgun = Weapon.Create(1, "Piercing Shotgun", WeaponType.Ranged, 4, 4, 4, 4);
shotgun.AddTrait(WeaponTrait.Create(TraitType.Piercing, 1));
proctor.AddWeapon(shotgun);
proctor.SelectWeapon(shotgun);

var castig = Operative.Create(2, "Castigator", 6, 2, 8, 4);
castig.AddWeapon(Weapon.Create(2, "Excruciator Maul", WeaponType.Ranged, 4, 3, 5, 5));
castig.SelectWeapon(castig.Weapons.First());

CombatLog.IsEnabled = true;

//var KillTeamCombatService = new KillTeamCombatService(new OperativeMapper(new WeaponTypeMapper(new WeaponTraitMapper())));


////var result = await KillTeamCombatService.SimulateAsync(proctor, castig, ActionType.Shoot, 1000);
//Console.WriteLine($"Attacker: {result.AttackerId}");
//Console.WriteLine($"Defender: {result.DefenderId}");
//Console.WriteLine($"Attacker Normal Hits: {result.AttackerNormalHitCount}");
//Console.WriteLine($"Attacker Critical Hits: {result.AttackerCritHitCount}");
//Console.WriteLine($"Defender Normal Hits: {result.DefenderNormalHitCount}");
//Console.WriteLine($"Defender Critical Hits: {result.DefenderCritHitCount}");

//Console.WriteLine($"Attacker Critical Hits Parried: {result.AttackerCriticalHitsParried}");
//Console.WriteLine($"Defender Critical Hits Parried: {result.DefenderCriticalHitsParried}");
//Console.WriteLine($"Attacker Normal Hits Parried: {result.AttackerNormalHitsParried}");
//Console.WriteLine($"Defender Normal Hits Parried: {result.DefenderNormalHitsParried}");

//Console.WriteLine($"Attacker Average Damage Dealt: {result.AttackerAverageDamageDealt}");
//Console.WriteLine($"Defender Average Damage Dealt: {result.DefenderAverageDamageDealt}");
//Console.WriteLine($"Attacker Average Remaining Wounds: {result.AttackerAverageRemainingWounds}");
//Console.WriteLine($"Defender Average Remaining Wounds: {result.DefenderAverageRemainingWounds}");
//Console.WriteLine($"Attacker Incapacitated: {result.AttackerIncapacitatedCount}");
//Console.WriteLine($"Defender Incapacitated: {result.DefenderIncapacitatedCount}");
//Console.WriteLine($"Effect Usage Counts: {string.Join(", ", result.EffectUsageCounts.Select(kvp => $"{kvp.Key}: {kvp.Value}"))}");
//Console.WriteLine($"Attacker Survival Rate: {result.AttackerSurvivalRate}");
//Console.WriteLine($"Defender Survival Rate: {result.DefenderSurvivalRate}");
//Console.WriteLine($"Attacker Average Crit Hit Chance: {result.AttackerAverageCritHitChance}");
//Console.WriteLine($"Attacker Average Normal Hit Chance: {result.AttackerAverageNormalHitChance}");
//Console.WriteLine($"Defender Average Crit Hit Chance: {result.DefenderAverageCritHitChance}");
//Console.WriteLine($"Defender Average Normal Hit Chance: {result.DefenderAverageNormalHitChance}");
//Console.WriteLine($"Attacker Average Defense Roll: {result.AttackerAverageDefenseRoll}");
//Console.WriteLine($"Defender Average Defense Roll: {result.DefenderAverageDefenseRoll}");
//Console.WriteLine($"Attacker Average Damage Roll: {result.AttackerAverageDamageRoll}");
//Console.WriteLine($"Defender Average Damage Roll: {result.DefenderAverageDamageRoll}");
//Console.WriteLine($"Attacker Weapon: {result.AttackerWeaponName}");
//Console.WriteLine($"Defender Weapon: {result.DefenderWeaponName}");
////Console.WriteLine($"Attacker Rolls: {string.Join(", ", result.AttackerRolls)}");
////Console.WriteLine($"Defender Rolls: {string.Join(", ", result.DefenderRolls)}");
//Console.WriteLine($"Action Type: {result.ActionType}");
//Console.WriteLine($"Simulation Count: {result.SimulationCount}");
//Console.WriteLine("Simulation complete.");
//Console.WriteLine("Press any key to exit...");


