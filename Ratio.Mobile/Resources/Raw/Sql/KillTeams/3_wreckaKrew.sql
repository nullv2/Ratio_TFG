-- ================================
-- WRECKA KREW (KillTeamId 3)
-- ================================

-- OPERATIVES
INSERT INTO OPERATIVE(Id, KillTeamId, Name, Movement, ActionPointLimit, Wounds, [Save], Image) VALUES(16, 3, 'Wrecka Boss Nob', 6, 2, 14, 4, 'images/wrecka.png');
INSERT INTO OPERATIVE(Id, KillTeamId, Name, Movement, ActionPointLimit, Wounds, [Save], Image) VALUES(17, 3, 'Wrecka Bomb Squig', 6, 2, 5, 5, 'images/wrecka.png');
INSERT INTO OPERATIVE(Id, KillTeamId, Name, Movement, ActionPointLimit, Wounds, [Save], Image) VALUES(18, 3, 'Breaka Boy Demolisha', 6, 2, 12, 4, 'images/wrecka.png');
INSERT INTO OPERATIVE(Id, KillTeamId, Name, Movement, ActionPointLimit, Wounds, [Save], Image) VALUES(19, 3, 'Breaka Boy Fighter', 6, 2, 12, 4, 'images/wrecka.png');
INSERT INTO OPERATIVE(Id, KillTeamId, Name, Movement, ActionPointLimit, Wounds, [Save], Image) VALUES(20, 3, 'Breaka Boy Krusha', 6, 2, 12, 4, 'images/wrecka.png');
INSERT INTO OPERATIVE(Id, KillTeamId, Name, Movement, ActionPointLimit, Wounds, [Save], Image) VALUES(21, 3, 'Tankbusta Gunner', 6, 2, 12, 4, 'images/wrecka.png');
INSERT INTO OPERATIVE(Id, KillTeamId, Name, Movement, ActionPointLimit, Wounds, [Save], Image) VALUES(22, 3, 'Tankbusta Rokkiteer', 6, 2, 12, 4, 'images/wrecka.png');

