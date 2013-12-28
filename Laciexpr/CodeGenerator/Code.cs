using System;

namespace Laciexpr
{
    /// <summary>
    /// Represents a code for the intermediate language.
    /// </summary>
    public struct Code
    {
        private readonly OpCode code;
        private readonly int operand;

        /// <summary>
        /// Gets the op-code.
        /// </summary>
        /// <value>The op-code.</value>
        public OpCode OpCode
        {
            get { return code; }
        }

        /// <summary>
        /// Gets the operand.
        /// </summary>
        /// <value>The operand.</value>
        public int Operand
        {
            get
            {
                if (OpCode != OpCode.Push)
                {
                    throw new InvalidOperationException("No operands are available except for PUSH.");
                }
                return operand;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Laciexpr.Code"/> struct without a operand.
        /// </summary>
        /// <param name="code">Op-code.</param>
        public Code(OpCode code)
        {
            this.code = code;
            this.operand = 0;   // dummy
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Laciexpr.Code"/> struct with operand.
        /// </summary>
        /// <param name="code">Op-Code.</param>
        /// <param name="operand">A value for operand.</param>
        public Code(OpCode code, int operand)
        {
            this.code = code;
            this.operand = operand;
        }
    }
}

