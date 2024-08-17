namespace Flyweight;

// TODO add concrete

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

public class Program {

    public static void Main(string[] args) {
    }
}
