using System.Collections.Generic;
using System;

namespace Graphs.Structures {
    public abstract class AdjListGraph : Graph {
        private Dictionary<Vertex, List<Vertex>> adjList =
            new Dictionary<Vertex, List<Vertex>>();

        override public void Init(Action<Vertex> f) {
            foreach (var vertex in this.GetVertices()) {
                foreach (var neighbour in this.GetNeighbours(vertex)) {
                    f(neighbour);
                }
            }
        }

        public Dictionary<Vertex, List<Vertex>> VertexList {
            get {
                return adjList;
            }
        }

        override public Graph Add(List<Edge> edges) {
            foreach(var edge in edges) {
                this.Add(edge);
            }
            return this;
        } 

       override public Vertex GetVertexById(string id) {
            foreach (var vertex in VertexList.Keys) {
                if (vertex.Name == id)
                    return vertex;
            }
            throw new System.Exception("Element not found: " + id);
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