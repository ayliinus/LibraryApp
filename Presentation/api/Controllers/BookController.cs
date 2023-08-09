using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Business;
using ViewModels;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookBusinessService _bookBusiness;

        public BookController(IBookBusinessService bookBusiness)
        {
            _bookBusiness = bookBusiness;
        }

        [HttpPost("AddBook")]
        public IActionResult AddBook([FromBody] AddBookVM model)
        {
            _bookBusiness.AddBook(model);
            return Ok(model);
        }

        [HttpPut("UpdateBook/{id:int}")]
        public IActionResult UpdateBook(int id, [FromBody] AddBookVM model)
        {
            try
            {
                _bookBusiness.UpdateBook(id, model);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeleteBook/{id:int}")]
        public IActionResult DeleteBook(int id)
        {
            try
            {
                _bookBusiness.DeleteBook(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetBookById/{id:int}")]
        public IActionResult GetBookById(int id)
        {
            var book = _bookBusiness.GetById(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        [HttpGet("GetAllBooks")]
        public IActionResult GetAllBooks()
        {
            var books = _bookBusiness.GetAllBooks();
            return Ok(books);
        }
    }
}
