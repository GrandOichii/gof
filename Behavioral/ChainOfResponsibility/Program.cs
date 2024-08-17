namespace ChainOfResponsibility;

// TODO add concrete

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

public class Program {

    public static void Main(string[] args) {

    }
}
