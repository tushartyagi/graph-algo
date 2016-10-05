using NUnit.Framework;
using Data.Structures;
using System.Collections.Generic;

namespace Data.Structures.Test {

    [TestFixture]
    public class PriorityQueueTestsForInts {

        private PriorityQueue<int> q = null;

        [SetUp]
        public void Init() {
            q = new PriorityQueue<int>(new List<int>{18, 12, 7});
        }

        [Test]
        public void PriorityQueueAddsTheElementsInOrder() {
            Assert.IsTrue(q.Min == 7);
        }

        [Test]
        public void PriorityQueueAddsNewElementsCorrectly() {
            q.Insert(5);
            Assert.IsTrue(q.Min == 5);
            q.Insert(1);
            Assert.IsTrue(q.Min == 1);
            q.Insert(3);
            Assert.IsTrue(q.Min == 1);
        }

        [Test]
        public void PriorityQueueExtractsTheMinElementCorrectly() {
            var min = q.Min;
            var extracted = q.ExtractMin();
            Assert.IsTrue(min == extracted);
        }

        [Test]
        public void PriorityQueueUpdatesTheMinElementAfterExtractOperation() {
            var _ = q.ExtractMin();
            Assert.IsTrue(q.Min == 12);
        }

    }

[TestFixture]
    public class PriorityQueueTestsForPQNodeInt {

        private PriorityQueue<PQNode<int>> q = null;

        [SetUp]
        public void Init() {
            var list = new List<PQNode<int>>{
                new PQNode<int>(18, 18),
                new PQNode<int>(16, 16),
                new PQNode<int>(12, 12),
                new PQNode<int>(6, 6),
            };

            q = new PriorityQueue<PQNode<int>>(list);
        }

        [Test]
        public void PriorityQueueAddsTheElementsInOrder() {
            Assert.IsTrue(q.Min.Priority == 6);
        }

        [Test]
        public void PriorityQueueAddsNewElementsCorrectly() {
            q.Insert(new PQNode<int>(5, 5));
            Assert.IsTrue(q.Min.Priority == 5);
            q.Insert(new PQNode<int>(1, 1));
            Assert.IsTrue(q.Min.Priority == 1);
            q.Insert(new PQNode<int>(3, 3));
            Assert.IsTrue(q.Min.Priority == 1);
        }

        [Test]
        public void PriorityQueueExtractsTheMinElementCorrectly() {
            var min = q.Min;
            var extracted = q.ExtractMin();
            Assert.IsTrue(min == extracted);
        }

        [Test]
        public void PriorityQueueUpdatesTheMinElementAfterExtractOperation() {
            var _ = q.ExtractMin();
            Assert.IsTrue(q.Min.Priority == 12);
        }

        [Test]
        public void PriorityQueueUpdatesWorkCorrectlyWhenPriorityIsReduced() {
            var min = q.Min;
            var newMin = new PQNode<int>(6, 3); // Changing priority to 3, still min
            q.Update(min, newMin);
            Assert.IsTrue(q.Min.Priority == 3);
        }

        [Test]
        public void PriorityQueueUpdatesWorkCorrectlyWhenPriorityIsIncreased() {
            var min = q.Min;
            var newMin = new PQNode<int>(6, 14); // Changing priority to 3, still min
            q.Update(min, newMin);
            Assert.IsTrue(q.Min.Priority == 12);
        }

    }
}