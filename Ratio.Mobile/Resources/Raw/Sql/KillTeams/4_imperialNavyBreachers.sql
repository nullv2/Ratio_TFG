-- ================================
-- IMPERIAL NAVY BREACHERS (KillTeamId 4)
-- ================================

-- OPERATIVES
INSERT INTO OPERATIVE(Id, KillTeamId, Name, Movement, ActionPointLimit, Wounds, [Save], Image) VALUES(23, 4, 'Navis Sergeant-At-Arms', 6, 2, 8, 4, 'images/breacher.png');
INSERT INTO OPERATIVE(Id, KillTeamId, Name, Movement, ActionPointLimit, Wounds, [Save], Image) VALUES(24, 4, 'Navis Armsman', 6, 2, 7, 4, 'images/breacher.png');
INSERT INTO OPERATIVE(Id, KillTeamId, Name, Movement, ActionPointLimit, Wounds, [Save], Image) VALUES(25, 4, 'Navis Axejack', 6, 2, 7, 4, 'images/breacher.png');
INSERT INTO OPERATIVE(Id, KillTeamId, Name, Movement, ActionPointLimit, Wounds, [Save], Image) VALUES(26, 4, 'Navis Endurant', 4, 2, 10, 2, 'images/breacher.png');
INSERT INTO OPERATIVE(Id, KillTeamId, Name, Movement, ActionPointLimit, Wounds, [Save], Image) VALUES(27, 4, 'Navis Grenadier', 6, 2, 7, 4, 'images/breacher.png');
INSERT INTO OPERATIVE(Id, KillTeamId, Name, Movement, ActionPointLimit, Wounds, [Save], Image) VALUES(28, 4, 'Navis Gunner', 6, 2, 8, 4, 'images/breacher.png');
INSERT INTO OPERATIVE(Id, KillTeamId, Name, Movement, ActionPointLimit, Wounds, [Save], Image) VALUES(29, 4, 'Navis Hatchcutter', 6, 2, 7, 4, 'images/breacher.png');
INSERT INTO OPERATIVE(Id, KillTeamId, Name, Movement, ActionPointLimit, Wounds, [Save], Image) VALUES(30, 4, 'Navis Surveyor', 6, 2, 7, 4, 'images/breacher.png');
INSERT INTO OPERATIVE(Id, KillTeamId, Name, Movement, ActionPointLimit, Wounds, [Save], Image) VALUES(31, 4, 'Navis Void-Jammer', 6, 2, 7, 4, 'images/breacher.png');

