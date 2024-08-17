namespace Momento;

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

#region Concrete

// Momento
public class Document {
    private List<string> _pages = [];
    
    public Document(List<string> pages) {
        _pages = pages;
    }

    public List<string> GetPages() { return _pages; }
    public void SetPages(List<string> pages) { _pages = pages; }
}

// Caretaker
public class DocumentHistory {
    public List<Document> History { get; } = [];

    public void Add(Document document) { History.Add(document); }
}

public class Editor {
    public List<string> Pages { get; private set; } = [];

    public void SetDocument(Document doc) {
        Pages = doc.GetPages();
    }

    public Document CreateDocument() {
        return new Document(new(Pages));
    }

    public void Add(int pageI, string text) {
        while (Pages.Count <= pageI) {
            Pages.Add("");
        }

        Pages[pageI] += text;
    }

    public void PrintContents() {
        for (int i = 0; i < Pages.Count; i++) {
            Console.WriteLine($"[Page {i + 1}]");
            Console.WriteLine(Pages[i]);
            Console.WriteLine();
        }
    }
}

#endregion

public class Program {

    public static void Main(string[] args) {
        var history = new DocumentHistory();
        var editor = new Editor();

        editor.Add(0, "Hello");
        editor.Add(1, "This is an example of a momento");
        history.Add(editor.CreateDocument());

        editor.Add(0, ", world!");
        history.Add(editor.CreateDocument());

        var momento1 = history.History[0];
        editor.SetDocument(momento1);
        System.Console.WriteLine("Momento 1");
        editor.PrintContents();

        var momento2 = history.History[1];        
        editor.SetDocument(momento2);
        System.Console.WriteLine("Momento 2");
        editor.PrintContents();
    }
}
