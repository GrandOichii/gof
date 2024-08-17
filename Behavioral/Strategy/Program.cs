namespace Strategy;


// Strategy
public interface IAccumulator {
    public int Initial();
    public int Accumulate(int current, int item);
}

// ConcreteStrategyA
public class SumAccumulator : IAccumulator {
    public int Initial() {
        return 0;
    }

    public int Accumulate(int current, int item) {
        return current + item;
    }
}

// ConcreteStrategyB
public class MultAccumulator : IAccumulator {
    public int Initial() {
        return 1;
    }

    public int Accumulate(int current, int item) {
        return current * item;
    }
}

// Context
public class Table {
    public List<int> Items { get; } = [];
    public IAccumulator Accumulator { get; set; }

    public Table(List<int> items, IAccumulator accumulator) {
        Items = items;
        Accumulator = accumulator;
    }

    public int Accumulate() {
        var result = Accumulator.Initial();
        foreach (var item in Items)
            result = Accumulator.Accumulate(result, item);
        return result;
    }
}

public class Program {

    public static void Main(string[] args) {
        var table = new Table([ 1, 5, 3 ], new SumAccumulator());
        System.Console.WriteLine($"Accumulated: {table.Accumulate()}");

        table.Accumulator = new MultAccumulator();
        System.Console.WriteLine($"Accumulated: {table.Accumulate()}");
    }
}