-- WEAPONS
INSERT INTO WEAPON(Id, Name, Type, Attacks, HitThreshold, NormalDamage, CriticalDamage) VALUES(50, 'Bolt Pistol', 'Ranged', 4, 4, 3, 4);
INSERT INTO WEAPON(Id, Name, Type, Attacks, HitThreshold, NormalDamage, CriticalDamage) VALUES(51, 'Heirloom Autopistol', 'Ranged', 4, 3, 2, 4);
INSERT INTO WEAPON(Id, Name, Type, Attacks, HitThreshold, NormalDamage, CriticalDamage) VALUES(52, 'Navis Shotgun (Close Range)', 'Ranged', 4, 3, 3, 3);
INSERT INTO WEAPON(Id, Name, Type, Attacks, HitThreshold, NormalDamage, CriticalDamage) VALUES(53, 'Navis Shotgun (Long Range)', 'Ranged', 4, 5, 1, 2);
INSERT INTO WEAPON(Id, Name, Type, Attacks, HitThreshold, NormalDamage, CriticalDamage) VALUES(54, 'Chainsword', 'Melee', 4, 3, 4, 5);
INSERT INTO WEAPON(Id, Name, Type, Attacks, HitThreshold, NormalDamage, CriticalDamage) VALUES(55, 'Navis Hatchet', 'Melee', 3, 4, 3, 4);
INSERT INTO WEAPON(Id, Name, Type, Attacks, HitThreshold, NormalDamage, CriticalDamage) VALUES(56, 'Power Weapon', 'Melee', 4, 3, 4, 6);
INSERT INTO WEAPON(Id, Name, Type, Attacks, HitThreshold, NormalDamage, CriticalDamage) VALUES(57, 'Autopistol', 'Ranged', 4, 4, 2, 3);
INSERT INTO WEAPON(Id, Name, Type, Attacks, HitThreshold, NormalDamage, CriticalDamage) VALUES(58, 'Navis Heavy Shotgun (Close Range)', 'Ranged', 4, 3, 3, 3);
INSERT INTO WEAPON(Id, Name, Type, Attacks, HitThreshold, NormalDamage, CriticalDamage) VALUES(59, 'Navis Heavy Shotgun (Long Range)', 'Ranged', 4, 5, 1, 2);
INSERT INTO WEAPON(Id, Name, Type, Attacks, HitThreshold, NormalDamage, CriticalDamage) VALUES(60, 'Shield Bash', 'Melee', 3, 4, 1, 2);
INSERT INTO WEAPON(Id, Name, Type, Attacks, HitThreshold, NormalDamage, CriticalDamage) VALUES(61, 'Demolition Charge', 'Ranged', 4, 3, 4, 6);
INSERT INTO WEAPON(Id, Name, Type, Attacks, HitThreshold, NormalDamage, CriticalDamage) VALUES(62, 'Meltagun', 'Ranged', 4, 4, 6, 3);
INSERT INTO WEAPON(Id, Name, Type, Attacks, HitThreshold, NormalDamage, CriticalDamage) VALUES(63, 'Navis Las-Volley (Focused)', 'Ranged', 5, 4, 4, 5);
INSERT INTO WEAPON(Id, Name, Type, Attacks, HitThreshold, NormalDamage, CriticalDamage) VALUES(64, 'Navis Las-Volley (Sweeping)', 'Ranged', 4, 3, 4, 5);
INSERT INTO WEAPON(Id, Name, Type, Attacks, HitThreshold, NormalDamage, CriticalDamage) VALUES(65, 'Plasma Gun (Standard)', 'Ranged', 4, 4, 4, 6);
INSERT INTO WEAPON(Id, Name, Type, Attacks, HitThreshold, NormalDamage, CriticalDamage) VALUES(66, 'Plasma Gun (Supercharge)', 'Ranged', 4, 4, 5, 6);
INSERT INTO WEAPON(Id, Name, Type, Attacks, HitThreshold, NormalDamage, CriticalDamage) VALUES(67, 'Gun Butt', 'Melee', 3, 4, 2, 3);
INSERT INTO WEAPON(Id, Name, Type, Attacks, HitThreshold, NormalDamage, CriticalDamage) VALUES(68, 'Chainfist', 'Melee', 4, 4, 5, 6);
INSERT INTO WEAPON(Id, Name, Type, Attacks, HitThreshold, NormalDamage, CriticalDamage) VALUES(69, 'Gheistskull Detonator', 'Ranged', 4, 3, 3, 4);

