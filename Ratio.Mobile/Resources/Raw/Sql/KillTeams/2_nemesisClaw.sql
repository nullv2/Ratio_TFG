-- ================================
-- NEMESIS CLAW (KillTeamId 2)
-- ================================

-- OPERATIVES
INSERT INTO OPERATIVE(Id, KillTeamId, Name, Movement, ActionPointLimit, Wounds, [Save], Image) VALUES(8, 2, 'Night Lord Visionary', 6, 3, 15, 3, 'images/nemesisClaw.png');
INSERT INTO OPERATIVE(Id, KillTeamId, Name, Movement, ActionPointLimit, Wounds, [Save], Image) VALUES(9, 2, 'Night Lord Fearmonger', 6, 3, 14, 3, 'images/nemesisClaw.png');
INSERT INTO OPERATIVE(Id, KillTeamId, Name, Movement, ActionPointLimit, Wounds, [Save], Image) VALUES(10, 2, 'Night Lord Gunner', 6, 3, 14, 3, 'images/nemesisClaw.png');
INSERT INTO OPERATIVE(Id, KillTeamId, Name, Movement, ActionPointLimit, Wounds, [Save], Image) VALUES(11, 2, 'Night Lord Heavy Gunner', 6, 3, 14, 3, 'images/nemesisClaw.png');
INSERT INTO OPERATIVE(Id, KillTeamId, Name, Movement, ActionPointLimit, Wounds, [Save], Image) VALUES(12, 2, 'Night Lord Screecher', 6, 3, 14, 3, 'images/nemesisClaw.png');
INSERT INTO OPERATIVE(Id, KillTeamId, Name, Movement, ActionPointLimit, Wounds, [Save], Image) VALUES(13, 2, 'Night Lord Skinthief', 6, 3, 14, 3, 'images/nemesisClaw.png');
INSERT INTO OPERATIVE(Id, KillTeamId, Name, Movement, ActionPointLimit, Wounds, [Save], Image) VALUES(14, 2, 'Night Lord Ventrilokar', 6, 3, 14, 3, 'images/nemesisClaw.png');
INSERT INTO OPERATIVE(Id, KillTeamId, Name, Movement, ActionPointLimit, Wounds, [Save], Image) VALUES(15, 2, 'Night Lord Warrior', 6, 3, 14, 3, 'images/nemesisClaw.png');

