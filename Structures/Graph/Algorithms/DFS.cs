using System;
using Graphs.Structures;

namespace Graphs.Algorithms
{
    public class DFS
    {
#region Declarations
        private class Timer {
            private int _timeStamp = 0;

            private void Tick() { 
                _timeStamp += 1;
            }

            public int CurrentTime() {
                Tick();
                return _timeStamp;
            }
        }


        private Timer _timer = new Timer();

        public delegate void ProcessDFSDelegate();
        public delegate void ProcessVertexDelegate(Vertex v);
        private void DoNothing() {}
        private void DoNothing(Vertex v) {}
        public Graph DFSGraph {get; set;}
        public ProcessDFSDelegate PreStartDelegate {get; set;}
        public ProcessDFSDelegate PostStartDelegate {get; set;}    
        public ProcessVertexDelegate PreExploredVertexDelegate {get; set;}
        public ProcessVertexDelegate PostExploredVertexDelegate {get; set;}
        public ProcessVertexDelegate PostStartPreExploredVertexDelegate {get; set;}
        public ProcessVertexDelegate PostStartPostExploredVertexDelegate {get; set;}

        private void UpdateStartTime(Vertex v) {
            v.StartTime = _timer.CurrentTime();
        }

        private void UpdateStopTime(Vertex v) {
            v.StopTime = _timer.CurrentTime();
        }
#endregion

        public DFS(Graph g) {
            DFSGraph = g;
            PreStartDelegate = DoNothing;
            PostStartDelegate = DoNothing;
            PreExploredVertexDelegate += UpdateStartTime;
            PostExploredVertexDelegate += UpdateStopTime;
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
                    neighbour.Visited = true;
                    PostExploredVertexDelegate(neighbour);
                }
            }
        }

        public void Start()
        {
            Init();
            var vertices = DFSGraph.GetVertices();
            PreStartDelegate();
            foreach(var vertex in vertices) {
                if (!vertex.Visited) {
                    PostStartPreExploredVertexDelegate(vertex);
                    PreExploredVertexDelegate(vertex);
                    Explore(vertex);
                    vertex.Visited = true;
                    PostExploredVertexDelegate(vertex);
                    PostStartPostExploredVertexDelegate(vertex);
                }
            }
            PostStartDelegate();
        }

        public void Init()
        {
            DFSGraph.Init((v) => {
                v.Visited = false;
            });
        }
    }
}
