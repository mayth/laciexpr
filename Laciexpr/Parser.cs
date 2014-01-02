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
            if (iter == null)
                throw new ArgumentNullException("Tokens must be given.");

            this.iter = iter;
            if (!iter.MoveNext())
                throw new ArgumentException("A collection for the tokens must have some tokens.");
        }

        public static Node Parse(IEnumerable<Token> tokens)
        {
            Node root = null;
            using (var iter = tokens.GetEnumerator())
            {
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
                if (!iter.MoveNext())
                    throw new InvalidSyntaxException("An operator (for an expression) must have an operand");

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
                if (!iter.MoveNext())
                    throw new InvalidSyntaxException("An operator (for a term) must have an operand.");

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
                        if (!iter.MoveNext())
                            throw new InvalidSyntaxException("An unary operator \"+\" must have an operand");
                        return new PositiveNode(ReadFactor());
                    }
                case TokenType.Minus:
                    {
                        if (!iter.MoveNext())
                            throw new InvalidSyntaxException("An unary operator \"-\" must have an operand");
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
                        if (!iter.MoveNext())
                            throw new InvalidSyntaxException("Unbalanced parenthesis");
                        var node = ReadExpression();
                        if (Current.Type != TokenType.RightParen)
                        {
                            throw new InvalidSyntaxException("Unbalanced parenthesis");
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

