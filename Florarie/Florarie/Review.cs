namespace Florarie;

public class Review
{
    public int SteleReview { get; set; }
    public int CodComanda { get; set; }
    public string Nume { get; set; }

    public Review(int steleReview, int codComanda, string nume)
    {
        SteleReview = steleReview;
        CodComanda = codComanda;
        Nume = nume;
    }

    public override string ToString()
    {
        return $"Comanda cu codul {CodComanda} a utilizatorului {Nume} a primit {SteleReview} stele.";
    }
}