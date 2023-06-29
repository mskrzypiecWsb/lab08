using System;

public enum KlasaRzadkosci
{
    Powszechny,
    Rzadki,
    Unikalny,
    Epicki
}

public enum TypPrzedmiotu
{
    Bron,
    Zbroja,
    Amulet,
    Pierscien,
    Helm,
    Tarcza,
    Buty
}

public struct Przedmiot
{
    public float Waga;
    public int Wartosc;
    public KlasaRzadkosci Rzadkosc;
    public TypPrzedmiotu Typ;
    public string NazwaWlasna;

    public Przedmiot(float waga, int wartosc, KlasaRzadkosci rzadkosc, TypPrzedmiotu typ, string nazwaWlasna)
    {
        Waga = waga;
        Wartosc = wartosc;
        Rzadkosc = rzadkosc;
        Typ = typ;
        NazwaWlasna = nazwaWlasna;
    }

    public void WyswietlInformacje()
    {
        Console.WriteLine($"Nazwa: {NazwaWlasna}");
        Console.WriteLine($"Typ: {Typ}");
        Console.WriteLine($"Rzadkosc: {Rzadkosc}");
        Console.WriteLine($"Waga: {Waga}");
        Console.WriteLine($"Wartosc: {Wartosc} sztuk złota");
        Console.WriteLine();
    }
}

public class Program
{
    public static void Main()
    {
        Przedmiot[] skrzynia = new Przedmiot[5];
        WypelnijSkrzynie(skrzynia);
        WyswietlPrzedmiotyZSkrzyni(skrzynia);

        Przedmiot wylosowanyPrzedmiot = LosujPrzedmiot(skrzynia);
        Console.WriteLine("Wylosowany przedmiot:");
        wylosowanyPrzedmiot.WyswietlInformacje();
    }

    public static void WypelnijSkrzynie(Przedmiot[] skrzynia)
    {
        skrzynia[0] = new Przedmiot(1.5f, 50, KlasaRzadkosci.Powszechny, TypPrzedmiotu.Bron, "Miecz");
        skrzynia[1] = new Przedmiot(2.0f, 100, KlasaRzadkosci.Rzadki, TypPrzedmiotu.Zbroja, "Zbroja płytowa");
        skrzynia[2] = new Przedmiot(0.5f, 200, KlasaRzadkosci.Unikalny, TypPrzedmiotu.Amulet, "Amulet mądrości");
        skrzynia[3] = new Przedmiot(0.2f, 500, KlasaRzadkosci.Epicki, TypPrzedmiotu.Pierscien, "Pierścień nieśmiertelności");
        skrzynia[4] = new Przedmiot(1.0f, 80, KlasaRzadkosci.Powszechny, TypPrzedmiotu.Helm, "Hełm rycerski");
    }

    public static void WyswietlPrzedmiotyZSkrzyni(Przedmiot[] skrzynia)
    {
        Console.WriteLine("Przedmioty w skrzyni:");
        Console.WriteLine();

        foreach (Przedmiot przedmiot in skrzynia)
        {
            przedmiot.WyswietlInformacje();
        }
    }

    public static Przedmiot LosujPrzedmiot(Przedmiot[] skrzynia)
    {
        Random random = new Random();
        int losowaPozycja = random.Next(0, skrzynia.Length);

        KlasaRzadkosci[] dostepneRzadkosci = { KlasaRzadkosci.Powszechny, KlasaRzadkosci.Rzadki, KlasaRzadkosci.Unikalny, KlasaRzadkosci.Epicki };

        while (true)
        {
            KlasaRzadkosci losowaRzadkosc = dostepneRzadkosci[random.Next(0, dostepneRzadkosci.Length)];

            for (int i = 0; i < skrzynia.Length; i++)
            {
                if (skrzynia[i].Rzadkosc == losowaRzadkosc && i == losowaPozycja)
                {
                    return skrzynia[i];
                }
            }
        }
    }
}