using System;

public interface ISupportHandler
{
    void SetNextHandler(ISupportHandler handler);
    void HandleTicket(Ticket ticket);
}

public abstract class SupportHandlerBase : ISupportHandler
{
    private ISupportHandler _nextHandler;

    public void SetNextHandler(ISupportHandler handler)
    {
        _nextHandler = handler;
    }

    public virtual void HandleTicket(Ticket ticket)
    {
        if (CanHandleTicket(ticket))
        {
            Handle(ticket);
        }
    
        else if (_nextHandler != null)
        {
            _nextHandler.HandleTicket(ticket);
        }
        
        else
        {
            Console.WriteLine("Ticket cannot be handled.");
        }
    }

    protected abstract bool CanHandleTicket(Ticket ticket);
    protected abstract void Handle(Ticket ticket);
}

public class Level1SupportHandler : SupportHandlerBase
{
    protected override bool CanHandleTicket(Ticket ticket)
    {
        return ticket.Severity == Severity.Low;
    }

    protected override void Handle(Ticket ticket)
    {
        Console.WriteLine("Level 1 Support handles the ticket.");
    }
}

public class Level2SupportHandler : SupportHandlerBase
{
    protected override bool CanHandleTicket(Ticket ticket)
    {
        return ticket.Severity == Severity.Medium;
    }

    protected override void Handle(Ticket ticket)
    {
        Console.WriteLine("Level 2 Support handles the ticket.");
    }
}

public class Level3SupportHandler : SupportHandlerBase
{
    protected override bool CanHandleTicket(Ticket ticket)
    {
        return ticket.Severity == Severity.High;
    }

    protected override void Handle(Ticket ticket)
    {
        Console.WriteLine("Level 3 Support handles the ticket.");
    }
}

public class Ticket
{
    public Severity Severity { get; set; }
}

public enum Severity
{
    Low,
    Medium,
    High
}

public class Program
{
    public static void Main()
    {
        var level3SupportHandler = new Level3SupportHandler();
        var level2SupportHandler = new Level2SupportHandler();
        var level1SupportHandler = new Level1SupportHandler();

        level1SupportHandler.SetNextHandler(level2SupportHandler);
        level2SupportHandler.SetNextHandler(level3SupportHandler);

        var ticket1 = new Ticket { Severity = Severity.Low };
        var ticket2 = new Ticket { Severity = Severity.Medium };
        var ticket3 = new Ticket { Severity = Severity.High };

        level1SupportHandler.HandleTicket(ticket1);
        level1SupportHandler.HandleTicket(ticket2);
        level1SupportHandler.HandleTicket(ticket3);
    }
}