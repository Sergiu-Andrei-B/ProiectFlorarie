// See https://aka.ms/new-console-template for more information

using Florarie;

public static class Program
{
    public static void Main()
    {
        UserRepo repo = new UserRepo("D:\\Faculta\\Anul 2\\Semestrul 1\\POO\\ProiectFlorarie\\Florarie\\Florarie\\user.txt");
        UserService service = new UserService(repo);
        GestionareComenzi gestionareComenzi = new GestionareComenzi();
        Meniu meniu = new Meniu(service, gestionareComenzi);
        meniu.startMeniu();
    }
}