using System;

namespace tushartyagi.graphs
{
    public static class DFS
    {

        public static void Explore(Graph g, Vertex s)
        {
            s.Visited = true;
            var neighbours = g.GetNeighbours(s);
            foreach(var neighbour in neighbours) {
                if (!neighbour.Visited) {
                    Explore(g, neighbour);
                }
            }
        }

        public static void Search(Graph g, Vertex s)
        {
            Init(g);
            var neighbours = g.GetNeighbours(s);
            s.Visited = true;
            foreach(var neighbour in neighbours) {
                if (!neighbour.Visited) {
                    Explore(g, neighbour);
                }
            }
        }

        // Marks every node as Unvisited.
        // TODO: Make this generic; allow passing in of a delegate
        public static void Init(Graph g)
        {
            // Do nothing right now. Just imagine that each node 
            // has already been marked unvisited (because we mark 
            // it that way during construction).
        }
    }
}