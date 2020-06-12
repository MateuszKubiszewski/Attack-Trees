using Solution.Nodes;
using System;
using System.Collections.Generic;
using System.Text;
using Task;

//  I certify that this assignment is entirely my own work, performed independently and without any help from the sources which are not allowed.
//  Mateusz Kubiszewski

namespace Solution.Visitor
{
    interface IVisitor<T>
    {
        T GetValue(IADTreeNode node, IVisitor<T> visitor, ADTreeContext context);
        T EvaluateANDNode(ANDNode node, ADTreeContext context);
        T EvaluateORNode(ORNode node, ADTreeContext context);
        T EvaluateLeaf(Leaf node, ADTreeContext context);
    }
}
