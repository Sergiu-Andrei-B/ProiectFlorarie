// See https://aka.ms/new-console-template for more information

using Florarie;

public static class Program
{
    public static void Main()
    {
        UserRepo repo = new UserRepo("E:\\ProiectePOO\\ProiectFlorarie\\Florarie\\Florarie\\user.txt");
        UserService service = new UserService(repo);
        Meniu meniu = new Meniu(service);
        meniu.runApp();
    }
}