-- WEAPON TRAITS
INSERT INTO WEAPONTRAIT(Id, WeaponId, TraitType, TraitValue) VALUES(70, 51, 'Lethal', 5);      -- Heirloom autopistol
INSERT INTO WEAPONTRAIT(Id, WeaponId, TraitType, TraitValue) VALUES(71, 56, 'Lethal', 5);      -- Power weapon (Sergeant)
INSERT INTO WEAPONTRAIT(Id, WeaponId, TraitType, TraitValue) VALUES(72, 58, 'Relentless', NULL); -- Navis heavy shotgun (close range)
INSERT INTO WEAPONTRAIT(Id, WeaponId, TraitType, TraitValue) VALUES(73, 59, 'Relentless', NULL); -- Navis heavy shotgun (long range)
INSERT INTO WEAPONTRAIT(Id, WeaponId, TraitType, TraitValue) VALUES(74, 60, 'Brutal', NULL);     -- Shield bash
INSERT INTO WEAPONTRAIT(Id, WeaponId, TraitType, TraitValue) VALUES(75, 61, 'Piercing', 1);    -- Demolition charge
INSERT INTO WEAPONTRAIT(Id, WeaponId, TraitType, TraitValue) VALUES(76, 62, 'Devastating', 4); -- Meltagun
INSERT INTO WEAPONTRAIT(Id, WeaponId, TraitType, TraitValue) VALUES(77, 62, 'Piercing', 2);    -- Meltagun
INSERT INTO WEAPONTRAIT(Id, WeaponId, TraitType, TraitValue) VALUES(78, 63, 'Rending', NULL);  -- Navis las-volley (focused)
INSERT INTO WEAPONTRAIT(Id, WeaponId, TraitType, TraitValue) VALUES(79, 64, 'Rending', NULL);  -- Navis las-volley (sweeping)
INSERT INTO WEAPONTRAIT(Id, WeaponId, TraitType, TraitValue) VALUES(80, 65, 'Piercing', 1);    -- Plasma gun (standard)
INSERT INTO WEAPONTRAIT(Id, WeaponId, TraitType, TraitValue) VALUES(81, 66, 'Hot', NULL);      -- Plasma gun (supercharge)
INSERT INTO WEAPONTRAIT(Id, WeaponId, TraitType, TraitValue) VALUES(82, 66, 'Lethal', 5);      -- Plasma gun (supercharge)
INSERT INTO WEAPONTRAIT(Id, WeaponId, TraitType, TraitValue) VALUES(83, 66, 'Piercing', 1);    -- Plasma gun (supercharge)
INSERT INTO WEAPONTRAIT(Id, WeaponId, TraitType, TraitValue) VALUES(84, 68, 'Brutal', NULL);   -- Chainfist (Navis Hatchcutter)
INSERT INTO WEAPONTRAIT(Id, WeaponId, TraitType, TraitValue) VALUES(85, 68, 'Rending', NULL);  -- Chainfist (Navis Hatchcutter)
INSERT INTO WEAPONTRAIT(Id, WeaponId, TraitType, TraitValue) VALUES(86, 69, 'Lethal', 5);      -- Gheistskull detonator

-- OPERATIVE WEAPON LINKS

-- Navis Sergeant-At-Arms
INSERT INTO OPERATIVEWEAPON(Id, OperativeId, WeaponId) VALUES(67, 23, 50); -- Bolt Pistol
INSERT INTO OPERATIVEWEAPON(Id, OperativeId, WeaponId) VALUES(68, 23, 51); -- Heirloom Autopistol
INSERT INTO OPERATIVEWEAPON(Id, OperativeId, WeaponId) VALUES(69, 23, 52); -- Navis Shotgun (Close Range)
INSERT INTO OPERATIVEWEAPON(Id, OperativeId, WeaponId) VALUES(70, 23, 53); -- Navis Shotgun (Long Range)
INSERT INTO OPERATIVEWEAPON(Id, OperativeId, WeaponId) VALUES(71, 23, 54); -- Chainsword
INSERT INTO OPERATIVEWEAPON(Id, OperativeId, WeaponId) VALUES(72, 23, 55); -- Navis Hatchet
INSERT INTO OPERATIVEWEAPON(Id, OperativeId, WeaponId) VALUES(73, 23, 56); -- Power Weapon

-- Navis Armsman
INSERT INTO OPERATIVEWEAPON(Id, OperativeId, WeaponId) VALUES(74, 24, 52); -- Navis Shotgun (Close Range)
INSERT INTO OPERATIVEWEAPON(Id, OperativeId, WeaponId) VALUES(75, 24, 53); -- Navis Shotgun (Long Range)
INSERT INTO OPERATIVEWEAPON(Id, OperativeId, WeaponId) VALUES(76, 24, 55); -- Navis Hatchet

