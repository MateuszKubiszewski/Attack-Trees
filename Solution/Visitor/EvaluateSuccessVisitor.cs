using Solution.Nodes;
using System;
using System.Collections.Generic;
using System.Text;
using Task;

//  I certify that this assignment is entirely my own work, performed independently and without any help from the sources which are not allowed.
//  Mateusz Kubiszewski

namespace Solution.Visitor
{
    class EvaluateSuccessVisitor : IVisitor<bool>
    {
        public bool GetValue(IADTreeNode node, IVisitor<bool> visitor, ADTreeContext context)
        {
            return node.Accept(this, context);
        }

        public bool EvaluateANDNode(ANDNode node, ADTreeContext context)
        {
            bool l = node.LeftChild.Accept(this, context);
            bool r = node.RightChild.Accept(this, context);
            return l && r;
        }

        public bool EvaluateORNode(ORNode node, ADTreeContext context)
        {
            bool l = node.LeftChild.Accept(this, context);
            bool r = node.RightChild.Accept(this, context);
            return l || r;
        }

        public bool EvaluateLeaf(Leaf node, ADTreeContext context)
        {
            bool? amiok = context.GetNodeOutcome(node.Name);
            if (amiok == null)
            {
                Random random = new Random();
                amiok = random.NextDouble() > 0.5;
            }
            return (bool)amiok;
        }
    }
}
