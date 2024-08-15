namespace Bridge

#region Implementors

// Implementor
public interface IPrinter {
    public void Print(string[] things);
} 

// Concrete implementor A
public class HorizontalPrinter : IPrinter {
    public void Print(string[] things) {
        Console.WriteLine(string.Join(" ", things));
    }
}

// Concrete implementor B
public class VerticalPrinter : IPrinter {
    public void Print(string[] things) {
        Console.WriteLine(string.Join("\n", things));
    }
}

#endregion

#region Abstraction

// Abstraction
public class StringPrinter {
    public IPrinter Printer { get; set; }

    public StringPrinter(IPrinter printer) {
        Printer = printer;
    }

    public virtual void PrintStrings(string[] strings) {
        Printer.Print(strings);
    }
}

// Abstraction implementation
public class SeparatedStringsPrinter : StringPrinter {
    public string Separator { get; }

    public SeparatedStringsPrinter(IPrinter printer, string separator)
        : base(printer)
    {
        Separator = separator;    
    }

    public override void PrintStrings(string[] strings)
    {
        var newStrings = new List<string>();
        for (int i = 0; i < strings.Length; i++) {
            if (i != 0)
                newStrings.Add(Separator);
            newStrings.Add(strings[i]);
        }

        base.PrintStrings(newStrings.ToArray());
    }
}

#endregion

public class Program {

    public static void Main(string[] args) {
        var vp = new VerticalPrinter();
        var hp = new HorizontalPrinter();
        string[] strings = [ "Hello", "World" ];

        var printer1 = new StringPrinter(vp);
        printer1.PrintStrings(strings);

        Console.WriteLine();

        printer1.Printer = hp;
        printer1.PrintStrings(strings);

        Console.WriteLine();

        var printer2 = new SeparatedStringsPrinter(vp, ",");
        printer2.PrintStrings(strings);

        Console.WriteLine();

        printer2.Printer = hp;
        printer2.PrintStrings(strings);
    }
}
