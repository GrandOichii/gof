namespace Visitor;

// TODO add concrete

#region Abstract

public interface IElement {
    public void Accept(IVisitor visitor);
}

public class ConcreteElementA {
    public void OperationA() {
        System.Console.WriteLine("ConcreteElementA OperationA");
    }

    public void Accept(IVisitor visitor) {
        visitor.VisitConcreteElementA(this);
    }
}

public class ConcreteElementB {
    public void OperationB() {
        System.Console.WriteLine("ConcreteElementA OperationB");
    }

    public void Accept(IVisitor visitor) {
        visitor.VisitConcreteElementB(this);
    }
}

public interface IVisitor {
    public void VisitConcreteElementA(ConcreteElementA element);
    public void VisitConcreteElementB(ConcreteElementB element);
}

public class ConcreteVisitor1 {
    public void VisitConcreteElementA(ConcreteElementA element) {
        System.Console.WriteLine("ConcreteVisitor1 VisitConcreteElementA");
    }

    public void VisitConcreteElementB(ConcreteElementB element) {
        System.Console.WriteLine("ConcreteVisitor1 VisitConcreteElementB");
    }
}

public class ConcreteVisitor2 {
    public void VisitConcreteElementA(ConcreteElementA element) {
        System.Console.WriteLine("ConcreteVisitor2 VisitConcreteElementA");
    }

    public void VisitConcreteElementB(ConcreteElementB element) {
        System.Console.WriteLine("ConcreteVisitor2 VisitConcreteElementB");
    }
}

#endregion

public class Program {

    public static void Main(string[] args) {
    }
}
