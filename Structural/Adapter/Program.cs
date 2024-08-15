namespace Adapter;

// Target
public interface IDrawable {
    public void Draw(int x, int y, int width, int height);
}

// Adaptee
public class SomeGuiFrameworkRectangle {
    public void Paint(int lx, int ly, int rx, int ry) {
        Console.WriteLine($"Drawing GUI Framework rectangle: ({lx}, {ly}) -> ({rx}, {ry})");
    }
}

// Adapter (composition)
public class RectangleAdapterComposition : IDrawable {
    public SomeGuiFrameworkRectangle Rect { get; } = new();

    public void Draw(int x, int y, int width, int height) {
        Rect.Paint(x, y, x + width, y + height);
    }
}

// Adapter (inheritance)
public class RectangleAdapterInheritance : SomeGuiFrameworkRectangle, IDrawable {
    public void Draw(int x, int y, int width, int height) {
        Paint(x, y, x + width, y + height);
    }
}

public class Program {

    public static void Main(string[] args) {
        IDrawable rect1 = new RectangleAdapterComposition();

        rect1.Draw(1, 0, 10, 20);

        IDrawable rect2 = new RectangleAdapterInheritance();

        rect2.Draw(-1, 5, 2, 12);
    }
}
