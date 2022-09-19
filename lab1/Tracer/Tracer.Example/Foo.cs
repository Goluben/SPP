using Tracer.Core;
using Tracer.Serialization;

namespace Tracer.Example;
public class Foo
{
    private Bar _bar;
    private ITracer _tracer;

    internal Foo(ITracer tracer)
    {
        _tracer = tracer;
        _bar = new Bar(_tracer);
    }
    
    public void MyMethod()
    {
        _tracer.StartTrace();
        _bar.InnerMethod();
        FooMethod();
        _tracer.StopTrace();
    }

    public void FooMethod()
    {
        _tracer.StartTrace();
        Console.WriteLine("My name is FOO!");
        _tracer.StopTrace();
    }
}

public class Bar
{
    private ITracer _tracer;

    internal Bar(ITracer tracer)
    {
        _tracer = tracer;
    }
    
    public void InnerMethod()
    {
        _tracer.StartTrace();
        InnerestMethod();
        _tracer.StopTrace();
    }

    private void InnerestMethod()
    {
        _tracer.StartTrace();
        Console.WriteLine("My name is BAR!");
        _tracer.StopTrace();
    }
}

public class MainClass
{
    public void Main()
    {
        var tracer = new Core.Tracer();
        var temp = new Foo(tracer);
        temp.MyMethod();
        var smth = tracer.GetTraceResult();
        
        var serializator = new Serializator();
        serializator.SerializeAll(smth);
    }
}