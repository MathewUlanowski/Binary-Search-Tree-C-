using System;
using System.Collections.Generic;

namespace BiSearchSharp
{
    // this is the class format for each individual node
    class Node
    {
        public int val;
        public Node RightNode;
        public Node LeftNode;

        //this is the constructor function for the Node
        public Node(int SomeValue)
        {
            val = SomeValue;
        }
    }

    // this is the class format for a binary search tree
    class BiSearchTree
    {
        public Node root;

        //constructor method if an node is provided
        public BiSearchTree(Node nodeInput)
        {
            root = nodeInput;
        }
        //overload constructor method if only an integer is provided this will create a node for root
        public BiSearchTree(int integerInput)
        {
            root = new Node(integerInput);
        }
        //overload constructor method that takes no inputs and leave the root null
        public BiSearchTree()
        {

        }

        //Add method will add the node to its corresponding location in the tree
        //takes in an int 
        private void RecurADD(Node Runner, int SomeValue)
        {
            if(SomeValue < Runner.val)
            {
                if(Runner.LeftNode != null)
                {
                    RecurADD(Runner.LeftNode, SomeValue);
                }
                else
                {
                    // Console.WriteLine("adding a node with the value of "+SomeValue);
                    Runner.LeftNode = new Node(SomeValue);
                }
            }
            if(SomeValue > Runner.val)
            {
                if(Runner.RightNode != null)
                {
                    RecurADD(Runner.RightNode, SomeValue);
                }
                else
                {
                    // Console.WriteLine("adding a node with the value of "+SomeValue);
                    Runner.RightNode = new Node(SomeValue);
                }
            }
            //implicit break case if its neither of the two conditions are met. saves some computational proccesing from running in the recursive call
        }
        public void Insert(int SomeValue)
        {
            if(root == null)
            {
                root = new Node(SomeValue);
            }
            else
            {
                RecurADD(root, SomeValue);
            }
        }

        private void RecurADD(Node Runner, Node node)
        {
            if(node.val < Runner.val)
            {
                if(Runner.LeftNode != null)
                {
                    RecurADD(Runner.LeftNode, node.val);
                }
                else
                {
                    Runner.LeftNode = node;
                }
            }
            if(node.val > Runner.val)
            {
                if(Runner.RightNode != null)
                {
                    RecurADD(Runner.RightNode, node.val);
                }
                else
                {
                    Runner.RightNode = node;
                }
            }
            //implicit break case if its neither of the two conditions are met. saves some computational proccesing from running in the recursive call
        }
        public void Insert(Node SomeValue)
        {
            if(root == null)
            {
                root = SomeValue;
            }
            else
            {
                RecurADD(root, SomeValue);
            }
        }

        // count will count the nubmer of nodes in the tree
        public int Count()
        {
            int result = 0;

            if(root == null)
            {
                //will allow it to return 0 if there is no root
                return result;
            }
            void recurse(Node node)
            {
                if(node.LeftNode != null)
                {
                    recurse(node.LeftNode);
                }
                if(node.RightNode != null)
                {
                    recurse(node.RightNode);
                }
                result++;
            }
            recurse(root);

            return result;
        }

        public int MaxLength()
        {
            int result = 0;
            int RunCount = 0;

            if(root == null)
            {
                return result;
            }

            void recurse(Node node)
            {
                // Console.WriteLine(RunCount);
                RunCount++;
                if(node.LeftNode !=null)
                {
                    recurse(node.LeftNode);
                }
                if(node.RightNode !=null)
                {
                    recurse(node.RightNode);
                }
                if(node.RightNode ==null && node.LeftNode ==null)
                {
                    if(RunCount > result)
                    {
                        // Console.WriteLine(RunCount);
                        result = RunCount;
                        Console.WriteLine("changing Max");
                    }
                }
                RunCount--;
                // Console.WriteLine(RunCount);

            }
            recurse(root);

            return result;
        }
        public int AvgLength()
        {
            List<int> numbers = new List<int>();
            int RunCount = 0;
            int result = 0;

            if(root == null)
            {
                return result;
            }

            void recurse(Node node)
            {
                // Console.WriteLine(RunCount);
                RunCount++;
                if(node.LeftNode !=null)
                {
                    recurse(node.LeftNode);
                }
                if(node.RightNode !=null)
                {
                    recurse(node.RightNode);
                }
                if(node.RightNode ==null && node.LeftNode ==null)
                {
                    numbers.Add(RunCount);
                    // Console.WriteLine("adding a value");
                }
                RunCount--;
                // Console.WriteLine(RunCount);
            }
            recurse(root);

            foreach (var item in numbers)
            {
                result = result+item;
            }
            result = result/numbers.Count;
            
            return result;
        }
        public int EndPoints()
        {
            int result = 0;
            
            if(root == null)
            {
                return result;
            }

            void recurse(Node node)
            {

                if(node.LeftNode !=null)
                {
                    recurse(node.LeftNode);
                }
                if(node.RightNode !=null)
                {
                    recurse(node.RightNode);
                }
                if(node.RightNode ==null && node.LeftNode ==null)
                {
                    result++;
                }


            }
            recurse(root);

            return result;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            BiSearchTree Tree1 = new BiSearchTree();
            
            Console.Write("Please put in a value for the root of the tree: ");
            int TreeRoot = Int32.Parse(Console.ReadLine());
            Tree1.Insert(TreeRoot);
            Console.Write("\nplease input the maxumum possible values in the tree: ");
            int MaxPosible = Int32.Parse(Console.ReadLine());
            Console.Write("\nplease enter the Lowest value that can be put in the tree: ");
            int MinVal = Int32.Parse(Console.ReadLine());
            Console.Write("\nPlease enter the Highest value that can be put in the tree: ");
            int MaxVal = Int32.Parse(Console.ReadLine());

            List<int> pushList = new List<int>();
            for (int i = 1; i <= MaxPosible; i++)
            {
                int num = new Random().Next(MinVal, MaxVal);
                pushList.Add(num);
                // Console.WriteLine("pusshing in a value of "+num);
            }
            foreach (var item in pushList)
            {
                Tree1.Insert(item);
            }
            Console.WriteLine($"\nThere are {Tree1.Count()} values in your tree");

            Console.WriteLine($"\nThe longest branch in the tree is {Tree1.MaxLength()}");

            Console.WriteLine($"\nThe average branch length is {Tree1.AvgLength()}");

            Console.WriteLine($"\nThere is {Tree1.EndPoints()} Endpoints in your tree");
        }
    }
}
