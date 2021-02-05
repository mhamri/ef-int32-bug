using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Research.Dotnet5AndOdata.Models
{
    public class BookStoreModel
    {
        [Key]
        public int StoreId { get; set; }
        [Key]
        public int BookId { get; set; }

        public StoreModel Store { get; set; }
        public BookModel Book { get; set; }
    }

    public class BookModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public PersonModel Author { get; set; }

        public IEnumerable<BookStoreModel> BookStore { get; set; }

    }

    public class PersonModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public IEnumerable<StoreModel> Stores { get; set; }
        public IEnumerable<BookModel> Books { get; set; }

    }

    public class StoreModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public PersonModel Owner { get; set; }

        public ICollection<BookModel> Books { get; set; }
        public ICollection<BookStoreModel> BookStore { get; set; }

    }
}