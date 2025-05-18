-- ================================
-- VESPID STINGWINGS (KillTeamId 1)
-- ================================

-- OPERATIVES
INSERT INTO OPERATIVE(Id, KillTeamId, Name, Movement, ActionPointLimit, Wounds, [Save], Image) VALUES(1, 1, 'Vespid Strain Leader', 6, 2, 10, 5, 'images/vespid.png');
INSERT INTO OPERATIVE(Id, KillTeamId, Name, Movement, ActionPointLimit, Wounds, [Save], Image) VALUES(2, 1, 'Oversight Drone', 8, 2, 5, 2, 'images/vespid.png');
INSERT INTO OPERATIVE(Id, KillTeamId, Name, Movement, ActionPointLimit, Wounds, [Save], Image) VALUES(3, 1, 'Vespid Longsting', 6, 2, 9, 5, 'images/vespid.png');
INSERT INTO OPERATIVE(Id, KillTeamId, Name, Movement, ActionPointLimit, Wounds, [Save], Image) VALUES(4, 1, 'Vespid Shadestrain', 6, 2, 9, 3, 'images/vespid.png');
INSERT INTO OPERATIVE(Id, KillTeamId, Name, Movement, ActionPointLimit, Wounds, [Save], Image) VALUES(5, 1, 'Vespid Skyblast', 6, 2, 9, 5, 'images/vespid.png');
INSERT INTO OPERATIVE(Id, KillTeamId, Name, Movement, ActionPointLimit, Wounds, [Save], Image) VALUES(6, 1, 'Vespid Swarmguard', 6, 2, 9, 5, 'images/vespid.png');
INSERT INTO OPERATIVE(Id, KillTeamId, Name, Movement, ActionPointLimit, Wounds, [Save], Image) VALUES(7, 1, 'Vespid Warrior', 6, 2, 9, 5, 'images/vespid.png');

-- WEAPONS
INSERT INTO WEAPON(Id, Name, Type, Attacks, HitThreshold, NormalDamage, CriticalDamage) VALUES(1, 'Neutron Blaster', 'Ranged', 4, 3, 3, 3);
INSERT INTO WEAPON(Id, Name, Type, Attacks, HitThreshold, NormalDamage, CriticalDamage) VALUES(2, 'Claws', 'Melee', 3, 4, 3, 4);
INSERT INTO WEAPON(Id, Name, Type, Attacks, HitThreshold, NormalDamage, CriticalDamage) VALUES(3, 'Ram', 'Melee', 3, 5, 1, 2);
INSERT INTO WEAPON(Id, Name, Type, Attacks, HitThreshold, NormalDamage, CriticalDamage) VALUES(4, 'Neutron Rail Rifle (Standard)', 'Ranged', 4, 4, 4, 4);
INSERT INTO WEAPON(Id, Name, Type, Attacks, HitThreshold, NormalDamage, CriticalDamage) VALUES(5, 'Neutron Rail Rifle (Aimed)', 'Ranged', 4, 3, 4, 4);
INSERT INTO WEAPON(Id, Name, Type, Attacks, HitThreshold, NormalDamage, CriticalDamage) VALUES(6, 'Neutron Sting', 'Ranged', 4, 4, 3, 3);
INSERT INTO WEAPON(Id, Name, Type, Attacks, HitThreshold, NormalDamage, CriticalDamage) VALUES(7, 'Neutron Grenade', 'Ranged', 4, 4, 3, 3);
INSERT INTO WEAPON(Id, Name, Type, Attacks, HitThreshold, NormalDamage, CriticalDamage) VALUES(8, 'Neutron Grenade Launcher', 'Ranged', 4, 4, 3, 3);
INSERT INTO WEAPON(Id, Name, Type, Attacks, HitThreshold, NormalDamage, CriticalDamage) VALUES(9, 'Flamer (Standard)', 'Ranged', 4, 2, 3, 3);
INSERT INTO WEAPON(Id, Name, Type, Attacks, HitThreshold, NormalDamage, CriticalDamage) VALUES(10, 'Flamer (Skytorch)', 'Ranged', 4, 2, 3, 3);

