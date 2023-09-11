using CustomConsole;
using GenericParse;

namespace LibraryCatalogSystem
{
	internal class Program
	{
		private static Library _currentLibrary = new Library();
		
		private static User _currentUser = new User();
		
		//public static Dictionary<ulong, Book> Catalog = Library.LibrarySelection;

		private static string[] menu1 = { "View library catalog", "Add new book", "Remove book", "Check out a book", "Return a book" };
		private static string[] menu2 = { "Exit program" };

		private static bool _loopMain = true;
		
		static void Main(string[] args)
		{
			while (_loopMain)
			{
				PrintMenu();
				SelectMenuOption();
			}
		}

		/// <summary>
		/// Displays all menu options in the console.
		/// </summary>
		static void PrintMenu()
		{
			Console.WriteLine("Welcome to the smallest Library Catalog");
			ConsoleHelper.PrintBlank();
			ConsoleHelper.PrintStrings( new[] {menu1, menu2} );
		}

		/// <summary>
		/// Waits for user input and calls SwitchOnMenuSelection(), passing the user's input as a parameter.
		/// </summary>
		private static void SelectMenuOption()
		{
			// looping until a valid option is selected
			while (true)
			{
				ConsoleHelper.PrintBlank();
				Console.Write("Select option: ");
				int tempSelect = GenericReadLine.TryReadLine<int>();

				if (!SwitchOnMenuSelection(tempSelect))
				{
					break;
				}
			}
		}
		
		/// <summary>
		/// Uses a switch statement to call the appropriate method based on the user's menu selection.
		/// </summary>
		/// <param name="selection">The user's menu selection</param>
		/// <returns>The desired loop state</returns>
		private static bool SwitchOnMenuSelection(int selection)
		{
			bool tempReturnValue = true;

			// clearing console and printing menu again to prevent clutter
			Console.Clear();
			PrintMenu();
			ConsoleHelper.PrintBlank();

			switch (selection)
			{
				case 1: // view library catalog
					SearchManager.PrintBooks(_currentLibrary.LibrarySelection);
					break;
				case 2: // add new book
					Console.Write("Enter the book's ISBN: ");
					ulong tempISBN = GenericReadLine.TryReadLine<ulong>();
					Console.Write("Enter the book's title: ");
					string tempTitle = GenericReadLine.TryReadLine<string>();
					Console.Write("Enter the book's author: ");
					string tempAuthor = GenericReadLine.TryReadLine<string>();
					if (_currentLibrary.AddBook(tempISBN, new Book(tempTitle, tempAuthor, BookStatus.Available)))
					{
						SearchManager.PrintBook(tempISBN, _currentLibrary.LibrarySelection[tempISBN]);
					}
					else
					{
						Console.WriteLine("A book with that ISBN already exists.");
					}
					
					break;
				case 3: // remove book
					break;
				case 4: // check out book
					break;
				case 5: // return book
					break;
				case 6: // exit program
					tempReturnValue = false;
					_loopMain = false;
					break;
				default:
					break;
			}
			
			/*
			 * 
			switch (selection)
			{
				case 1: // View all books
					SearchManager.PrintBooks(Catalog);
					break;
				case 2: // Search by ISBN
					Console.Write("Search for a book by ISBN: ");
					SearchManager.SearchByISBN(GenericReadLine.TryReadLine<ulong>(), Catalog, out Dictionary<ulong, Book> resultsISBN);
					break;
				case 3: // Search by Title
					Console.Write("Search for a book via title: ");
					SearchManager.SearchByTitle(GenericReadLine.TryReadLine<string>(), Catalog, out Dictionary<ulong, Book> resultsTitle);
					break;
				case 4: // Search by Author
                    Console.Write("Search for a book via author: ");
                    SearchManager.SearchByAuthor(GenericReadLine.TryReadLine<string>(), Catalog, out Dictionary<ulong, Book> resultsAuthor);
					break;
				case 5: // Check out book
					Console.Write("Enter the ISBN of the book you wish to check out: ");
					SearchManager.CheckOutBook(GenericReadLine.TryReadLine<ulong>(), ref Catalog);
					break;
				case 6: // return book
					Console.Write("Enter the ISBN of the book you wish to return: ");
					SearchManager.ReturnBook(GenericReadLine.TryReadLine<ulong>(), ref Catalog);
					break;
				case 7: // exit program
					tempReturnValue = false;
					_loopMain = false;
					break;
				default: // Invalid selection
					ConsoleHelper.PrintInvalidSelection();
					break;
			}
			 */
			return tempReturnValue;
		}
	}
}