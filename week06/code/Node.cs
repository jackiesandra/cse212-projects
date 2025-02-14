public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    // Insert unique values only (Problem 1)
    public void Insert(int value)
    {
        // Skip if the value is already in the tree (to prevent duplicates)
        if (value == Data)
        {
            return; // Do nothing if the value already exists
        }

        if (value < Data)
        {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else
        {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    // Contains function to search recursively (Problem 2)
    public bool Contains(int value)
    {
        if (value == Data)
            return true; // Found the value

        if (value < Data)
        {
            // Search in the left subtree
            return Left?.Contains(value) ?? false;
        }
        else
        {
            // Search in the right subtree
            return Right?.Contains(value) ?? false;
        }
    }

    // Get the height of the tree (Problem 4)
    public int GetHeight()
    {
        // If the node is null, return 0 (base case for recursion)
        int leftHeight = Left?.GetHeight() ?? 0;
        int rightHeight = Right?.GetHeight() ?? 0;

        // Return the maximum of left and right height plus 1
        return 1 + Math.Max(leftHeight, rightHeight);
    }
}
