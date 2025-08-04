using LibraryReservationSystem.Business;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Hosting;

namespace LibraryReservationSystem.Data
{
    public class FileBookRepository : IBookRepository
    {
        private readonly string _filePath;
        private List<Book> _books;

        public FileBookRepository()
        {
            _filePath = HostingEnvironment.MapPath("~/App_Data/books.json");
            LoadBooks();
        }

        private void LoadBooks()
        {
            if (!File.Exists(_filePath))
            {
                _books = new List<Book>();
                SaveBooks();
                return;
            }

            var json = File.ReadAllText(_filePath);
            _books = string.IsNullOrWhiteSpace(json)
                ? new List<Book>()
                : JsonConvert.DeserializeObject<List<Book>>(json);
        }

        private void SaveBooks()
        {
            var json = JsonConvert.SerializeObject(_books, Formatting.Indented);
            File.WriteAllText(_filePath, json);
        }

        public IList<Book> GetBooks()
        {
            LoadBooks();
            return _books;
        }

        public void AddBook(Book newBook)
        {
            int nextId = _books.Count > 0 ? _books.Max(b => b.Id) + 1 : 1;
            newBook.Id = nextId;
            _books.Add(newBook);
            SaveBooks();
        }

        public void UpdateBook(Book updatedBook)
        {
            var book = _books.FirstOrDefault(b => b.Id == updatedBook.Id);
            if (book != null)
            {
                book.Title = updatedBook.Title;
                book.Author = updatedBook.Author;
                book.Year = updatedBook.Year;
                book.Description = updatedBook.Description;
                book.IsInStock = updatedBook.IsInStock;
                SaveBooks();
            }
        }
    }
}