-- WEAPON TRAITS
INSERT INTO WEAPONTRAIT(Id, WeaponId, TraitType, TraitValue) VALUES(1, 1, 'Devastating', 2);
INSERT INTO WEAPONTRAIT(Id, WeaponId, TraitType, TraitValue) VALUES(2, 4, 'Devastating', 2);
INSERT INTO WEAPONTRAIT(Id, WeaponId, TraitType, TraitValue) VALUES(3, 4, 'Lethal', 5);
INSERT INTO WEAPONTRAIT(Id, WeaponId, TraitType, TraitValue) VALUES(4, 5, 'Devastating', 2);
INSERT INTO WEAPONTRAIT(Id, WeaponId, TraitType, TraitValue) VALUES(5, 5, 'Lethal', 5);
INSERT INTO WEAPONTRAIT(Id, WeaponId, TraitType, TraitValue) VALUES(6, 6, 'Devastating', 2);
INSERT INTO WEAPONTRAIT(Id, WeaponId, TraitType, TraitValue) VALUES(7, 7, 'Devastating', 2);
INSERT INTO WEAPONTRAIT(Id, WeaponId, TraitType, TraitValue) VALUES(8, 8, 'Devastating', 2);

-- OPERATIVE WEAPON LINKS

-- Vespid Strain Leader
INSERT INTO OPERATIVEWEAPON(Id, OperativeId, WeaponId) VALUES(1, 1, 1); -- Neutron Blaster
INSERT INTO OPERATIVEWEAPON(Id, OperativeId, WeaponId) VALUES(2, 1, 2); -- Claws

-- Oversight Drone
INSERT INTO OPERATIVEWEAPON(Id, OperativeId, WeaponId) VALUES (3, 2, 3); -- Ram

-- Vespid Longsting
INSERT INTO OPERATIVEWEAPON(Id, OperativeId, WeaponId) VALUES(4, 3, 4); -- Neutron Rail Rifle (Standard)
INSERT INTO OPERATIVEWEAPON(Id, OperativeId, WeaponId) VALUES(5, 3, 5); -- Neutron Rail Rifle (Aimed)
INSERT INTO OPERATIVEWEAPON(Id, OperativeId, WeaponId) VALUES(6, 3, 2); -- Claws

-- Vespid Shadestrain
INSERT INTO OPERATIVEWEAPON(Id, OperativeId, WeaponId) VALUES(7, 4, 6); -- Neutron Sting
INSERT INTO OPERATIVEWEAPON(Id, OperativeId, WeaponId) VALUES(8, 4, 7); -- Neutron Grenade
INSERT INTO OPERATIVEWEAPON(Id, OperativeId, WeaponId) VALUES(9, 4, 2); -- Claws

-- Vespid Skyblast
INSERT INTO OPERATIVEWEAPON(Id, OperativeId, WeaponId) VALUES(10, 5, 8); -- Neutron Grenade Launcher
INSERT INTO OPERATIVEWEAPON(Id, OperativeId, WeaponId) VALUES(11, 5, 2); -- Claws

-- Vespid Swarmguard
INSERT INTO OPERATIVEWEAPON(Id, OperativeId, WeaponId) VALUES(12, 6, 9); -- Flamer (Standard)
INSERT INTO OPERATIVEWEAPON(Id, OperativeId, WeaponId) VALUES(13, 6, 10); -- Flamer (Skytorch)
INSERT INTO OPERATIVEWEAPON(Id, OperativeId, WeaponId) VALUES(14, 6, 2); -- Claws

-- Vespid Warrior
INSERT INTO OPERATIVEWEAPON(Id, OperativeId, WeaponId) VALUES(15, 7, 1); -- Neutron Blaster
INSERT INTO OPERATIVEWEAPON(Id, OperativeId, WeaponId) VALUES(16, 7, 2); -- Claws
