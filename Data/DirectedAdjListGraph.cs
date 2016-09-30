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
            var reversed = this.Reverse();
            var dfsOfReverse = new DFS(reversed);
            dfsOfReverse.Start();
            
            var topologicalSort = new TopologicalSort(reversed);
            var reversedPostList = topologicalSort.Sort();
            var currentComponent = 0; // Seed value.
            var components = new List<List<Vertex>>();
            List<Vertex> innerList = new List<Vertex>();

            var exploringDFS = new DFS(this);
            exploringDFS.PostExploredVertexDelegate = (v) => {
                v.Component = currentComponent;
                innerList.Add(v);
            };

            // TopologicalSort has marked all the nodes as visited, but 
            // below we need this flag to be unset for all nodes.
            this.ClearVisited();
            foreach(var vertex in reversedPostList) vertex.Visited = false;

            foreach (var vertex in reversedPostList)
            {
                innerList = new List<Vertex>();
                if (!vertex.Visited) {
                    currentComponent += 1;
                    exploringDFS.Explore(vertex);
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
            return reversed;
        }
    }
}