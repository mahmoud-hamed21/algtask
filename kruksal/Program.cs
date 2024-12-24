using System;
using System.Collections.Generic;
using System.Linq;

class KruskalAlgorithm
{
    // Edge structure to represent graph edges
    public class Edge : IComparable<Edge>
    {
        public int Source, Destination, Weight;

        public int CompareTo(Edge other)
        {
            return this.Weight.CompareTo(other.Weight);
        }
    }

    // Disjoint Set (Union-Find) structure
    public class UnionFind
    {
        private int[] parent, rank;

        public UnionFind(int size)
        {
            parent = new int[size];
            rank = new int[size];
            for (int i = 0; i < size; i++)
            {
                parent[i] = i;
                rank[i] = 0;
            }
        }

        // Find operation with path compression
        public int Find(int node)
        {
            if (parent[node] != node)
                parent[node] = Find(parent[node]);
            return parent[node];
        }

        // Union operation by rank
        public void Union(int x, int y)
        {
            int rootX = Find(x);
            int rootY = Find(y);

            if (rootX != rootY)
            {
                if (rank[rootX] < rank[rootY])
                    parent[rootX] = rootY;
                else if (rank[rootX] > rank[rootY])
                    parent[rootY] = rootX;
                else
                {
                    parent[rootY] = rootX;
                    rank[rootX]++;
                }
            }
        }
    }

    // Kruskal's Algorithm
    public static List<Edge> KruskalMST(List<Edge> edges, int vertices)
    {
        // Sort edges by weight
        edges.Sort();

        UnionFind uf = new UnionFind(vertices);
        List<Edge> mst = new List<Edge>();

        foreach (Edge edge in edges)
        {
            int root1 = uf.Find(edge.Source);
            int root2 = uf.Find(edge.Destination);

            // If adding this edge does not form a cycle
            if (root1 != root2)
            {
                mst.Add(edge);
                uf.Union(root1, root2);
            }

            // Stop if MST contains V-1 edges
            if (mst.Count == vertices - 1)
                break;
        }

        return mst;
    }

    // Main Method to Test Kruskal's Algorithm
    static void Main(string[] args)
    {
        int vertices = 4;
        List<Edge> edges = new List<Edge>
        {
            new Edge { Source = 0, Destination = 1, Weight = 10 },
            new Edge { Source = 0, Destination = 2, Weight = 6 },
            new Edge { Source = 0, Destination = 3, Weight = 5 },
            new Edge { Source = 1, Destination = 3, Weight = 15 },
            new Edge { Source = 2, Destination = 3, Weight = 4 }
        };

        List<Edge> mst = KruskalMST(edges, vertices);

        Console.WriteLine("Edges in the Minimum Spanning Tree:");
        foreach (var edge in mst)
        {
            Console.WriteLine($"{edge.Source} -- {edge.Destination} == {edge.Weight}");
        }
    }
}
