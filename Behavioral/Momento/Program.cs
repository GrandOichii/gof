namespace Momento;

// TODO add concrete

#region Abstract

public class Caretaker {
    public List<Momento> Momentos { get; } = [];

    public void Add(Momento momento) { Momentos.Add(momento); }
}

public class Momento {
    private int _state;

    public Momento(int state) { _state = state; }

    public int GetState() { return _state; }
    public void SetState(int state) { _state = state; }
}

public class Originator {
    private int _state = 0;

    public void SetMomento(Momento momento) {
        _state = momento.GetState();
    }

    public Momento CreateMomento() {
        return new Momento(_state);
    }
}

#endregion

public class Program {

    public static void Main(string[] args) {

    }
}
