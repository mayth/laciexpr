using System;

namespace Laciexpr
{
    public class SubtractNode : Node
    {
        private readonly Node left;
        private readonly Node right;

        public SubtractNode(Node left, Node right)
        {
            this.left = left;
            this.right = right;
        }

        public override int Evaluate()
        {
            return left.Evaluate() - right.Evaluate();
        }
    }
}

