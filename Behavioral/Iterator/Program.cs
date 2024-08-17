namespace Iterator;

// Aggregate
public interface ITable {
    public ITableIterator CreateIterator();
}

// ConcreteAggregate
public class Table : ITable {
    public List<string> Items { get; } = [];

    public Table(List<string> items) {
        Items = items;
    }

    public ITableIterator CreateIterator() {
        return new ForwardTableIterator(this);
    }
}

// Iterator
public interface ITableIterator {
    public void First();
    public void Next();
    public bool IsDone();
    public string CurrentItem();
}

// ConcreteIterator
public class ForwardTableIterator : ITableIterator {
    private Table _table;
    private int _idx;

    public ForwardTableIterator(Table table) {
        _table = table;
        _idx = 0;
    }

    public void First() {
        _idx = 0;
    }

    public void Next() {
        ++_idx;
    }

    public bool IsDone() {
        return _idx >= _table.Items.Count;
    }

    public string CurrentItem() {
        if (IsDone())
            throw new Exception($"Table idx out of range ({_idx})");

        return _table.Items[_idx];
    }
}

public class BackwardTableIterator : ITableIterator {
    private Table _table;
    private int _idx;

    public BackwardTableIterator(Table table) {
        _table = table;
    }

    public void First() {
        _idx = _table.Items.Count - 1;
    }

    public void Next() {
        --_idx;
    }

    public bool IsDone() {
        return _idx < 0;
    }

    public string CurrentItem() {
        if (IsDone())
            throw new Exception($"Table idx out of range ({_idx})");

        return _table.Items[_idx];
    }
}

public class Program {

    public static void Main(string[] args) {
        var table = new Table([ "hello", "world", "!" ]);
        var i = table.CreateIterator();

        for (i.First(); !i.IsDone(); i.Next()) {
            System.Console.WriteLine(i.CurrentItem());
        }

        i = new BackwardTableIterator(table);
        for (i.First(); !i.IsDone(); i.Next()) {
            System.Console.WriteLine(i.CurrentItem());
        }
        
    }
}
