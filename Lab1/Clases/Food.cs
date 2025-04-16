public class Food : IFood
{
    public string Type { get; private set; }
    public int Quantity { get; private set; }

    public Food(string type, int quantity)
    {
        Type = type;
        Quantity = quantity;
    }

    public void UseFood(int amount)
    {
        if (amount <= Quantity)
            Quantity -= amount;
    }
}