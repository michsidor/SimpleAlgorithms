using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

amespace MyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Queen krolowa = new Queen();
            krolowa.StartPositionX = 2;
            krolowa.StartPositionY = 4;
            Console.WriteLine(krolowa.PieceType);

            foreach(var value in krolowa.AddingSafePosition())
            {
                  Console.WriteLine(value);
            }


            Pon pionek = new Pon();
            pionek.StartPositionX = 2;
            pionek.StartPositionY = 4;
            Console.WriteLine(pionek.PieceType);
            foreach (var value in pionek.AddingSafePosition())
            {
                Console.WriteLine(value);
            }
        }

    }
    
    interface IChessPiece // tutaj deklarujemy tylko to co na pewno uzyjemy w klasach dziedziczacy. Jest to pozycja startowa x, pozycja startowa y 
                          // oraz readonly string ktory zwraca nam nazwe figury
    {
        int StartPositionX { get; set; }
        int StartPositionY { get; set; }
        string PieceType
        {
            get { return string.Empty; }
        }

    }

    abstract class ChessBoardCounts // korzystamy z klasy abstrakcyjnej, poniewaz wtedy mozemy dziedziczyc z dwoch rzeczy w klasach ponizszych. Na dodatek Chce pocwiczyc override metod.
    {
        public static int ChessboardSize = 8; // statyczna bo nigdy nam sie nie zmieni rozmiar szachownicy
        public List<(int, int)> SafePositions = new List<(int, int)>(); // zwykla deklaracja listy, nie moglem jako properties bo wywalal blad
        // properties w klasach abstrakcyjnych deklarujemy tak samo jak w innycyh -- NOTATKA, NIE WYKORZYSTUJE TEGO W PROGRAMIE
        public int BFactor(int sPositionX, int sPositionY)// obliczenie wspolczynnika b jako metoda ktora zwraca ten wspolczynnik
        {
            return sPositionX - sPositionY;
        }

        public int SummaryPosition(int sPositionX, int sPositionY)// obliczenie sumy pozycji, jako metoda ktora zwraca ta sume
        {
            return sPositionX + sPositionY;
        }

        public abstract List<(int, int)> AddingSafePosition(); // deklaracja klasy abstrakcyjnej, ktora deklarujemy ze bedziemy overridowac i uzywac.

    }

    class Queen : ChessBoardCounts, IChessPiece
    {
        private int _startPositionX;
        private int _startPositionY;

        public int StartPositionX { get { return _startPositionX; } set { _startPositionX = value; } }
        public int StartPositionY { get { return _startPositionY; } set { _startPositionY = value; } }

        public string PieceType
        {
            get { return "Queen"; }
        }

        public override List<(int, int)> AddingSafePosition()
        {
            {
                for (int i = 0; i < ChessboardSize; i++)
                {
                    for (int j = 0; j < ChessboardSize; j++)
                    {
                        if (i + j == SummaryPosition(_startPositionX, _startPositionY) || i - j == BFactor(_startPositionX
                            , _startPositionY) || i == _startPositionX || j == _startPositionY) continue;
                        else SafePositions.Add((i, j));
                    }
                }
                return SafePositions;
            }
        }

    }

    class Pon : ChessBoardCounts, IChessPiece // najpierw ustalamy dziedziczenie po klasach, a dopiero potem po interfejsach
    {
        private int _startPositionX;
        private int _startPositionY;

        public int StartPositionX { get { return _startPositionX; } set { _startPositionX = value; } }
        public int StartPositionY { get { return _startPositionY; } set { _startPositionY = value; } }

        public string PieceType
        {
            get { return "Pon"; }
        }

        public override List<(int, int)> AddingSafePosition()
        {
            {
                for (int i = 0; i < ChessboardSize; i++)
                {
                    for (int j = 0; j < ChessboardSize; j++)
                    {
                        if ((i+1 == _startPositionX) && ((j - 1 == _startPositionY) || (j + 1 == _startPositionY))) SafePositions.Add((i, j));
                        else continue;
                    }
                }
                return SafePositions;
            }
        }
    }
}

//MOJ TOK ROZUMOWANIE W TYM PROGRAMIE
//tworze interfejs dla pionkow, ktory ma jedynie pobierac poczatekX, poczatekY oraz zwracac string z nazwa figury. Wedle SOLID klasa ma robic tylko to do czego jest przeznaczona,
//wiec ten interfejs wlasnie do tego sluzy. Tylko do ustalenia rzeczy z pionkami. Druga klasa abstarkcyjna to jest tak od robienia planszy. Robie ja abstrakcyjna, bo nie chce
// zeby ktokolwiek z niej korzystal z samej w sobie. Ona ma nam tylko zebrac wszystkie metody w calosc. Deklaruje static int, bo rozmiar szachownicy sie nie zmieni oraz tuple liste
// ktora bedzie nam zbierac pozycje bezpiecznie. Rerdklaruje rowniez metody, ktore z argumentami policza nam wspolczynnik b oraz sume pozycji. Deklaruje rowniez abstakcyjna metode,
// z ktorej nie chce zeby ktos korzystal, a sluzy nam jedynie do overridow, bo w kazdej figurze bedzie ona inaczej wygladac. No i potem dla kazdej figury wywoluje wszystko po kolei.
// Wiem ze moglbym uzyc konstruktorow, ale juz mi sie nie chce tego robic. Pozdro600 na rejonie dla kazdego kto to czyta.
}
