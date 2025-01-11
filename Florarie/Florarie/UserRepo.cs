namespace Florarie;

public class UserRepo
{
    private string path;
    private Dictionary<string, Utilizator> users = new Dictionary<string, Utilizator>();

    public UserRepo(string path)
    {
        this.path = path;
        read();
    }

    private void read()
    {
        string[] lines = System.IO.File.ReadAllLines(path);
        foreach (string line in lines) 
        {
            Utilizator utilizator = Utils.getUserFromString(line);
            add(utilizator);
        }
    }

    private void write()
    {
        using (StreamWriter writer = new StreamWriter(path))
        {
            foreach (var user in users.Values)
            {
                writer.WriteLine(user);
            }
        }
    }

    public Utilizator findOne(string cod)
    {
        if (users.ContainsKey(cod))
            return users[cod];
        return null;
    }

    public IEnumerable<Utilizator> findAll()
    {
        return users.Values;
    }

    public bool add(Utilizator utilizator)
    {
        if (users.ContainsKey(utilizator.cod))
        {
            Console.WriteLine("Cod deja existent");
            return false;
        }

        users[utilizator.cod] = utilizator;
        write();
        return true;
    }

}