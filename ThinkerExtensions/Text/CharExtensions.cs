namespace ThinkerExtensions.Text
{
    /// <summary>
    /// Provides extension methods for <see cref="char"/>
    /// </summary>
    public static class CharExtensions
    {
        /// <summary>
        /// Converts the character to its uppercase form
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Uppercase character</returns>
        public static char ToUpper(this char value)
        {
            return char.ToUpper(value);
        }

        /// <summary>
        /// Converts the character to its lowercase form
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Lowercase character</returns>
        public static char ToLower(this char value)
        {
            return char.ToLower(value);
        }
    }
}
