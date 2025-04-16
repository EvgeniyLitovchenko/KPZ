public sealed class Authenticator
{
    private static readonly object _syncRoot = new object();
    private static Authenticator? _instance;

    private Authenticator()
    {
        Console.WriteLine("New Authenticator created.");
    }

    public static Authenticator Instance
    {
        get
        {
            if (_instance == null)
            {
                lock (_syncRoot)
                {
                    _instance ??= new Authenticator();
                }
            }
            return _instance;
        }
    }

    public void Authenticate(string username, string password)
    {
        Console.WriteLine($"User '{username}' is being authenticated with password length: {password.Length}");
    }
}

class Program
{
    static void Main()
    {
        var auth1 = Authenticator.Instance;
        var auth2 = Authenticator.Instance;

        Console.WriteLine(auth1.Equals(auth2) ? "Instances are equal" : "Instances differ");

        auth1.Authenticate("user1", "password123");
    }
}
