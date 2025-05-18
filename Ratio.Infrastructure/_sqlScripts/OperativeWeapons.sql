CREATE TABLE OperativeWeapons (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    OperativeId TEXT NOT NULL,
    WeaponId INTEGER NOT NULL,
    FOREIGN KEY (OperativeId) REFERENCES Operatives(Id),
    FOREIGN KEY (WeaponId) REFERENCES Weapons(Id)
);
