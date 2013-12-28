using System;

namespace Laciexpr
{
    public enum TokenType
    {
        /// <summary>
        /// End of Line
        /// </summary>
        EndOfLine,
        /// <summary>
        /// Number ([0-9]+)
        /// </summary>
        Number,
        /// <summary>
        /// "+"
        /// </summary>
        Plus,
        /// <summary>
        /// "-"
        /// </summary>
        Minus,
        /// <summary>
        /// "*"
        /// </summary>
        Asterisk,
        /// <summary>
        /// "/"
        /// </summary>
        Slash,
        /// <summary>
        /// "("
        /// </summary>
        LeftParen,
        /// <summary>
        /// ")"
        /// </summary>
        RightParen
    }
}

