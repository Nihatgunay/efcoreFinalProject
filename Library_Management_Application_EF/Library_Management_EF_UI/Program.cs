using Library_Management_EF_Business.Implementations;
using Library_Management_EF_Business.Interfaces;
using Library_Management_EF_Core.Models;
using static System.Reflection.Metadata.BlobBuilder;

namespace Library_Management_EF_UI
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            ILoanService loanService = new LoanService();
            IBorrowerService borrowerService = new BorrowerService();
            IBookService bookService = new BookService();
            IAuthorService authorService = new AuthorService();
            while (true)
            {
                Console.WriteLine("1 - Author actions");
                Console.WriteLine("2 - Book actions");
                Console.WriteLine("3 - Borrower actions"); 
                Console.WriteLine("4 - Borrow book");
                Console.WriteLine("5 - return book");
                Console.WriteLine("6 - Max borrowed book");
                Console.WriteLine("7 - borrowers with late returns");
                Console.WriteLine("8 - borrowed books");
                Console.WriteLine("9 - FilterBooksByTitle");
                Console.WriteLine("10 - FilterBooksByAuthor");
                Console.WriteLine("0 - Exit");

                Console.Write("  choose one: ");
                string choice1 = Console.ReadLine();
                if (int.TryParse(choice1, out int choicemain))
                {
                    switch (choicemain)
                    {
                        case 1:
                            Console.WriteLine("   1 - Get All Authors");
                            Console.WriteLine("   2 - create author");
                            Console.WriteLine("   3 - edit author");
                            Console.WriteLine("   4 - delete author");
                            Console.WriteLine("   0 - Exit");
                            Console.Write("choose one: ");
                            string choice2 = Console.ReadLine();
                            if (int.TryParse(choice2, out int choicemain2))
                            {
                                switch (choicemain2)
                                {
                                    case 1:
                                        var getallauthors = await authorService.GetAllAuthorsAsync();
                                        if (getallauthors != null)
                                        {
                                            foreach (var item in getallauthors)
                                            {
                                                await Console.Out.WriteLineAsync($"id - {item.Id} Author Name - {item.Name}");
                                                await Console.Out.WriteLineAsync(" ");
                                            }
                                        }
                                        break;
                                    case 2:
                                        while (true)
                                        {
                                            Console.Write("enter author name: ");
                                            string autname = Console.ReadLine();
                                            if (string.IsNullOrEmpty(autname) || autname.Any(char.IsDigit))
                                            {
                                                Console.WriteLine("name cannot be null or contain numbers");
                                            }
                                            else
                                            {
                                                await authorService.CreateAuthorAsync(new Author
                                                {
                                                    Name = autname
                                                });
                                                Console.WriteLine("author created");
                                                Console.WriteLine(" ");
                                                break;
                                            }
                                        }
                                        break;
                                    case 3:
                                        while (true)
                                        {
                                            await Console.Out.WriteLineAsync("enter id of author you want to edit:");
                                            string editauthorid = Console.ReadLine();
                                            if (int.TryParse(editauthorid, out int authorid))
                                            {
                                                Console.Write("enter author name to edit: ");
                                                string auteditname = Console.ReadLine();
                                                if (string.IsNullOrEmpty(auteditname) || auteditname.Any(char.IsDigit))
                                                {
                                                    Console.WriteLine("name cannot be null or contain numbers");
                                                }
                                                else
                                                {
                                                    await authorService.UpdateAuthorAsync(new Author
                                                    {
                                                        Id = authorid,
                                                        Name = auteditname
                                                    });
                                                    Console.WriteLine("author updated");
                                                    Console.WriteLine(" ");
                                                    break;
                                                }
                                            }
                                            else
                                            {
                                                await Console.Out.WriteLineAsync("there is no such an id");
                                            }
                                        }
                                        break;
                                    case 4:
                                        while (true)
                                        {
                                            Console.Write("enter id of author you want to delete: ");
                                            string authorid = Console.ReadLine();
                                            if (int.TryParse(authorid, out int idchoice1))
                                            {
                                                await authorService.DeleteAuthorAsync(idchoice1);
                                                break;
                                            }
                                            else
                                            {
                                                Console.WriteLine("type again");
                                            }
                                        }
                                        break;
                                    case 0:
                                        continue;
                                }
                            }
                            else
                            {
                                Console.WriteLine("TYPE BETWEEN 0-4");
                                Console.WriteLine(" ");
                            }
                            break;
                        case 2:
                            Console.WriteLine("   1 - Get All Books");
                            Console.WriteLine("   2 - create book");
                            Console.WriteLine("   3 - edit book");
                            Console.WriteLine("   4 - delete book");
                            Console.WriteLine("   0 - Exit");
                            Console.Write("choose one: ");
                            string choicebook = Console.ReadLine();
                            if (int.TryParse(choicebook, out int choicemainbook))
                            {
                                switch (choicemainbook)
                                {
                                    case 1:
                                        var books1 = await bookService.GetAllBooksAsync();
                                        if (books1 != null)
                                        {
                                            foreach (var item in books1)
                                            {
                                                await Console.Out.WriteLineAsync($" Id - {item.Id} " +
                                                    $"Book title - {item.Title}" +
                                                    $"book desc - {item.Desc}" +
                                                    $"book published year - {item.PublishedYear}");
                                                await Console.Out.WriteLineAsync(" ");
                                            }
                                        }
                                        break;
                                    case 2:
                                        while (true)
                                        {
                                            Console.Write("enter book name: ");
                                            string bookname = Console.ReadLine();
                                            if (string.IsNullOrEmpty(bookname))
                                            {
                                                Console.WriteLine("name cannot be null");
                                            }
                                            else
                                            {
                                                Console.Write("enter book description: ");
                                                string? bookdesc = Console.ReadLine();
                                                    await Console.Out.WriteLineAsync("enter published year");
                                                    string bookyear = Console.ReadLine();
                                                    if (string.IsNullOrEmpty(bookyear) || bookyear.Any(char.IsLetter) || !int.TryParse(bookyear, out int year))
                                                    {
                                                        await Console.Out.WriteLineAsync("year cannot be null or contain letters or be lower than 2000");
                                                    }
                                                    else
                                                    {
                                                        await bookService.CreateBookAsync(new Book
                                                        {
                                                            Title = bookname,
                                                            Desc = bookdesc,
                                                            PublishedYear = int.Parse(bookyear)
                                                        });
                                                        Console.WriteLine("book created");
                                                        Console.WriteLine(" ");
                                                        break;
                                                    }
                                            }
                                        }
                                        break;
                                    case 3:
                                        while (true)
                                        {
                                            await Console.Out.WriteLineAsync("enter id of book you want to edit:");
                                            string bookeditid = Console.ReadLine();
                                            if (int.TryParse(bookeditid, out int bookid))
                                            {
                                                Console.Write("enter Book name: ");
                                                string bookname = Console.ReadLine();
                                                if (string.IsNullOrEmpty(bookname) || bookname.Any(char.IsDigit))
                                                {
                                                    Console.WriteLine("name cannot be null or contain numbers");
                                                }
                                                else
                                                {
                                                    await Console.Out.WriteAsync("enter book description: ");
                                                    string bookdesc = Console.ReadLine();
                                                    if (string.IsNullOrEmpty(bookdesc))
                                                    {
                                                        await Console.Out.WriteLineAsync("desc cannot be null");
                                                    }
                                                    else
                                                    {
                                                        await bookService.UpdateBookAsync(new Book
                                                        {
                                                            Id = bookid,
                                                            Title = bookname,
                                                            Desc = bookdesc
                                                        });
                                                        Console.WriteLine("book updated");
                                                        Console.WriteLine(" ");
                                                        break;
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                await Console.Out.WriteLineAsync("there is no such an id");
                                            }
                                        }
                                        break;
                                    case 4:
                                        while (true)
                                        {
                                            Console.Write("enter id of book you want to delete: ");
                                            string bookid = Console.ReadLine();
                                            if (int.TryParse(bookid, out int bookiddel))
                                            {
                                                await bookService.DeleteBookAsync(bookiddel);
                                                break;
                                            }
                                            else
                                            {
                                                Console.WriteLine("type again");
                                            }
                                        }
                                        break;
                                    case 0:
                                        continue;
                                }
                            }
                            else
                            {
                                Console.WriteLine("TYPE BETWEEN 0-4");
                                Console.WriteLine(" ");
                            }
                            break;
                        case 3:
                            Console.WriteLine("   1 - Get All Borrowers");
                            Console.WriteLine("   2 - create borrower");
                            Console.WriteLine("   3 - edit borrower");
                            Console.WriteLine("   4 - delete borrower");
                            Console.WriteLine("   0 - Exit");
                            Console.Write("choose one: ");
                            string choicebor = Console.ReadLine();
                            if (int.TryParse(choicebor, out int borrowerch))
                            {
                                switch (borrowerch)
                                {
                                    case 1:
                                        var borrowers1 = await borrowerService.GetAllBorrowersAsync();
                                        if (borrowers1 != null)
                                        {
                                            foreach (var item in borrowers1)
                                            {
                                                await Console.Out.WriteLineAsync($"Id - {item.Id} " +
                                                    $"borrower Name - {item.Name}" +
                                                    $"borrower email - {item.Email}");
                                                await Console.Out.WriteLineAsync(" ");
                                            }
                                        }
                                        break;
                                    case 2:
                                        while (true)
                                        {
                                            Console.Write("enter borrower name: ");
                                            string borrowername = Console.ReadLine();
                                            if (string.IsNullOrEmpty(borrowername) || borrowername.Any(char.IsDigit))
                                            {
                                                Console.WriteLine("name cannot be null or contain numbers");
                                            }
                                            else
                                            {
                                                Console.Write("enter borrower email: ");
                                                string? borroweremail = Console.ReadLine();
                                                if (string.IsNullOrEmpty(borroweremail) || !borroweremail.Contains("@gmail.com"))
                                                {
                                                    Console.WriteLine("email cannot be null or needs to have @gmail.com ");
                                                }
                                                else
                                                {
                                                    await borrowerService.CreateBorrowerAsync(new Borrower
                                                    {
                                                        Name = borrowername,
                                                        Email = borroweremail,
                                                    });
                                                    Console.WriteLine("borrower created");
                                                    Console.WriteLine(" ");
                                                    break;
                                                }
                                            }
                                        }
                                        break;
                                    case 3:
                                        while (true)
                                        {
                                            await Console.Out.WriteLineAsync("enter id of borrower you want to edit:");
                                            string borreditid = Console.ReadLine();
                                            if (int.TryParse(borreditid, out int borid))
                                            {
                                                Console.Write("enter Borrower name: ");
                                                string borreditname = Console.ReadLine();
                                                if (string.IsNullOrEmpty(borreditname) || borreditname.Any(char.IsDigit))
                                                {
                                                    Console.WriteLine("name cannot be null or contain numbers");
                                                }
                                                else
                                                {
                                                    await Console.Out.WriteAsync("enter borrower email: ");
                                                    string boremail2 = Console.ReadLine();
                                                    if (string.IsNullOrEmpty(boremail2) || !boremail2.Contains("@gmail.com"))
                                                    {
                                                        await Console.Out.WriteLineAsync("email cannot be null or needs to have @gmail.com ");
                                                    }
                                                    else
                                                    {
                                                        await borrowerService.UpdateBorrowerAsync(new Borrower
                                                        {
                                                            Id = borid,
                                                            Name = borreditname,
                                                            Email = boremail2
                                                        });
                                                        Console.WriteLine("borrower updated");
                                                        Console.WriteLine(" ");
                                                        break;
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                await Console.Out.WriteLineAsync("there is no such an id");
                                            }
                                        }
                                        break;
                                    case 4:
                                        while (true)
                                        {
                                            Console.Write("enter id of borrower you want to delete: ");
                                            string borid = Console.ReadLine();
                                            if (int.TryParse(borid, out int borrowid))
                                            {
                                                await borrowerService.DeleteBorrowerAsync(borrowid);
                                                break;
                                            }
                                            else
                                            {
                                                Console.WriteLine("type again");
                                            }
                                        }
                                        break;
                                    case 0:
                                        continue;
                                }
                            }
                            else
                            {
                                Console.WriteLine("TYPE BETWEEN 0-4");
                                Console.WriteLine(" ");
                            }
                            break;
                        case 4:
                            Console.WriteLine("Borrowers:");
                            var borrowers = await borrowerService.GetAllBorrowersAsync();
                            if (borrowers != null)
                            {
                                foreach (var item in borrowers)
                                {
                                    await Console.Out.WriteLineAsync($"Id - {item.Id} " +
                                        $"borrower Name - {item.Name} " +
                                        $"borrower email - {item.Email}");
                                    await Console.Out.WriteLineAsync(" ");
                                }
                            }
                            await Console.Out.WriteLineAsync("Books: ");
                            var books = await bookService.GetAllBooksWhereNoBorrowerAsync();
                            if (books != null)
                            {
                                foreach (var item in books)
                                {
                                    await Console.Out.WriteLineAsync($"Id - {item.Id} " +
                                        $"Book title - {item.Title} " +
                                        $"book desc - {item.Desc} " +
                                        $"borrowerId - {item.BorrowerId} " +
                                        $"book published year - {item.PublishedYear}");
                                    await Console.Out.WriteLineAsync(" ");
                                }
                            }
                            await Console.Out.WriteAsync("enter borrower id: ");
                            string borchoice = Console.ReadLine();
                            if (string.IsNullOrEmpty(borchoice) || borchoice.Any(char.IsLetter))
                            {
                                await Console.Out.WriteLineAsync("try again");
                            }
                            else
                            {
                                await Console.Out.WriteAsync("enter book id: ");
                                string bookchoice = Console.ReadLine();
                                if (string.IsNullOrEmpty(bookchoice) || bookchoice.Any(char.IsLetter))
                                {
                                    await Console.Out.WriteLineAsync("try again");
                                }
                                else
                                {
                                    await loanService.BorrowBook(int.Parse(borchoice), int.Parse(bookchoice));
                                }
                            }
                            break;
                        case 5:
                            var bookswhere = await bookService.GetAllBooksWhereAsync();
                            if (bookswhere != null)
                            {
                                foreach (var item in bookswhere)
                                {
                                    await Console.Out.WriteLineAsync($"Id - {item.Id} " +
                                        $"Book title - {item.Title}" +
                                        $"book desc - {item.Desc} " +
                                        $"borrowerId - {item.BorrowerId} " +
                                        $"book published year - {item.PublishedYear}");
                                    await Console.Out.WriteLineAsync(" ");
                                }
                                await Console.Out.WriteAsync("enter book id: ");
                                string bookchoice2 = Console.ReadLine();
                                if (string.IsNullOrEmpty(bookchoice2) || bookchoice2.Any(char.IsLetter))
                                {
                                    await Console.Out.WriteLineAsync("try again");
                                }
                                else
                                {
                                    await loanService.ReturnBook(int.Parse(bookchoice2));
                                    await Console.Out.WriteLineAsync("Book returned successfully.");
                                }
                            }
                            else
                            {
                                await Console.Out.WriteLineAsync("No borrowed Books");
                            }
                            break;
                        case 7:
                            var latereturned = await loanService.LateReturnedBorrowers();
                            if (latereturned != null)
                            {
                                foreach (var item in latereturned)
                                {
                                    await Console.Out.WriteLineAsync($"borrower name - {item.Name}" +
                                        $"borrower email - {item.Email}");
                                    await Console.Out.WriteLineAsync(" ");
                                }
                            }
                            break;
                        case 8:
                            var borbooks = await loanService.BorrowersWithBooks();
                            if (borbooks != null)
                            {
                                foreach (var item in borbooks)
                                {
                                    await Console.Out.WriteLineAsync($"borrower name - {item.Name} " +
                                        $"borrower email - {item.Email} ");
                                    await Console.Out.WriteLineAsync(" ");
                                }
                            }
                            break;
                        case 9:
                            await Console.Out.WriteLineAsync("enter title for filtering books");
                            string title = Console.ReadLine();
                            if (string.IsNullOrEmpty(title))
                            {
                                await Console.Out.WriteLineAsync("try again");
                            }
                            else
                            {
                                var filbooks1 = await bookService.FilterBooksByTitle(title);
                                if (filbooks1 != null)
                                {
                                    foreach (var item in filbooks1)
                                    {
                                        await Console.Out.WriteLineAsync($"Book title - {item.Title} " +
                                            $"book desc - {item.Desc} " +
                                            $"book published year - {item.PublishedYear}");
                                        await Console.Out.WriteLineAsync(" ");
                                    }
                                }
                            }
                            break;
                        case 10:
                            await Console.Out.WriteLineAsync("enter authoor name for filtering books");
                            string autname2 = Console.ReadLine();
                            if (string.IsNullOrEmpty(autname2))
                            {
                                await Console.Out.WriteLineAsync("try again");
                            }
                            else
                            {
                                var filbooks = await bookService.FilterBooksByAuthor(autname2);
                                if (filbooks != null)
                                {
                                    foreach (var item in filbooks)
                                    {
                                        await Console.Out.WriteLineAsync($"Book title - {item.Title} " +
                                            $"book desc - {item.Desc} " +
                                            $"book published year - {item.PublishedYear}");
                                        await Console.Out.WriteLineAsync(" ");
                                    }
                                }
                            }
                            break;
                        case 0:
                            return;
                    }
                }
                else
                {
                    Console.WriteLine("TYPE BETWEEN 1-10");
                    Console.WriteLine(" ");
                }    
            }
        }
    }
}
