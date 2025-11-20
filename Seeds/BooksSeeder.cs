using System.Linq;
using Contemporary_Programming_Final_Project.Data;
using BookModel = Contemporary_Programming_Final_Project.Models.Book;

namespace Contemporary_Programming_Final_Project.Seeds
{
    public static class BooksSeeder
    {
        public static void Seed(AppDbContext context)
        {
            if (context.Books.Any()) return;

            var books = new[]
            {
                new BookModel
                {
                    ISBN = 9780140449136L,
                    AuthorName = "Homer",
                    Title = "The Odyssey",
                    Genre = "Epic Poetry",
                    PublicationYear = 800
                },
                new BookModel
                {
                    ISBN = 9780061120084L,
                    AuthorName = "Harper Lee",
                    Title = "To Kill a Mockingbird",
                    Genre = "Fiction",
                    PublicationYear = 1960
                },
                new BookModel
                {
                    ISBN = 9780451524935L,
                    AuthorName = "George Orwell",
                    Title = "1984",
                    Genre = "Dystopian",
                    PublicationYear = 1949
                },
                new BookModel
                {
                    ISBN = 9780307277671L,
                    AuthorName = "F. Scott Fitzgerald",
                    Title = "The Great Gatsby",
                    Genre = "Novel",
                    PublicationYear = 1925
                }
            };

            context.Books.AddRange(books);
            context.SaveChanges();
        }
    }
}