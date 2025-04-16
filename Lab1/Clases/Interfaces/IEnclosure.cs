
public interface IEnclosure
{
    int Id { get; }
    string Type { get; }
    int Capacity { get; }
    bool AddAnimal(IAnimal animal);
    int GetAnimalCount();
}

