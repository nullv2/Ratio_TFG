CREATE TABLE Ploys (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    KillTeamId INTEGER NOT NULL,
    Name TEXT NOT NULL,
    Type TEXT NOT NULL, -- 'Strategy', 'Firefight', 'FactionRule'
    EffectType TEXT NOT NULL,
    Description TEXT,
    FOREIGN KEY (KillTeamId) REFERENCES KillTeams(Id)
);
