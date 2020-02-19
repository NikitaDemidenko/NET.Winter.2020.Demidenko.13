using System;
using System.Collections.Generic;
using System.Linq;

namespace FlaviusJosephusTask
{
    /// <summary>Josephus game.</summary>
    public static class JosephusGame
    {
        /// <summary>Simulates Josephus game.</summary>
        /// <param name="count">Count of people.</param>
        /// <param name="k">Number of person to be deleted.</param>
        /// <returns>People removal sequence.</returns>
        /// <exception cref="System.ArgumentException">Thrown when <em>count</em> or <em>k</em> is invalid.</exception>
        public static IEnumerable<int> Josephus(int count, int k)
        {
            if (count < 1)
            {
                throw new ArgumentException($"{nameof(count)} must be greater than zero.");
            }

            if (k < 1)
            {
                throw new ArgumentException($"{nameof(k)} must be greater than zero.");
            }

            var circle = new List<int>(Enumerable.Range(1, count));

            int indexToRemove = 0;
            int currentElementIndex = 0;

            while (circle.Count != 0)
            {
                currentElementIndex++;
                if (currentElementIndex == k)
                {
                    yield return circle[indexToRemove];
                    circle.RemoveAt(indexToRemove);

                    indexToRemove--;
                    currentElementIndex = 0;
                }

                if (indexToRemove == circle.Count - 1)
                {
                    indexToRemove = 0;
                }
                else
                {
                    indexToRemove++;
                }
            }
        }
    }
}
