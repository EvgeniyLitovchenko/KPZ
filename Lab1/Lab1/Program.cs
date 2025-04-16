
public class Program
{
    public static void Main()
    {
        IInventory zoo = new ZooInventory(); 

        IEnclosure savanna = new Enclosure(1, "Savanna", 5);
        IEnclosure jungle = new Enclosure(2, "Jungle", 3);
        zoo.AddEnclosure(savanna);
        zoo.AddEnclosure(jungle);

        IAnimal lion = new Lion("Simba", 5);
        IAnimal elephant = new Elephant("Dumbo", 10);
        zoo.AddAnimal(lion, savanna);
        zoo.AddAnimal(elephant, jungle);

        zoo.AddEmployee(new Employee("John", "Vet"));
        zoo.AddEmployee(new Employee("Alice", "Caretaker"));

        zoo.AddFood(new Food("Meat", 100));
        zoo.AddFood(new Food("Grass", 200));

        zoo.PrintInventory();
    }
}