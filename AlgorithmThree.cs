using System;
using System.Linq;
public class AlgorithmFive
{
    List<string> _anagrams = new List<string>();

    public List<string> Anagrams
    {
        get { 
            return _anagrams;
        }

        set {
            _anagrams = value;
        }
    }

    public List<string> Segregation() // method used to sort anagrams
    {
        List<string> anagramse_sorted = new List<string>();

        anagramse_sorted.Add(","); // adding a comma to segregate group of anagrams.
        do
        {
            for (int j = 0; j < _anagrams.Count; j++) // adding anagrams to sorted list.
            {
                if (String.Concat(_anagrams[0].OrderBy(ch => ch)).SequenceEqual(String.Concat(_anagrams[j].OrderBy(ch => ch))))
                {
                    anagramse_sorted.Add(_anagrams[j]);
                }
            }
            anagramse_sorted.Add(","); // adding a comma to segregate group of anagrams

            foreach(var values in anagramse_sorted) // removing sorted anagrams from list to computer memory relase
            {
               _anagrams.RemoveAll(item => item.Contains(values));
            }
        }

        while (_anagrams.Any());

        return anagramse_sorted;
    }

    public string[][] AddingToJagged()
    {
        List<string> sorted_anagrams = new List<string>();
        List<int> index_of_comma = new List<int>();

        sorted_anagrams = Segregation();
        int number_of_commas = 0;
        int jagged_counter = 0; // counter for indexes of first column in jagged array 

        for(int i = 0; i < sorted_anagrams.Count; i++)
        {
            if (sorted_anagrams[i] == ",")
            {
                number_of_commas++;
                index_of_comma.Add(i);
            }
        }

        string[][] jaggedArray = new string[number_of_commas - 1][]; 
        for (int i = 0; i < number_of_commas - 1; i++) 
        {
            jaggedArray[i] = new string[index_of_comma[i+1] - index_of_comma[i] - 1];
            for(int j = index_of_comma[i] + 1; j < index_of_comma[i+1]; j++)
            {
                jaggedArray[i][jagged_counter] = sorted_anagrams[j];
                jagged_counter++;
            }
            jagged_counter = 0;
        }

        sorted_anagrams.Clear();
        index_of_comma.Clear();
        return jaggedArray;

    }


}

namespace TutorialOne
{
    class Program
    {
        static void Main(string[] args)
        {
            string[][] jaggedExercise;
            List<string> anagrams_list = new List<string>();

            string word_insert;
            int itterator = 1; // do while loop iterator
            do
            {
                Console.WriteLine("Insert your words");
                word_insert = Console.ReadLine();
                anagrams_list.Add(word_insert);
                itterator++;
            }
            while (word_insert != "f");
            anagrams_list.RemoveAt(anagrams_list.Count - 1);

            anagrams_list.ForEach(values => Console.Write($"Your inputed words: {values} \n "));

            // Executing AlgorithFive class methods.
            AlgorithmFive exercise = new AlgorithmFive();
            exercise.Anagrams = anagrams_list;
            jaggedExercise = exercise.AddingToJagged();
            for (int i = 0; i < jaggedExercise.Length; i++)
            {
                for (int j = 0; j < jaggedExercise[i].Length; j++)
                {
                    Console.WriteLine(jaggedExercise[i][j]);
                }
            }
        }

    }
}
