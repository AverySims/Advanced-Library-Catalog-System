﻿namespace LibraryCatalogSystem
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
	}
}