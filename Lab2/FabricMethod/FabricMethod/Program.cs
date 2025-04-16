using System;
using System.Collections.Generic;

public abstract class Subscription
{
    public abstract string Name { get; }
    public abstract decimal MonthlyFee { get; }
    public abstract int MinPeriodMonths { get; }
    public abstract List<string> Channels { get; }

    public void DisplayInfo()
    {
        Console.WriteLine($"Subscription: {Name}\nMonthly Fee: {MonthlyFee}$\nMin Period: {MinPeriodMonths} months\nChannels: {string.Join(", ", Channels)}\n");
    }
}

public class DomesticSubscription : Subscription
{
    public override string Name => "Domestic";
    public override decimal MonthlyFee => 10;
    public override int MinPeriodMonths => 6;
    public override List<string> Channels => new() { "News", "Movies", "Sports" };
}

public class EducationalSubscription : Subscription
{
    public override string Name => "Educational";
    public override decimal MonthlyFee => 8;
    public override int MinPeriodMonths => 3;
    public override List<string> Channels => new() { "Discovery", "National Geographic", "History" };
}

public class PremiumSubscription : Subscription
{
    public override string Name => "Premium";
    public override decimal MonthlyFee => 20;
    public override int MinPeriodMonths => 12;
    public override List<string> Channels => new() { "All Channels", "Exclusive Content" };
}

public abstract class SubscriptionFactory
{
    public abstract Subscription CreateSubscription(string type);
}

public class WebSite : SubscriptionFactory
{

    public override Subscription CreateSubscription(string type)
    {
        Subscription subscription = type.ToLower() switch
        {
            "domestic" => new DomesticSubscription(),
            "educational" => new EducationalSubscription(),
            "premium" => new PremiumSubscription(),
            _ => throw new ArgumentException("Unknown subscription type")
        };
        return subscription;
    }
}

public class MobileApp : SubscriptionFactory
{

    public override Subscription CreateSubscription(string type)
    {
        Subscription subscription = type.ToLower() switch
        {
            "domestic" => new DomesticSubscription(),
            "educational" => new EducationalSubscription(),
            "premium" => new PremiumSubscription(),
            _ => throw new ArgumentException("Unknown subscription type")
        };
        return subscription;
    }
}

public class ManagerCall : SubscriptionFactory
{
    public override Subscription CreateSubscription(string type)
    {
        Subscription subscription = type.ToLower() switch
        {
            "domestic" => new DomesticSubscription(),
            "educational" => new EducationalSubscription(),
            "premium" => new PremiumSubscription(),
            _ => throw new ArgumentException("Unknown subscription type")
        };
        return subscription;
    }
}

class Program
{
    static void Main()
    {
        SubscriptionFactory website = new WebSite();
        SubscriptionFactory mobileApp = new MobileApp();
        SubscriptionFactory managerCall = new ManagerCall();

       
        Subscription sub1 = website.CreateSubscription("domestic");
        Subscription sub2 = mobileApp.CreateSubscription("educational");
        Subscription sub3 = managerCall.CreateSubscription("premium");

        sub1.DisplayInfo();
        sub2.DisplayInfo();
        sub3.DisplayInfo();
    }
}
