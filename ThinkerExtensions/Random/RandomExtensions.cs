using System;
using ThinkerExtensions.Text;

namespace ThinkerExtensions.Random
{
    /// <summary>
    /// Provides extension methods to the <see cref="Random"/> class
    /// </summary>
    public static class RandomExtensions
    {
        private const string ALL_ASCII_CHARS = " !\"#$%&'()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[\\]^_`abcdefghijklmnopqrstuvwxyz{|}~";

        private const string LOWERCASE_LETTERS = "abcdefghijklmnopqrstuvwxyz";

        private const string DIGITS = "0123456789";

        private static char RandomCharInString(this System.Random r, string input)
            => input[r.Next(0, input.Length)];
        
        /// <summary>
        /// Give a random True/False output with equal probability for both
        /// </summary>
        /// <param name="random"><see cref="Random"/> to generate with</param>
        /// <returns>True or False with equal probability for any of them</returns>
        public static bool CoinToss(this System.Random random)
        {
            return random.NextDouble() < 0.5;
        }

        /// <summary>
        /// Give a weighted random True/False output based on the specified probability
        /// </summary>
        /// <param name="random"><see cref="Random"/> to genereate with</param>
        /// <param name="probability">Value between between 0 and 1</param>
        /// <returns></returns>
        public static bool NextBool(this System.Random random, double probability)
        {
            if (probability >= 0 && probability <= 1)
            {
                return random.NextDouble() < probability;
            }
            throw new ArgumentOutOfRangeException(nameof(probability),$"{nameof(probability)} must be in range 0-1.");
        }

        /// <summary>
        /// Get a random ASCII character
        /// </summary>
        /// <param name="random"><see cref="Random"/> to generate with</param>
        /// <returns>Random ASCII character</returns>
        public static char NextAsciiChar(this System.Random random)
        {
            return random.RandomCharInString(ALL_ASCII_CHARS);
        }

        /// <summary>
        /// Get a random digit (0-9)
        /// </summary>
        /// <param name="random"></param>
        /// <returns>Random arabic digit</returns>
        public static char NextDigit(this System.Random random)
        {
            return random.RandomCharInString(DIGITS);
        }

        /// <summary>
        /// Get a lowercase letter
        /// </summary>
        /// <param name="random"></param>
        /// <returns>Lowercase latin letter</returns>
        public static char NextLowercaseLetter(this System.Random random)
        {
            return random.RandomCharInString(LOWERCASE_LETTERS);
        }

        /// <summary>
        /// Get an uppercase letter
        /// </summary>
        /// <param name="random"></param>
        /// <returns>Uppercase latin letter</returns>
        public static char NextUppercaseLetter(this System.Random random)
        {
            return random.RandomCharInString(LOWERCASE_LETTERS).ToUpper();
        }

        /// <summary>
        /// Get any letter (uppercase or lowercase)
        /// </summary>
        /// <param name="random"></param>
        /// <returns>Random letter</returns>
        public static char NextLetter(this System.Random random)
        {
            switch (random.CoinToss())
            {
                case true:
                    return random.NextLowercaseLetter();
                case false:
                    return random.NextUppercaseLetter();
            }
            throw new Exception("Unexpectedly fell out of switch statement on boolean value.");
        }
    }
}
