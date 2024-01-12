using System;

public class DatabaseLogger
{
    public void Log(string message)
    {
        Console.WriteLine($"Zapis u bazu podataka: {message}");
    }
}

// Visokorazinski modul
public class Logger
{
    private DatabaseLogger databaseLogger = new DatabaseLogger();

    public void LogMessage(string message)
    {
        databaseLogger.Log(message);
    }
}

class Program
{
    static void Main()
    {
        Logger logger = new Logger();
        logger.LogMessage("Ovo je poruka za zapisivanje u bazu podataka.");
    }
}

//Ovdje klasa Logger koja je visokorazinski modul, direktno ovisi o niskorazinskom modulu DatabaseLogger
//To krsi DIP jer klasa Logger ne bi trebala ovisiti o klasi DatabaseLogger vec bi oboje trebali ovisiti o apstrakciji.
//Dobro bi bilo napraviti nekakvo sucelje ILogger npr i unutar toga metodu Log i onda u klasi Logger instancirati to sucelje ILogger 
//npr. private ILogger logger i onda ga ubrizgati kroz konstruktor i na taj nacin postujemo DIP. 