using System.Collections.Generic;
using Graphs.Algorithms;

namespace Graphs.Data {

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
            int componentCount = 0;  // Not 0 indexed; Value starts from 1 below.

            dfs.PostStartPreExploredVertexDelegate += (_) => { 
                innerList = new List<Vertex>();
                componentCount += 1;
            };
            
            dfs.PreExploredVertexDelegate += (v) => {
                v.Component = componentCount;
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
}