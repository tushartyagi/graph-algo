using System.Collections.Generic;

namespace Graphs.Data {
    public class AdjMatrixGraph : Graph {
        //TODO: Change this to a matrix
        public Dictionary<Vertex, List<Vertex>> adjList;

        override public Vertex GetVertexById(string id) {
            foreach (var vertex in adjList.Keys) {
                if (vertex.Name == id)
                    return vertex;
            }
            throw new System.Exception("Element not found: " + id);
        }

        override public IEnumerable<Vertex> GetNeighbours(Vertex v) {
            return new List<Vertex>();
        }

        override public IEnumerable<Vertex> GetVertices() {
            return new List<Vertex>();
        }

        override public Graph Add (Vertex v) {
            return this;
        }
        override public Graph Add (Edge e) {
            return this;
        }
        override public bool Contains(Vertex v) {
            return true;
        }

        override public bool Contains(Edge e) {
            return true;
        }

        override public IEnumerable<IEnumerable<Vertex>> ConnectedComponents() {
            return new List<List<Vertex>>();
        }

        override public IEnumerable<Edge> GetEdges() {
            return new List<Edge>();
        }

        override public Graph Reverse() {
            return this;
        }

        override public void ClearVisited() {
            
        }
    }
}