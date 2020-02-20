using System;
using System.Collections.Generic;

namespace BinarySearchAlgorithmTask
{
    /// <summary>Provides methods to search elements in arrays.</summary>
    public static class ElementSearch
    {
        /// <summary>Binary search.</summary>
        /// <typeparam name="T">Type of elements.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="item">The item.</param>
        /// <param name="comparer">The comparer.</param>
        /// <returns>Index of element in the array if it was found; -1 otherwise.</returns>
        public static int BinarySearch<T>(T[] source, T item, IComparer<T> comparer)
        {
            Validation(source, comparer);

            int i = 0;
            int j = source.Length - 1;
            int middleIndex;
            while (i < j)
            {
                middleIndex = (i + j) / 2;
                if (comparer.Compare(item, source[middleIndex]) > 0)
                {
                    i = middleIndex + 1;
                }
                else
                {
                    j = middleIndex;
                }
            }

            return comparer.Compare(source[i], item) == 0 ? i : -1;
        }

        /// <summary>Binary search.</summary>
        /// <typeparam name="T">Type of elements.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="item">The item.</param>
        /// <param name="comparer">The comparer.</param>
        /// <returns>Index of element in the array if it was found; -1 otherwise.</returns>
        public static int BinarySearch<T>(T[] source, T item, Comparison<T> comparer)
        {
            if (comparer == null)
            {
                throw new ArgumentNullException(nameof(comparer));
            }

            return BinarySearch(source, item, new ComparerAdapter<T>(comparer));
        }

        private static void Validation<T>(T[] source, IComparer<T> comparer)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (comparer == null)
            {
                throw new ArgumentNullException(nameof(comparer));
            }

            for (int i = 0; i < source.Length - 1; i++)
            {
                if (comparer.Compare(source[i], source[i + 1]) > 0)
                {
                    throw new ArgumentException($"{nameof(source)} is not sorted.");
                }
            }
        }
    }
}
