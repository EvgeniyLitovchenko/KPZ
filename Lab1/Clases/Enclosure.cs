public class Enclosure : IEnclosure
{
    public int Id { get; private set; }
    public string Type { get; private set; }
    public int Capacity { get; private set; }
    private List<IAnimal> Animals { get; set; } 

    public Enclosure(int id, string type, int capacity)
    {
        Id = id;
        Type = type;
        Capacity = capacity;
        Animals = new List<IAnimal>();
    }

    public bool AddAnimal(IAnimal animal)
    {
        if (Animals.Count >= Capacity)
        {
            return false;
        }
        Animals.Add(animal);
        return true;
    }

    public int GetAnimalCount() => Animals.Count;
}