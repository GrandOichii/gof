namespace Composite;

// Component
public interface ITreePart {
    public int GetFruitCount();
    public void Add(ITreePart child);
    public void Remove(ITreePart child);
    public ITreePart Get(int childI);
}

// Leaf
public class Twig : ITreePart {
    public bool HasFruit { get; }

    public Twig(bool hasFruit) {
        HasFruit = hasFruit;
    }

    public int GetFruitCount() {
        return HasFruit
            ? 1
            : 0
        ;
    }

    public void Add(ITreePart child) {
        throw new Exception("can't add tree parts to Twig");
    }

    public void Remove(ITreePart child) {
        throw new Exception("can't remove tree parts from Twig");

    }

    public ITreePart Get(int childI) {
        throw new Exception("Twig has no tree parts");
    }
}

public class Branch : ITreePart {
    public List<ITreePart> Children { get; } = [];

    public int GetFruitCount() {
        var result = 0;

        foreach (var child in Children)
            result += child.GetFruitCount();
        
        return result;
    }

    public void Add(ITreePart child) {
        Children.Add(child);
    }

    public void Remove(ITreePart child) {
        Children.Remove(child);
    }

    public ITreePart Get(int childI) {
        return Children[childI];
    }

}

public class Program {

    public static void Main(string[] args) {
        ITreePart tree = new Branch();

        ITreePart b1 = new Branch();
        tree.Add(b1);

            b1.Add(new Twig(false));
            b1.Add(new Twig(true));

        ITreePart b2 = new Branch();
        tree.Add(b2);

            b2.Add(new Twig(false));

            ITreePart b3 = new Branch();
            b2.Add(b3);

                b3.Add(new Twig(true));
                b3.Add(new Twig(true));
                b3.Add(new Twig(true));

            b2.Add(new Twig(false));

        Console.WriteLine($"Fruit count: {tree.GetFruitCount()}");
    }
}
