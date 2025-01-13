namespace Florarie;

public class GestionareComenzi
{
    public List<ComandaMaterie> ComenziMaterie { get; set; } = new List<ComandaMaterie>();
    public List<ComandaBuchet> ComenziBuchet { get; set; } = new List<ComandaBuchet>();
    public List<Review> Recenzii { get; set; } = new List<Review>();

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

    public string Review(int codReview, int nrStele, string Client)
    {
        var comanda = ComenziBuchet.FirstOrDefault(Comanda => Comanda.CodComanda == codReview);
        if (comanda == null)
        {
            return "Comanda nu exista.";
        }

        if (comanda.StatusBuchet != ComandaBuchet.Status.Revendicat)
        {
            return "Comanda nu a fost revendicata, deci nu exista.";
        }

        Recenzii.Add(new Review(nrStele, codReview, Client));
        return
            $"Review-ul a fost adaugat cu succes pentru comanda {codReview} a lui {Client}. Numar stele - {nrStele}.";
    }

    public void VizualizareComenziClienti()
    {
        foreach (var comanda in ComenziBuchet)
        {
            if (comanda == null)
            {
                Console.WriteLine("Nu exista nicio comanda!");
                return;
            }

            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("Detalii comanda ");
            Console.WriteLine($"Numar comanda : {comanda.CodComanda}");
            Console.WriteLine($"Numele clientului : {comanda.NumeClient}");
            Console.WriteLine($"Numar de telefon : {comanda.NrTelefon}");
            Console.WriteLine($"Descrierea buchetului : {comanda.DescriereComanda}");
            Console.WriteLine($"Statusul comenzii : {comanda.StatusBuchet}");
            Console.WriteLine("-------------------------------------------");
        }
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
    
    
    public void VizualizareIstoricComenzi(Client client )
    {
        foreach (var comanda in ComenziBuchet)
        {
            if ((client.prenume == comanda.NumeClient) && (comanda.StatusBuchet == ComandaBuchet.Status.Finalizat))
            {
                Console.WriteLine("-------------------------------------------");
                Console.WriteLine("Detalii comanda ");
                Console.WriteLine($"Numar comanda : {comanda.CodComanda}");
                Console.WriteLine($"Numele clientului : {comanda.NumeClient}");
                Console.WriteLine($"Numar de telefon : {comanda.NrTelefon}");
                Console.WriteLine($"Descrierea buchetului : {comanda.DescriereComanda}");
                Console.WriteLine($"Statusul comenzii : {comanda.StatusBuchet}");
                Console.WriteLine("-------------------------------------------");
            }
        }
    }

    public void VizualizareDetaliiComanda(int codComanda)
    {
        foreach (var comanda in ComenziBuchet)
        {
            if (comanda.CodComanda == codComanda)
            {
                Console.WriteLine("-------------------------------------------");
                Console.WriteLine("Detalii comanda ");
                Console.WriteLine($"Numar comanda : {comanda.CodComanda}");
                Console.WriteLine($"Numele clientului : {comanda.NumeClient}");
                Console.WriteLine($"Numar de telefon : {comanda.NrTelefon}");
                Console.WriteLine($"Descrierea buchetului : {comanda.DescriereComanda}");
                Console.WriteLine($"Statusul comenzii : {comanda.StatusBuchet}");
                Console.WriteLine("-------------------------------------------");
            }
        }
    }
}
