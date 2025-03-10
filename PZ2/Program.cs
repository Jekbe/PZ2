namespace PZ2;

internal static class Program
{
    private static void Main()
    {
        var biblioteka = new Biblioteka();
        var go = true;

        while (go)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Dodaj książkę");
            Console.WriteLine("2. Wyszukaj dokument po ISBN");
            Console.WriteLine("3. Wyszukaj dokumenty po tytule");
            Console.WriteLine("4. Wyświetl wszystkie dokumenty");
            Console.WriteLine("0. Wyjście");
            Console.Write("Wybierz opcję: ");

            if (int.TryParse(Console.ReadLine(), out var wybor))
            {
                switch (wybor)
                {
                    case 0:
                        go = false;
                        break;
                    case 1:
                        DodajDokument(biblioteka);
                        break;
                    case 2:
                        WyszukajDokumentPoIsbn(biblioteka);
                        break;
                    case 3:
                        WyszukajDokumentyPoTytule(biblioteka);
                        break;
                    case 4:
                        WszystkieDokumenty(biblioteka);
                        break;
                    default:
                        Console.WriteLine("Nieznane polecenie!");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Niepoprawny wybór, spróbuj ponownie.");
            }
        }
    }

    private static void DodajDokument(Biblioteka biblioteka)
    {
        try
        {
            Console.Write("Podaj rodzaj dokumentu (1 - książka, 2 - tom, 3 - czasopismo): ");
            var wybor = int.Parse(Console.ReadLine()!);
            
            Console.Write("Podaj ISBN: ");
            var isbn = Console.ReadLine();
            Console.Write("Podaj tytuł: ");
            var tytul = Console.ReadLine();
            Console.Write("Podaj rok wydania: ");
            var rokWydania = int.Parse(Console.ReadLine()!);
            Console.Write("Podaj liczbę stron: ");
            var liczbaStron = int.Parse(Console.ReadLine()!);

            Dokument dokument;
            switch (wybor)
            {
                case 1:
                    Console.Write("Podaj autora: "); 
                    var autor = Console.ReadLine();
                    dokument = new Ksiazka(isbn!, tytul!, rokWydania, liczbaStron, autor!);
                    break;
                case 2:
                    Console.Write("Podaj autora: "); 
                    autor = Console.ReadLine();
                    Console.Write("Podaj numer tomu: ");
                    var numerTomu = int.Parse(Console.ReadLine()!);
                    Console.Write("Podaj ile jest tomów w serii: ");
                    var liczbaTomow = int.Parse(Console.ReadLine()!);
                    dokument = new Tom(isbn, tytul, rokWydania, liczbaStron, autor, numerTomu, liczbaTomow);
                    break;
                case 3:
                    Console.Write("Podaj numer: ");
                    var numer = int.Parse(Console.ReadLine()!);
                    Console.Write("Podaj częstotliwość (1 - dziennik, 2 - tygodnik, 3 - miesięcznik, 4 - rocznik): ");
                    var wybor2 = int.Parse(Console.ReadLine()!);
                    var czestotliwosc = wybor2 switch
                    {
                        1 => Czestotliwosc.Dziennik,
                        2 => Czestotliwosc.Tygodnik,
                        3 => Czestotliwosc.Miesiecznik,
                        4 => Czestotliwosc.Rocznik,
                        _ => throw new NullReferenceException("Nie wybrano poprawnego roku!")
                    };

                    dokument = new Czasopismo(isbn, tytul, rokWydania, liczbaStron, numer, czestotliwosc);
                    break;
                default:
                    throw new NullReferenceException("Nie udało się utworzyć dokumentu!");
            }

            biblioteka.DodajDokument(dokument);
            Console.WriteLine("Dodano książkę!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Błąd: {ex.Message}");
        }
    }

    private static void WyszukajDokumentPoIsbn(Biblioteka biblioteka)
    {
        Console.Write("Podaj ISBN: ");
        var isbn = Console.ReadLine();
        var doc = biblioteka.PobierzDokument(isbn!);
        Console.WriteLine(doc! != null! ? doc.ToString() : "Nie znaleziono dokumentu.");
    }

    private static void WyszukajDokumentyPoTytule(Biblioteka biblioteka)
    {
        Console.Write("Podaj frazę w tytule: ");
        var fraza = Console.ReadLine();
        var dokumenty = biblioteka.SzukajWTytule(fraza!);
            
        if (dokumenty.Count > 0)
        {
            Console.WriteLine("Znalezione dokumenty:");
            dokumenty.ForEach(Console.WriteLine);
        }
        else Console.WriteLine("Brak wyników.");
    }

    private static void WszystkieDokumenty(Biblioteka biblioteka)
    {
        var dokumenty = biblioteka.WszystkieDokumenty();
        if (dokumenty.Count > 0) dokumenty.ForEach(Console.WriteLine);
        else Console.WriteLine("Brak wyników.");
    }
}