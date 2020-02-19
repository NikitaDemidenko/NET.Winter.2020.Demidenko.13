using System;
using System.Collections.Generic;

namespace ValidParenthesesTask
{
    /// <summary>Provides method for determine whether the specified string has valid parentheses.</summary>
    public static class ValidParentheses
    {
        /// <summary>Determines whether the specified string has valid parentheses.</summary>
        /// <param name="str">The string.</param>
        /// <param name="parentheses">The parentheses.</param>
        /// <returns>
        ///   <c>true</c> if string has valid parentheses; otherwise, <c>false</c>.</returns>
        /// <exception cref="System.ArgumentNullException">Thrown when string or parentheses is null.</exception>
        public static bool IsValidParentheses(string str, IParenthesesSource parentheses)
        {
            if (str == null)
            {
                throw new ArgumentNullException(nameof(str));
            }

            if (parentheses == null)
            {
                throw new ArgumentNullException(nameof(parentheses));
            }

            var stack = new Stack<char>();

            foreach (var symbol in str)
            {
                if (parentheses.OpeningBrackets.ContainsKey(symbol))
                {
                    stack.Push(symbol);
                }
                else if (parentheses.ClosingBrackets.ContainsKey(symbol))
                {
                    if (stack.Count == 0)
                    {
                        return false;
                    }

                    if (parentheses.ClosingBrackets[symbol] + parentheses.OpeningBrackets[stack.Peek()] == 0)
                    {
                        stack.Pop();
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            return stack.Count == 0;
        }
    }
}
