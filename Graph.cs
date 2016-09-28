public class Vertex {
    public Boolean Visited {get; set;}
    public String Name {get; set;}
}

public class Edge {
    public Vertex Vertex1 {get; set;}
    public Vertex Vertex2 {get; set;}
}

public abstract class Graph {

}

public class AdjListGraph : Graph {

}