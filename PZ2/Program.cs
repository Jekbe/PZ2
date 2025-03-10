namespace PZ2
{
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
                Console.WriteLine("4. Wyświetl czasopisma o danej częstotliwości");
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
                            DodajKsiazke(biblioteka);
                            break;
                        case 2:
                            WyszukajDokumentPoIsbn(biblioteka);
                            break;
                        case 3:
                            WyszukajDokumentyPoTytule(biblioteka);
                            break;
                        case 4:
                            PobierzCzasopisma(biblioteka);
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

        private static void DodajKsiazke(Biblioteka zarzadzanie)
        {
            try
            {
                Console.Write("Podaj ISBN: ");
                var isbn = Console.ReadLine();
                Console.Write("Podaj tytuł: ");
                var tytul = Console.ReadLine();
                Console.Write("Podaj rok wydania: ");
                var rokWydania = int.Parse(Console.ReadLine()!);
                Console.Write("Podaj liczbę stron: ");
                var liczbaStron = int.Parse(Console.ReadLine()!);
                Console.Write("Podaj autora: ");
                var autor = Console.ReadLine();

                var ksiazka = new Ksiazka(isbn!, tytul!, rokWydania, liczbaStron, autor!);
                zarzadzanie.DodajDokument(ksiazka);
                Console.WriteLine("Dodano książkę!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Błąd: {ex.Message}");
            }
        }

        private static void WyszukajDokumentPoIsbn(Biblioteka zarzadzanie)
        {
            Console.Write("Podaj ISBN: ");
            var isbn = Console.ReadLine();
            var doc = zarzadzanie.PobierzDokument(isbn!);
            Console.WriteLine(doc != null! ? doc.ToString() : "Nie znaleziono dokumentu.");
        }

        private static void WyszukajDokumentyPoTytule(Biblioteka zarzadzanie)
        {
            Console.Write("Podaj frazę w tytule: ");
            var fraza = Console.ReadLine();
            var dokumenty = zarzadzanie.SzukajWTytule(fraza!);
            
            if (dokumenty.Count > 0)
            {
                Console.WriteLine("Znalezione dokumenty:");
                dokumenty.ForEach(Console.WriteLine);
            }
            else
            {
                Console.WriteLine("Brak wyników.");
            }
        }

        private static void PobierzCzasopisma(Biblioteka zarzadzanie)
        {
            Console.WriteLine("Dostępne częstotliwości: 0 - Dziennik, 1 - Tygodnik, 2 - Miesięcznik, 3 - Rocznik");
            Console.Write("Podaj numer częstotliwości: ");
            
            if (Enum.TryParse(Console.ReadLine(), out Czestotliwosc czestotliwosc))
            {
                var czasopisma = zarzadzanie.PobierzCzasopisma(czestotliwosc);
                
                if (czasopisma.Count > 0)
                {
                    Console.WriteLine("Znalezione czasopisma:");
                    czasopisma.ForEach(Console.WriteLine);
                }
                else
                {
                    Console.WriteLine("Brak wyników.");
                }
            }
            else
            {
                Console.WriteLine("Niepoprawny wybór.");
            }
        }
    }
}