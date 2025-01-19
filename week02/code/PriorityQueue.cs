using System;
using System.Collections.Generic;

public class PriorityQueue
{
    private readonly List<(string Item, int Priority)> _queue = new();

    // Enqueue: Adds an item to the queue with a given priority
    public void Enqueue(string item, int priority)
    {
        // Insert the item into the queue in sorted order (highest priority first)
        int index = _queue.FindIndex(x => x.Priority < priority);
        if (index == -1) 
        {
            // If no smaller priority is found, add it at the end
            _queue.Add((item, priority));
        }
        else 
        {
            // Insert the item at the right position to maintain the priority order
            _queue.Insert(index, (item, priority));
        }
    }

    // Dequeue: Removes and returns the item with the highest priority
    public string Dequeue()
    {
        if (_queue.Count == 0)
        {
            throw new InvalidOperationException("The queue is empty.");
        }

        var highestPriorityItem = _queue[0];
        _queue.RemoveAt(0); // Removes the item at the front (highest priority)
        return highestPriorityItem.Item;
    }

    // To get the current number of elements in the queue
    public int Length => _queue.Count;
}
