using System;

public class AlgorithmSeven { 
    List<int> _numbers = new List<int> ();

    public List<int> Numbers
    {
        get { return _numbers; }
        set { _numbers = value; }
    }

    public List<int> SortingList()
    {
        List<int> resultList = new List<int> ();

        _numbers.Sort();
        _numbers.Reverse();


        bool result = false;

        foreach(int values in _numbers)
        {
            result = values > 0 ? true : false;
        }

        switch (result)
        {
            case true:

                return _numbers;
                break;
            
            case false:

                foreach(var values in _numbers)
                {
                    if (values > 0) resultList.Add(values); 
                }

                if (!resultList.Any())
                {
                    resultList.Add(_numbers.Max());
                }

                return resultList;
                break;
        }
    }

}

namespace TutorialOne
{
    class Program
    {
        static void Main(string[] args)
        {
           List<int> input_numbers = new List<int>() { -3,-1,-2,-4,-10};
           AlgorithmSeven answer = new AlgorithmSeven();
           answer.Numbers = input_numbers;
           foreach(var values in answer.SortingList())
            {
                Console.WriteLine(values);
            }


        }

    }
}