-- WEAPONS
INSERT INTO WEAPON(Id, Name, Type, Attacks, HitThreshold, NormalDamage, CriticalDamage) VALUES(11, 'Bolt Pistol', 'Ranged', 4, 3, 3, 4);
INSERT INTO WEAPON(Id, Name, Type, Attacks, HitThreshold, NormalDamage, CriticalDamage) VALUES(12, 'Plasma Pistol (Standard)', 'Ranged', 4, 3, 3, 5);
INSERT INTO WEAPON(Id, Name, Type, Attacks, HitThreshold, NormalDamage, CriticalDamage) VALUES(13, 'Plasma Pistol (Supercharge)', 'Ranged', 4, 3, 4, 5);
INSERT INTO WEAPON(Id, Name, Type, Attacks, HitThreshold, NormalDamage, CriticalDamage) VALUES(14, 'Nostraman Chainblade', 'Melee', 5, 3, 4, 5);
INSERT INTO WEAPON(Id, Name, Type, Attacks, HitThreshold, NormalDamage, CriticalDamage) VALUES(15, 'Power Fist', 'Melee', 5, 4, 5, 7);
INSERT INTO WEAPON(Id, Name, Type, Attacks, HitThreshold, NormalDamage, CriticalDamage) VALUES(16, 'Power Maul', 'Melee', 5, 3, 4, 6);
INSERT INTO WEAPON(Id, Name, Type, Attacks, HitThreshold, NormalDamage, CriticalDamage) VALUES(17, 'Power Weapon', 'Melee', 5, 3, 4, 6);
INSERT INTO WEAPON(Id, Name, Type, Attacks, HitThreshold, NormalDamage, CriticalDamage) VALUES(18, 'Scoped Bolt Pistol (Short Range)', 'Ranged', 4, 3, 3, 4);
INSERT INTO WEAPON(Id, Name, Type, Attacks, HitThreshold, NormalDamage, CriticalDamage) VALUES(19, 'Scoped Bolt Pistol (Long Range)', 'Ranged', 4, 3, 3, 4);
INSERT INTO WEAPON(Id, Name, Type, Attacks, HitThreshold, NormalDamage, CriticalDamage) VALUES(20, 'Terrorchem Vial', 'Melee', 5, 3, 2, 0);
INSERT INTO WEAPON(Id, Name, Type, Attacks, HitThreshold, NormalDamage, CriticalDamage) VALUES(21, 'Tainted Blade', 'Melee', 5, 3, 3, 5);
INSERT INTO WEAPON(Id, Name, Type, Attacks, HitThreshold, NormalDamage, CriticalDamage) VALUES(22, 'Flamer', 'Ranged', 4, 2, 3, 3);
INSERT INTO WEAPON(Id, Name, Type, Attacks, HitThreshold, NormalDamage, CriticalDamage) VALUES(23, 'Meltagun', 'Ranged', 4, 6, 6, 3);
INSERT INTO WEAPON(Id, Name, Type, Attacks, HitThreshold, NormalDamage, CriticalDamage) VALUES(24, 'Plasma Gun (Standard)', 'Ranged', 4, 3, 4, 6);
INSERT INTO WEAPON(Id, Name, Type, Attacks, HitThreshold, NormalDamage, CriticalDamage) VALUES(25, 'Plasma Gun (Supercharge)', 'Ranged', 4, 3, 5, 6);
INSERT INTO WEAPON(Id, Name, Type, Attacks, HitThreshold, NormalDamage, CriticalDamage) VALUES(26, 'Fists', 'Melee', 4, 3, 3, 4);
INSERT INTO WEAPON(Id, Name, Type, Attacks, HitThreshold, NormalDamage, CriticalDamage) VALUES(27, 'Heavy Bolter (Focused)', 'Ranged', 4, 3, 4, 5);
INSERT INTO WEAPON(Id, Name, Type, Attacks, HitThreshold, NormalDamage, CriticalDamage) VALUES(28, 'Heavy Bolter (Sweeping)', 'Ranged', 4, 3, 4, 5);
INSERT INTO WEAPON(Id, Name, Type, Attacks, HitThreshold, NormalDamage, CriticalDamage) VALUES(29, 'Missile Launcher (Frag)', 'Ranged', 4, 3, 5, 5);
INSERT INTO WEAPON(Id, Name, Type, Attacks, HitThreshold, NormalDamage, CriticalDamage) VALUES(30, 'Missile Launcher (Krak)', 'Ranged', 4, 3, 5, 7);
INSERT INTO WEAPON(Id, Name, Type, Attacks, HitThreshold, NormalDamage, CriticalDamage) VALUES(31, 'Lightning Claws', 'Melee', 5, 3, 4, 5);
INSERT INTO WEAPON(Id, Name, Type, Attacks, HitThreshold, NormalDamage, CriticalDamage) VALUES(32, 'Nostraman Chainglave', 'Melee', 5, 3, 4, 6);
INSERT INTO WEAPON(Id, Name, Type, Attacks, HitThreshold, NormalDamage, CriticalDamage) VALUES(33, 'Chainsword', 'Melee', 5, 3, 4, 5);
INSERT INTO WEAPON(Id, Name, Type, Attacks, HitThreshold, NormalDamage, CriticalDamage) VALUES(34, 'Boltgun', 'Ranged', 4, 3, 3, 4);

