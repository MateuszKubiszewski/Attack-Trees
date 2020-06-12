using Solution.Nodes;
using System.Collections.Generic;
using System.Linq;

//  I certify that this assignment is entirely my own work, performed independently and without any help from the sources which are not allowed.
//  Mateusz Kubiszewski

namespace Task
{
    class ADTreeParser
    {
        public IADTreeNode Parse(string prefix_expression)
        {
            Stack<string> tokens = new Stack<string>(prefix_expression.Split(' ').Reverse<string>());
            var expression = ParseNext(tokens);
            if (tokens.Count != 0) throw new SyntaxErrorException();
            return expression;
        }

        private IADTreeNode ParseNext(Stack<string> tokens)
        {
            if (tokens.Count == 0) throw new SyntaxErrorException();
            string[] split = tokens.Pop().Split(',');
            if (split.Length != 4) throw new SyntaxErrorException();
            string type = split[0];
            string name = split[1];
            int cost = int.Parse(split[2]);
            int time = int.Parse(split[3]);
            switch (type)
            {
                // TODO: complete parser implementation (build the ADTree corresponding to string input and return its root node).
                case "AND":
                    {
                        IADTreeNode left = ParseNext(tokens);
                        IADTreeNode right = ParseNext(tokens);
                        return new ANDNode(left, right, name, time, cost);
                    }
                case "OR":
                    {
                        IADTreeNode left = ParseNext(tokens);
                        IADTreeNode right = ParseNext(tokens);
                        return new ORNode(left, right, name, time, cost);
                    }
                case "LEAF":
                    {
                        return new Leaf(name, time, cost);
                    }
                default: throw new SyntaxErrorException();
            }
        }
    }
}
