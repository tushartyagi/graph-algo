using System;
using System.Collections.Generic;
using Graphs.Data;

namespace Graphs.Algorithms {
    public class TopologicalSort {
        // Add the node to the front of a linked list as part 
        // of the postExplore hook.
        public List<Vertex> Vertices = new List<Vertex>();
        public Graph DFSGraph;

        public TopologicalSort(Graph g) {
            DFSGraph = g;
        }

        private void AppendToList(Vertex v) {
            Vertices.Insert(0, v);
        }
        
        public IEnumerable<Vertex> Sort() {
            var dfs = new DFS(DFSGraph);
            dfs.PostExploredVertexDelegate += AppendToList;
            dfs.Start();
            return Vertices;
        }
    }
}