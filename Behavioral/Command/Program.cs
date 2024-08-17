namespace Command;

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

#region Concrete

// Command
public interface IAction {
    public void Execute(Player player);
}

// Concrete command
public class RestCommand : IAction {
    public void Execute(Player player) {
        System.Console.WriteLine($"{player.Name} rests");
    }
}

// Concrete command
public class AttackCommand : IAction {
    public void Execute(Player player) {
        System.Console.WriteLine($"{player.Name} attack a nearby slime");
    }
}

public class Player {
    private readonly Dictionary<string, IAction> Actions = new() {
        { "rest", new RestCommand() },
        { "attack", new AttackCommand() },
    };

    public string Name { get; }

    public Player(string name) {
        Name = name;
    }

    public void Action(string word) {
        if (!Actions.ContainsKey(word)) {
            System.Console.WriteLine($"I don't understand that...");
            return;
        }

        Actions[word].Execute(this);
    }
}

#endregion

public class Program {

    public static void Main(string[] args) {
        var player = new Player("Player1");

        player.Action("attack");

        player.Action("rest");

        player.Action("profit?");
    }
}
