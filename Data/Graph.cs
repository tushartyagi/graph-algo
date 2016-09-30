using System;
using System.Collections.Generic;
using Graphs.Algorithms;

namespace Graphs.Data
{
    public class Vertex {

        public Vertex (string name, bool visited=false) {
            Name = name;
            Visited = visited;
        }
        public bool Visited {get; set;}
        public int StartTime {get; set;}
        public int StopTime {get; set;}
        public string Name {get; set;}

        public override int GetHashCode() {
            if (Name == null) return 0;
            return Name.GetHashCode();
        }

        public override bool Equals(object obj) {
            Vertex other = obj as Vertex;
            return other != null && other.Name == this.Name;
        }

    }

    public class Edge {

        public Edge(Vertex v1, Vertex v2) {
            Vertex1 = v1;
            Vertex2 = v2;
        }
        public Vertex Vertex1 {get; set;}
        public Vertex Vertex2 {get; set;}

        public Edge Reverse() {
            // Create new Vertices so these are initialised to unvisited.
            var v2 = new Vertex(Vertex2.Name);
            var v1 = new Vertex(Vertex1.Name);
            return new Edge(v2, v1);
        }
    }

    public abstract class Graph {
        public abstract Graph Add (Vertex v);
        public abstract Graph Add (Edge e);
        public abstract bool Contains(Vertex v);
        public abstract bool Contains(Edge e);

        public abstract IEnumerable<Vertex> GetNeighbours(Vertex v);

        public abstract IEnumerable<Vertex> GetVertices();

        public abstract IEnumerable<Edge> GetEdges();

        public abstract IEnumerable<IEnumerable<Vertex>> ConnectedComponents();

        public abstract Graph Reverse();

    }

    //TODO: Assuming this to be undirected graph, make this generic and 
    // create a specialised subclass

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

    }

    public class UndirectedAdjListGraph : AdjListGraph {
        
        override public Graph Add (Edge e) {
            // This needs to add both the vertices in the adjList
            Vertex vertex1 = e.Vertex1,
                vertex2 = e.Vertex2;

            if (VertexList.ContainsKey(vertex1)) {
                VertexList[vertex1].Add(vertex2);
            } 
            else {
                VertexList.Add(vertex1, new List<Vertex>{ vertex2 });
            }

            if (VertexList.ContainsKey(vertex2)) {
                VertexList[vertex2].Add(vertex1);
            } 
            else {
                VertexList.Add(vertex2, new List<Vertex>{ vertex1 });
            }

            return this;
        }

        override public bool Contains(Edge e) {
            if (this.Contains(e.Vertex1)) {
              List<Vertex> vertices; 
              var found = VertexList.TryGetValue(e.Vertex1, out vertices);
              if (found) {
                 return vertices.Contains(e.Vertex2);
              }
            } 
            else if (this.Contains(e.Vertex2)) {
              List<Vertex> vertices; 
              var found = VertexList.TryGetValue(e.Vertex2, out vertices);
              if (found) {
                 return vertices.Contains(e.Vertex1);
              }
            }
            return false;
        }

        override public IEnumerable<IEnumerable<Vertex>> ConnectedComponents() {
            var components = new List<List<Vertex>>();
            var dfs = new DFS(this);
            List<Vertex> innerList = new List<Vertex>();

            dfs.PostStartPreExploredVertexDelegate += (_) => { 
                innerList = new List<Vertex>();
            };
            
            dfs.PreExploredVertexDelegate += (v) => {
                innerList.Add(v);
            };

            dfs.PostStartPostExploredVertexDelegate += (_) => {
                components.Add(innerList);
            };

            dfs.Start();

            return components;
        }

        override public Graph Reverse() {
            return this;
        }
    }

    public class DirectedAdjListGraph : AdjListGraph {

        override public Graph Add (Edge e) {
            // This needs to add only this edge in the list, not the reverse
            Vertex vertex1 = e.Vertex1,
                vertex2 = e.Vertex2;

            if (VertexList.ContainsKey(vertex1)) {
                VertexList[vertex1].Add(vertex2);
            } 
            else {
                VertexList.Add(vertex1, new List<Vertex>{ vertex2 });
            }

            return this;
        }


        override public bool Contains(Edge e) {
            if (this.Contains(e.Vertex1)) {
              List<Vertex> vertices; 
              var found = VertexList.TryGetValue(e.Vertex1, out vertices);
              if (found) {
                 return vertices.Contains(e.Vertex2);
              }
            } 
            return false;
        }

        override public IEnumerable<IEnumerable<Vertex>> ConnectedComponents() {

            return new List<List<Vertex>>();
        }

        override public Graph Reverse() {
            Graph clone = new DirectedAdjListGraph();
            foreach (var edge in this.GetEdges())
            {
                clone.Add(edge.Reverse());
            }
            return clone;
        }
    }

    public class AdjMatrixGraph : Graph {
        //TODO: Change this to a matrix
        public Dictionary<Vertex, List<Vertex>> adjList;

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
    }
}
