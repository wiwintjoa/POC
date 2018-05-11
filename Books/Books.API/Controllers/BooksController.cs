using Books.API.Helper;
using Books.API.Models;
using Books.DataAccess;
using Books.Domain.Model;
using Newtonsoft.Json;
using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using WebApiThrottle;

namespace Books.API.Controllers
{
    [RoutePrefix("api/books")]
    public class BooksController : ApiController
    {
        private BooksAPIContext db = new BooksAPIContext();

        // Typed lambda expression for Select() method. 
        private static readonly Expression<Func<Book, BookDto>> AsBookDto =
            x => new BookDto
            {
                Title = x.Title,
                Author = x.Author.Name,
                Genre = x.Genre
            };

        // GET: api/Books
        [Route("")]
        [EnableThrottling(PerSecond = 1)]
        //[EnableThrottling()]        
        public IHttpActionResult GetBooks()
        {
            var books = db.Books.Include(b => b.Author).Select(AsBookDto);

            string results = JsonConvert.SerializeObject(books, Formatting.None);

            return Ok(results);
        }

        // GET: api/Books/5
        [Route("{id:int}")]
        [ResponseType(typeof(BookDto))]
        public async Task<IHttpActionResult> GetBook(int id)
        {
            BookDto book = await db.Books.Include(b => b.Author)
                .Where(b => b.BookId == id)
                .Select(AsBookDto)
                .FirstOrDefaultAsync();
            if (book == null)
            {
                return NotFound();
            }

            string result = JsonConvert.SerializeObject(book, Formatting.None);

            return Ok(result);
        }

        // GET: /api/books/1/details
        [Route("{id:int}/details")]
        [ResponseType(typeof(BookDetailDto))]
        public async Task<IHttpActionResult> GetBookDetail(int id)
        {
            var book = await (from b in db.Books.Include(b => b.Author)
                              where b.AuthorId == id
                              select new BookDetailDto
                              {
                                  Title = b.Title,
                                  Genre = b.Genre,
                                  PublishDate = b.PublishDate,
                                  Price = b.Price,
                                  Description = b.Description,
                                  Author = b.Author.Name
                              }).FirstOrDefaultAsync();

            if (book == null)
            {
                return NotFound();
            }

            string result = JsonConvert.SerializeObject(book, Formatting.None);

            return Ok(result);
        }

        // GET: /api/books/fantasy
        [Route("{genre}")]
        public IHttpActionResult GetBooksByGenre(string genre)
        {
            var books = db.Books.Include(b => b.Author)
                .Where(b => b.Genre.Equals(genre, StringComparison.OrdinalIgnoreCase))
                .Select(AsBookDto);

            string results = JsonConvert.SerializeObject(books, Formatting.None);

            return Ok(results);
        }

        // The tilde (~) in the route template overrides the route prefix in the RoutePrefix attribute.
        // GET: /api/authors/id/books
        [Route("~/api/authors/{authorId:int}/books")]
        public IHttpActionResult GetBooksByAuthor(int authorId)
        {
            var books = db.Books.Include(b => b.Author)
                .Where(b => b.AuthorId == authorId)
                .Select(AsBookDto);

            string results = JsonConvert.SerializeObject(books, Formatting.None);

            return Ok(results);          
        }


        // (*) This tells the routing engine that {pubdate} should match the rest of the URI. By default, a template parameter matches a single URI segment. 
        [Route("api/books/date/{pubdate:datetime:regex(\\d{4}-\\d{2}-\\d{2})}")]  // GET: /api/books/date/yyyy-mm-dd
        [Route("date/{*pubdate:datetime:regex(\\d{4}/\\d{2}/\\d{2})}")]  // GET: /api/books/date/yyyy/mm/dd
        public IHttpActionResult GetBooks(DateTime pubdate)
        {
            var books =  db.Books.Include(b => b.Author)
                .Where(b => DbFunctions.TruncateTime(b.PublishDate)
                    == DbFunctions.TruncateTime(pubdate))
                .Select(AsBookDto);

            string results = JsonConvert.SerializeObject(books, Formatting.None);

            return Ok(results);

        }

        #region unused
        //// PUT: api/Books/5
        //[ResponseType(typeof(void))]
        //public async Task<IHttpActionResult> PutBook(int id, Book book)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != book.BookId)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(book).State = EntityState.Modified;

        //    try
        //    {
        //        await db.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!BookExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        //// POST: api/Books
        //[ResponseType(typeof(Book))]
        //public async Task<IHttpActionResult> PostBook(Book book)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.Books.Add(book);
        //    await db.SaveChangesAsync();

        //    return CreatedAtRoute("DefaultApi", new { id = book.BookId }, book);
        //}

        //// DELETE: api/Books/5
        //[ResponseType(typeof(Book))]
        //public async Task<IHttpActionResult> DeleteBook(int id)
        //{
        //    Book book = await db.Books.FindAsync(id);
        //    if (book == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Books.Remove(book);
        //    await db.SaveChangesAsync();

        //    return Ok(book);
        //}

        #endregion

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BookExists(int id)
        {
            return db.Books.Count(e => e.BookId == id) > 0;
        }
    }
}