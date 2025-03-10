namespace PZ2;

public class Biblioteka
{
    private readonly List<Dokument?> _dokumenty = [];

    public void DodajDokument(Dokument? dokument)
    {
        if (_dokumenty.Any(d => d!.Isbn == dokument!.Isbn)) throw new DuplikatIsbnException($"Dokument z ISBN {dokument!.Isbn} już istnieje.");
        if (dokument!.RokWydania < 1438) throw new WczesnaKsiazkaException("druk wynaleziono dopiero w 1438!");
        if (dokument is Tom tom) 
            if (tom.NumerTomu > tom.LiczbaTomow) throw new NiepoprawnyTomException($"numer tomu nie może być większy niż liczba tomów ({tom.LiczbaTomow})");

        _dokumenty.Add(dokument);
    }

    public Dokument? PobierzDokument(string isbn)
    {
        return _dokumenty.FirstOrDefault(d => d!.Isbn == isbn);
    }

    public List<Dokument?> SzukajWTytule(string fraza)
    {
        return _dokumenty.Where(d => d!.Tytul!.Contains(fraza, StringComparison.OrdinalIgnoreCase)).ToList();
    }

    public List<Dokument?> WszystkieDokumenty()
    {
        return _dokumenty;
    }
}