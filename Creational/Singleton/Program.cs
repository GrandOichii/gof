namespace Singleton;

// Singleton
public class Application {
    public static readonly Application Instance = new();

    private Application() { }
} 

public class Program {

    public static void Main(string[] args) {
        var application = Application.Instance;

        Console.WriteLine(application);

        // ! Can't create new Application instances
        // new Application(); // -> will throw an error
    }
}
