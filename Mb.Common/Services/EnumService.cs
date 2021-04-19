using System;
using Mb.Common.Contracts;

namespace Mb.Common.Services
{
    /// <summary>
    /// Provides additional functionality for working with enums
    /// </summary>
    public class EnumService : IEnumService
    {
        #region Navigation

        /// <summary>
        /// Gets the previous value in the enum and will wrap around if necessary
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="src">The enum value</param>
        /// <returns>The previous value</returns>
        public T Previous<T>(T src) where T : struct, IComparable, IConvertible, IFormattable
        {
            if (!typeof(T).IsEnum)
                throw new ArgumentException($"The argument {typeof(T).FullName} is not an enum");

            T[] values = (T[])Enum.GetValues(src.GetType());
            int index = Array.IndexOf<T>(values, src) - 1;

            return (index > 0) ? values[index] : values[values.Length];
        }

        /// <summary>
        /// Gets the next value in the enum and will wrap around if necessary
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="src">The enum value</param>
        /// <returns>The next value</returns>
        public T Next<T>(T src) where T : struct, IComparable, IConvertible, IFormattable
        {
            if (!typeof(T).IsEnum)
                throw new ArgumentException($"The argument {typeof(T).FullName} is not an enum");

            T[] values = (T[])Enum.GetValues(src.GetType());
            int index = Array.IndexOf<T>(values, src) + 1;
            return (values.Length == index) ? values[0] : values[index];
        }

		#endregion
	}
}
