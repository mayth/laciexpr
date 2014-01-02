using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Laciexpr
{
    public static class Tokenizer
    {
        public static IEnumerable<Token> Tokenize(TextReader reader)
        {
            int i;
            while ((i = reader.Read()) != -1)
            {
                char c = (char)i;
                if (char.IsDigit(c))
                {
                    yield return new Token(ReadNumber(reader, c - '0'));
                }
                else if (c == '\n')
                {
                    yield return new Token(TokenType.EndOfLine);
                }
                else if (!char.IsWhiteSpace(c))
                {
                    yield return ToToken(c);
                }
            }
        }

        static int ReadNumber(TextReader reader, int initial)
        {
            int n = initial;
            int i;
            while ((i = reader.Peek()) != -1 && char.IsDigit((char)i))
            {
                n = n * 10 + (i - '0');
                reader.Read();  // go next
            }
            return n;
        }

        static Token ToToken(char c)
        {
            switch (c)
            {
                case '+':
                    return new Token(TokenType.Plus);
                case '-':
                    return new Token(TokenType.Minus);
                case '*':
                    return new Token(TokenType.Asterisk);
                case '/':
                    return new Token(TokenType.Slash);
                case '(':
                    return new Token(TokenType.LeftParen);
                case ')':
                    return new Token(TokenType.RightParen);
                default:
                    throw new ArgumentException(string.Format("Invalid character (U+{0:X4} '{1}')", (int)c, c));
            }
        }
    }
}                