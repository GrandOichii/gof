namespace Flyweight;

#region Abstract

public interface IFlyweight {
    public void Operation(int extrinsicState);
}

public class ConcreteFlyweight : IFlyweight {
    public int IntrinsicState { get; set; } = 0;

    public void Operation(int extrinsicState) {
        System.Console.WriteLine($"ConcreteFlyweight Operation extrinsicState: {extrinsicState}");
    }
}

public class FlyweightFactory {
    public Dictionary<string, IFlyweight> Flyweights { get; set; } = [];

    public IFlyweight GetFlyweight(string key) {
        // return existing if exists
        if (Flyweights.ContainsKey(key)) {
            return Flyweights[key];
        }

        // create new flyweight and return it
        Flyweights[key] = new ConcreteFlyweight();

        return Flyweights[key];
    } 
}

#endregion

#region Concrete

// ? is this accurate

// Flyweight
public abstract class Creature {
    public string Color { get; protected set; }

    public Creature(string color) {
        Color = color;
    }
    
    public abstract string GetDescription();
}

// Concrete flyweight 1
public class Dragon : Creature
{
    public Dragon(string color)
        : base(color)
    {}

    public override string GetDescription()
    {
        return "A mighty dragon";
    }
}

// Concrete flyweight 2
public class Zombie : Creature
{
    public Zombie(string color)
        : base(color)
    {}
    
    public override string GetDescription()
    {
        return "A walking corpse";
    }
}

// Flyweight factory
public class CreatureFactory {
    private readonly Dictionary<string, Creature> _index = [];

    public Creature GetCreature(string s) {
        if (_index.ContainsKey(s)) {
            return _index[s];
        }

        var split = s.Split(" ");
        if (split.Length != 2) {
            throw new Exception($"Can't parse creature string: {s}");
        }

        var color = split[0];
        var type = split[1];

        Creature newCreature;
        switch (type) {

        case "dragon":
            newCreature = new Dragon(color);
            break;
        case "zombie":
            newCreature = new Zombie(color);
            break;
        default:
            throw new Exception($"Don't know what {type} is");
        
        }

        _index[s] = newCreature;
        return newCreature;
    }
}


#endregion

public class Program {

    public static void Main(string[] args) {
        var factory = new CreatureFactory();

        var zombie1 = factory.GetCreature("green zombie");
        var zombie2 = factory.GetCreature("red zombie");

        var dragon1 = factory.GetCreature("blue dragon");
        var dragon2 = factory.GetCreature("blue dragon");

        var creatures = new List<Creature>() {
            zombie1,
            zombie2,
            dragon1,
            dragon2,
        };
        foreach (var creature in creatures) {
            System.Console.WriteLine($"({creature.Color}) {creature.GetDescription()}");
        }

        // ! dragon1 and dragon2 are the same object
        System.Console.WriteLine(dragon1 == dragon2);
    }
}
