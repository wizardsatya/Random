using Random;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DifferenceCode
{
    class Program
    {

        static void Main(string[] args)
        {
            // Question 1: Array Problem
            int[] arr = { 1, 3, 4, 7, 9, 13 };
            int a = 4;
            bool IsTrue = FindDiff.FindTheDiff(arr, a);
            Console.WriteLine(IsTrue);

            //Question 2:Binary String Problem
            string BinString = "10110111";
            string NBinStr = BinString.TrimStart('0');
            int length = 0;
            if (NBinStr.Length > 0)
            {
                length = FindUniversalStrings.FindUniversalString(NBinStr);
            }

            Console.WriteLine("Intital String : " + BinString);
            Console.WriteLine("Maximum string: " + length);

            // Question 3: Reverse Binary Tree
            Node root = newNode(7);
            root.left = newNode(6);
            root.right = newNode(5);
            root.left.left = newNode(4);
            root.left.right = newNode(3);
            root.right.left = newNode(2);
            root.right.right = newNode(1);

            int data = 4;
            inorder(root);

            reverseTreePath(root, data);
            Console.ReadLine();
            inorder(root);

            Console.ReadKey();
        }

        public class Node
        {
            public int data;
            public Node left, right;
        }

        public class INT
        {
            public int data;
        }

        public static Node reverseTreePathUtil(Node root, int data,
                                               IDictionary<int, int> temp,
                                               int level, INT nextpos)
        {
            if (root == null)
            {
                return null;
            }

            if (data == root.data)
            {
                temp[level] = root.data;
                root.data = temp[nextpos.data];
                nextpos.data++;
                return root;
            }

            temp[level] = root.data;
            Node left, right = null;
            left = reverseTreePathUtil(root.left, data, temp,
                                       level + 1, nextpos);
            if (left == null)
            {
                right = reverseTreePathUtil(root.right, data, temp,
                                            level + 1, nextpos);
            }

            if (left != null || right != null)
            {
                root.data = temp[nextpos.data];
                nextpos.data++;
                return (left != null ? left : right);
            }

            return null;
        }

        public static void reverseTreePath(Node root,
                                           int data)
        {
            IDictionary<int,
                        int> temp = new Dictionary<int,
                                                   int>();

            INT nextpos = new INT();
            nextpos.data = 0;

            reverseTreePathUtil(root, data,
                                temp, 0, nextpos);
        }

        public static void inorder(Node root)
        {
            if (root != null)
            {
                inorder(root.left);
                Console.Write(root.data + " ");
                inorder(root.right);
            }
        }

        public static Node newNode(int data)
        {
            Node temp = new Node();
            temp.data = data;
            temp.left = temp.right = null;
            return temp;
        }
    }
}
