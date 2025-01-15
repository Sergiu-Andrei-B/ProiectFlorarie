// See https://aka.ms/new-console-template for more information

using Florarie;

public static class Program
{
    public static void Main()
    {
        UserRepo repo = new UserRepo("D:\\Faculta\\Anul 2\\Semestrul 1\\POO\\ProiectFlorarie\\Florarie\\Florarie\\user.txt");
        var BuchetPath = "D:\\Faculta\\Anul 2\\Semestrul 1\\POO\\ProiectFlorarie\\Florarie\\Florarie\\ComenziBuchet.txt";
        var MaterialePath = "D:\\Faculta\\Anul 2\\Semestrul 1\\POO\\ProiectFlorarie\\Florarie\\Florarie\\ComenziMateriale.txt";
        UserService service = new UserService(repo);
        GestionareComenzi gestionareComenzi = new GestionareComenzi();
        gestionareComenzi.IncarcareComenzi(BuchetPath, MaterialePath);
        Meniu meniu = new Meniu(service, gestionareComenzi);
        meniu.startMeniu();
        gestionareComenzi.SalvareComenzi(BuchetPath, MaterialePath);
    }
}