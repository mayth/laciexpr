using System;

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
    }
}

