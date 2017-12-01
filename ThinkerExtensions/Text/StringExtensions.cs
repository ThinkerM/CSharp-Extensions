using System;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace ThinkerExtensions.Text
{
    /// <summary>
    /// Provides extension methods for <see cref="string"/>
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Indicates whether the specified string is null or an <see cref="string.Empty"/> string
        /// </summary>
        /// <param name="value">String to check</param>
        /// <returns>True if null or <see cref="string.Empty"/>, False otherwise</returns>
        public static bool IsNullOrEmpty(this string value)
        {
            return string.IsNullOrEmpty(value);
        }

        /// <summary>
        /// Indicates whether the specified string is null, empty, or consists only of white-space characters
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsNullOrWhiteSpace(this string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }

        /// <summary>
        /// Change the input's first letter to upper-case
        /// </summary>
        /// <param name="input"></param>
        /// <returns>Capitalized input</returns>
        public static string Capitalize(this string input)
        {
            return input[0].ToString().ToUpper() + input.Substring(1);
        }

        /// <summary>
        /// Turn a camel-/Pascal-case input into individual separate words
        /// </summary>
        /// <param name="camelCaseInput"></param>
        /// <returns></returns>
        public static string Wordify(this string camelCaseInput)
        {
            // if the word is all upper, just return it
            return !Regex.IsMatch(camelCaseInput, "[a-z]")
                ? camelCaseInput
                : string.Join(" ", Regex.Split(camelCaseInput, @"(?<!^)(?=[A-Z])"));
        }

        /// <summary>
        /// Parse string into a specified enum
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static TEnum ParseEnum<TEnum>(this string value)
        {
            return value.ParseEnum<TEnum>(true);
        }

        /// <summary>
        /// Parse string into a specified enum
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="value"></param>
        /// <param name="ignoreCase"></param>
        /// <returns></returns>
        public static TEnum ParseEnum<TEnum>(this string value, bool ignoreCase)
        {

            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            value = value.Trim();

            if (value.Length == 0)
            {
                throw new ArgumentException("Must specify valid information for parsing in the string.", nameof(value));
            }

            Type t = typeof(TEnum);

            if (!t.IsEnum)
            {
                throw new ArgumentException("Type provided must be an Enum.", nameof(TEnum));
            }

            return (TEnum)Enum.Parse(t, value, ignoreCase);
        }

        /// <summary>
        /// Remove the last character
        /// </summary>
        /// <param name="value">String to remove from</param>
        /// <returns></returns>
        public static string RemoveLastCharacter(this string value)
        {
            return value.IsNullOrEmpty()
                ? value
                : value.Substring(0, value.Length - 1);
        }

        /// <summary>
        /// Remove the specified amount of characters from the end of the string
        /// </summary>
        /// <param name="value">String to remove from</param>
        /// <param name="amount">Number of characters to remove</param>
        /// <returns></returns>
        public static string RemoveLast(this string value, int amount)
        {
            if (amount == 0 || value.IsNullOrEmpty())
                return value;
            return amount >= value.Length
                ? string.Empty
                : value.Remove(value.Length - amount);
        }

        /// <summary>
        /// Remove the first character
        /// </summary>
        /// <param name="value">String to remove from</param>
        /// <returns></returns>
        public static string RemoveFirstCharacter(this string value)
        {
            return value.IsNullOrEmpty()
                ? value
                : value.Substring(1);
        }

        /// <summary>
        /// Remove the specified amount of characters from the beginning of the string
        /// </summary>
        /// <param name="value">String to remove from</param>
        /// <param name="amount">Number of characters to remove</param>
        /// <returns></returns>
        public static string RemoveFirst(this string value, int amount)
        {
            if (amount == 0 || value.IsNullOrEmpty())
                return value;

            return amount >= value.Length
                ? string.Empty
                : value.Substring(amount);
        }

        /// <summary>
        /// Determine if the string is convertible to the specified type
        /// </summary>
        /// <param name="value">String to check for convertibility</param>
        /// <param name="type">Target type</param>
        /// <returns>True if conversion is possible, false otherwise</returns>
        public static bool CanConvertTo(this string value, Type type)
        {
            TypeConverter converter = TypeDescriptor.GetConverter(type);
            return converter.IsValid(value);
        }

        /// <summary>
        /// Use the framework's safe parsing method to obtain 
        /// either an integral value contained in the string or the default value
        /// </summary>
        /// <param name="value">String to try parsing from</param>
        /// <param name="defaultValue">Value to be returned if a proper value could not be parsed</param>
        /// <returns></returns>
        public static int ParseIntSafe(this string value, int defaultValue = 0)
        {
            return int.TryParse(value, out int result)
                ? result
                : defaultValue;
        }
    }
}
