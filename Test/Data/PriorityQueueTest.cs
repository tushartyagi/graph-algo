using NUnit.Framework;
using Data.Structures;
using System.Collections.Generic;

namespace Data.Structures.Test {

    [TestFixture]
    public class PriorityQueueTests {

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

}