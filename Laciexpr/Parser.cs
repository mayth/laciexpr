using System;
using System.Collections.Generic;
using System.Linq;

namespace Laciexpr
{
    public class Parser
    {
        private IEnumerator<Token> iter;

        private Parser(IEnumerator<Token> iter)
        {
            this.iter = iter;
        }

        public static Node Parse(IEnumerable<Token> tokens)
        {
            Node root = null;
            using (var iter = tokens.GetEnumerator())
            {
                iter.MoveNext();
                var parser = new Parser(iter);
                root = parser.ReadExpression();
            }
            return root;
        }

        private Node ReadExpression()
        {
            Node node;
            // expr = ("+"|"-")? <term> (("+"|"-") <term>)*
            switch (iter.Current.Type)
            {
                case TokenType.Plus:
                    iter.MoveNext();
                    node = new PositiveNode(ReadTerm());
                    break;
                case TokenType.Minus:
                    iter.MoveNext();
                    node = new NegativeNode(ReadTerm());
                    break;
                default:
                    node = ReadTerm();
                    break;
            }
            while (iter.Current.Type == TokenType.Plus || iter.Current.Type == TokenType.Minus)
            {
                var op = iter.Current.Type;
                if (!iter.MoveNext())
                {
                    break;
                }
                var right = ReadTerm();
                if (op == TokenType.Plus)
                {
                    node = new AddNode(node, right);
                }
                else
                {
                    node = new SubtractNode(node, right);
                }
            }
            return node;
        }

        private Node ReadTerm()
        {
            // term = <factor> (("*"|"/") <factor>)*
            var node = ReadFactor();
            while (iter.Current.Type == TokenType.Asterisk || iter.Current.Type == TokenType.Slash)
            {
                var op = iter.Current.Type;
                if (!iter.MoveNext())
                {
                    break;
                }
                var right = ReadFactor();
                if (op == TokenType.Asterisk)
                {
                    node = new MultiplyNode(node, right);
                }
                else
                {
                    node = new DivideNode(node, right);
                }
            }
            return node;
        }

        private Node ReadFactor()
        {
            // factor = number | "(" <expr> ")"
            switch (iter.Current.Type)
            {
                case TokenType.Plus:
                    {
                        iter.MoveNext();
                        return new PositiveNode(ReadExpression());
                    }
                case TokenType.Minus:
                    {
                        iter.MoveNext();
                        return new NegativeNode(ReadExpression());
                    }
                case TokenType.Number:
                    {
                        var node = new NumberNode(iter.Current.Value);
                        iter.MoveNext();
                        return node;
                    }
                case TokenType.LeftParen:
                    {
                        iter.MoveNext();
                        var node = ReadExpression();
                        if (iter.Current.Type != TokenType.RightParen)
                        {
                            throw new InvalidOperationException("Unbalanced parenthesis");
                        }
                        iter.MoveNext();
                        return node;
                    }
                default:
                    throw new InvalidOperationException("unreachable");
            }
        }
    }
}

