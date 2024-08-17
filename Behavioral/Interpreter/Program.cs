namespace Interpreter;

#region Abstract

public class Context {}

public interface IAbstractExpression {
    public void Interpret(Context ctx);
}

public class TerminalExpression : IAbstractExpression {
    public void Interpret(Context ctx) {
        System.Console.WriteLine("TerminalExpression Interpret");
    }
}

public class NonterminalExpression : IAbstractExpression {
    public void Interpret(Context ctx) {
        System.Console.WriteLine("NonterminalExpression Interpret");
    }
}

#endregion

#region Concrete

public class EvalContext {
    public Dictionary<string, bool> Booleans { get; set; } = [];

    public void Assign(VariableExpression var, bool v) {
        Booleans[var.Name] = v;
    }

    public bool Lookup(string name) {
        if (!Booleans.ContainsKey(name))
            throw new Exception($"Unassigned boolean variable: {name}");
        return Booleans[name];
    }
}

public interface IBooleanExpression {
    public bool Evaluate(EvalContext ctx);
}

public class OrExpression : IBooleanExpression {
    public IBooleanExpression First { get; }
    public IBooleanExpression Second { get; }

    public OrExpression(IBooleanExpression first, IBooleanExpression second) {
        First = first;
        Second = second;
    }

    public bool Evaluate(EvalContext ctx) {
        return First.Evaluate(ctx) || Second.Evaluate(ctx);
    }
}

public class AndExpression : IBooleanExpression {
    public IBooleanExpression First { get; }
    public IBooleanExpression Second { get; }

    public AndExpression(IBooleanExpression first, IBooleanExpression second) {
        First = first;
        Second = second;
    }

    public bool Evaluate(EvalContext ctx) {
        return First.Evaluate(ctx) && Second.Evaluate(ctx);
    }
}

public class VariableExpression : IBooleanExpression {
    public string Name { get; }

    public VariableExpression(string name) {
        Name = name;
    }

    public bool Evaluate(EvalContext ctx) {
        return ctx.Lookup(Name);
    }
}

public class Constant : IBooleanExpression {
    public bool Value { get; }

    public Constant(bool v) {
        Value = v;
    } 

    public bool Evaluate(EvalContext ctx) {
        return Value;
    }
}

public class NotExpression : IBooleanExpression {
    public IBooleanExpression Wrapped { get; }

    public NotExpression(IBooleanExpression wrapped) {
        Wrapped = wrapped;
    } 

    public bool Evaluate(EvalContext ctx) {
        return !Wrapped.Evaluate(ctx);
    }
}



#endregion

public class Program {

    public static void Main(string[] args) {
        var ctx = new EvalContext();

        var x = new VariableExpression("X");
        var y = new VariableExpression("Y");

        IBooleanExpression exp = new OrExpression(
            new AndExpression(new Constant(true), x),
            new AndExpression(y, new NotExpression(x))
        );

        ctx.Assign(x, false);
        ctx.Assign(y, true);

        var result = exp.Evaluate(ctx);

        System.Console.WriteLine($"Evaluation result: {result}");
    }
}
