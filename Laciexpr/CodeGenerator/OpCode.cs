using System;

namespace Laciexpr
{
    public enum OpCode
    {
        /// <summary>
        /// Push: [k] -> [n k]
        /// </summary>
        Push,
        /// <summary>
        /// Add: [n m k] -> [(n+m) k]
        /// </summary>
        Add,
        /// <summary>
        /// Subtract: [n m k] -> [(m-n) k]
        /// </summary>
        Sub,
        /// <summary>
        /// Multiply: [n m k] -> [(n*m) k]
        /// </summary>
        Mul,
        /// <summary>
        /// Divide: [n m k] -> [(m/n) k]
        /// </summary>
        Div,
        /// <summary>
        /// Positive: [n k] -> [+n k]
        /// </summary>
        Pos,
        /// <summary>
        /// Negative: [n k] -> [-n k]
        /// </summary>
        Neg,
        /// <summary>
        /// Print: [n k] -> [k] (print 'n')
        /// </summary>
        Print
    }
}

