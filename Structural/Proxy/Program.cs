namespace Proxy;

// TODO add concrete

#region Abstract

public interface ISubject {
    public void Request();
}

public class RealSubject : ISubject {
    public void Request() {
        System.Console.WriteLine("RealSubject Request");
    }
}

public class Proxy : ISubject {
    private RealSubject? _realSubject = null;

    public void Request() {
        if (_realSubject is null)
            _realSubject = new RealSubject();
            
        _realSubject.Request();
    }
}

#endregion

public class Program {

    public static void Main(string[] args) {

    }
}
