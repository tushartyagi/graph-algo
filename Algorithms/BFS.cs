using System.Collections.Generic;
using Graphs.Data;

namespace Graphs.Algorithms {

    public class BFS {

        public Graph BFSGraph {get; private set;}
        private Queue<Vertex> q = new Queue<Vertex>();
        private int _distance = 0;
        public int Distance {
            get {
                _distance += 1;
                return _distance;
            }
        }

        public BFS(Graph g) {
            BFSGraph = g;
        }

        private void Init() {
            BFSGraph.Init((v) => {
                v.Distance = -1;
                v.Color = Color.White;
                v.Previous = null;
            });
        }

        public void Start(Vertex v) {
            Init();

            v.Distance = 0;
            v.Color = Color.Grey;
            v.Previous = null;
            q.Enqueue(v);

            while (q.Count > 0) {
                var node = q.Dequeue();
                
                foreach (var neighbour in BFSGraph.GetNeighbours(node)) {
                    if (neighbour.Color == Color.White) { // Another way to check if this has been visited.
                        neighbour.Previous = node;
                        neighbour.Distance = node.Distance + 1;
                        neighbour.Color = Color.Grey;
                        q.Enqueue(neighbour);
                    }
                }
                node.Color = Color.Black;
                node.Visited = true;  // We don't really need this. Move this to an interface or something.
            }
        }
    }
}