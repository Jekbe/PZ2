namespace PZ2;

public enum Czestotliwosc { Dziennik, Tygodnik, Miesiecznik, Rocznik }

public class Czasopismo : Dokument
{
    public int Numer { get; set; }
    public Czestotliwosc CzestotliwoscWydania { get; set; }

    public Czasopismo() { }

    public Czasopismo(string? isbn, string? tytul, int rokWydania, int liczbaStron, int numer, Czestotliwosc czestotliwosc) : base(isbn, tytul, rokWydania, liczbaStron)
    {
        Numer = numer;
        CzestotliwoscWydania = czestotliwosc;
    }

    public override string Print() => $"Drukowanie czasopisma: {Tytul}, nr {Numer}, {CzestotliwoscWydania}";
}