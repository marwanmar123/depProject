using bookapi.Controllers;
using bookapi.Models;
using bookapi.Repository;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace book.test
{
    public class BookTesting
    {

        public Mock<IBook> mock = new Mock<IBook>();
        [Fact]
        public async Task GetBookById()
        {
            mock.Setup(p => p.GetBookbyId(3)).ReturnsAsync("popp");
            BookController book = new BookController(mock.Object);
            string result = await book.GetBookById(3);
            Assert.Equal("popp", result);


        }
        [Fact]

        public  async Task GetBookDetails()
        {

            
            var bookdto = new Book()
            {
                Id = 3,
                Title = "popp",
                Author = "popo",
                Description="popp"
            };
            mock.Setup(p => p.GetBookDetails(3)).ReturnsAsync(bookdto);
            BookController book = new BookController(mock.Object);
            var result = await book.GetBookDetails(3);
            Assert.True(bookdto.Equals(result));


        }
    }
}
