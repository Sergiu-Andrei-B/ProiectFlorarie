namespace Florarie;

public class ComandaMaterie : Comanda
{
    public enum StatusMaterie{ InAsteptare, Finalizat}
    
    public StatusMaterie Status { get; set; }

    public ComandaMaterie(string DescriereComanda, int CodComanda, StatusMaterie status) : base(DescriereComanda, CodComanda)
    {
        Status = status;
    }
    
    
    
    
}