# Weapon

Represents a ranged or melee weapon and its embedded rule modifiers.

```csharp
public enum WeaponType { Ranged, Melee }

public class Weapon
{
    public string Name { get; set; }
    public WeaponType Type { get; set; }
    public int Attacks { get; set; }
    public int HitThreshold { get; set; }
    public int NormalDamage { get; set; }
    public int CriticalDamage { get; set; }

    // Dice rule modifiers
    public bool Balanced { get; set; } = false;
    public bool Brutal { get; set; } = false;
    public bool Ceaseless { get; set; } = false;
    public bool Relentless { get; set; } = false;
    public bool Rending { get; set; } = false;
    public bool Severe { get; set; } = false;
    public bool Punishing { get; set; } = false;
    public bool Shock { get; set; } = false;

    // Numeric rule parameters
    public int? AccurateX { get; set; } = null;
    public int? DevastatingX { get; set; } = null;
    public int? LethalThreshold { get; set; } = null;  // for Lethal x+, e.g., 5 means "Lethal 5+"
    public int? PiercingX { get; set; } = null;
    public int? PiercingCritsX { get; set; } = null;

    // Hot rule
    public bool Hot { get; set; } = false;

    // Utility
    public bool HasAnyRules =>
        Balanced || Brutal || Ceaseless || Relentless || Rending || Severe || Punishing || Shock ||
        AccurateX.HasValue || DevastatingX.HasValue || LethalThreshold.HasValue ||
        PiercingX.HasValue || PiercingCritsX.HasValue || Hot;
}
```


```sql
-- Weapons
CREATE TABLE Weapons (
    WeaponId INT PRIMARY KEY,
    Name VARCHAR(100),
    Type VARCHAR(20), -- 'Ranged' or 'Melee'
    Attacks INT,
    HitThreshold INT,
    NormalDamage INT,
    CriticalDamage INT,
    Balanced BOOLEAN,
    Brutal BOOLEAN,
    Ceaseless BOOLEAN,
    DevastatingX INT,
    Hot BOOLEAN,
    LethalThreshold INT,
    PiercingX INT,
    PiercingCritsX INT,
    Punishing BOOLEAN,
    Relentless BOOLEAN,
    Rending BOOLEAN,
    Severe BOOLEAN,
    Shock BOOLEAN,
    AccurateX INT
);

-- OperativeWeapon mapping (allowed weapons per operative)
CREATE TABLE OperativeWeapons (
    OperativeId INT,
    WeaponId INT,
    IsDefault BOOLEAN, -- Indicates default loadout
    FOREIGN KEY (OperativeId) REFERENCES Operatives(OperativeId),
    FOREIGN KEY (WeaponId) REFERENCES Weapons(WeaponId),
    PRIMARY KEY (OperativeId, WeaponId)
);

```