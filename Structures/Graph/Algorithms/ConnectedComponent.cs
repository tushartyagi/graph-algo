using System;
using Graphs.Structures;

namespace Graphs.Algorithms {
    public static class ConnectedComponent {

        public static int components = 0;
        public static void IncrementComponents(Vertex v) {
            components += 1;
        }
        
        public static int CountComponents(Graph g) {

            var dfs = new DFS(g);
            dfs.PostStartPostExploredVertexDelegate = IncrementComponents;
            foreach(var vertex in g.GetVertices()) {
                if (!vertex.Visited)
                    dfs.Start();  
            }
            return components;
        }
    }
}