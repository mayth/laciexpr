using System;

namespace Laciexpr
{
    public class NegativeNode : Node
    {
        private readonly Node node;

        public NegativeNode(Node node)
        {
            this.node = node;
        }

        public override int Evaluate()
        {
            return -node.Evaluate();
        }

        public override string ToString()
        {
            return string.Format("(Neg {0})", node.ToString());
        }
    }
}

