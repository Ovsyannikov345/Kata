using System;
using System.Collections.Generic;

public class PaginationHelper<T>
{
    private IList<T> itemsList;

    private int itemsPerPage;

    /// <summary>
    /// Constructor, takes in a list of items and the number of items that fit within a single page
    /// </summary>
    /// <param name="collection">A list of items</param>
    /// <param name="itemsPerPage">The number of items that fit within a single page</param>
    public PaginationHelper(IList<T> collection, int itemsPerPage)
    {
        itemsList = collection;
        this.itemsPerPage = itemsPerPage;
    }

    /// <summary>
    /// The number of items within the collection
    /// </summary>
    public int ItemCount { get => itemsList.Count; }

    /// <summary>
    /// The number of pages
    /// </summary>
    public int PageCount { get => (int)Math.Ceiling(ItemCount * 1.0 / itemsPerPage); }

    /// <summary>
    /// Returns the number of items in the page at the given page index 
    /// </summary>
    /// <param name="pageIndex">The zero-based page index to get the number of items for</param>
    /// <returns>The number of items on the specified page or -1 for pageIndex values that are out of range</returns>
    public int PageItemCount(int pageIndex)
    {
        if (pageIndex < 0 || pageIndex > PageCount - 1)
        {
            return -1;
        }

        if (pageIndex == PageCount - 1)
        {
            return ItemCount - pageIndex * itemsPerPage;
        }

        return itemsPerPage;
    }

    /// <summary>
    /// Returns the page index of the page containing the item at the given item index.
    /// </summary>
    /// <param name="itemIndex">The zero-based index of the item to get the pageIndex for</param>
    /// <returns>The zero-based page index of the page containing the item at the given item index or -1 if the item index is out of range</returns>
    public int PageIndex(int itemIndex)
    {
        if (itemIndex < 0 || itemIndex > ItemCount - 1)
        {
            return -1;
        }

        return itemIndex / itemsPerPage;
    }
}