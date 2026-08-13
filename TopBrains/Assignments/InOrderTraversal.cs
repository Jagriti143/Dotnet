using System;
using System.Collections.Generic;
using System.IO;

public class Node
{
    public int data;
    public Node left;
    public Node right;

    public Node(int item)
    {
        data = item;
        left = null;
        right = null;
    }
}

class Solution
{
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

    static void InOrder(Node root)
    {
        if (root == null)
            return;

        InOrder(root.left);
        Console.Write(root.data + " ");
        InOrder(root.right);
    }

    static void Main(String[] args)
    {
        int t = int.Parse(Console.ReadLine());

        Node root = null;

        string[] values = Console.ReadLine().Split(' ');

        for (int i = 0; i < t; i++)
        {
            root = Insert(root, int.Parse(values[i]));
        }

        InOrder(root);
    }
}
