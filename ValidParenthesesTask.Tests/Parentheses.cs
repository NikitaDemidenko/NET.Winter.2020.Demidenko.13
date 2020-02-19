using System;
using System.Collections.Generic;
using System.Text;

namespace ValidParenthesesTask.Tests
{
    public class Parentheses : IParenthesesSource
    {
        public Dictionary<char, int> OpeningBrackets { get; } = new Dictionary<char, int>
        {
            ['('] = 1,
            ['['] = 2,
            ['{'] = 3,
        };

        public Dictionary<char, int> ClosingBrackets { get; } = new Dictionary<char, int>
        {
            [')'] = -1,
            [']'] = -2,
            ['}'] = -3,
        };
    }
}
