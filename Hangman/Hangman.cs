using System;
using System.Linq;

namespace Hangman
{
    /// <summary>
    /// Hangman Base Class
    /// </summary>
    public class Hangman
    {
        /// <summary>
        /// Delimiter for the Guessed Word
        /// </summary>
        private const char hyphen = '-';

        /// <summary>
        /// Word which should be guessed
        /// </summary>
        private readonly string word;

        /// <summary>
        /// Result which was already guessed
        /// </summary>
        private readonly char[] result;

        /// <summary>
        /// Initializes a new instance of the <see cref="Hangman"/> class.
        /// </summary>
        /// <param name="word"></param>
        public Hangman(string word)
        {
            if (word.Contains(hyphen))
            {
                throw new ArgumentException($"Word must not contain hyphen '{hyphen}'");
            }

            this.word = word;
            this.result = new string(hyphen, this.word.Length).ToCharArray();
        }

        /// <summary>
        /// Guesses a new Character
        /// </summary>
        /// <param name="ch">Character which will be guessed</param>
        /// <returns>Result after the Character was validated against the unknown word</returns>
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

        /// <summary>
        /// Gets the Result
        /// </summary>
        public string Result => new string(this.result);

        /// <summary>
        /// Indicates if the word has been guessed
        /// </summary>
        public bool Guessed => !this.result.Contains(hyphen);
    }
}