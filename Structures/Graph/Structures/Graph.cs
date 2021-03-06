using System.Collections.Generic;
using System;

namespace Graphs.Structures
{
    public abstract class Graph {
        public abstract void Init(Action<Vertex> function);
        public abstract Vertex GetVertexById (string id);
        public abstract Graph Add (List<Edge> edges);
        public abstract Graph Add (Vertex v);
        public abstract Graph Add (Edge e);
        public abstract bool Contains(Vertex v);
        public abstract bool Contains(Edge e);
        public abstract IEnumerable<Vertex> GetNeighbours(Vertex v);
        public abstract IEnumerable<Vertex> GetVertices();
        public abstract IEnumerable<Edge> GetEdges();
        public abstract IEnumerable<IEnumerable<Vertex>> ConnectedComponents();
        public abstract Graph Reverse();
        public abstract void ClearVisited();

    }
}
