﻿namespace Decorator;

// TODO add concrete

// Singleton

#region Abstract

// Component
public interface IComponent {
    public void Operation();
}

// ConcreteComponent
public class ConcreteComponent : IComponent {
    public void Operation() {
        Console.WriteLine("ConcreteComponent Operation");
    }
}

// Decorator
public abstract class Decorator : IComponent {
    public IComponent? Wrapped { get; set; }

    public virtual void Operation() {
        System.Console.WriteLine("Decorator Operation");
        Wrapped?.Operation();
    }
}

// ConcreteDecoratorA
public class ConcreteDecoratorA : Decorator {
    public int SomeAddedState { get; set; } = 0;
}

public class ConcreteDecoratorB : Decorator {
    public void AddedBehavior() {
        System.Console.WriteLine("ConcreteDecoratorB AddedBehavior");
    }

    public override void Operation()
    {
        base.Operation();
        AddedBehavior();
    }
}

#endregion

#region Concrete



#endregion

public class Program {

    public static void Main(string[] args) {
    }
}
