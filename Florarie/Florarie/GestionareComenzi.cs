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
    
    public string PreiaComandaBuchet(int codComandaBuchet, Angajat angajat)
    {
        if (angajat.comandaCurenta != null)
        {
            return $"Este deja o comanda in lucru cu codul {angajat.comandaCurenta.CodComanda}";
        }
        
        var comanda = ComenziBuchet.FirstOrDefault(Comanda => Comanda.CodComanda == codComandaBuchet);
        if (comanda == null)
        {
            return "Comanda de buchet nu a fost găsită!";
        }

        if (comanda.StatusBuchet != ComandaBuchet.Status.InPreluare)
        {
            return "Comanda nu este disponibila pentru a fi preluata.";
        }
        
        if (comanda.MaterialeDisponibileVerificare())
        {
            comanda.StatusBuchet = ComandaBuchet.Status.InLucru;
            angajat.comandaCurenta = comanda;
            return $"Comanda de buchet cu codul {codComandaBuchet} a fost preluată si este în lucru.";
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

    public string FinalizareComanda(Angajat angajat)
    {
        if (angajat.comandaCurenta == null)
        {
            return "Angajatul nu are nicio comanda in momentul de fata.";
        }

        angajat.comandaCurenta.StatusBuchet = ComandaBuchet.Status.Finalizat;
        int codFinalizat = angajat.comandaCurenta.CodComanda;
        angajat.comandaCurenta = null;
        return $"Comanda cu codul {codFinalizat} a fost finalizata.";
    }

    public string RidicareComanda(int codComandaBuchet)
    {
        var comanda = ComenziBuchet.FirstOrDefault(Comanda => Comanda.CodComanda == codComandaBuchet);
        if (comanda == null)
        {
            return "Comanda nu a fost gasita.";
        }

        if (comanda.StatusBuchet != ComandaBuchet.Status.Finalizat)
        {
            return "Comanda nu a fost finalizata inca.";
        }

        comanda.StatusBuchet = ComandaBuchet.Status.Revendicat;
        return "Comanda a fost revendicata cu succes. Multumim ca ati apelat la noi si va mai asteptam curand!";
    }

    
    
}