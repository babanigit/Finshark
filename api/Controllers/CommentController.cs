using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.comments;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/comment")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository _commentRepo;
        private readonly IStockRepository _stockRepo;

        public CommentController(ICommentRepository commentRepo, IStockRepository stockRepo)
        {
            _commentRepo = commentRepo;
            _stockRepo = stockRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var comments = await _commentRepo.GetAllAsync(); //interface\repo
            var commentDto = comments.Select(s => s.ToCommentDto()); //dto\mapper
            return Ok(commentDto);
        }


        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var comment = await _commentRepo.GetByIdAsync(id); //rpo

            if (comment == null)
            {
                return NotFound();
            }

            return Ok(comment.ToCommentDto()); //dto
        }

        // [HttpPost("{stockId}")]
        // public async Task<IActionResult> Create([FromBody] int stockId, CreateCommentDto commentDto)
        // {

        //     var stock = await _stockRepo.GetByIdAsync(stockId);


        // }


    }
}