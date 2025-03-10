namespace PZ2;

public class Biblioteka
{
    private readonly List<Dokument?> _dokumenty = [];

    public void DodajDokument(Dokument? dokument)
    {
        if (_dokumenty.Any(d => d!.ISBN == dokument!.ISBN))
            throw new DuplikatIsbnException($"Dokument z ISBN {dokument!.ISBN} już istnieje.");

        _dokumenty.Add(dokument);
    }

    public Dokument? PobierzDokument(string isbn)
    {
        return _dokumenty.FirstOrDefault(d => d!.ISBN == isbn);
    }

    public List<Dokument?> SzukajWTytule(string fraza)
    {
        return _dokumenty.Where(d => d!.Tytul.Contains(fraza, StringComparison.OrdinalIgnoreCase)).ToList();
    }

    public List<Czasopismo> PobierzCzasopisma(Czestotliwosc czestotliwosc)
    {
        return _dokumenty.OfType<Czasopismo>().Where(c => c.CzestotliwoscWydania == czestotliwosc).ToList();
    }
}