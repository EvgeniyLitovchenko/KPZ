public class ZooInventory : IInventory
{
    private readonly List<IAnimal> animals;
    private readonly List<IEnclosure> enclosures;
    private readonly List<IEmployee> employees;
    private readonly List<IFood> foodStock;

    public ZooInventory()
    {
        animals = new List<IAnimal>();
        enclosures = new List<IEnclosure>();
        employees = new List<IEmployee>();
        foodStock = new List<IFood>();
    }

    public void AddAnimal(IAnimal animal, IEnclosure enclosure)
    {
        if (enclosure.AddAnimal(animal))
        {
            animals.Add(animal);
            Console.WriteLine($"Animal {animal.Name} added to enclosure {enclosure.Id}");
        }
        else
        {
            Console.WriteLine($"Enclosure {enclosure.Id} is full!");
        }
    }

    public void AddEnclosure(IEnclosure enclosure)
    {
        enclosures.Add(enclosure);
    }

    public void AddEmployee(IEmployee employee)
    {
        employees.Add(employee);
    }

    public void AddFood(IFood food)
    {
        var existingFood = foodStock.FirstOrDefault(f => f.Type == food.Type);
        if (existingFood != null)
        {
            existingFood.UseFood(-food.Quantity);
        }
        else
        {
            foodStock.Add(food);
        }
    }

    public void PrintInventory()
    {
        Console.WriteLine("\n=== Zoo Inventory ===");

        Console.WriteLine("\nAnimals:");
        foreach (var animal in animals)
        {
            Console.WriteLine($"Name: {animal.Name}, Species: {animal.Species}, Age: {animal.Age}, Sound: {animal.MakeSound()}");
        }

        Console.WriteLine("\nEnclosures:");
        foreach (var enclosure in enclosures)
        {
            Console.WriteLine($"ID: {enclosure.Id}, Type: {enclosure.Type}, Animals: {enclosure.GetAnimalCount()}/{enclosure.Capacity}");
        }

        Console.WriteLine("\nEmployees:");
        foreach (var employee in employees)
        {
            Console.WriteLine($"Name: {employee.Name}, Role: {employee.Role}");
        }

        Console.WriteLine("\nFood Stock:");
        foreach (var food in foodStock)
        {
            Console.WriteLine($"Type: {food.Type}, Quantity: {food.Quantity} kg");
        }
    }
}