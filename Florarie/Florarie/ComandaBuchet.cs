namespace Florarie;

public class ComandaBuchet : Comanda
{
    public enum Status{ InPreluare, AsteptareMaterie, InLucru, Finalizat, Revendicat}
    
    public string NumeClient { get; set; }
    public string NrTelefon  { get; set; }
    public Status StatusBuchet { get; set; }
    public List<ComandaMaterie> Materiale { get; set; } = new List<ComandaMaterie>();

    public ComandaBuchet(string DescriereComanda, int CodComanda, string numeClient, string nrTelefon, Status statusBuchet) : base(DescriereComanda, CodComanda)
    {
        NumeClient = numeClient;
        NrTelefon = nrTelefon;
        StatusBuchet = statusBuchet;
    }

    public bool MaterialeDisponibileVerificare()
    {
        return Materiale.All(material => material.Status == ComandaMaterie.StatusMaterie.Finalizat);
    }
    
}