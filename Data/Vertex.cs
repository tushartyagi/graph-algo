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
        public int Component {get; set;}  

        public override int GetHashCode() {
            if (Name == null) return 0;
            return Name.GetHashCode();
        }

        public override bool Equals(object obj) {
            Vertex other = obj as Vertex;
            return other != null && other.Name == this.Name;
        }

    }
}