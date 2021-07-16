using bookapi.Models;
using bookapi.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace bookapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
         IBook _book;
        public BookController(IBook book)
        {
            _book = book;

        }

        [HttpGet(nameof(GetBookById))]
        public async Task<string> GetBookById(int Id)
        {
            var result = await _book.GetBookbyId(Id);
            return result;
        }
        [HttpGet(nameof(GetBookDetails))]
        public async Task<Book> GetBookDetails(int Id)
        {
            var result = await _book.GetBookDetails(Id);
            return result;
        }
    }
}
