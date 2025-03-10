namespace PZ2;

public class Tom : Ksiazka
{
    public int NumerTomu { get; set; }
    public int LiczbaTomow { get; set; }

    public Tom() { }

    public Tom(string isbn, string tytul, int rokWydania, int liczbaStron, string autor, int numerTomu, int liczbaTomow) : base(isbn, tytul, rokWydania, liczbaStron, autor)
    {
        if (numerTomu > liczbaTomow)
            throw new NiepoprawnyTomException("Numer tomu nie może być większy od liczby wszystkich tomów w serii.");

        NumerTomu = numerTomu;
        LiczbaTomow = liczbaTomow;
    }

    public override string Print() => $"Drukowanie tomu {NumerTomu}/{LiczbaTomow}: {Tytul} - {Autor}";
}
