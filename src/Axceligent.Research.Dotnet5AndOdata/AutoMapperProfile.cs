using AutoMapper;
using Research.Dotnet5AndOdata.Entities;
using Research.Dotnet5AndOdata.Models;

namespace Research.Dotnet5AndOdata
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile() {

            CreateMap<Person, PersonModel>();
            CreateMap<Book, BookModel>();
            CreateMap<Store, StoreModel>();
            CreateMap<BookStore, BookStoreModel>();

        } 
    }
}
