﻿using Solution.Nodes;
using System;
using System.Collections.Generic;
using System.Text;
using Task;

//  I certify that this assignment is entirely my own work, performed independently and without any help from the sources which are not allowed.
//  Mateusz Kubiszewski

namespace Solution.Visitor
{
    class EvaluateCostVisitor : IVisitor<int>
    {
        public int EvaluateANDNode(ANDNode node, ADTreeContext context)
        {
            return node.LeftChild.Accept(this, context) + node.RightChild.Accept(this, context) + node.Cost;
        }

        public int EvaluateLeaf(Leaf node, ADTreeContext context)
        {
            return node.Cost;
        }

        public int EvaluateORNode(ORNode node, ADTreeContext context)
        {
            int a = node.LeftChild.Accept(this, context) + node.Cost;
            int b = node.RightChild.Accept(this, context) + node.Cost;
            return a > b ? b : a;
        }

        public int GetValue(IADTreeNode node, IVisitor<int> visitor, ADTreeContext context)
        {
            return node.Accept(this, context);
        }
    }
}
