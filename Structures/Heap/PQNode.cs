using System;

namespace Data.Structures {

    public interface IPQNode<T> {

        T Node {get; set;}
        int Priority {get; set;}
    }

    public class PQNode<T> : IPQNode<T>, IComparable<PQNode<T>>, IEquatable<PQNode<T>>{
        public T Node {get; set;}
        public int Priority {get; set;}
        public PQNode(T node, int priority) {
            Node = node;
            Priority = priority;
        }

        public bool Equals (PQNode<T> other)
        {   
            if (other == null || GetType() != other.GetType())
            {
                return false;
            }
            
            return Node.Equals(other.Node);
        }
        
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        
        public int CompareTo(PQNode<T> other) {
            return Priority.CompareTo(other.Priority);
        }
    }
}