using System;
using System.Collections.Generic;

class CoursePrerequisiteSystem
{
    static int V = 6;
    static List<int>[] graph = new List<int>[6];
    static List<int>[] reverseGraph = new List<int>[6];

    static void Main()
    {
        
        for (int i = 0; i < V; i++)
        {
            graph[i] = new List<int>();
            reverseGraph[i] = new List<int>();
        }

        
        AddEdge(0, 1); 
        AddEdge(0, 2); 
        AddEdge(1, 3); 
        AddEdge(2, 3); 
        AddEdge(2, 4); 
        AddEdge(3, 5);
        AddEdge(4, 5); 

        
        HashSet<int> prerequisites = GetAllPrerequisites(5);
        Console.WriteLine("All prerequisites of Course 5:");
        foreach (int course in prerequisites)
            Console.Write(course + " ");
        Console.WriteLine();

        Console.WriteLine("\nDirect prerequisites of Course 3:");
        foreach (int prereq in reverseGraph[3])
            Console.Write(prereq + " ");
        Console.WriteLine();

        
        bool hasCycle = HasCycle();
        Console.WriteLine("\nCycle Present: " + hasCycle);

        
        if (!hasCycle)
        {
            List<int> order = TopologicalSort();

            Console.WriteLine("\nTopological Order:");
            foreach (int course in order)
                Console.Write(course + " ");
            Console.WriteLine();
        }

        
        List<int> noPrereq = GetCoursesWithNoPrerequisites();

        Console.WriteLine("\nCourses with no prerequisites:");
        foreach (int course in noPrereq)
            Console.Write(course + " ");
        Console.WriteLine();

      
        Console.WriteLine("\nCourses directly depending on Course 2:");
        foreach (int course in graph[2])
            Console.Write(course + " ");
        Console.WriteLine();

        Console.WriteLine("Count: " + graph[2].Count);
    }

    static void AddEdge(int prerequisite, int course)
    {
        graph[prerequisite].Add(course);
        reverseGraph[course].Add(prerequisite);
    }

    
    static HashSet<int> GetAllPrerequisites(int course)
    {
        HashSet<int> visited = new HashSet<int>();
        DFSPrerequisites(course, visited);
        return visited;
    }

    static void DFSPrerequisites(int course, HashSet<int> visited)
    {
        foreach (int prereq in reverseGraph[course])
        {
            if (!visited.Contains(prereq))
            {
                visited.Add(prereq);
                DFSPrerequisites(prereq, visited);
            }
        }
    }

    
    static bool HasCycle()
    {
        bool[] visited = new bool[V];
        bool[] recStack = new bool[V];

        for (int i = 0; i < V; i++)
        {
            if (!visited[i])
            {
                if (DFSCycle(i, visited, recStack))
                    return true;
            }
        }

        return false;
    }

    static bool DFSCycle(int node, bool[] visited, bool[] recStack)
    {
        visited[node] = true;
        recStack[node] = true;

        foreach (int neighbor in graph[node])
        {
            if (!visited[neighbor])
            {
                if (DFSCycle(neighbor, visited, recStack))
                    return true;
            }
            else if (recStack[neighbor])
            {
                return true;
            }
        }

        recStack[node] = false;
        return false;
    }

  
    static List<int> TopologicalSort()
    {
        int[] indegree = new int[V];

        for (int i = 0; i < V; i++)
        {
            foreach (int neighbor in graph[i])
            {
                indegree[neighbor]++;
            }
        }

       
        int[] queue = new int[V];
        int front = 0;
        int rear = 0;

       
        for (int i = 0; i < V; i++)
        {
            if (indegree[i] == 0)
            {
                queue[rear] = i;
                rear++;
            }
        }

        List<int> result = new List<int>();

        while (front < rear)
        {
            int current = queue[front];
            front++;

            result.Add(current);

            foreach (int neighbor in graph[current])
            {
                indegree[neighbor]--;

                if (indegree[neighbor] == 0)
                {
                    queue[rear] = neighbor;
                    rear++;
                }
            }
        }

        return result;
    }

   
    static List<int> GetCoursesWithNoPrerequisites()
    {
        int[] indegree = new int[V];

        for (int i = 0; i < V; i++)
        {
            foreach (int neighbor in graph[i])
            {
                indegree[neighbor]++;
            }
        }

        List<int> result = new List<int>();

        for (int i = 0; i < V; i++)
        {
            if (indegree[i] == 0)
                result.Add(i);
        }

        return result;
    }
}
