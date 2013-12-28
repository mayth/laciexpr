using System;
using System.Collections.Generic;

namespace Laciexpr
{
    public class PositiveNode : Node
    {
        private readonly Node node;

        public PositiveNode(Node node)
        {
            this.node = node;
        }

        public override int Evaluate()
        {
            return node.Evaluate();
        }

        public override void Emit(IList<Code> codes)
        {
            node.Emit(codes);
            codes.Add(new Code(OpCode.Pos));
        }

        public override string ToString()
        {
            return string.Format("(Pos {0})", node.ToString());
        }
    }
}

