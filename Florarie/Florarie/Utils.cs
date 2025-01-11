namespace Florarie;

public static class Utils
{
    
    
        public static Utilizator getUserFromString(string line)
        {
            var arr = line.Split('|');
            Utilizator utilizator = new Utilizator(arr[0], arr[1], arr[2], arr[3], arr[4]);
            return utilizator;
        }
    
}