using System.Collections.Generic;

namespace Research.Dotnet5AndOdata.Entities
{
    public class BookStore
    {
        public int StoreId { get; set; }
        public int BookId { get; set; }

        public Store Store { get; set; }
        public Book Book { get; set; }
    }

    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AuthorId { get; set; }
        public Person Author { get; set; }

        public ICollection<BookStore> BookStore { get; set; }
    }

    public class Person
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public ICollection<Store> Stores { get; set; }
        public ICollection<Book> Books { get; set; }

    }

    public class Store
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int OwnerId { get; set; }
        public Person Owner { get; set; }

        public ICollection<Book> Books { get; set; }
        public ICollection<BookStore> BookStore { get; set; }

    }
}