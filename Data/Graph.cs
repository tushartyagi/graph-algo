using System.Collections.Generic;

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
    }

    public class Edge {

        public Edge(Vertex v1, Vertex v2) {
            Vertex1 = v1;
            Vertex2 = v2;
        }
        public Vertex Vertex1 {get; set;}
        public Vertex Vertex2 {get; set;}
    }

    public abstract class Graph {
        public abstract Graph Add (Vertex v);
        public abstract Graph Add (Edge e);
        public abstract bool Contains(Vertex v);
        public abstract bool Contains(Edge e);

        public abstract IEnumerable<Vertex> GetNeighbours(Vertex v);

        public abstract IEnumerable<Vertex> GetVertices();

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
    }
}
