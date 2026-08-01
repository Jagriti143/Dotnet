using System;

class Node
{
    public int data;
    public Node left, right;

    public Node(int data)
    {
        this.data = data;
        left = right = null;
    }
}

class Solution
{
    public static Node Insert(Node root, int data)
    {
        if (root == null)
            return new Node(data);

        if (data <= root.data)
            root.left = Insert(root.left, data);
        else
            root.right = Insert(root.right, data);

        return root;
    }

    public static void preOrder(Node root)
    {
        if (root == null)
            return;

        Console.Write(root.data + " ");
        preOrder(root.left);
        preOrder(root.right);
    }

    static void Main(String[] args)
    {
        int t = Convert.ToInt32(Console.ReadLine());
        string[] values = Console.ReadLine().Split(' ');

        Node root = null;

        for (int i = 0; i < t; i++)
        {
            root = Insert(root, Convert.ToInt32(values[i]));
        }

        preOrder(root);
    }
}