using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Hangman
{
    public class Hangman
    {
        private const char hyphen = '-';

        private readonly string word;
        private readonly char[] result;

        public Hangman(string word)
        {
            if (word.Contains(hyphen))
            {
                throw new ArgumentException($"Word must not contain hyphen '{hyphen}'");
            }

            this.word = word;
            this.result = new string(hyphen, this.word.Length).ToCharArray();
        }

        public string Guess(char ch)
        {
            for (int i = 0; i < this.word.Length; i++)
            {
                if (char.ToLower(this.word[i]) == char.ToLower(ch))
                {
                    this.result[i] = word[i];
                }
            }

            return new string(this.result);
        }

        public string Result => new string(this.result);

        public bool Guessed => !this.result.Contains(hyphen);
    }
}
