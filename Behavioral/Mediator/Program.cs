namespace Mediator;

// * not sure about this one

// TODO add concrete

#region Abstract

public interface IMediator {

}

public class ConcreteMediator : IMediator {
    public ConcreteColleague1 Colleague1 { get; }
    public List<ConcreteColleague2> Colleagues2 { get; set; }
}

public class Colleague {
    public IMediator Mediator { get; set; }

    public Colleague(IMediator mediator) {
        Mediator = mediator;
    }
}

public class ConcreteColleague1 : Colleague {
    public ConcreteColleague1(IMediator mediator) : base(mediator) {}
}

public class ConcreteColleague2 : Colleague {
    public ConcreteColleague2(IMediator mediator) : base(mediator) {}
}

#endregion

public class Program {

    public static void Main(string[] args) {
    }
}
