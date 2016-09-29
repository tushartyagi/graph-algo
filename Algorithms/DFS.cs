using System;
using Graphs.Data;

namespace Graphs.Algorithms
{
    public class DFS
    {
        public delegate void ProcessVertexDelegate(Vertex v);
        private void DoNothing(Vertex v) {}
        public Graph DFSGraph {get; set;}
        public ProcessVertexDelegate PreStartVertexDelegate {get; set;}
        public ProcessVertexDelegate PostStartVertexDelegate {get; set;}    
        public ProcessVertexDelegate PreExploredVertexDelegate {get; set;}
        public ProcessVertexDelegate PostExploredVertexDelegate {get; set;}
        public ProcessVertexDelegate PostStartPreExploredVertexDelegate {get; set;}
        public ProcessVertexDelegate PostStartPostExploredVertexDelegate {get; set;}

        public DFS(Graph g) {
            DFSGraph = g;
            PreStartVertexDelegate = DoNothing;
            PostStartVertexDelegate = DoNothing;
            PreExploredVertexDelegate = DoNothing;
            PostExploredVertexDelegate = DoNothing;
            PostStartPostExploredVertexDelegate = DoNothing;
            PostStartPreExploredVertexDelegate = DoNothing;
        }

        public void Explore(Vertex s)
        {
            s.Visited = true;
            var neighbours = DFSGraph.GetNeighbours(s);
            foreach(var neighbour in neighbours) {
                if (!neighbour.Visited) {
                    PreExploredVertexDelegate(neighbour);
                    Explore(neighbour);
                    PostExploredVertexDelegate(neighbour);
                }
            }
        }

        public void Start(Vertex s)
        {
            Init();
            var neighbours = DFSGraph.GetNeighbours(s);
            PreStartVertexDelegate(s);
            s.Visited = true;
            foreach(var neighbour in neighbours) {
                if (!neighbour.Visited) {
                    PreExploredVertexDelegate(neighbour);
                    PostStartPreExploredVertexDelegate(neighbour);
                    Explore(neighbour);
                    PostExploredVertexDelegate(neighbour);
                    PostStartPostExploredVertexDelegate(neighbour);
                }
            }
            PostStartVertexDelegate(s);
        }

        // Marks every node as Unvisited.
        // TODO: Make this generic; allow passing in of a delegate
        public void Init()
        {
            // Do nothing right now. Just imagine that each node 
            // has already been marked unvisited (because we mark 
            // it that way during construction).
        }
    }
}
