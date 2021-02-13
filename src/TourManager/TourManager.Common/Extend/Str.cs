using System;

namespace TourManager.Common.Extend
{
    /// <summary>
    /// A set of extensions for string
    /// </summary>
    public static class Str
    {
        /// <summary>
        /// Convert string to enum or use default value
        /// </summary>
        /// <typeparam name="T">The type to parse </typeparam>
        /// <param name="value">The source to convert</param>
        /// <param name="defaultValue">The given default value</param>
        /// <returns></returns>
        public static T ToEnum<T>(this string value, T defaultValue) where T : struct
        {
            if (value.IsBlank())
            {
                return defaultValue;
            }

            if (!Enum.TryParse<T>(value, true, out var result))
            {
                return defaultValue;
            }

            return result;
        }

        /// <summary>
        /// Checks if given string is empty, null or whitespace
        /// </summary>
        /// <param name="str">The given string to test</param>
        /// <returns></returns>
        public static bool IsBlank(this string str)
        {
            return string.IsNullOrWhiteSpace(str);
        }
    }
}
