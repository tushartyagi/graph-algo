using System.Collections.Generic;
using Graphs.Structures;

namespace Graphs.Algorithms {

    public class ShortestPath {
        public Graph ShortestPathGraph;
        public ShortestPath(Graph g) {
            ShortestPathGraph = g;
        }

        public IEnumerable<Vertex> Path(Vertex source, Vertex destination) {
            // Create the Shortest Path "Tree"
            var BFS = new BFS(ShortestPathGraph);
            BFS.Start(source);

            var path = new List<Vertex>();

            while (destination != source) {
                path.Add(destination);
                destination = destination.Previous;
            }

            path.Reverse();
            return path;
        }
    }

}