using System;
using System.Collections.Generic;
using System.Text;
using Task;

//  I certify that this assignment is entirely my own work, performed independently and without any help from the sources which are not allowed.
//  Mateusz Kubiszewski

namespace Solution.Nodes
{
    class Leaf : ADTreeLeaf
    {
        public Leaf(string name, int duration, int cost) : base(name, duration, cost) { }

        public override T Accept<T>(Visitor.IVisitor<T> visitor, ADTreeContext context)
        {
            return visitor.EvaluateLeaf(this, context);
        }
    }
}
