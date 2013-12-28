using System;
using System.Diagnostics.Contracts;

namespace Laciexpr
{
    public class Token
    {
        private readonly TokenType type;
        private readonly int value;

        /// <summary>
        /// Gets the type.
        /// </summary>
        /// <value>The type.</value>
        public TokenType Type
        {
            get { return type; }
        }

        public int Value
        {
            get
            {
                // Contract.Requires<InvalidOperationException>(Type == TokenType.Number);
                if (Type != TokenType.Number)
                {
                    throw new InvalidOperationException("Value property is available only for a number token.");
                }
                return value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="laciexpr.Token"/> class.
        /// </summary>
        /// <param name="type">A type of a new token.</param>
        public Token(TokenType type)
        {
            // Contract.Requires<ArgumentException>(type != TokenType.Number);
            if (type == TokenType.Number)
            {
                throw new ArgumentException("A number token must have its value. This overload cannot specify the token's value.");
            }
            this.type = type;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="laciexpr.Token"/> class which represents a number.
        /// </summary>
        /// <param name="value">A value for a new number token.</param>
        public Token(int value)
        {
            this.type = TokenType.Number;
            this.value = value;
        }

        public override string ToString()
        {
            return string.Format("[Token: {0}]", Type == TokenType.Number ? Value.ToString() : Type.ToString());
        }
    }
}

