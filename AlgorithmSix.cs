using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Algorithm8
{
    class Program
    {
        static void Main(string[] args)
        {
            SentenceChecker sentenceChecker = new SentenceChecker();
            sentenceChecker.Sentence = "";
            sentenceChecker.SentenceOrNot();
        }

    }
    
    class SentenceChecker
    {
        private string _sentence;
        public string Sentence { get { return _sentence; } set { _sentence = value; } }

        public bool CheckControlOne() // First letter is capiital, and next is lower case or space
        {
            char white_space = ' ';
            bool white_space_condition = false;

            if(_sentence[1] == white_space)
            {
                white_space_condition = true;
            }

            if (Char.IsUpper(_sentence[0]) && ( Char.IsLower(_sentence[1]) || white_space_condition))
            {
                return true;
            }
            return false;
        }
        public bool CheckControlTwo() // after all words we have a white space
        {
            for(int i =0; i < _sentence.Length; i++)
            {
                if (_sentence[i] == ' ' && _sentence[i+1] == ' ')
                {
                    return false;
                }
            }
            return true;
        }
        public bool CheckControlThree() // words are not a combination of numbers, letters and special mark
        {
            string patern = @"[!?;:0-9]";
            Regex rgx = new Regex(patern);
            string sentence_copy = _sentence.Remove(_sentence.Length - 1);
            int counter = rgx.Matches(sentence_copy).Count;
            bool result = (counter > 0) ? false : true;
            return result;
        }
        public bool CheckControlFour() // Special mark could be only on last index of sentence and it could by: : , ; ? ! . ?? 
        {
            string patern = @"[a - zA - Z!?;:.]";
            Regex rgx = new Regex(patern);
            int counter = rgx.Matches(_sentence[_sentence.Length-1].ToString()).Count;
            bool result = (counter > 0) ? true : false;
            return result;
        }
        public void SentenceOrNot()
        {
            if (CheckControlOne() && CheckControlTwo() && CheckControlThree() && CheckControlFour()) Console.WriteLine("This quote is a santance");
            else Console.WriteLine("This quote is not a santance");
        }
    }
}
