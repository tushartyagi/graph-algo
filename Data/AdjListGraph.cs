using System.Collections.Generic;

namespace Graphs.Data {
    public abstract class AdjListGraph : Graph {
        private Dictionary<Vertex, List<Vertex>> adjList =
            new Dictionary<Vertex, List<Vertex>>();
        
        public Dictionary<Vertex, List<Vertex>> VertexList {
            get {
                return adjList;
            }
        }

        override public IEnumerable<Vertex> GetNeighbours(Vertex v) {
            if (VertexList.ContainsKey(v)) {
                return VertexList[v];
            }
            else {
                return new List<Vertex>();
            }
        }

        override public IEnumerable<Vertex> GetVertices() {
            return VertexList.Keys;
        }
        
        override public IEnumerable<Edge> GetEdges() {
            var edges = new HashSet<Edge>();
            foreach (var vertex in GetVertices()) {
               foreach (var neighbour in GetNeighbours(vertex)) {
                   edges.Add(new Edge(vertex, neighbour));
               } 
            }
            return edges;
        }

        override public Graph Add (Vertex v) {
            VertexList.Add(v, new List<Vertex>());
            return this;
        }

        override public bool Contains(Vertex v) {
            return VertexList.ContainsKey(v);
        }

        override public void ClearVisited() {
            foreach (var vertex in GetVertices()) {
                vertex.Visited = false;
                foreach (var neighbour in GetNeighbours(vertex)) {
                    neighbour.Visited = false;
                }
            }
        }

    }
}