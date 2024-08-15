namespace Builder;

// Product
public class Animal {
    public int Legs { get; set; } = 0;
    public int Wings { get; set; } = 0;

    public override string ToString() {
        return $"Legs: {Legs}\tWings: {Wings}";
    }
}

#region Builders

// Builder
public interface IAnimalBuilder {
    public void AddLegs();
    public void AddWings();

    public Animal Build();
}

// Concrete builder 1
public class CatBuilder : IAnimalBuilder {
    private Animal _animal = new();

    public void AddLegs() {
        Console.WriteLine("Added 4 legs to a cat");
        _animal.Legs = 4;
    }

    public void AddWings() {
        Console.WriteLine("Cats have no wings :)");
        _animal.Wings = 0;
    }

    public Animal Build() {
        return _animal;
    }
}

// Concrete builder 2
public class HawkBuilder : IAnimalBuilder {
    private Animal _animal = new();

    public void AddLegs() {
        Console.WriteLine("Added 2 legs to a hawk");
        _animal.Legs = 2;
    }

    public void AddWings() {
        Console.WriteLine("Added 2 wings to a hawk");
        _animal.Wings = 2;
    }

    public Animal Build() {
        return _animal;
    }
}

#endregion

public class Program {

    public static void Main(string[] args) {
        var zoo = new List<Animal>();

        IAnimalBuilder ab1 = new HawkBuilder();
        ab1.AddLegs();
        ab1.AddWings();
        var animal1 = ab1.Build();
        zoo.Add(animal1);

        IAnimalBuilder ab2 = new CatBuilder();
        ab2.AddLegs();
        ab2.AddWings();
        var animal2 = ab2.Build();
        zoo.Add(animal2);

        foreach (var animal in zoo)
            Console.WriteLine(animal);
    }
}
