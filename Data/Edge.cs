namespace Graphs.Data {
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
}