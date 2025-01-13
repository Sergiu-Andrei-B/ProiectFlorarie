namespace Florarie;

public class Client : Utilizator
{
    public ComandaBuchet comandaCurenta { get; set; }
    public Client(string cod, string nume, string prenume, string email, string parola) : base(cod, nume, prenume, email, parola)
    { }
    
}
