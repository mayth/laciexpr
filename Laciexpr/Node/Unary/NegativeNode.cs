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
    }
}

