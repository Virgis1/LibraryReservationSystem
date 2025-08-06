using LibraryReservationSystem.Business;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace LibraryReservationSystem.Data
{
    public class DbBookRepository : IBookRepository
    {
        private readonly string _connectionString;

        public DbBookRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["LibraryDb"].ConnectionString;
        }

        public IList<Book> GetBooks()
        {
            var books = new List<Book>();

            using (var conn = new SqlConnection(_connectionString))
            {
                string query = "SELECT Id, Title, Author, Year, Description, IsInStock FROM Books";
                var cmd = new SqlCommand(query, conn);
                conn.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        books.Add(new Book
                        {
                            Id = reader.GetInt32(0),
                            Title = reader.GetString(1),
                            Author = reader.GetString(2),
                            Year = reader.GetInt32(3),
                            Description = reader.IsDBNull(4) ? "" : reader.GetString(4),
                            IsInStock = reader.GetBoolean(5)
                        });
                    }
                }
            }

            return books;
        }

        public void AddBook(Book newBook)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                string query = @"INSERT INTO Books (Title, Author, Year, Description, IsInStock)
                                 VALUES (@Title, @Author, @Year, @Description, @IsInStock)";
                var cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Title", newBook.Title);
                cmd.Parameters.AddWithValue("@Author", newBook.Author);
                cmd.Parameters.AddWithValue("@Year", newBook.Year);
                cmd.Parameters.AddWithValue("@Description", newBook.Description ?? "");
                cmd.Parameters.AddWithValue("@IsInStock", newBook.IsInStock);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateBook(Book updatedBook)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                string query = @"UPDATE Books SET Title=@Title, Author=@Author, Year=@Year, Description=@Description, IsInStock=@IsInStock
                                 WHERE Id=@Id";
                var cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", updatedBook.Id);
                cmd.Parameters.AddWithValue("@Title", updatedBook.Title);
                cmd.Parameters.AddWithValue("@Author", updatedBook.Author);
                cmd.Parameters.AddWithValue("@Year", updatedBook.Year);
                cmd.Parameters.AddWithValue("@Description", updatedBook.Description ?? "");
                cmd.Parameters.AddWithValue("@IsInStock", updatedBook.IsInStock);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}

