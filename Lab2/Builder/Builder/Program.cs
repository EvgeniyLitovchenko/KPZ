public interface ICharacterBuilder
{
    ICharacterBuilder SetHeight(double height);
    ICharacterBuilder SetBodyType(string bodyType);
    ICharacterBuilder SetHairColor(string hairColor);
    ICharacterBuilder SetEyeColor(string eyeColor);
    ICharacterBuilder SetClothing(string clothing);
    ICharacterBuilder AddInventoryItem(string item);
    ICharacterBuilder DoGoodDeed(string item);
    ICharacterBuilder DoEvilDeed(string item);
    Character Build();
}

public class Character
{
    public string Name { get; set; }
    public double Height { get; set; }
    public string BodyType { get; set; }
    public string HairColor { get; set; }
    public string EyeColor { get; set; }
    public string Clothing { get; set; }
    public List<string> Inventory { get; set; } = new();
    public List<string> Actions { get; set; } = new();

    public void ShowInfo() =>
        Console.WriteLine($"Character: {Name}\nHeight: {Height}\nBody Type: {BodyType}\nHair Color: {HairColor}\nEye Color: {EyeColor}\nClothing: {Clothing}\nInventory: {string.Join(", ", Inventory)}\nActions: {string.Join(", ", Actions)}\n");
}

public class HeroBuilder : ICharacterBuilder
{
    private readonly Character character;

    public HeroBuilder(string name) => character = new Character { Name = name };

    public ICharacterBuilder SetHeight(double height) { character.Height = height; return this; }
    public ICharacterBuilder SetBodyType(string bodyType) { character.BodyType = bodyType; return this; }
    public ICharacterBuilder SetHairColor(string hairColor) { character.HairColor = hairColor; return this; }
    public ICharacterBuilder SetEyeColor(string eyeColor) { character.EyeColor = eyeColor; return this; }
    public ICharacterBuilder SetClothing(string clothing) { character.Clothing = clothing; return this; }
    public ICharacterBuilder AddInventoryItem(string item) { character.Inventory.Add(item); return this; }
    public ICharacterBuilder DoGoodDeed(string deed) { character.Actions.Add(deed); return this; }
    public ICharacterBuilder DoEvilDeed(string deed) => this;
    public Character Build() => character;
}

public class EnemyBuilder : ICharacterBuilder
{
    private readonly Character character;

    public EnemyBuilder(string name) => character = new Character { Name = name };

    public ICharacterBuilder SetHeight(double height) { character.Height = height; return this; }
    public ICharacterBuilder SetBodyType(string bodyType) { character.BodyType = bodyType; return this; }
    public ICharacterBuilder SetHairColor(string hairColor) { character.HairColor = hairColor; return this; }
    public ICharacterBuilder SetEyeColor(string eyeColor) { character.EyeColor = eyeColor; return this; }
    public ICharacterBuilder SetClothing(string clothing) { character.Clothing = clothing; return this; }
    public ICharacterBuilder AddInventoryItem(string item) { character.Inventory.Add(item); return this; }
    public ICharacterBuilder DoEvilDeed(string deed) { character.Actions.Add(deed); return this; }
    public ICharacterBuilder DoGoodDeed(string deed) => this;
    public Character Build() => character;
}

public class CharacterDirector
{
    public Character CreateHero() =>
        new HeroBuilder("Legendary Hero")
            .SetHeight(1.85)
            .SetBodyType("Muscular")
            .SetHairColor("Blonde")
            .SetEyeColor("Blue")
            .SetClothing("Knight Armor")
            .AddInventoryItem("Sword")
            .AddInventoryItem("Shield")
            .DoGoodDeed("Saved a village")
            .DoGoodDeed("Defeated the dragon")
            .Build();

    public Character CreateEnemy() =>
        new EnemyBuilder("Dark Lord")
            .SetHeight(2.0)
            .SetBodyType("Shadowy")
            .SetHairColor("Black")
            .SetEyeColor("Red")
            .SetClothing("Dark Cloak")
            .AddInventoryItem("Cursed Staff")
            .DoEvilDeed("Destroyed a kingdom")
            .DoEvilDeed("Summoned a demon")
            .Build();
}

class Program
{
    static void Main()
    {
        var director = new CharacterDirector();
        var hero = director.CreateHero();
        var enemy = director.CreateEnemy();

        Console.WriteLine("Hero:");
        hero.ShowInfo();

        Console.WriteLine("Enemy:");
        enemy.ShowInfo();
    }
}
