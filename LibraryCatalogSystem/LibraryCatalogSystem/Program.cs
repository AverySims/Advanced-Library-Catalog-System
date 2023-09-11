using CustomConsole;
using GenericParse;

namespace LibraryCatalogSystem
{
	internal class Program
	{
		// because of how the program is structured, these two objects must be static
		private static readonly Library CurrentLibrary = new Library();
		private static readonly User CurrentUser = new User();

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
					SearchManager.PrintBooks(CurrentLibrary.LibrarySelection);
					break;
				case 2: // add new book
					AddNewBook();
					
					break;
				case 3: // remove book
					break;
				case 4: // check out book
					CheckOutBook();
					
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
			
			return tempReturnValue;
		}

		private static void AddNewBook()
		{
			Console.Write("Enter the book's ISBN: ");
			ulong tempISBN = GenericReadLine.TryReadLine<ulong>();
			
			ConsoleHelper.PrintBlank();
			Console.Write("Enter the book's title: ");
			string tempTitle = GenericReadLine.TryReadLine<string>();
			
			ConsoleHelper.PrintBlank();
			Console.Write("Enter the book's author: ");
			string tempAuthor = GenericReadLine.TryReadLine<string>();

			ConsoleHelper.PrintBlank();
			while (true)
			{
				// attempting to add the book to the library
				if (CurrentLibrary.AddBook(tempISBN, new Book(tempTitle, tempAuthor, BookStatus.Available)))
				{
					// clearing console and printing menu again to prevent clutter
					Console.Clear();
					PrintMenu();
					
					ConsoleHelper.PrintBlank();
					Console.WriteLine("Book successfully added!");
					
					SearchManager.PrintBook(tempISBN, CurrentLibrary.LibrarySelection[tempISBN]);
					break;
				}
				
				// if the book wasn't successfully added, ask for a different ISBN
				while (true)
				{
					// clearing console and printing menu again to prevent clutter
					Console.Clear();
					PrintMenu();
					
					ConsoleHelper.PrintBlank();
					Console.WriteLine("A book with that ISBN already exists.");
					Console.Write("Please enter a different ISBN: ");
					
					tempISBN = GenericReadLine.TryReadLine<ulong>();
					break;
				}
			}
		}
		
		private static void CheckOutBook()
		{
			Console.Write("Enter the ISBN of the book you wish to check out: ");
			ulong tempISBN = GenericReadLine.TryReadLine<ulong>();
			
			// clearing console and printing menu again to prevent clutter
			Console.Clear();
			PrintMenu();
			
			ConsoleHelper.PrintBlank();
			if (CurrentLibrary.CheckOutBook(tempISBN, CurrentUser))
			{
				Console.WriteLine("Successfully checked out book: ");
				SearchManager.PrintBook(tempISBN, CurrentLibrary.LibrarySelection[tempISBN]);
			}
			else
			{
				Console.WriteLine("That book is currently not available for check-out...");
			}
		}
	}
}