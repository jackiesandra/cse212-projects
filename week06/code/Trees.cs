public static class Trees
{
    /// <summary>
    /// Given a sorted list (sorted_list), create a balanced BST. If the values in the
    /// sortedNumbers were inserted in order from left to right into the BST, then it
    /// would resemble a linked list (unbalanced). To get a balanced BST, the
    /// InsertMiddle function is called to find the middle item in the list to add
    /// first to the BST. The InsertMiddle function takes the whole list but also takes
    /// a range (first to last) to consider. For the first call, the full range of
    /// 0 to Length-1 used.
    /// </summary>
    public static BinarySearchTree CreateTreeFromSortedList(int[] sortedNumbers)
    {
        var bst = new BinarySearchTree(); // Create an empty BST to start with 
        InsertMiddle(sortedNumbers, 0, sortedNumbers.Length - 1, bst);
        return bst;
    }

    /// <summary>
    /// This function will attempt to insert the item in the middle of 'sortedNumbers' into
    /// the 'bst' tree. The middle is determined by using indices represented by 'first' and
    /// 'last'.
    /// </summary>
    /// <param name="sortedNumbers">input numbers that are already sorted</param>
    /// <param name="first">the first index in the sortedNumbers to insert</param>
    /// <param name="last">the last index in the sortedNumbers to insert</param>
    /// <param name="bst">the BinarySearchTree in which to insert the values</param>
    private static void InsertMiddle(int[] sortedNumbers, int first, int last, BinarySearchTree bst)
    {
        // Base case: if the range is invalid, return
        if (first > last)
        {
            return;
        }

        // Find the middle index
        int mid = (first + last) / 2;

        // Insert the middle element into the BST
        bst.Insert(sortedNumbers[mid]);

        // Recursively insert the middle of the left half and the right half
        InsertMiddle(sortedNumbers, first, mid - 1, bst); // Left side
        InsertMiddle(sortedNumbers, mid + 1, last, bst);  // Right side
    }
}
