public class Lion : Animal
{
    public Lion(string name, int age) : base(name, "Lion", age, "Carnivore") { }

    public override string MakeSound() => $"{Name} roars!";
}