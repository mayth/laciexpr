using System;

namespace Laciexpr
{
    public class NumberNode : Node
    {
        private readonly int value;

        public NumberNode(int value)
        {
            this.value = value;
        }

        public override int Evaluate()
        {
            return value;
        }
    }
}
