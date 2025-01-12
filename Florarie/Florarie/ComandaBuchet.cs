namespace Florarie;

public class ComandaBuchet : Comanda
{
    public enum Status{ InPreluare, AsteptareMaterie, InLucru, Finalizat, Revendicat}
    
    public string NumeClient { get; set; }
    public string NrTelefon  { get; set; }
    public Status StatusBuchet { get; set; }
    public List<ComandaMaterie> Materiale { get; set; } 

    public ComandaBuchet(string DescriereComanda, int CodComanda, string numeClient, string nrTelefon, Status statusBuchet) : base(DescriereComanda, CodComanda)
    {
        NumeClient = numeClient;
        NrTelefon = nrTelefon;
        StatusBuchet = statusBuchet;
    }

    public bool ValidareNrTelefon(string NrTelefon)
    {
        foreach (char c in NrTelefon)
        {
            if (!char.IsDigit(c))
            {
                return false;
            }
        }
        if (NrTelefon.Length != 10 || string.IsNullOrEmpty(NrTelefon))
        {
            return false;
        }

        return true;
    }

    public bool MaterialeDisponibileVerificare()
    {
        return Materiale.All(material => material.Status == ComandaMaterie.StatusMaterie.Finalizat);
    }
    
}