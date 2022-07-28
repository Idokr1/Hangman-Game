using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman_Exercise
{
    public class Manager
    {
        private string _word;
        private int _countMistakes;
        private int _correctGuesses;
        private char _c1, _c2, _c3;
        private int _possibleMistakes10 = 10, _possibleMistakes8 = 8;
        private bool _isEasy = false, _isHard = false;

        public void NewGame()
        {
            _word = Wordsbank.RandomWord();
            _c1 = _word[0]; _c2 = _word[1]; _c3 = _word[2];
        }

        public bool GameOver()
        {
            if(_isEasy == true)
                if(_countMistakes == _possibleMistakes10)
                {
                    _countMistakes = 0;
                    return true;
                }
            if (_isHard == true)
                if (_countMistakes == _possibleMistakes8)
                {
                    _countMistakes = 0;
                    return true;
                }

            return false;                
        }
        public bool isWinner()
        {
            if (_correctGuesses == 3)
                return true;
            return false;
        }

        public string Word
        { get { return _word; } }
        public int CountMistakes { get { return _countMistakes; } set { _countMistakes = value; } }

        public int PossibleMistakes10 { get { return _possibleMistakes10; } }
        public int PossibleMistakes8 { get { return _possibleMistakes8; } }

        public int CorrectGuesses
        { get { return _correctGuesses; } set { _correctGuesses = value; } }
        public char C1
        { get { return _c1; } set { _c1 = value; } }
        public char C2
        { get { return _c2; } set { _c2 = value; } }
        public char C3
        { get { return _c3; } set { _c3 = value; } }

        public bool IsEasy { get { return _isEasy; } set { _isEasy = value; } }
        public bool IsHard { get { return _isHard; } set { _isHard = value; } }


    }
}
