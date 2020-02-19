using System;
using NUnit.Framework;
using static ValidParenthesesTask.ValidParentheses;

namespace ValidParenthesesTask.Tests
{
    public class ValidParenthesesTests
    {
        private readonly Parentheses parentheses = new Parentheses();

        [Test]
        public void IsValidParentheses_StringIsNull() =>
            Assert.Throws<ArgumentNullException>(() => IsValidParentheses(null, parentheses));

        [Test]
        public void IsValidParentheses_ParenthesesIsNull() =>
            Assert.Throws<ArgumentNullException>(() => IsValidParentheses("test", null));

        [TestCase("", ExpectedResult = true)]
        [TestCase("{{..]..[..}}", ExpectedResult = false)]
        [TestCase("((hello))..({{[...]}})", ExpectedResult = true)]
        [TestCase("[[((.....)])]", ExpectedResult = false)]
        [TestCase("(x +(x-y) * (x[1] + x[2]))", ExpectedResult = true)]
        [TestCase("[[[[((({{{9}}})))]]]]", ExpectedResult = true)]
        [TestCase("((hello))..({[...]}})", ExpectedResult = false)]
        [TestCase("(((({[[[((({111[321(455)]123})))]]]}))])", ExpectedResult = false)]
        public bool IsValidParenthesesTests(string str)
        {
            return IsValidParentheses(str, parentheses);
        }
    }
}