-- WEAPONS
INSERT INTO WEAPON(Id, Name, Type, Attacks, HitThreshold, NormalDamage, CriticalDamage) VALUES(35, 'Rokkit Pistol', 'Ranged', 6, 5, 4, 5);
INSERT INTO WEAPON(Id, Name, Type, Attacks, HitThreshold, NormalDamage, CriticalDamage) VALUES(36, 'Two Rokkit Pistols (Focused)', 'Ranged', 6, 4, 4, 5);
INSERT INTO WEAPON(Id, Name, Type, Attacks, HitThreshold, NormalDamage, CriticalDamage) VALUES(37, 'Two Rokkit Pistols (Salvo)', 'Ranged', 6, 4, 4, 5);
INSERT INTO WEAPON(Id, Name, Type, Attacks, HitThreshold, NormalDamage, CriticalDamage) VALUES(38, 'Choppa', 'Melee', 4, 3, 4, 5);
INSERT INTO WEAPON(Id, Name, Type, Attacks, HitThreshold, NormalDamage, CriticalDamage) VALUES(39, 'Smash Hammer', 'Melee', 4, 3, 5, 6);
INSERT INTO WEAPON(Id, Name, Type, Attacks, HitThreshold, NormalDamage, CriticalDamage) VALUES(40, 'Explosives', 'Ranged', 6, 4, 4, 5);
INSERT INTO WEAPON(Id, Name, Type, Attacks, HitThreshold, NormalDamage, CriticalDamage) VALUES(41, 'Bite', 'Melee', 3, 4, 4, 5);
INSERT INTO WEAPON(Id, Name, Type, Attacks, HitThreshold, NormalDamage, CriticalDamage) VALUES(42, 'Tankhammer (Bash)', 'Melee', 4, 3, 4, 5);
INSERT INTO WEAPON(Id, Name, Type, Attacks, HitThreshold, NormalDamage, CriticalDamage) VALUES(43, 'Tankhammer (Detonate)', 'Melee', 4, 3, 0, 0);
INSERT INTO WEAPON(Id, Name, Type, Attacks, HitThreshold, NormalDamage, CriticalDamage) VALUES(44, 'Knucklebustas', 'Melee', 4, 3, 5, 6);
INSERT INTO WEAPON(Id, Name, Type, Attacks, HitThreshold, NormalDamage, CriticalDamage) VALUES(45, '''Eavy Rokkit Launcha', 'Ranged', 6, 4, 4, 5);
INSERT INTO WEAPON(Id, Name, Type, Attacks, HitThreshold, NormalDamage, CriticalDamage) VALUES(46, 'Rokkit Launcha', 'Ranged', 6, 5, 4, 5);
INSERT INTO WEAPON(Id, Name, Type, Attacks, HitThreshold, NormalDamage, CriticalDamage) VALUES(47, 'Fists', 'Melee', 3, 3, 3, 4);
INSERT INTO WEAPON(Id, Name, Type, Attacks, HitThreshold, NormalDamage, CriticalDamage) VALUES(48, 'Pulsa Rokkit', 'Ranged', 6, 5, 0, 0);
INSERT INTO WEAPON(Id, Name, Type, Attacks, HitThreshold, NormalDamage, CriticalDamage) VALUES(49, 'Rokkit Rack', 'Ranged', 6, 5, 4, 5);

-- WEAPON TRAITS
INSERT INTO WEAPONTRAIT(Id, WeaponId, TraitType, TraitValue) VALUES(31, 36, 'Ceaseless', NULL);  -- Two Rokkit Pistols (Focused)
INSERT INTO WEAPONTRAIT(Id, WeaponId, TraitType, TraitValue) VALUES(32, 39, 'Brutal', NULL);     -- Smash Hammer
INSERT INTO WEAPONTRAIT(Id, WeaponId, TraitType, TraitValue) VALUES(33, 44, 'Brutal', NULL);     -- Knucklebustas
INSERT INTO WEAPONTRAIT(Id, WeaponId, TraitType, TraitValue) VALUES(34, 44, 'Shock', NULL);      -- Knucklebustas
INSERT INTO WEAPONTRAIT(Id, WeaponId, TraitType, TraitValue) VALUES(35, 48, 'Relentless', NULL); -- Pulsa Rokkit

-- OPERATIVE WEAPON LINKS

-- Wrecka Boss Nob
INSERT INTO OPERATIVEWEAPON(Id, OperativeId, WeaponId) VALUES(49, 16, 35); -- Rokkit Pistol
INSERT INTO OPERATIVEWEAPON(Id, OperativeId, WeaponId) VALUES(50, 16, 36); -- Two Rokkit Pistols (Focused)
INSERT INTO OPERATIVEWEAPON(Id, OperativeId, WeaponId) VALUES(51, 16, 37); -- Two Rokkit Pistols (Salvo)
INSERT INTO OPERATIVEWEAPON(Id, OperativeId, WeaponId) VALUES(52, 16, 38); -- Choppa
INSERT INTO OPERATIVEWEAPON(Id, OperativeId, WeaponId) VALUES(53, 16, 39); -- Smash Hammer

-- Wrecka Bomb Squig
INSERT INTO OPERATIVEWEAPON(Id, OperativeId, WeaponId) VALUES(54, 17, 40); -- Explosives
INSERT INTO OPERATIVEWEAPON(Id, OperativeId, WeaponId) VALUES(55, 17, 41); -- Bite

-- Breaka Boy Demolisha
INSERT INTO OPERATIVEWEAPON(Id, OperativeId, WeaponId) VALUES(56, 18, 42); -- Tankhammer (Bash)
INSERT INTO OPERATIVEWEAPON(Id, OperativeId, WeaponId) VALUES(57, 18, 43); -- Tankhammer (Detonate)

-- Breaka Boy Fighter
INSERT INTO OPERATIVEWEAPON(Id, OperativeId, WeaponId) VALUES(58, 19, 39); -- Smash Hammer

-- Breaka Boy Krusha
INSERT INTO OPERATIVEWEAPON(Id, OperativeId, WeaponId) VALUES(59, 20, 44); -- Knucklebustas

-- Tankbusta Gunner
INSERT INTO OPERATIVEWEAPON(Id, OperativeId, WeaponId) VALUES(60, 21, 45); -- 'Eavy Rokkit Launcha
INSERT INTO OPERATIVEWEAPON(Id, OperativeId, WeaponId) VALUES(61, 21, 46); -- Rokkit Launcha
INSERT INTO OPERATIVEWEAPON(Id, OperativeId, WeaponId) VALUES(62, 21, 47); -- Fists

-- Tankbusta Rokkiteer
INSERT INTO OPERATIVEWEAPON(Id, OperativeId, WeaponId) VALUES(63, 22, 48); -- Pulsa Rokkit
INSERT INTO OPERATIVEWEAPON(Id, OperativeId, WeaponId) VALUES(64, 22, 46); -- Rokkit Launcha
INSERT INTO OPERATIVEWEAPON(Id, OperativeId, WeaponId) VALUES(65, 22, 49); -- Rokkit Rack
INSERT INTO OPERATIVEWEAPON(Id, OperativeId, WeaponId) VALUES(66, 22, 47); -- Fists
