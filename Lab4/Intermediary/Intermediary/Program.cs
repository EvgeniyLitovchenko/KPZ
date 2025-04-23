
interface ICommandCentre
{
    void RequestLanding(Aircraft aircraft);
    void RequestTakeOff(Aircraft aircraft);
}

class CommandCentre : ICommandCentre
{
    private List<Runway> _runways;
    private List<Aircraft> _aircrafts;

    public CommandCentre(Runway[] runways, Aircraft[] aircrafts)
    {
        _runways = runways.ToList();
        _aircrafts = aircrafts.ToList();
    }

    public void RequestLanding(Aircraft aircraft)
    {
        Console.WriteLine($"Aircraft {aircraft.Name} requesting landing...");
        Runway availableRunway = _runways.FirstOrDefault(runway => runway.IsAvailable());

        if (availableRunway != null)
        {
            availableRunway.Land(aircraft);
        }
        else
        {
            Console.WriteLine("No available runways for landing.");
        }
    }

    public void RequestTakeOff(Aircraft aircraft)
    {
        Console.WriteLine($"Aircraft {aircraft.Name} requesting take-off...");
        if (aircraft.CurrentRunway != null)
        {
            aircraft.CurrentRunway.TakeOff(aircraft);
        }
        else
        {
            Console.WriteLine("Aircraft is not on a runway to take off.");
        }
    }
}

class Aircraft
{
    public string Name { get; }
    public Runway? CurrentRunway { get; set; }
    public bool IsTakingOff { get; set; }

    public Aircraft(string name)
    {
        Name = name;
    }
}

class Runway
{
    public readonly Guid Id = Guid.NewGuid();
    public Aircraft? IsBusyWithAircraft;

    public bool IsAvailable()
    {
        return IsBusyWithAircraft == null;
    }

    public void Land(Aircraft aircraft)
    {
        Console.WriteLine($"Aircraft {aircraft.Name} is landing on runway {Id}");
        IsBusyWithAircraft = aircraft;
        HighlightRed();
        aircraft.CurrentRunway = this;
    }

    public void TakeOff(Aircraft aircraft)
    {
        Console.WriteLine($"Aircraft {aircraft.Name} is taking off from runway {Id}");
        IsBusyWithAircraft = null;
        HighlightGreen();
        aircraft.CurrentRunway = null;
    }

    private void HighlightRed()
    {
        Console.WriteLine($"Runway {Id} is now busy!");
    }

    private void HighlightGreen()
    {
        Console.WriteLine($"Runway {Id} is now free!");
    }
}

class Program
{
    static void Main(string[] args)
    {
        var runway1 = new Runway();
        var runway2 = new Runway();

        var aircraft1 = new Aircraft("Aircraft 1");
        var aircraft2 = new Aircraft("Aircraft 2");

        var commandCentre = new CommandCentre(new[] { runway1, runway2 }, new[] { aircraft1, aircraft2 });

        commandCentre.RequestLanding(aircraft1);
        commandCentre.RequestLanding(aircraft2);

        commandCentre.RequestTakeOff(aircraft1);
        commandCentre.RequestTakeOff(aircraft2);
    }
}
