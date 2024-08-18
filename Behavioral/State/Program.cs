using Microsoft.VisualBasic;

namespace State;

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

#region Concrete

public class Creature {
    public ICreatureState State { get; set; }
    public string Name { get; }

    public Creature(string name, ICreatureState initialState) {
        Name = name;
        State = initialState;
    }

    public void Behave() {
        State.Handle(this);
    }
}

public interface ICreatureState {
    public void Handle(Creature creature);
}

public class Wonder : ICreatureState
{
    private static readonly Random Rng = new();

    public ICreatureState? SeePlayerReaction { get; set; } = null;

    private bool SeesPlayer() {
        return Rng.Next() % 3 == 0;
    }

    public void Handle(Creature creature)
    {
        System.Console.WriteLine($"{creature.Name} wonders");

        if (SeesPlayer() && SeePlayerReaction is not null) {
            System.Console.WriteLine($"{creature.Name} noticed the player");
            creature.State = SeePlayerReaction;
        }
    }
}

public class Chase : ICreatureState
{
    private static readonly Random Rng = new();

    public Wonder Wonder { get; }

    public Chase(Wonder wonder) {
        Wonder = wonder;
    }

    private bool LosesInterest() {
        return Rng.Next() % 2 == 0;
    }

    public void Handle(Creature creature)
    {
        System.Console.WriteLine($"{creature.Name} chases after the player");

        if (LosesInterest()) {
            System.Console.WriteLine($"{creature.Name} loses interest");
            creature.State = Wonder;
        }
    }

}

#endregion

public class Program {

    public static void Main(string[] args) {
        var wonder = new Wonder();

        var chase = new Chase(wonder);
        wonder.SeePlayerReaction = chase;

        var creature = new Creature("Zombie", wonder);

        while (true) {
            creature.Behave();

            Thread.Sleep(500);
        }
    }
}
