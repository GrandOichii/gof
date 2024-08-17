namespace TemplateMethod;

// TODO add concrete

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

public class Program {

    public static void Main(string[] args) {

    }
}
