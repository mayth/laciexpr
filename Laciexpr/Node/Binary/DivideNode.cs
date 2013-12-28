using System;
using System.Collections.Generic;

namespace Laciexpr
{
    public class DivideNode : Node
    {
        private readonly Node left;
        private readonly Node right;

        public DivideNode(Node left, Node right)
        {
            this.left = left;
            this.right = right;
        }

        public override int Evaluate()
        {
            return left.Evaluate() / right.Evaluate();
        }

        public override void Emit(IList<Code> codes)
        {
            left.Emit(codes);
            right.Emit(codes);
            codes.Add(new Code(OpCode.Div));
        }

        public override string ToString()
        {
            return string.Format("(Div {0} {1})", left.ToString(), right.ToString());
        }
    }
}

