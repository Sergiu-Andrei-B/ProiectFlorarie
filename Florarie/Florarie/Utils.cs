namespace Florarie;

public static class Utils
{
    
    public static Utilizator getUserFromString(string line)
    {
        var arr = line.Split('|');
        var cod = arr[0];
        if (cod.StartsWith("a"))
        {
            return new Angajat(cod, arr[1], arr[2], arr[3], arr[4]);
        }
        else if (cod.StartsWith("b"))
        {
            return new Client(cod, arr[1], arr[2], arr[3], arr[4]);
        }
        else
        {
            throw new Exception("Tipul de utilizator este necunoscut.");
        }
    }
    
}