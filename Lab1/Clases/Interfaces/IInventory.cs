public interface IInventory
{
    void AddAnimal(IAnimal animal, IEnclosure enclosure);
    void AddEnclosure(IEnclosure enclosure);
    void AddEmployee(IEmployee employee);
    void AddFood(IFood food);
    void PrintInventory();
}