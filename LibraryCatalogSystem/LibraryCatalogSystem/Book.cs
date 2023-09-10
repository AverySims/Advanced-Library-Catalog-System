namespace LibraryCatalogSystem
{
	public enum BookStatus
	{
		Available,
		CheckedOut
	}

	public class Book
	{
		// Properties
		public ulong ISBN { get; set; }
		public string Title { get; set; }
		public string Author { get; set; }
		public BookStatus Status { get; set; }

		// Constructor
		public Book(string title, string author, BookStatus status)
		{
			// ISBN is currently not saved in the constructor,
			// but instead is used as a key in the dictionary
			Title = title;
			Author = author;
			Status = status;
		}

		// The original ISBN keys were 13 digits long and it was annoying to type them out constantly,
		// so I've shortened them down to 4 digits for convenience while demonstrating the program.
		public static Dictionary<ulong, Book> PresetLibrary { get; private set; } = new Dictionary<ulong, Book>
		{
			{ 0084, new Book("To Kill a Mockingbird", "Harper Lee", BookStatus.Available) },
			{ 9970, new Book("Pride and Prejudice", "Jane Austen", BookStatus.CheckedOut) },
			{ 6225, new Book("The Da Vinci Code", "Dan Brown", BookStatus.Available) },
			{ 3415, new Book("The Hobbit", "J.R.R. Tolkien", BookStatus.Available) },
			{ 0803, new Book("1984", "George Orwell", BookStatus.CheckedOut) },
			{ 4113, new Book("The Catcher in the Rye", "J.D. Salinger", BookStatus.Available) },
			{ 2719, new Book("Dune", "Frank Herbert", BookStatus.CheckedOut) },
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
		
	}
}