public interface IFood
{
    string Type { get; }
    int Quantity { get; }
    void UseFood(int amount);
}