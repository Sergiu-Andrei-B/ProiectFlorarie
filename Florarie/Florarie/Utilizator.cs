namespace Florarie;

public abstract class Utilizator
{
    public string cod { get; set; }
    public string nume { get; set; }
    public string prenume { get; set; }
    public string email { get; set; }
    public string parola { get; set; }
    

    public Utilizator(string cod, string nume, string prenume, string email, string parola)
    {
        this.cod = cod;
        this.nume = nume;
        this.prenume = prenume;
        this.email = email;
        this.parola = parola;
    }

    public override string ToString()
    {
        return cod + "|" + nume + "|" + prenume + "|" + email + "|" + parola;
    }
}