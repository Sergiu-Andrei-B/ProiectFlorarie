namespace Florarie;

public class Angajat : Utilizator
{
    public ComandaBuchet comandaCurenta { get; set; }

    public Angajat(string cod, string nume, string prenume, string email, string parola) : base(cod, nume, prenume,
        email, parola)
    {
        comandaCurenta = null; 
    }
}
