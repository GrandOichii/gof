namespace Command;

// TODO add concrete
// TODO? add more

#region Abstract

public interface ICommand {
    public void Execute(); 
}

public class ConcreteCommand1 : ICommand {
    public void Execute() {
        System.Console.WriteLine("ConcreteCommand1 Execute");
    }
}

public class ConcreteCommand2 : ICommand {
    public void Execute() {
        System.Console.WriteLine("ConcreteCommand2 Execute");
    }
}

#endregion

public class Program {

    public static void Main(string[] args) {
    }
}
