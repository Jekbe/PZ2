namespace PZ2;

public class Ksiazka : Dokument
{
    public string? Autor { get; set; }

    public Ksiazka() { }

    public Ksiazka(string? isbn, string? tytul, int rokWydania, int liczbaStron, string? autor) : base(isbn, tytul, rokWydania, liczbaStron)
    {
        if (rokWydania < 1440)
            throw new WczesnaKsiazkaException("Rok wydania książki nie może być wcześniejszy niż wynalezienie druku (1440).");

        Autor = autor;
    }

    public override string Print() => $"Drukowanie książki: {Tytul} - {Autor}";
}