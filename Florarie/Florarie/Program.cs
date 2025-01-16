// See https://aka.ms/new-console-template for more information

using Florarie;

public static class Program
{
    public static void Main()
    {
        UserRepo repo = new UserRepo("E:\\ProiectePOO\\ProiectFlorarie\\Florarie\\Florarie\\user.txt");
        var BuchetPath = "E:\\ProiectePOO\\ProiectFlorarie\\Florarie\\Florarie\\ComenziBuchet.txt";
        var MaterialePath = "E:\\ProiectePOO\\ProiectFlorarie\\Florarie\\Florarie\\ComenziMateriale.txt";
        UserService service = new UserService(repo);
        
        GestionareComenzi gestionareComenzi = new GestionareComenzi(BuchetPath, MaterialePath);
        gestionareComenzi.IncarcareComenzi();
        
        Meniu meniu = new Meniu(service, gestionareComenzi);
        meniu.startMeniu();
    }
}