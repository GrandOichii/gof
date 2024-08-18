namespace Proxy;

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

#region Concrete

public interface IImage {
    public byte[] GetImage();
}

public class FileImage : IImage {
    private byte[] _content;

    public FileImage(string path) {
        System.Console.WriteLine($"Reading image from file {path}");
        _content = [];
    }

    public byte[] GetImage() {
        return _content;
    }
}

public class FileImageProxy : IImage {
    private FileImage? _wrapped;
    private string _path;

    public FileImageProxy(string path) {
        _path = path;
        _wrapped = null;
    }

    public byte[] GetImage() {
        if (_wrapped is null)
            _wrapped = new FileImage(_path);

        return _wrapped.GetImage();
    }
}

#endregion

public class Program {

    public static void Main(string[] args) {
        IImage image1 = new FileImageProxy("images/cat.png");
        IImage image2 = new FileImageProxy("images/dog.png");

        System.Console.WriteLine(image1.GetImage());
        System.Console.WriteLine(image2.GetImage());
    }
}
