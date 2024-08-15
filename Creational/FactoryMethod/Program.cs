namespace FactoryMethod;

#region Products

// Product
public interface IItem {
    public string GetName();
}

// Concrete product 1
public class Sword : IItem
{
    public string GetName()
    {
        return "Sharp Sword";
    }
}

// Concrete product 2
public class Potion : IItem
{
    public string GetName()
    {
        return "Suspicious potion";
    }
}

// Concrete product 3
public class Cake : IItem
{
    public string GetName()
    {
        return "Delicious cake";
    }
}

#endregion

public class ItemCreator {
    
    // Abstract method
    public IItem Create(string name) {
        switch (name) {

        case "sword":
            return new Sword();
        case "potion":
            return new Potion();
        case "cake":
            return new Cake();
        default:
            throw new Exception($"Unrecognized item type: {name}");

        }
    }
}

public class Program {

    public static void Main(string[] args) {
        var creator = new ItemCreator();

        var cake = creator.Create("cake");
        Console.WriteLine(
            cake.GetName()
        );

        var sword = creator.Create("sword");
        Console.WriteLine(
            sword.GetName()
        );

        var potion = creator.Create("potion");
        Console.WriteLine(
            potion.GetName()
        );
    }
}
