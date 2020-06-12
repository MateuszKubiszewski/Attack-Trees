using Solution.Visitor;

//  I certify that this assignment is entirely my own work, performed independently and without any help from the sources which are not allowed.
//  Mateusz Kubiszewski

namespace Task
{
    interface IADTreeNode
    {
        string Name { get; set; }
        int Duration { get; set; }
        int Cost { get; set; }
        // TODO: Add your method(s) to the interface, implement it in classes corresponding to nodes of different types, and add functionality to evaluate the tree.
        T Accept<T>(IVisitor<T> visitor, ADTreeContext context);
    }

    abstract class ADTreeNode : IADTreeNode
    {
        // The assumption in the task says that the number of children is fixed and equal to 2, in different case we would need to have an array of Children
        public IADTreeNode LeftChild { get; set; }
        public IADTreeNode RightChild { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }
        public int Cost { get; set; }
        public ADTreeNode(IADTreeNode left, IADTreeNode right, string name, int duration, int cost)
        {
            LeftChild = left;
            RightChild = right;
            Name = name;
            Duration = duration;
            Cost = cost;
        }
        public abstract T Accept<T>(IVisitor<T> visitor, ADTreeContext context);
    }

    abstract class ADTreeLeaf : IADTreeNode
    {
        public string Name { get; set; }
        public int Duration { get; set; }
        public int Cost { get; set; }
        public ADTreeLeaf(string name, int duration, int cost)
        {
            Name = name;
            Duration = duration;
            Cost = cost;
        }
        public abstract T Accept<T>(IVisitor<T> visitor, ADTreeContext context);
    }
}
