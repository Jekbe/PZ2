namespace PZ2;

public abstract class Dokument
{
    public string? Isbn { get; set; }
    public string? Tytul { get; set; }
    public int RokWydania { get; set; }
    public int LiczbaStron { get; set; }

    protected Dokument() { }

    protected Dokument(string? isbn, string? tytul, int rokWydania, int liczbaStron)
    {
        Isbn = isbn;
        Tytul = tytul;
        RokWydania = rokWydania;
        LiczbaStron = liczbaStron;
    }

    public abstract string Print();

    public override string ToString()
    {
        return $"{Isbn}, {Tytul}, {RokWydania}, {LiczbaStron}";
    }

    public override bool Equals(object? obj)
    {
        if (obj is Dokument dokument)
            return ToString() == dokument.ToString();
        return false;
    }

    public override int GetHashCode() => ToString().GetHashCode();

    public static bool operator ==(Dokument d1, Dokument d2) => d1.Equals(d2);
    public static bool operator !=(Dokument d1, Dokument d2) => !d1.Equals(d2);
}