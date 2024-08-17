namespace Observer;

// TODO add concrete

#region Abstract

public class Subject {
    private List<IObserver> _observers = [];

    public void Attach(IObserver observer) {
        _observers.Add(observer);
    }

    public void Detach(IObserver observer) {
        _observers.Remove(observer);
    }

    public void Notify() {
        foreach (var observer in _observers) {
            observer.Update();
        }
    }
}

public class ConcreteSubject : Subject {
    private int _state = 0;

    public int GetState() { return _state; }
    public int SetState(int state) { _state = state; }
}

public interface IObserver {
    public void Update();
}

public class ConcreteObserver : IObserver {
    public int ObserverState { get; private set; }
    private ConcreteSubject _subject;

    public ConcreteObserver(ConcreteSubject subject) {
        _subject = subject;
    }

    public void Update() {
        ObserverState = _subject.GetState();
    }
}

#endregion

public class Program {

    public static void Main(string[] args) {
        
    }
}
