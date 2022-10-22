using System;
using System.Text.RegularExpressions;

namespace Algorithm9
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> tabOne = new List<int> { 2, 3, 7, 5, 4};
            List<int> tabTwo = new List<int> { 4, 3, 4, 2, 9};
            List<int> tablica_finish = new List<int>();

            tabOne.Sort();
            tabTwo.Sort();

            int T1_it = 0;
            int T2_it = 0;
            int x = 0;
           do
            {

                if (tabOne[T1_it] >= tabTwo[T2_it])
                {
                    tablica_finish.Add(tabTwo[T2_it]);
                    T2_it++;
                }
                if (T2_it == tabTwo.Count)
                {
                    tablica_finish.Add(tabOne[T1_it]);
                    break;
                }
                if ((tabOne[T1_it] < tabTwo[T2_it]))
                {
                    tablica_finish.Add(tabOne[T1_it]);
                    T1_it++;
                }
                if (T1_it == tabOne.Count)
                {
                    tablica_finish.Add(tabOne[T2_it]);
                    break;
                }
                x++;

            }
            while (x < tabOne.Count + tabTwo.Count);



        foreach (var values in tablica_finish)
            {
                Console.WriteLine(values);
            }
        }

    }
}
