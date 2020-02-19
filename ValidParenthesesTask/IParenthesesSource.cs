using System;
using System.Collections.Generic;
using System.Text;

namespace ValidParenthesesTask
{
    /// <summary>Provides collections of parentheses.</summary>
    public interface IParenthesesSource
    {
        /// <summary>Gets the opening brackets.</summary>
        /// <value>The opening brackets.</value>
        Dictionary<char, int> OpeningBrackets { get; }

        /// <summary>Gets the closing brackets.</summary>
        /// <value>The closing brackets.</value>
        Dictionary<char, int> ClosingBrackets { get; }
    }
}
