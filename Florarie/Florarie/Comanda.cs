namespace Florarie;

public abstract class Comanda
{
    public string DescriereComanda { get; set; }
    public int CodComanda { get; set; }

    public Comanda(string descriereComanda, int codComanda)
    {
        DescriereComanda = descriereComanda;
        CodComanda = codComanda;
    }

    public override string ToString()
    {
        return $"Comanda:{DescriereComanda} cu codul:{CodComanda} a fost aduagata";
    }
}