using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Mapster;
using Mapster.Utils;
using Research.Dotnet5AndOdata.Models;

namespace Research.Dotnet5AndOdata.Models
{
    public static partial class StoreModelMapper
    {
        public static StoreModelDto AdaptToDto(this StoreModel p1)
        {
            if (p1 == null)
            {
                return null;
            }
            MapContextScope scope = new MapContextScope();
            
            try
            {
                object cache;
                
                Dictionary<ReferenceTuple, object> references = scope.Context.References;
                ReferenceTuple key = new ReferenceTuple(p1, typeof(StoreModelDto));
                
                if (references.TryGetValue(key, out cache))
                {
                    return (StoreModelDto)cache;
                }
                StoreModelDto result = new StoreModelDto();
                references[key] = (object)result;
                
                result.Id = p1.Id;
                result.Name = p1.Name;
                result.Owner = funcMain1(p1.Owner);
                result.Books = funcMain2(p1.Books);
                result.BookStore = funcMain4(p1.BookStore);
                return result;
            }
            finally
            {
                scope.Dispose();
            }
            
        }
        public static StoreModelDto AdaptTo(this StoreModel p7, StoreModelDto p8)
        {
            if (p7 == null)
            {
                return null;
            }
            MapContextScope scope = new MapContextScope();
            
            try
            {
                object cache;
                
                Dictionary<ReferenceTuple, object> references = scope.Context.References;
                ReferenceTuple key = new ReferenceTuple(p7, typeof(StoreModelDto));
                
                if (references.TryGetValue(key, out cache))
                {
                    return (StoreModelDto)cache;
                }
                StoreModelDto result = p8 ?? new StoreModelDto();
                references[key] = (object)result;
                
                result.Id = p7.Id;
                result.Name = p7.Name;
                result.Owner = funcMain6(p7.Owner, result.Owner);
                result.Books = funcMain7(p7.Books, result.Books);
                result.BookStore = funcMain9(p7.BookStore, result.BookStore);
                return result;
            }
            finally
            {
                scope.Dispose();
            }
            
        }
        public static Expression<Func<StoreModel, StoreModelDto>> ProjectToDto => p17 => new StoreModelDto()
        {
            Id = p17.Id,
            Name = p17.Name,
            Owner = p17.Owner,
            Books = p17.Books,
            BookStore = p17.BookStore
        };
        
        private static PersonModel funcMain1(PersonModel p2)
        {
            if (p2 == null)
            {
                return null;
            }
            MapContextScope scope = new MapContextScope();
            
            try
            {
                object cache;
                
                Dictionary<ReferenceTuple, object> references = scope.Context.References;
                ReferenceTuple key = new ReferenceTuple(p2, typeof(PersonModel));
                
                if (references.TryGetValue(key, out cache))
                {
                    return (PersonModel)cache;
                }
                PersonModel result = new PersonModel();
                references[key] = (object)result;
                
                result.Id = p2.Id;
                result.FirstName = p2.FirstName;
                result.LastName = p2.LastName;
                result.Stores = null;
                result.Books = null;
                return result;
            }
            finally
            {
                scope.Dispose();
            }
            
        }
        
        private static ICollection<BookModel> funcMain2(ICollection<BookModel> p3)
        {
            if (p3 == null)
            {
                return null;
            }
            MapContextScope scope = new MapContextScope();
            
            try
            {
                object cache;
                
                Dictionary<ReferenceTuple, object> references = scope.Context.References;
                ReferenceTuple key = new ReferenceTuple(p3, typeof(ICollection<BookModel>));
                
                if (references.TryGetValue(key, out cache))
                {
                    return (ICollection<BookModel>)cache;
                }
                ICollection<BookModel> result = new List<BookModel>(p3.Count);
                references[key] = (object)result;
                
                IEnumerator<BookModel> enumerator = p3.GetEnumerator();
                
                while (enumerator.MoveNext())
                {
                    BookModel item = enumerator.Current;
                    result.Add(funcMain3(item));
                }
                return result;
            }
            finally
            {
                scope.Dispose();
            }
            
        }
        
        private static ICollection<BookStoreModel> funcMain4(ICollection<BookStoreModel> p5)
        {
            if (p5 == null)
            {
                return null;
            }
            MapContextScope scope = new MapContextScope();
            
            try
            {
                object cache;
                
                Dictionary<ReferenceTuple, object> references = scope.Context.References;
                ReferenceTuple key = new ReferenceTuple(p5, typeof(ICollection<BookStoreModel>));
                
                if (references.TryGetValue(key, out cache))
                {
                    return (ICollection<BookStoreModel>)cache;
                }
                ICollection<BookStoreModel> result = new List<BookStoreModel>(p5.Count);
                references[key] = (object)result;
                
                IEnumerator<BookStoreModel> enumerator = p5.GetEnumerator();
                
                while (enumerator.MoveNext())
                {
                    BookStoreModel item = enumerator.Current;
                    result.Add(funcMain5(item));
                }
                return result;
            }
            finally
            {
                scope.Dispose();
            }
            
        }
        
