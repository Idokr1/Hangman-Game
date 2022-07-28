using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman_Exercise
{
    public static class Wordsbank
    {
        private static string[] _wordsBank = {
            "axe", "pen", "rip", "jam", "van", "war", "pet", "sit", "god", "hat", "net", "pig", "cat", "dog", "fat", "fan", "bar", "aid", "gun"};

        public static string RandomWord()
        {
            Random random = new Random();
            return _wordsBank[random.Next(_wordsBank.Length)];
        }
    }
}
