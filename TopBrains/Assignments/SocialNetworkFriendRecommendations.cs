using System;
using System.Collections.Generic;

class Program
{
    static Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();

    static void AddEdge(int u, int v)
    {
        graph[u].Add(v);
        graph[v].Add(u);
    }

    static bool IsConnected(int start, int target)
    {
        Queue<int> q = new Queue<int>();
        bool[] visited = new bool[6];

        q.Enqueue(start);
        visited[start] = true;

        while (q.Count > 0)
        {
            int node = q.Dequeue();

            if (node == target)
                return true;

            foreach (int neighbor in graph[node])
            {
                if (!visited[neighbor])
                {
                    visited[neighbor] = true;
                    q.Enqueue(neighbor);
                }
            }
        }

        return false;
    }

    static List<int> ShortestPath(int start, int target)
    {
        Queue<int> q = new Queue<int>();
        bool[] visited = new bool[6];
        int[] parent = new int[6];

        for (int i = 0; i < 6; i++)
            parent[i] = -1;

        q.Enqueue(start);
        visited[start] = true;

        while (q.Count > 0)
        {
            int node = q.Dequeue();

            foreach (int neighbor in graph[node])
            {
                if (!visited[neighbor])
                {
                    visited[neighbor] = true;
                    parent[neighbor] = node;
                    q.Enqueue(neighbor);
                }
            }
        }

        List<int> path = new List<int>();

        if (!visited[target])
            return path;

        for (int v = target; v != -1; v = parent[v])
            path.Add(v);

        path.Reverse();
        return path;
    }

    static List<int> Distance2Users(int start)
    {
        Queue<int> q = new Queue<int>();
        bool[] visited = new bool[6];
        int[] distance = new int[6];

        q.Enqueue(start);
        visited[start] = true;

        while (q.Count > 0)
        {
            int node = q.Dequeue();

            foreach (int neighbor in graph[node])
            {
                if (!visited[neighbor])
                {
                    visited[neighbor] = true;
                    distance[neighbor] = distance[node] + 1;
                    q.Enqueue(neighbor);
                }
            }
        }

        List<int> result = new List<int>();

        for (int i = 0; i < 6; i++)
        {
            if (distance[i] == 2)
                result.Add(i);
        }

        return result;
    }

    static bool HasCycleDFS(int node, int parent, bool[] visited)
    {
        visited[node] = true;

        foreach (int neighbor in graph[node])
        {
            if (!visited[neighbor])
            {
                if (HasCycleDFS(neighbor, node, visited))
                    return true;
            }
            else if (neighbor != parent)
            {
                return true;
            }
        }

        return false;
    }

    static bool HasCycle()
    {
        bool[] visited = new bool[6];

        for (int i = 0; i < 6; i++)
        {
            if (!visited[i])
            {
                if (HasCycleDFS(i, -1, visited))
                    return true;
            }
        }

        return false;
    }

    static void ConnectedComponents()
    {
        bool[] visited = new bool[6];

        for (int i = 0; i < 6; i++)
        {
            if (!visited[i])
            {
                Queue<int> q = new Queue<int>();
                q.Enqueue(i);
                visited[i] = true;

                Console.Write("Group: ");

                while (q.Count > 0)
                {
                    int node = q.Dequeue();
                    Console.Write(node + " ");

                    foreach (int neighbor in graph[node])
                    {
                        if (!visited[neighbor])
                        {
                            visited[neighbor] = true;
                            q.Enqueue(neighbor);
                        }
                    }
                }

                Console.WriteLine();
            }
        }
    }

    static void Main()
    {
        for (int i = 0; i < 6; i++)
            graph[i] = new List<int>();

        AddEdge(0, 1);
        AddEdge(0, 2);
        AddEdge(1, 3);
        AddEdge(2, 3);
        AddEdge(2, 4);
        AddEdge(3, 5);
        AddEdge(4, 5);

        Console.WriteLine("Friends of User 2:");
        foreach (int friend in graph[2])
            Console.Write(friend + " ");
        Console.WriteLine();

        Console.WriteLine("0 and 5 Connected: " + IsConnected(0, 5));

        List<int> path = ShortestPath(0, 5);
        Console.Write("Shortest Path: ");
        foreach (int node in path)
            Console.Write(node + " ");
        Console.WriteLine();

        List<int> users = Distance2Users(1);
        Console.Write("Distance 2 from User 1: ");
        foreach (int user in users)
            Console.Write(user + " ");
        Console.WriteLine();

        Console.WriteLine("Cycle Exists: " + HasCycle());

        Console.WriteLine("Connected Components:");
        ConnectedComponents();
    }
}