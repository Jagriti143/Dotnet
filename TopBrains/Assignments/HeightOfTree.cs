
using System;

class Node
{
    public int data;
    public Node left;
    public Node right;

    public Node(int item)
    {
        data = item;
        left = right = null;
    }
}

class Solution
{
    // Insert a node into the BST
    static Node Insert(Node root, int data)
    {
        if (root == null)
        {
            return new Node(data);
        }

        if (data <= root.data)
        {
            root.left = Insert(root.left, data);
        }
        else
        {
            root.right = Insert(root.right, data);
        }

        return root;
    }

    // Find the height of the tree
    static int getHeight(Node root)
    {
        if (root == null)
        {
            return -1;
        }

        int leftHeight = getHeight(root.left);
        int rightHeight = getHeight(root.right);

        return Math.Max(leftHeight, rightHeight) + 1;
    }

    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        string[] values = Console.ReadLine().Split(' ');
        Node root = null;

        for (int i = 0; i < n; i++)
        {
            root = Insert(root, int.Parse(values[i]));
        }

        Console.WriteLine(getHeight(root));
    }
}

