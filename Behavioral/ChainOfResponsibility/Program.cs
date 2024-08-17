namespace ChainOfResponsibility;

#region Abstract

public class Handler {
    public Handler? Child { get; set; } = null;

    public virtual void HandleRequest() {
        System.Console.WriteLine("Handler HandleRequest");
        Child?.HandleRequest();
    }
}

public class ConcreteHandler1 : Handler {
    public override void HandleRequest()
    {
        System.Console.WriteLine("ConcreteHandler1 HandleRequest");
        base.HandleRequest();
    }
}

public class ConcreteHandler2 : Handler {
    public override void HandleRequest()
    {
        System.Console.WriteLine("ConcreteHandler1 HandleRequest");
        base.HandleRequest();
    }
}

#endregion

#region Concrete

public class Telephone {
    public Telephone? Next { get; }
    
    public Telephone(Telephone? next) {
        Next = next;
    }

    public virtual string Receive(string msg) {
        if (Next is not null)
            msg = Next.Receive(msg);
        return msg;
    }
}

public class BrokenTelephone : Telephone {
    private static readonly Random _rng = new();
    public BrokenTelephone(Telephone? next)
        : base(next)
    {}

    public override string Receive(string msg)
    {
        msg = msg.Remove(_rng.Next() % msg.Length, 1);

        return base.Receive(msg);
    }
}

#endregion

public class Program {

    public static void Main(string[] args) {
        var chain = 
            new Telephone(
            new BrokenTelephone(
            new BrokenTelephone(
            new Telephone(
            new BrokenTelephone(
            null
        )))));

        var received = chain.Receive("Hello, world!");
        System.Console.WriteLine($"Received message: {received}");
    }
}
