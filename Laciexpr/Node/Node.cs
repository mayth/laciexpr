using System;
using System.Collections.Generic;
using System.Linq;

namespace Laciexpr
{
    public abstract class Node
    {
        abstract public int Evaluate();
        abstract public void Emit(IList<Code> codes);
        abstract public override string ToString();

        public IEnumerable<Code> Emit()
        {
            var codes = new List<Code>();
            Emit(codes);
            return codes;
        }
    }
}

