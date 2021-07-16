using bookapi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookapi.Repository
{
    public interface IBook
    {
        Task<string> GetBookbyId(int Id);
        Task<Book> GetBookDetails(int Id);
    }
}
