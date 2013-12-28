using System;
using System.Collections.Generic;

namespace Laciexpr
{
    public abstract class Node
    {
        abstract public int Evaluate();
        abstract public void Emit(IList<Code> codes);
        abstract public override string ToString();

        public IEnumerable<Code> Emit(bool appendPrint)
        {
            var codes = new List<Code>();
            Emit(codes);
            if (appendPrint)
            {
                codes.Add(new Code(OpCode.Print));
            }
            return codes;
        }
    }
}