        private static PersonModel funcMain6(PersonModel p9, PersonModel p10)
        {
            if (p9 == null)
            {
                return null;
            }
            MapContextScope scope = new MapContextScope();
            
            try
            {
                object cache;
                
                Dictionary<ReferenceTuple, object> references = scope.Context.References;
                ReferenceTuple key = new ReferenceTuple(p9, typeof(PersonModel));
                
                if (references.TryGetValue(key, out cache))
                {
                    return (PersonModel)cache;
                }
                PersonModel result = p10 ?? new PersonModel();
                references[key] = (object)result;
                
                result.Id = p9.Id;
                result.FirstName = p9.FirstName;
                result.LastName = p9.LastName;
                result.Stores = null;
                result.Books = null;
                return result;
            }
            finally
            {
                scope.Dispose();
            }
            
        }
        
        private static ICollection<BookModel> funcMain7(ICollection<BookModel> p11, ICollection<BookModel> p12)
        {
            if (p11 == null)
            {
                return null;
            }
            MapContextScope scope = new MapContextScope();
            
            try
            {
                object cache;
                
                Dictionary<ReferenceTuple, object> references = scope.Context.References;
                ReferenceTuple key = new ReferenceTuple(p11, typeof(ICollection<BookModel>));
                
                if (references.TryGetValue(key, out cache))
                {
                    return (ICollection<BookModel>)cache;
                }
                ICollection<BookModel> result = new List<BookModel>(p11.Count);
                references[key] = (object)result;
                
                IEnumerator<BookModel> enumerator = p11.GetEnumerator();
                
                while (enumerator.MoveNext())
                {
                    BookModel item = enumerator.Current;
                    result.Add(funcMain8(item));
                }
                return result;
            }
            finally
            {
                scope.Dispose();
            }
            
        }
        
        private static ICollection<BookStoreModel> funcMain9(ICollection<BookStoreModel> p14, ICollection<BookStoreModel> p15)
        {
            if (p14 == null)
            {
                return null;
            }
            MapContextScope scope = new MapContextScope();
            
            try
            {
                object cache;
                
                Dictionary<ReferenceTuple, object> references = scope.Context.References;
                ReferenceTuple key = new ReferenceTuple(p14, typeof(ICollection<BookStoreModel>));
                
                if (references.TryGetValue(key, out cache))
                {
                    return (ICollection<BookStoreModel>)cache;
                }
                ICollection<BookStoreModel> result = new List<BookStoreModel>(p14.Count);
                references[key] = (object)result;
                
                IEnumerator<BookStoreModel> enumerator = p14.GetEnumerator();
                
                while (enumerator.MoveNext())
                {
                    BookStoreModel item = enumerator.Current;
                    result.Add(funcMain10(item));
                }
                return result;
            }
            finally
            {
                scope.Dispose();
            }
            
        }
        
        private static BookModel funcMain3(BookModel p4)
        {
            if (p4 == null)
            {
                return null;
            }
            MapContextScope scope = new MapContextScope();
            
            try
            {
                object cache;
                
                Dictionary<ReferenceTuple, object> references = scope.Context.References;
                ReferenceTuple key = new ReferenceTuple(p4, typeof(BookModel));
                
                if (references.TryGetValue(key, out cache))
                {
                    return (BookModel)cache;
                }
                BookModel result = new BookModel();
                references[key] = (object)result;
                
                result.Id = p4.Id;
                result.Name = p4.Name;
                result.Author = null;
                result.BookStore = null;
                return result;
            }
            finally
            {
                scope.Dispose();
            }
            
        }
        
        private static BookStoreModel funcMain5(BookStoreModel p6)
        {
            if (p6 == null)
            {
                return null;
            }
            MapContextScope scope = new MapContextScope();
            
            try
            {
                object cache;
                
                Dictionary<ReferenceTuple, object> references = scope.Context.References;
                ReferenceTuple key = new ReferenceTuple(p6, typeof(BookStoreModel));
                
                if (references.TryGetValue(key, out cache))
                {
                    return (BookStoreModel)cache;
                }
                BookStoreModel result = new BookStoreModel();
                references[key] = (object)result;
                
                result.StoreId = p6.StoreId;
                result.BookId = p6.BookId;
                result.Store = null;
                result.Book = null;
                return result;
            }
            finally
            {
                scope.Dispose();
            }
            
        }
        
        private static BookModel funcMain8(BookModel p13)
        {
            if (p13 == null)
            {
                return null;
            }
            MapContextScope scope = new MapContextScope();
            
            try
            {
                object cache;
                
                Dictionary<ReferenceTuple, object> references = scope.Context.References;
                ReferenceTuple key = new ReferenceTuple(p13, typeof(BookModel));
                
                if (references.TryGetValue(key, out cache))
                {
                    return (BookModel)cache;
                }
                BookModel result = new BookModel();
                references[key] = (object)result;
                
                result.Id = p13.Id;
                result.Name = p13.Name;
                result.Author = null;
                result.BookStore = null;
                return result;
            }
            finally
            {
                scope.Dispose();
            }
            
        }
        
        private static BookStoreModel funcMain10(BookStoreModel p16)
        {
            if (p16 == null)
            {
                return null;
            }
            MapContextScope scope = new MapContextScope();
            
            try
            {
                object cache;
                
                Dictionary<ReferenceTuple, object> references = scope.Context.References;
                ReferenceTuple key = new ReferenceTuple(p16, typeof(BookStoreModel));
                
                if (references.TryGetValue(key, out cache))
                {
                    return (BookStoreModel)cache;
                }
                BookStoreModel result = new BookStoreModel();
                references[key] = (object)result;
                
                result.StoreId = p16.StoreId;
                result.BookId = p16.BookId;
                result.Store = null;
                result.Book = null;
                return result;
            }
            finally
            {
                scope.Dispose();
            }
            
        }
    }
}