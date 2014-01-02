using System;
using System.Collections.Generic;
using System.Linq;

namespace Laciexpr
{
    public class Parser
    {
        private IEnumerator<Token> iter;

        private Token Current
        {
            get
            {
                // Contract.Requires<InvalidOperationException>(iter != null);
                if (iter == null)
                    throw new InvalidOperationException("Enumerator is not available.");
                return iter.Current;
            }
        }

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
            // expr = <expr> ("+"|"-") <term>
            // -> expr  = <term> <expr'>
            //    expr' = ("+"|"-") <term> <expr'> | e
            var node = ReadTerm();
            while (Current.Type == TokenType.Plus || Current.Type == TokenType.Minus)
            {
                var op = Current.Type;
                iter.MoveNext();
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
            // term = <term> ("*"|"/") <factor>
            // -> term  = <factor> <term'>
            //    term' = ("*"|"/") <factor> <term'> | e
            var node = ReadFactor();
            while (Current.Type == TokenType.Asterisk || Current.Type == TokenType.Slash)
            {
                var op = Current.Type;
                iter.MoveNext();
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
            // factor = number | ("-"|"+") <factor> | "(" <expr> ")"
            switch (Current.Type)
            {
                case TokenType.Plus:
                    {
                        iter.MoveNext();
                        return new PositiveNode(ReadFactor());
                    }
                case TokenType.Minus:
                    {
                        iter.MoveNext();
                        return new NegativeNode(ReadFactor());
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
                        if (Current.Type != TokenType.RightParen)
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

