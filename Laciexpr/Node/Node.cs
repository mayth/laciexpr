using System;

namespace Laciexpr
{
    public abstract class Node
    {
        abstract public int Evaluate();
        abstract public override string ToString();
    }
}

