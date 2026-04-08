public static class Trees
{
    /// <summary>
    /// Given a sorted list (sorted_list), create a balanced BST.
    /// </summary>
    public static BinarySearchTree CreateTreeFromSortedList(int[] sortedNumbers)
    {
        var bst = new BinarySearchTree(); // Create an empty BST to start with 
        InsertMiddle(sortedNumbers, 0, sortedNumbers.Length - 1, bst);
        return bst;
    }

    /// <summary>
    /// Insert the middle element of the current range into the BST,
    /// then recurse left and right to build a balanced tree.
    /// </summary>
    private static void InsertMiddle(int[] sortedNumbers, int first, int last, BinarySearchTree bst)
    {
        if (first > last)
        {
            return; // base case: no elements left
        }

        // Find the middle index
        int mid = (first + last) / 2;

        // Insert the middle value into the tree
        bst.Insert(sortedNumbers[mid]);

        // Recurse on the left half
        InsertMiddle(sortedNumbers, first, mid - 1, bst);

        // Recurse on the right half
        InsertMiddle(sortedNumbers, mid + 1, last, bst);
    }
}