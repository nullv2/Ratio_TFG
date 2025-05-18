# Operative

Represents a combat unit with stats and weapons.

```csharp
public class Operative {
    public int Id { get; set; }
    public string Name { get; set; }
    public int Move { get; set; }
    public int APL { get; set; }
    public int Wounds { get; set; }
    public int Save { get; set; }

    public List<Weapon> Weapons { get; set; } = new();
    public List<Equipment> Equipment { get; set; } = new();
    public List<Ploy> ActivePloys { get; set; } = new();

    // Optional: shortcut to get the currently equipped weapon for simulation
    public Weapon? SelectedWeapon { get; set; }
}

```
```sql
-- Operatives
CREATE TABLE Operatives (
    OperativeId INT PRIMARY KEY,
    Name VARCHAR(100),
    Move INT,
    APL INT,
    Wounds INT,
    Save INT
);

```