using System.Collections.Generic;
using Math=System.Math;
using Convert=System.Convert;

namespace Data.Structures {
    /* PriorityQueue: This internally uses a list/array of elements and 
    satisfies the min heap property: A[Parent(i)] <= A[i].
    The smallest element of the heap is at the root, so O(1) access time.

    */
    public class PriorityQueue<T> where T : System.IComparable<T> {

        private T _min;
        private List<T> _elements = new List<T>();
        private int Parent(int i) {
            return (int)Math.Floor((double)i / 2);
        }
        private int Right(int i) {
            return 2 * i;
        }
        private int Left(int i) {
            return 2 * i - 1;
        }

        public T ExtractMin() {
            return _min;
        }
        
        public void Add(T element) {

        }

        private void Exchange(int from, int to) {
            var temp = _elements[from];
            _elements[from] = _elements[from];
            _elements[to] = temp;
        }

        /* Maintain the heapify property. If either of the children is greater than 
        the parent, then exchange the parent and recursively repeat the procedure down. 
        */
        private void Heapify(int i) {
            if (_elements[i].CompareTo(_elements[Left(i)]) > 0) {
                Exchange(i, Left(i));
                Heapify(Left(i));
            }
            else if (_elements[i].CompareTo(_elements[Right(i)]) > 0) {
                Exchange(i, Right(i));
                Heapify(Right(i));
            }
        }

        public T Min() {
            return _min;
        }

        public void ChangePriority(T element, int priority) {

        }

    }
}