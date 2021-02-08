using System.Collections.Generic;
using Research.Dotnet5AndOdata.Models;

namespace Research.Dotnet5AndOdata.Models
{
    public partial class StoreModelDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public PersonModel Owner { get; set; }
        public ICollection<BookModel> Books { get; set; }
        public ICollection<BookStoreModel> BookStore { get; set; }
    }
}