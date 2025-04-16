using System;
using System.Collections.Generic;

public class Virus : ICloneable
{
    public string Name { get; set; }
    public string Type { get; set; }
    public double Weight { get; set; }
    public int Age { get; set; }
    public int MutationLevel { get; set; }
    public List<Virus> Variants { get; set; } = new List<Virus>();

    public Virus(string name, string type, double weight, int age, int mutationLevel = 0)
    {
        Name = name;
        Type = type;
        Weight = weight;
        Age = age;
        MutationLevel = mutationLevel;
    }

    public object Clone()
    {
        Virus clone = new Virus(Name, Type, Weight, Age, MutationLevel);
        foreach (var variant in Variants)
        {
            clone.Variants.Add((Virus)variant.Clone());
        }
        return clone;
    }

    public void ShowInfo(int level = 0)
    {
        Console.WriteLine(new string(' ', level * 2) + $"Name: {Name}, Type: {Type}, Weight: {Weight}g, Age: {Age} days, Mutation: {MutationLevel}");

        foreach (var variant in Variants)
        {
            variant.ShowInfo(level + 1);
        }
    }
}

class Program
{
    static void Main()
    {
        Virus parent = new Virus("Omicron", "DNA", 3.1, 7, 1);
        Virus child1 = new Virus("Lambda", "DNA", 1.6, 4, 2);
        Virus child2 = new Virus("Kappa", "Retrovirus", 1.4, 3, 2);
        Virus grandchild1 = new Virus("Theta", "DNA", 0.9, 2, 3);
        Virus grandchild2 = new Virus("Sigma", "Retrovirus", 0.85, 2, 3);
        Virus greatGrandchild = new Virus("Pi", "DNA", 0.6, 1, 4);

        grandchild1.Variants.Add(greatGrandchild);
        child1.Variants.Add(grandchild1);
        child1.Variants.Add(grandchild2);
        parent.Variants.Add(child1);
        parent.Variants.Add(child2);

        Console.WriteLine("Original Virus Family:");
        parent.ShowInfo();

        Virus cloned = (Virus)parent.Clone();

        Console.WriteLine("\nCloned Virus Family:");
        cloned.ShowInfo();
    }
}
