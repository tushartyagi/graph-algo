using System.Collections.Generic;

namespace Data.Structures {
    public interface IHeap<T> where T : IComparer<T> {
        void Comparer();
        T Extract();
        void Insert(T element);
    }

    public interface IPriorityQueue {
        int Priority {get; set;}
    }
}