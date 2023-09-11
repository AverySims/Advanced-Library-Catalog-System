namespace LibraryCatalogSystem;

public class Library
{
    /// <summary>
    /// A static dictionary of books that is used as the default library.
    /// </summary>
    public static Dictionary<ulong, Book> StaticLibrary { get; } = new Dictionary<ulong, Book>
    {
        { 0084, new Book("To Kill a Mockingbird", "Harper Lee", BookStatus.Available) },
        { 9970, new Book("Pride and Prejudice", "Jane Austen", BookStatus.Available) },
        { 6225, new Book("The Da Vinci Code", "Dan Brown", BookStatus.Available) },
        { 3415, new Book("The Hobbit", "J.R.R. Tolkien", BookStatus.Available) },
        { 0803, new Book("1984", "George Orwell", BookStatus.Available) },
        { 4113, new Book("The Catcher in the Rye", "J.D. Salinger", BookStatus.Available) },
        { 2719, new Book("Dune", "Frank Herbert", BookStatus.Available) },
        { 0524, new Book("The Great Gatsby", "F. Scott Fitzgerald", BookStatus.Available) }
        /* original ISBN book keys
         *  9780061120084
            9780141439970
            9780739326225
            9780544003415
            9780141980803
            9781400064113
            9780441172719
            9780060850524
        */
    };
    
    public Dictionary<ulong, Book> LibrarySelection = StaticLibrary;
    
    /// <summary>
    /// Adds a new book to the library.
    /// </summary>
    /// <param name="isbn">The book's key value</param>
    /// <param name="book">The book object to be added</param>
    /// <returns>True if the book was successfully added, false if the book already exists.</returns>
    public bool AddBook(ulong isbn, Book book)
    {
        // if the book already exists in the library, return false
        if (LibrarySelection.ContainsKey(isbn)) return false;
        
        LibrarySelection.Add(isbn, book);
        LibrarySelection[isbn].Status = BookStatus.Available;
        return true;
    }
    
    /// <summary>
    /// Removes a book from the library.
    /// </summary>
    /// <param name="isbn">The book's key value</param>
    /// <param name="removedBook">The book that was removed</param>
    /// <returns>True if the book was successfully removed, false if the book wasn't found.</returns>
    public bool RemoveBook(ulong isbn, out Book removedBook)
    {
        removedBook = null;
        
        // if the book doesn't exist in the library, return false
        if (!LibrarySelection.ContainsKey(isbn)) return false;
        
        removedBook = LibrarySelection[isbn];
        
        LibrarySelection.Remove(isbn);
        return true;
    }
    
    /// <summary>
    /// Attempts to check out a book from the library. Then adds the book to the user's checked out books.
    /// </summary>
    /// <param name="isbn">The book's key value</param>
    /// <param name="user">The user that is checking out the book</param>
    /// <returns>True if the book was successfully checked out, false if the book couldn't be checked out</returns>
    public bool CheckOutBook(ulong isbn, User user)
    {
        // if the book doesn't exist in the library, return false
        if (!LibrarySelection.ContainsKey(isbn)) return false;

        // if the book is already checked out, return false
        if (LibrarySelection[isbn].Status != BookStatus.Available) return false;
        
        SetBookStatus(isbn, BookStatus.CheckedOut);
        user.CheckedOutBooks.Add(isbn, LibrarySelection[isbn]);
        return true;
    }
    
    public void SetBookStatus(ulong isbn, BookStatus newStatus)
    {
        LibrarySelection[isbn].Status = newStatus;
    }
}