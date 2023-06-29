using System;

public enum Plec
{
    Mezczyzna,
    Kobieta
}

public struct Student
{
    public string Nazwisko;
    public int NrAlbumu;
    public float Ocena;
    public Plec Plec;

    public void Wypelnij(string nazwisko, int nrAlbumu, float ocena, Plec plec)
    {
        Nazwisko = nazwisko;
        NrAlbumu = nrAlbumu;
        Ocena = Math.Max(2.0f, Math.Min(5.0f, ocena));
        Plec = plec;
    }

    public static float ObliczSrednia(Student[] grupaStudentow)
    {
        float sumaOcen = 0;
        foreach (Student student in grupaStudentow)
        {
            sumaOcen += student.Ocena;
        }

        return sumaOcen / grupaStudentow.Length;
    }

    public void WyswietlInformacje()
    {
        Console.WriteLine($"Nazwisko: {Nazwisko}, Nr albumu: {NrAlbumu}, Ocena: {Ocena}, Płeć: {Plec}");
    }
}

public class Program
{
    public static void Main()
    {
        Student[] grupaStudentow = new Student[5];
        WypelnijGrupaStudentow(grupaStudentow);
        WyswietlGrupaStudentow(grupaStudentow);

        float srednia = Student.ObliczSrednia(grupaStudentow);
        Console.WriteLine($"Średnia ocen: {srednia}");
    }

    public static void WypelnijGrupaStudentow(Student[] grupaStudentow)
    {
        grupaStudentow[0].Wypelnij("Kowalski", 123456, 4.5f, Plec.Mezczyzna);
        grupaStudentow[1].Wypelnij("Nowak", 234567, 3.8f, Plec.Kobieta);
        grupaStudentow[2].Wypelnij("Wiśniewski", 345678, 5.5f, Plec.Mezczyzna); // Wartość spoza zakresu
        grupaStudentow[3].Wypelnij("Kwiatkowska", 456789, 2.3f, Plec.Kobieta);
        grupaStudentow[4].Wypelnij("Lewandowski", 567890, 4.0f, Plec.Mezczyzna);
    }

    public static void WyswietlGrupaStudentow(Student[] grupaStudentow)
    {
        Console.WriteLine("Grupa studentów:");
        foreach (Student student in grupaStudentow)
        {
            student.WyswietlInformacje();
        }
    }
}