-- WEAPON TRAITS
INSERT INTO WEAPONTRAIT(Id, WeaponId, TraitType, TraitValue) VALUES(9, 12, 'Piercing', 1);
INSERT INTO WEAPONTRAIT(Id, WeaponId, TraitType, TraitValue) VALUES(10, 13, 'Hot', NULL);
INSERT INTO WEAPONTRAIT(Id, WeaponId, TraitType, TraitValue) VALUES(11, 13, 'Lethal', 5);
INSERT INTO WEAPONTRAIT(Id, WeaponId, TraitType, TraitValue) VALUES(12, 13, 'Piercing', 1);
INSERT INTO WEAPONTRAIT(Id, WeaponId, TraitType, TraitValue) VALUES(13, 14, 'Rending', NULL);
INSERT INTO WEAPONTRAIT(Id, WeaponId, TraitType, TraitValue) VALUES(14, 15, 'Brutal', NULL);
INSERT INTO WEAPONTRAIT(Id, WeaponId, TraitType, TraitValue) VALUES(15, 16, 'Shock', NULL);
INSERT INTO WEAPONTRAIT(Id, WeaponId, TraitType, TraitValue) VALUES(16, 17, 'Lethal', 5);
INSERT INTO WEAPONTRAIT(Id, WeaponId, TraitType, TraitValue) VALUES(17, 18, 'Lethal', 5);
INSERT INTO WEAPONTRAIT(Id, WeaponId, TraitType, TraitValue) VALUES(18, 22, 'Devastating', 4);
INSERT INTO WEAPONTRAIT(Id, WeaponId, TraitType, TraitValue) VALUES(19, 23, 'Devastating', 4);
INSERT INTO WEAPONTRAIT(Id, WeaponId, TraitType, TraitValue) VALUES(20, 23, 'Piercing', 2);
INSERT INTO WEAPONTRAIT(Id, WeaponId, TraitType, TraitValue) VALUES(21, 24, 'Piercing', 1);
INSERT INTO WEAPONTRAIT(Id, WeaponId, TraitType, TraitValue) VALUES(22, 25, 'Hot', NULL);
INSERT INTO WEAPONTRAIT(Id, WeaponId, TraitType, TraitValue) VALUES(23, 25, 'Lethal', 5);
INSERT INTO WEAPONTRAIT(Id, WeaponId, TraitType, TraitValue) VALUES(24, 25, 'Piercing', 1);
INSERT INTO WEAPONTRAIT(Id, WeaponId, TraitType, TraitValue) VALUES(25, 27, 'PiercingCrits', 1);
INSERT INTO WEAPONTRAIT(Id, WeaponId, TraitType, TraitValue) VALUES(26, 28, 'PiercingCrits', 1);
INSERT INTO WEAPONTRAIT(Id, WeaponId, TraitType, TraitValue) VALUES(27, 30, 'Piercing', 1);
INSERT INTO WEAPONTRAIT(Id, WeaponId, TraitType, TraitValue) VALUES(28, 31, 'Ceaseless', NULL);
INSERT INTO WEAPONTRAIT(Id, WeaponId, TraitType, TraitValue) VALUES(29, 31, 'Lethal', 5);
INSERT INTO WEAPONTRAIT(Id, WeaponId, TraitType, TraitValue) VALUES(30, 32, 'Rending', NULL);

-- OPERATIVE WEAPON LINKS

-- Night Lord Visionary
INSERT INTO OPERATIVEWEAPON(Id, OperativeId, WeaponId) VALUES(17, 8, 11); -- Bolt Pistol
INSERT INTO OPERATIVEWEAPON(Id, OperativeId, WeaponId) VALUES(18, 8, 12); -- Plasma Pistol (Standard)
INSERT INTO OPERATIVEWEAPON(Id, OperativeId, WeaponId) VALUES(19, 8, 13); -- Plasma Pistol (Supercharge)
INSERT INTO OPERATIVEWEAPON(Id, OperativeId, WeaponId) VALUES(20, 8, 14); -- Nostraman Chainblade
INSERT INTO OPERATIVEWEAPON(Id, OperativeId, WeaponId) VALUES(21, 8, 15); -- Power Fist
INSERT INTO OPERATIVEWEAPON(Id, OperativeId, WeaponId) VALUES(22, 8, 16); -- Power Maul
INSERT INTO OPERATIVEWEAPON(Id, OperativeId, WeaponId) VALUES(23, 8, 17); -- Power Weapon

