namespace State;

// TODO add concrete

#region Abstract

public class Context {
    public IState Current { get; set; }

    public void Request() {
        Current.Handle(this);
    }
}

public interface IState {
    public void Handle(Context ctx);
}

public class ConcreteStateA : IState {
    public void Handle(Context ctx) {
        System.Console.WriteLine("ConcreteStateA Handle");
        ctx.Current = new ConcreteStateB();
    }
}

public class ConcreteStateB : IState {
    public void Handle(Context ctx) {
        System.Console.WriteLine("ConcreteStateB Handle");
        ctx.Current = new ConcreteStateA();
    }
}

#endregion

public class Program {

    public static void Main(string[] args) {

    }
}
