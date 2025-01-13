namespace Florarie;

public class GestionareComenzi
{
    public List<ComandaMaterie> ComenziMaterie { get; set; } = new List<ComandaMaterie>();
    public List<ComandaBuchet> ComenziBuchet { get; set; } = new List<ComandaBuchet>();

    public void AddComandaMaterie(ComandaMaterie comanda)
    {
        ComenziMaterie.Add(comanda);
    }

    public void AddComandaBuchet(ComandaBuchet comanda)
    {
        ComenziBuchet.Add(comanda);
    }
    
    public string PreiaComandaBuchet(int codComandaBuchet)
    {
        var comanda = ComenziBuchet.FirstOrDefault(Comanda => Comanda.CodComanda == codComandaBuchet);
        if (comanda == null)
        {
            return "Comanda de buchet nu a fost găsită.";
        }

        if (comanda.MaterialeDisponibileVerificare())
        {
            comanda.StatusBuchet = ComandaBuchet.Status.InLucru;
            return "Comanda de buchet a fost preluată și este în lucru.";
        }
        else
        {
            comanda.StatusBuchet = ComandaBuchet.Status.AsteptareMaterie;
            return "Materialele necesare nu sunt încă disponibile.";
        }
    }

    public string PreiaComandaMaterie(int codMaterie)
    {
        var comanda = ComenziMaterie.FirstOrDefault(Comanda => Comanda.CodComanda == codMaterie);
        if (comanda == null)
        {
            return "Comanda de materie nu a fost gasita.";
        }

        if (comanda.Status == ComandaMaterie.StatusMaterie.Finalizat)
        {
            return "Comanda de materie este deja finalizata.";
        }
        
        comanda.Status = ComandaMaterie.StatusMaterie.Finalizat;
        return $"Comanda de materie cu codul {codMaterie} a fost finalizata.";
    }
    
}