-- Night Lord Fearmonger
INSERT INTO OPERATIVEWEAPON(Id, OperativeId, WeaponId) VALUES(24, 9, 18); -- Scoped Bolt Pistol (Short Range)
INSERT INTO OPERATIVEWEAPON(Id, OperativeId, WeaponId) VALUES(25, 9, 19); -- Scoped Bolt Pistol (Long Range)
INSERT INTO OPERATIVEWEAPON(Id, OperativeId, WeaponId) VALUES(26, 9, 20); -- Terrorchem Vial
INSERT INTO OPERATIVEWEAPON(Id, OperativeId, WeaponId) VALUES(27, 9, 21); -- Tainted Blade

-- Night Lord Gunner
INSERT INTO OPERATIVEWEAPON(Id, OperativeId, WeaponId) VALUES(28, 10, 11); -- Bolt Pistol
INSERT INTO OPERATIVEWEAPON(Id, OperativeId, WeaponId) VALUES(29, 10, 22); -- Flamer
INSERT INTO OPERATIVEWEAPON(Id, OperativeId, WeaponId) VALUES(30, 10, 23); -- Meltagun
INSERT INTO OPERATIVEWEAPON(Id, OperativeId, WeaponId) VALUES(31, 10, 24); -- Plasma Gun (Standard)
INSERT INTO OPERATIVEWEAPON(Id, OperativeId, WeaponId) VALUES(32, 10, 25); -- Plasma Gun (Supercharge)
INSERT INTO OPERATIVEWEAPON(Id, OperativeId, WeaponId) VALUES(33, 10, 26); -- Fists

-- Night Lord Heavy Gunner
INSERT INTO OPERATIVEWEAPON(Id, OperativeId, WeaponId) VALUES(34, 11, 11); -- Bolt Pistol
INSERT INTO OPERATIVEWEAPON(Id, OperativeId, WeaponId) VALUES(35, 11, 27); -- Heavy Bolter (Focused)
INSERT INTO OPERATIVEWEAPON(Id, OperativeId, WeaponId) VALUES(36, 11, 28); -- Heavy Bolter (Sweeping)
INSERT INTO OPERATIVEWEAPON(Id, OperativeId, WeaponId) VALUES(37, 11, 29); -- Missile Launcher (Frag)
INSERT INTO OPERATIVEWEAPON(Id, OperativeId, WeaponId) VALUES(38, 11, 30); -- Missile Launcher (Krak)
INSERT INTO OPERATIVEWEAPON(Id, OperativeId, WeaponId) VALUES(39, 11, 26); -- Fists

-- Night Lord Screecher
INSERT INTO OPERATIVEWEAPON(Id, OperativeId, WeaponId) VALUES(40, 12, 31); -- Lightning Claws

-- Night Lord Skinthief
INSERT INTO OPERATIVEWEAPON(Id, OperativeId, WeaponId) VALUES(41, 13, 11); -- Bolt Pistol
INSERT INTO OPERATIVEWEAPON(Id, OperativeId, WeaponId) VALUES(42, 13, 32); -- Nostraman Chainglave

-- Night Lord Ventrilokar
INSERT INTO OPERATIVEWEAPON(Id, OperativeId, WeaponId) VALUES(43, 14, 11); -- Bolt Pistol
INSERT INTO OPERATIVEWEAPON(Id, OperativeId, WeaponId) VALUES(44, 14, 33); -- Chainsword

-- Night Lord Warrior
INSERT INTO OPERATIVEWEAPON(Id, OperativeId, WeaponId) VALUES(45, 15, 11); -- Bolt Pistol
INSERT INTO OPERATIVEWEAPON(Id, OperativeId, WeaponId) VALUES(46, 15, 34); -- Boltgun
INSERT INTO OPERATIVEWEAPON(Id, OperativeId, WeaponId) VALUES(47, 15, 33); -- Chainsword
INSERT INTO OPERATIVEWEAPON(Id, OperativeId, WeaponId) VALUES(48, 15, 26); -- Fists