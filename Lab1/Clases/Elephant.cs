public class Elephant : Animal
{
    public Elephant(string name, int age) : base(name, "Elephant", age, "Herbivore") { }

    public override string MakeSound() => $"{Name} trumpets!";
}