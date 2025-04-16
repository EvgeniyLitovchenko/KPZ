public interface IAnimal
{
    string Name { get; }
    string Species { get; }
    int Age { get; }
    string DietType { get; }
    string MakeSound();
}