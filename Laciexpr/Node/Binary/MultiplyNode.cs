using System;
using System.Collections.Generic;

namespace Laciexpr
{
    public class MultiplyNode : Node
    {
        private readonly Node left;
        private readonly Node right;

        public MultiplyNode(Node left, Node right)
        {
            this.left = left;
            this.right = right;
        }

        public override int Evaluate()
        {
            return left.Evaluate() * right.Evaluate();
        }

        public override void Emit(IList<Code> codes)
        {
            left.Emit(codes);
            right.Emit(codes);
            codes.Add(new Code(OpCode.Mul));
        }

        public override string ToString()
        {
            return string.Format("(Mul {0} {1})", left.ToString(), right.ToString());
        }
    }
}

