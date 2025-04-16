public abstract class Animal : IAnimal
{
    public string Name { get; private set; }
    public string Species { get; private set; }
    public int Age { get; private set; }
    public string DietType { get; private set; }

    protected Animal(string name, string species, int age, string dietType)
    {
        Name = name;
        Species = species;
        Age = age;
        DietType = dietType;
    }

    public abstract string MakeSound();
}