using System;

namespace Algorithm2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<(int, int)> moja_lista = new List<(int, int)> { (30, 75), (0, 50), (60, 150) };
            List<(int, int)> check_list = new List<(int, int)>();
            bool result = false;
            moja_lista.Sort();
            int iterator = 0;
            do
            {
                check_list.Add(moja_lista[0]); //  zawsze sprawdzamy dla 1 wartosci w kolekcji
                for (int i = 0; i < moja_lista.Count; i++) // sprawdzamy po wszystkich wartosciach w kolekcji
                {
                    if (!(Enumerable.Range(check_list[0].Item1, check_list[0].Item2 - check_list[0].Item1).Contains(moja_lista[i].Item1))) // jesli wartosc ta nie zwraca prawdy, czyli znaczy to ze nie nalezy do przedzialu to wchodzimy
                    {
                        foreach (var values in check_list)// sprawdzamy tutaj ta wartosc dla kazdego elementu w liscie. czy nie jest przypadkiem tak ze mamy 1 i 2 element ktory sie nie nachodzi, sprawdzamy trzeci
                            // a tam jest tak ze 3 z 1 sie nie nachodzi ale z drugim sie juz nachodzi
                        {
                            if (Enumerable.Range(values.Item1, values.Item2 - values.Item1).Contains(moja_lista[i].Item1)) // jesli sie nachodza to usuwamy ta petle
                            {
                                result = true;
                                break;
                            }
                        }
                        if (result == false) check_list.Add(moja_lista[i]); // resultat jest false, poniewaz znaczy to ze nie wykonal sie poprzedni if, czyli nie nachodza siee
                    }
                    result = false; // ustawiamy resultat false w razie jakby if wszedl i resultat bylby true
                }
                for (int i = 0; i < check_list.Count; i++) //  usuwamy wszystkie elementy dodanie do drugiej listy, ktore znajduja sie w pierwszej liscie
                {
                    moja_lista.RemoveAll(liczba => liczba == check_list[i]);
                }
                iterator++; // nabijamy iterator.
            }
            while (moja_lista.Any()); //  robimy to dopoki na liscie bedzie jakikolwiek element
            Console.WriteLine(iterator);
        }
    }
}
