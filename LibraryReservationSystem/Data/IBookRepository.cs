using System.Collections.Generic;
using LibraryReservationSystem.Business;

namespace LibraryReservationSystem.Data
{
    public interface IBookRepository
    {
        IList<Book> GetBooks();
        void UpdateBook(Book updatedBook);
        void AddBook(Book newBook);
    }
}