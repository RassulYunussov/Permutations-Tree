using System;
using System.Collections.Generic;
using System.Linq;
namespace dstratree
{
    class Node:IComparable<Node>
    {
        public int Value { get; }
        HashSet<Node> nodes = new HashSet<Node>();
        public int CompareTo(Node other)
        {
           return Value.CompareTo(other.Value);
        }
        public override int GetHashCode()
        {
            return Value;
        }
        public override bool Equals(object obj)
        {
           return this.GetHashCode()==obj.GetHashCode();
        }
        public Node(int [] src,int value = 0)
        {
            Value = value;
            Add(src.Where(x=>x!=Value).ToArray());
        }
        private void Add(int [] src)
        {
            for (int i = 0; i < src.Length; i++)
                nodes.Add(new Node(src,src[i]));
        }
        public void Print(string val = "")
        {
           if(nodes.Count()==0)
             System.Console.WriteLine(val);
           else
               foreach (var n in nodes)
                   n.Print($"{val} {n.Value}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int [] a = new int []{1,2,3,4};
            Node root = new Node(a);
            root.Print();
        }
    }
}