-- Navis Axejack
INSERT INTO OPERATIVEWEAPON(Id, OperativeId, WeaponId) VALUES(77, 25, 57); -- Autopistol
INSERT INTO OPERATIVEWEAPON(Id, OperativeId, WeaponId) VALUES(78, 25, 56); -- Power Weapon

-- Navis Endurant
INSERT INTO OPERATIVEWEAPON(Id, OperativeId, WeaponId) VALUES(79, 26, 58); -- Navis Heavy Shotgun (Close Range)
INSERT INTO OPERATIVEWEAPON(Id, OperativeId, WeaponId) VALUES(80, 26, 59); -- Navis Heavy Shotgun (Long Range)
INSERT INTO OPERATIVEWEAPON(Id, OperativeId, WeaponId) VALUES(81, 26, 60); -- Shield Bash

-- Navis Grenadier
INSERT INTO OPERATIVEWEAPON(Id, OperativeId, WeaponId) VALUES(82, 27, 61); -- Demolition Charge
INSERT INTO OPERATIVEWEAPON(Id, OperativeId, WeaponId) VALUES(83, 27, 52); -- Navis Shotgun (Close Range)
INSERT INTO OPERATIVEWEAPON(Id, OperativeId, WeaponId) VALUES(84, 27, 53); -- Navis Shotgun (Long Range)
INSERT INTO OPERATIVEWEAPON(Id, OperativeId, WeaponId) VALUES(85, 27, 55); -- Navis Hatchet

-- Navis Gunner
INSERT INTO OPERATIVEWEAPON(Id, OperativeId, WeaponId) VALUES(86, 28, 62); -- Meltagun
INSERT INTO OPERATIVEWEAPON(Id, OperativeId, WeaponId) VALUES(87, 28, 63); -- Navis Las-Volley (Focused)
INSERT INTO OPERATIVEWEAPON(Id, OperativeId, WeaponId) VALUES(88, 28, 64); -- Navis Las-Volley (Sweeping)
INSERT INTO OPERATIVEWEAPON(Id, OperativeId, WeaponId) VALUES(89, 28, 65); -- Plasma Gun (Standard)
INSERT INTO OPERATIVEWEAPON(Id, OperativeId, WeaponId) VALUES(90, 28, 66); -- Plasma Gun (Supercharge)
INSERT INTO OPERATIVEWEAPON(Id, OperativeId, WeaponId) VALUES(91, 28, 67); -- Gun Butt

-- Navis Hatchcutter
INSERT INTO OPERATIVEWEAPON(Id, OperativeId, WeaponId) VALUES(92, 29, 57); -- Autopistol
INSERT INTO OPERATIVEWEAPON(Id, OperativeId, WeaponId) VALUES(93, 29, 68); -- Chainfist

-- Navis Surveyor
INSERT INTO OPERATIVEWEAPON(Id, OperativeId, WeaponId) VALUES(94, 30, 52); -- Navis Shotgun (Close Range)
INSERT INTO OPERATIVEWEAPON(Id, OperativeId, WeaponId) VALUES(95, 30, 53); -- Navis Shotgun (Long Range)
INSERT INTO OPERATIVEWEAPON(Id, OperativeId, WeaponId) VALUES(96, 30, 55); -- Navis Hatchet

-- Navis Void-Jammer
INSERT INTO OPERATIVEWEAPON(Id, OperativeId, WeaponId) VALUES(97, 31, 69); -- Gheistskull Detonator
INSERT INTO OPERATIVEWEAPON(Id, OperativeId, WeaponId) VALUES(98, 31, 52); -- Navis Shotgun (Close Range)
INSERT INTO OPERATIVEWEAPON(Id, OperativeId, WeaponId) VALUES(99, 31, 53); -- Navis Shotgun (Long Range)
INSERT INTO OPERATIVEWEAPON(Id, OperativeId, WeaponId) VALUES(100, 31, 55); -- Navis Hatchet