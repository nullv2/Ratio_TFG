CREATE TABLE Weapons (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    Name TEXT NOT NULL,
    Type TEXT NOT NULL, -- 'Melee' or 'Ranged'
    Attacks INTEGER NOT NULL,
    HitThreshold INTEGER NOT NULL,
    NormalDamage INTEGER NOT NULL,
    CriticalDamage INTEGER NOT NULL
);
