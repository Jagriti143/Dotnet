// using System;
// public class BinaryTreeNode
// {
//     public int Value{get;set;}
//     public BinaryTreeNode Left{get;set;}
//     public BinaryTreeNode Right{get;set;}
//     public BinaryTreeNode(int value)
//     {
//         Value=value;
//         Left=null;
//         Right=null;
//     }
// }
// public class BinaryTree
// {
//     public BinaryTreeNode Root{get;set;}
//     public BinaryTree()
//     {
//         Root=null;
//     }
//     public void Inorder(BinaryTreeNode node)
//     {
//         if(node != null)
//         {
//             Inorder(node.Left);
//             Console.Write(node.Value+" ");
//             Inorder(node.Right);
//         }
//     }

//     public void Preorder(BinaryTreeNode node)
//     {
//         if (node != null)
//         {
//             Console.Write(node.Value+" ");
//             Preorder(node.Left);
//             Preorder(node.Right);
//         }
//     }
//     public void PostOrder(BinaryTreeNode node)
//     {
//         if(node != null)
//         {
//             PostOrder(node.Left);
//             PostOrder(node.Right);
//             Console.WriteLine(node.Value+" ");
//         }
//     }


// }
// public class Program
// {
//     public static void Main(string[] args)
//     {
//         BinaryTree bt=new BinaryTree();
//         bt.Root=new BinaryTreeNode(1);
//         bt.Root.Left=new BinaryTreeNode(2);
//         bt.Root.Right=new BinaryTreeNode(3);
//         bt.Root.Left.Left=new BinaryTreeNode(4);
//         Console.Write("Inorder: ");
//         bt.Inorder(bt.Root);
//         Console.WriteLine();
//     }
// }