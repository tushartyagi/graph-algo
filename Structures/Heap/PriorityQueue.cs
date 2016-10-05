using System.Collections.Generic;
using Math=System.Math;
using System;

namespace Data.Structures {
    /* 
    PriorityQueue: This internally uses a list/array of elements and 
    satisfies the min heap property: A[Parent(i)] <= A[i].
    The smallest element of the heap is at the root, so O(1) access time.
    */
    public class PriorityQueue<T> where T: IComparable<T>, IEquatable<T> {

        private List<T> _elements = new List<T>();

        public PriorityQueue() { }
        public PriorityQueue(List<T> elements) {
            foreach (var element in elements)
            {
                Insert(element);
            }
        }

        public T this[int i] {
            get {
                return _elements[i];
            }
            private set {
                _elements[i] = value;
            }
        }
        public T Min {
            get {
                return this[0];
            }
        }
        private int Parent(int i) {
            if (i > Count) {
                throw new ArgumentOutOfRangeException("i");
            }
            return (int)Math.Floor((double)i / 2);
        }
        private int Right(int i) {
            if (i > Count) {
                throw new ArgumentOutOfRangeException("i");
            }
            return 2 * i + 2;
        }
        private int Left(int i) {
            if (i > Count) {
                throw new ArgumentOutOfRangeException("i");
            }
            return 2 * i + 1;
        }
        public int Count {
            get {
                return _elements.Count;
            }
        }
        public T ExtractMin() {
            var min = _elements[0];
            var last = _elements[Count - 1];
            _elements.RemoveAt(0);
            _elements.RemoveAt(Count - 1);
            _elements.Insert(0, last);
            SiftDown(0);
            return min;
        }
        
        public void Insert(T element) {
            _elements.Add(element);
            var elementPos = Count - 1;
            BubbleUp(elementPos);
        }

        public void Update(T element, T newElement) {
            var pos = Position(element);
            _elements.RemoveAt(pos);
            Insert(newElement);
        }

        private int Position(T element) {
            var pos = 0;
            foreach(var e in _elements) {
                if (e.Equals(element)) {
                    return pos;
                }
                pos += 1;
            }
            throw new Exception("Element not found");
        }

        // If the child is less than the parent, then exchange the 
        // parent and child and repeat the procedure for the new parent.
        private void BubbleUp(int position) {
            var parentPos = Parent(position);
            if (parentPos >= 0 && this[position].CompareTo(this[parentPos]) < 0) {
                Exchange(position, parentPos);
                BubbleUp(parentPos);
            }
        }

        private void Exchange(int from, int to) {
            var temp = this[from];
            this[from] = this[to];
            this[to] = temp;
        }

        private void SiftDown(int position) {
            int left = Left(position),
                right = Right(position);

            if (left < Count && this[position].CompareTo(this[left]) > 0) {
                Exchange(left, position);
                SiftDown(left);
            }
            if (right < Count && this[position].CompareTo(this[right]) > 0) {
                Exchange(right, position);
                SiftDown(right);
            }
        }
    }
}