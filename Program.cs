using System;
using System.IO;

class Program
{
    public static void Main(string[] args)
    {
        while(true)
        {
            Console.Clear();
            Console.WriteLine("Witaj. Jakie działanie chcesz podjąc?");
            Console.WriteLine("a) Zapisz do pliku tekstowego ");
            Console.WriteLine("b) Odczytaj z pliku tekstowego ");
            Console.WriteLine("c) Wyjdź ");

            string str_wczyt_odcz = Console.ReadLine();
            Console.Clear();
                
            if(!string.IsNullOrEmpty(str_wczyt_odcz))
            {
                char wczyt_odcz;
                string patch = "C:/Users/Program-W2/Desktop/Bez_tytulu.txt";
                if(char.TryParse(str_wczyt_odcz, out wczyt_odcz))
                {
                    if(wczyt_odcz == 'a' || wczyt_odcz == 'A')
                    {
                        string[] str_indeks = File.ReadAllLines(patch);
                        int indeks = str_indeks.Length+1;

                        Console.WriteLine("Co chcesz zapisać? ");
                        Console.WriteLine("a) Tekst");
                        Console.WriteLine("b) Liczbę");
                            
                        string str_liczba_tekst = Console.ReadLine();

                        if(!string.IsNullOrEmpty(str_liczba_tekst))
                        {
                            char liczba_tekst = char.Parse(str_liczba_tekst);
                            Console.Clear();

                            if(liczba_tekst == 'a' || liczba_tekst == 'A')
                            {
                                string prefiks = "A";

                                DateTime teraz = DateTime.Now;
                                string czas = teraz.ToString();

                                Console.WriteLine("Wpisz tekst do zapisu: ");
                                string tekst = Console.ReadLine();

                                Zapis_tekstu(patch, tekst, czas, prefiks);
                                Console.WriteLine("Zapisano: "+tekst);
                                Console.ReadKey();
                            }

                            else if(liczba_tekst == 'b' || liczba_tekst == 'B')
                            {
                                string prefiks = "B";

                                DateTime teraz = DateTime.Now;
                                string czas = teraz.ToString();

                                Console.WriteLine("Wpisz liczby do zapisu: ");
                                string str_liczba = Console.ReadLine();
                                
                                Zapis_liczby(str_liczba, patch, czas, prefiks);
                                Console.WriteLine("Zapisano liczbę: " +str_liczba);
                                Console.ReadKey();
                            }

                            else
                            {
                                Console.WriteLine("Taka opcja nie istnieje");
                                Console.ReadKey();
                            }
                        }
                    }  

                    else if(wczyt_odcz == 'b' || wczyt_odcz == 'B')
                    {
                        Console.Clear();
                        Console.WriteLine("Co chcesz odczytać?");
                        Console.WriteLine("a) Tekst");
                        Console.WriteLine("b) Liczbę");
                        Console.WriteLine("c) Wszystko");
                        Console.WriteLine("d) Indeks");

                        string str_odczyt_co = Console.ReadLine();

                        if(!string.IsNullOrEmpty(str_odczyt_co))
                        {
                            char odczyt_co = char.Parse(str_odczyt_co);

                            if(odczyt_co == 'a' || odczyt_co == 'A')
                            {
                                Console.Clear();
                                string prefiks = "A";
                                Odczyt_tekst(patch, prefiks);
                                Console.WriteLine("--");
                                Console.WriteLine("Naciśnij dowolny klawisz aby kontynuować...");
                                Console.ReadKey();
                            }
                            else if(odczyt_co == 'b' || odczyt_co == 'B')
                            {
                                Console.Clear();
                                string prefiks = "B";
                                Odczyt_tekst(patch, prefiks);
                                Console.WriteLine("--");
                                Console.WriteLine("Naciśnij dowolny klawisz aby kontynuować...");
                                Console.ReadKey();
                            }
                            else if(odczyt_co == 'c' || odczyt_co == 'C')
                            {
                                Console.Clear();
                                Odczyt_wszystko(patch);
                                Console.WriteLine("--");
                                Console.WriteLine("Naciśnij dowolny klawisz aby kontynuować...");
                                Console.ReadKey();
                            }
                            else if(odczyt_co == 'd' || odczyt_co == 'D')
                            {
                                Console.Clear();
                                Console.WriteLine("Podaj prefiks, np. A, B, C: ");
                                string prefiks = Console.ReadLine();
                                if(!string.IsNullOrEmpty(prefiks))
                                {
                                    Console.Clear();
                                    Odczyt_tekst(patch, prefiks);
                                    Console.WriteLine("--");
                                    Console.WriteLine("Naciśnij dowolny klawisz aby kontynuować...");
                                    Console.ReadKey();
                                }

                                else
                                {
                                    Console.WriteLine("Hola.. nie podałeś prefiksu!");
                                    Console.ReadKey();
                                }
                            }

                            else
                            {
                                Console.WriteLine("Nie ma takiej opcji!");
                                Console.ReadKey();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Opcja nie może być null or empty!");
                            Console.ReadKey();
                        }
                    }

                    else if(wczyt_odcz == 'c' || wczyt_odcz == 'C')
                    {
                        Console.WriteLine("Nacisnij dowolny klawisz aby wyjść...");
                        Console.ReadKey();
                        break;
                    }

                    else
                    {
                        Console.WriteLine("Taka opcja nie istnieje");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.WriteLine("Wybor nie może byc null or empty");
                    Console.ReadKey();
                }
            }
        }
    }

    public static void Zapis_tekstu(string patch, string tekst, string czas, string prefiks)
    {
        string[] str_indeks = File.ReadAllLines(patch);
        int indeks = str_indeks.Length+1;

        using (StreamWriter zapis_tekstu = new StreamWriter(patch, true))
            zapis_tekstu.WriteLine(indeks+ ". [" +prefiks+ "] " +tekst+ " | zapisany o: " +czas);
    }

    public static void Zapis_liczby(string str_liczba, string patch, string czas, string prefiks)
    {
        if(!string.IsNullOrEmpty(str_liczba))
        {
            if(int.TryParse(str_liczba, out int liczba))
            {
                string[] str_indeks = File.ReadAllLines(patch);
                int indeks = str_indeks.Length+1;

                using (StreamWriter zapis_liczby = new StreamWriter(patch, true))
                    zapis_liczby.WriteLine(indeks+ ". [" +prefiks+ "] " +liczba+ " | zapisana o: " +czas);
            }

            else
            {
                Console.WriteLine("Błąd Parse");
                Console.ReadKey();
            }
        }
        
        else
        {
            Console.WriteLine("Wybór nie może byc null or empty!");
            Console.ReadKey();
        }
    }

    public static void Odczyt_tekst(string patch, string prefiks)
    {
        if(File.Exists(patch))
        {
            using (StreamReader odczyt = new StreamReader(patch))
            {
                string wiersze;

                while((wiersze = odczyt.ReadLine()) != null)
                {
                    if(wiersze.Contains(prefiks))
                        Console.WriteLine(wiersze);
                }
            }
        }

        else
        {
            Console.WriteLine("Błąd: Pliku nie ma! :<");
            Console.ReadKey();
        }
    }

    public static void Odczyt_wszystko(string patch)
    {
        if(File.Exists(patch))
        {
            using (StreamReader odczyt = new StreamReader(patch))
            {
                string wiersze;

                while((wiersze = odczyt.ReadLine()) != null)
                    Console.WriteLine(wiersze);
            }
        }
    }
}