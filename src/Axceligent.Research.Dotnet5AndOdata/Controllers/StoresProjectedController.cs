using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using AgileObjects.ReadableExpressions;
using AutoMapper;
using LinqKit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Research.Dotnet5AndOdata.Db;
using Research.Dotnet5AndOdata.Entities;
using Research.Dotnet5AndOdata.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Research.Dotnet5AndOdata.Controllers
{
    public class StoresProjectedController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly MyContext _context;

        public StoresProjectedController( IMapper mapper, MyContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        [EnableQuery]
        [ProducesResponseType(typeof(IQueryable<Store>), StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            AddSampleDataToDb();
            var result = _context.Stores.AsQueryable();

            var resultModel = _mapper.ProjectTo<StoreModel>(result);

            Console.WriteLine(resultModel.Expression.ToReadableString());

            return Ok(resultModel);
        }

        private void AddSampleDataToDb() {
            if (_context.BooksStores.Any())
                return;

            var person1 = new Person {FirstName = "Jack", LastName = "Jacky"};
            var person2 = new Person {FirstName = "Joe", LastName = "Janna"};
            _context.People.AddRange(person1, person2);
            _context.SaveChanges(true);

            var author1 = new Person {FirstName = "Jams", LastName = "Band"};
            var author2 = new Person {FirstName = "Brian", LastName = "Putin"};
            _context.People.AddRange(author1, author2);
            _context.SaveChanges(true);


            var book1 = new Book {AuthorId = author1.Id, Name = "Book_1"};
            var book2 = new Book {AuthorId = author2.Id, Name = "Book_2"};
            var book3 = new Book {AuthorId = author1.Id, Name = "Book_3"};
            var book4 = new Book {AuthorId = author2.Id, Name = "Book_4"};

            _context.Books.AddRange(book1, book2, book3, book4);
            _context.SaveChanges(true);

            var store1 = new Store {Name = "Store_1", OwnerId = person1.Id};
            var store2 = new Store {Name = "Store_2", OwnerId = person2.Id};

            _context.Stores.Add(store1);
            _context.Stores.Add(store2);
            _context.SaveChanges(true);


            _context.BooksStores.AddRange(new BookStore
            {
                BookId = book1.Id,
                StoreId = store1.Id
            }, new BookStore
            {
                BookId = book2.Id,
                StoreId = store1.Id
            }, new BookStore
            {
                BookId = book3.Id,
                StoreId = store1.Id
            }, new BookStore
            {
                BookId = book1.Id,
                StoreId = store2.Id
            }, new BookStore
            {
                BookId = book4.Id,
                StoreId = store2.Id
            });
            _context.SaveChanges(true);
        }
    }
}