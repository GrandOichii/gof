namespace TemplateMethod;

#region Abstract

public interface IAbstractClass {
    public void PrimitiveOperation1();

    public void PrimitiveOperation2();

    public void TemplateMethod() {
        System.Console.WriteLine("Before PrimitiveOperation1");
        PrimitiveOperation1();
        System.Console.WriteLine("After PrimitiveOperation1, Before PrimitiveOperation2");
        PrimitiveOperation2();
        System.Console.WriteLine("After PrimitiveOperation2");
    }
}

public class ConcreteClass : IAbstractClass {
    public void PrimitiveOperation1() {
        System.Console.WriteLine("ConcreteClass PrimitiveOperation1");
    }

    public void PrimitiveOperation2() {
        System.Console.WriteLine("ConcreteClass PrimitiveOperation2");
    }
}

#endregion

#region Concrete

public interface IPolygon {
    public string GetColor();
    public List<int[]> GetVerticies();

    public void Draw() {
        var verticies = GetVerticies();
        var color = GetColor();

        System.Console.WriteLine($"Drawing polygon with color {color}");
        foreach (var vert in verticies)
            System.Console.WriteLine($"Drawing point at ({vert[0]}, {vert[1]})");
    }
}

public class Rectangle : IPolygon {
    private string _color;
    private int _x;
    private int _y;
    private int _width;
    private int _height;
    
    public Rectangle(string color, int x, int y, int width, int height) {
        _color = color;
        _x = x;
        _y = y;
        _width = width;
        _height = height;
    }

    public string GetColor() {
        return _color;
    }

    public List<int[]> GetVerticies() {
        return [
            [_x, _y],
            [_x + _width, _y],
            [_x + _width, _y + _height],
            [_x, _y + _height],
        ];
    }
}

#endregion

public class Program {

    public static void Main(string[] args) {
        IPolygon polygon = new Rectangle("blue", 0, 1, 5, 3);         

        polygon.Draw();
    }
}
