namespace AbstractFactory;

#region Product A

// Abstract product A
public interface IButton {
    public string GetName();
}

// Product A1
public class WindowsButton : IButton
{
    public string GetName()
    {
        return "Windows button";
    }
}

// Product A2
public class MacButton : IButton
{
    public string GetName()
    {
        return "Mac button";
    }
}

#endregion

#region Product B

// Abstract product B
public interface IWindow {
    public string GetTitle();
}

// Product B1
public class WindowsWindow : IWindow
{
    public string GetTitle()
    {
        return "Windows window";
    }
}

// Product B2
public class MacWindow : IWindow
{
    public string GetTitle()
    {
        return "Mac window";
    }
}


#endregion

#region Factories

// Abstract factory
public interface IApplicationFactory {

    public IWindow CreateWindow();
    public IButton CreateButton();
}

// Concrete factory 1
public class WindowsFactory : IApplicationFactory {
    public IWindow CreateWindow() {
        return new WindowsWindow();
    }

    public IButton CreateButton() {
        return new WindowsButton();
    }
}

// Concrete factory 2
public class MacFactory : IApplicationFactory
{
    public IWindow CreateWindow()
    {
        return new MacWindow();
    }
    
    public IButton CreateButton()
    {
        return new MacButton();
    }

}

#endregion

public class Program {
    public static void Main(string[] args) {
        IApplicationFactory factory;

        factory = new MacFactory();
        // factory = new WindowsFactory();

        var window = factory.CreateWindow();
        Console.WriteLine(
            window.GetTitle()
        );
        
        var button = factory.CreateButton();
        Console.WriteLine(
            button.GetName()
        );
    }
}
