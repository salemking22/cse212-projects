using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue items with different priorities and dequeue.
    // Expected Result: Highest priority item should be removed first.
    // Defect(s) Found: FAILED initially. PASSED after fix.
    public void TestPriorityQueue_DequeueHighestPriority()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("A", 1);
        pq.Enqueue("B", 5);
        pq.Enqueue("C", 3);

        Assert.AreEqual("B", pq.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue items with same priority and dequeue.
    // Expected Result: FIFO order should be respected.
    // Defect(s) Found: FAILED initially. PASSED after fix.
    public void TestPriorityQueue_DequeueFIFOOnTie()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("A", 5);
        pq.Enqueue("B", 5);
        pq.Enqueue("C", 5);

        Assert.AreEqual("A", pq.Dequeue());
        Assert.AreEqual("B", pq.Dequeue());
        Assert.AreEqual("C", pq.Dequeue());
    }

    [TestMethod]
    // Scenario: Try to dequeue from an empty queue.
    // Expected Result: InvalidOperationException with message "The queue is empty."
    // Defect(s) Found: FAILED initially. PASSED after fix.
    public void TestPriorityQueue_EmptyQueue()
    {
        var pq = new PriorityQueue();

        try
        {
            pq.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
    }
}