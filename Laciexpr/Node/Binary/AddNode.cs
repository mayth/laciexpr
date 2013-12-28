using System;

namespace Laciexpr
{
    public class AddNode : Node
    {
        private readonly Node left;
        private readonly Node right;

        public AddNode(Node left, Node right)
        {
            this.left = left;
            this.right = right;
        }

        public override int Evaluate()
        {
            return left.Evaluate() + right.Evaluate();
        }

        public override string ToString()
        {
            return string.Format("(Add {0} {1})", left.ToString(), right.ToString());
        }
    }
}

