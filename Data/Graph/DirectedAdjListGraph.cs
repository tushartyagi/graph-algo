using System.Collections.Generic;
using Graphs.Algorithms;

namespace Graphs.Data {
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

            // The second vertex also needs to be added to the adjList,
            // because even if the edge is directed, the vertex needs to
            // be present in the list for the record.
            // AB will add both A -> B and B -> {} in the list for 
            // recording.
            if (!VertexList.ContainsKey(vertex2)) {
                VertexList.Add(vertex2, new List<Vertex>());
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

        private void Assign(Vertex v, Vertex root, IEnumerable<IEnumerable<Vertex>> components) {

        }

        /* This is a 3 step algo:
            1. Do a DFS of the graph to give postorder timings to each node.
            2. Reverse the graph.
            3. From the order found in step 1, start doing a DFS/Exploration 
            of the reversed graph. Each vertex which can be visited from a 
            given one belong to the same SCC.
        */
        override public IEnumerable<IEnumerable<Vertex>> ConnectedComponents() {
            var components = new List<List<Vertex>>();
            var currentComponent = 0; // Seed value.
            List<Vertex> innerList = new List<Vertex>();

            
            // Step 1. Topological sort runs a DFS and arranges the nodes 
            // in postorder.
            var topologicalSort = new TopologicalSort(this);
            var topologicalVertices = topologicalSort.Sort();
            
            // Step 2. Prepare the reversed graph to collect vertices in teh 
            // same SCC.
            var reversed = this.Reverse();
            var exploringDFS = new DFS(reversed);
            exploringDFS.PostExploredVertexDelegate = (v) => {
                v.Component = currentComponent;
                innerList.Add(v);
            };

            // Step 3
            foreach (var topologicalVertex in topologicalVertices)
            {
                innerList = new List<Vertex>();
                var vertexInGraph = reversed.GetVertexById(topologicalVertex.Name);
                if (!vertexInGraph.Visited) {
                    currentComponent += 1;
                    vertexInGraph.Component = currentComponent;
                    innerList.Add(vertexInGraph);

                    exploringDFS.Explore(vertexInGraph);
                    components.Add(innerList);
                }
            }

            return components;
        }

        override public Graph Reverse() {
            Graph reversed = new DirectedAdjListGraph();
            foreach (var edge in this.GetEdges())
            {
                reversed.Add(edge.Reverse());
            }
            reversed.ClearVisited();
            return reversed;
        }
    }
}