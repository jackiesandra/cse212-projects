using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add elements with different priorities and check that the element with the highest priority is dequeued first.
    // Expected Result: The order should be Item3, Item1, Item2 (in descending priority order).
    // Defect(s) Found: None so far.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();

        // Add elements with different priorities
        priorityQueue.Enqueue("Item1", 1);  // Low priority
        priorityQueue.Enqueue("Item2", 2);  // Medium priority
        priorityQueue.Enqueue("Item3", 3);  // High priority

        // Verify the order of dequeued elements
        Assert.AreEqual("Item3", priorityQueue.Dequeue());
        Assert.AreEqual("Item2", priorityQueue.Dequeue());
        Assert.AreEqual("Item1", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Add elements with the same priority and check the order in which they are dequeued.
    // Expected Result: Elements should be dequeued in the order they were added (FIFO behavior for equal priority).
    // Defect(s) Found: None so far.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();

        // Add elements with the same priority
        priorityQueue.Enqueue("Item1", 1);
        priorityQueue.Enqueue("Item2", 1);
        priorityQueue.Enqueue("Item3", 1);

        // Verify the order of dequeued elements (FIFO for equal priorities)
        Assert.AreEqual("Item1", priorityQueue.Dequeue());
        Assert.AreEqual("Item2", priorityQueue.Dequeue());
        Assert.AreEqual("Item3", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Try to dequeue from an empty queue.
    // Expected Result: Exception should be thrown with appropriate error message.
    // Defect(s) Found: None so far.
    public void TestPriorityQueue_EmptyQueue()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
    }

    // Add more test cases as needed below.
}
