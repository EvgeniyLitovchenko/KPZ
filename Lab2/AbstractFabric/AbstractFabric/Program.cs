using System;

interface ILaptop
{
    public void ShowInfo();
}

interface ISmartphone
{
    public void ShowInfo();
}

class IProneLaptop : ILaptop
{
    public void ShowInfo()
    {
        Console.WriteLine("IProne Laptop Created");
    }
}

class KiaomiLaptop : ILaptop
{
    public void ShowInfo()
    {
        Console.WriteLine("Kiaomi Laptop Created");
    }
}

class BalaxyLaptop : ILaptop
{
    public void ShowInfo()
    {
        Console.WriteLine("Balaxy Laptop Created");
    }
}

class IProneSmartphone : ISmartphone
{
    public void ShowInfo()
    {
        Console.WriteLine("IProne Smartphone Created");
    }
}

class KiaomiSmartphone : ISmartphone
{
    public void ShowInfo()
    {
        Console.WriteLine("Kiaomi Smartphone Created");
    }
}

class BalaxySmartphone : ISmartphone
{
    public void ShowInfo()
    {
        Console.WriteLine("Balaxy Smartphone Created");
    }
}

interface ITechFactory
{
    ILaptop CreateLaptop();
    ISmartphone CreateSmartphone();
}

class IProneFactory : ITechFactory
{
    public ILaptop CreateLaptop()
    {
        return new IProneLaptop();
    }

    public ISmartphone CreateSmartphone()
    {
        return new IProneSmartphone();
    }
}

class KiaomiFactory : ITechFactory
{
    public ILaptop CreateLaptop()
    {
        return new KiaomiLaptop();
    }

    public ISmartphone CreateSmartphone()
    {
        return new KiaomiSmartphone();
    }
}

class BalaxyFactory : ITechFactory
{
    public ILaptop CreateLaptop()
    {
        return new BalaxyLaptop();
    }

    public ISmartphone CreateSmartphone()
    {
        return new BalaxySmartphone();
    }
}

class Program
{
    static void Main()
    {
        ITechFactory iproneFactory = new IProneFactory();
        ITechFactory kiaomiFactory = new KiaomiFactory();
        ITechFactory balaxyFactory = new BalaxyFactory();

        ISmartphone ipronePhone = iproneFactory.CreateSmartphone();
        ILaptop kiaomiLaptop = kiaomiFactory.CreateLaptop();
        ISmartphone balaxyPhone = balaxyFactory.CreateSmartphone();

        kiaomiLaptop.ShowInfo();
        ipronePhone.ShowInfo();
        balaxyPhone.ShowInfo();
    }
}
