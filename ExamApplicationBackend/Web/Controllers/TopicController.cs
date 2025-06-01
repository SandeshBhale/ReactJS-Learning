using Core;
using Infra.Repo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopicController : ControllerBase
    {
        public readonly ITopicRepo _repo;
        public TopicController(ITopicRepo repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var rec = await this._repo.GetAll();
            return Ok(rec);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAll(Int64 id)
        {
            if (ModelState.IsValid)
            {
                var rec = await this._repo.FindById(id);
                return Ok(rec);
            }
            return NotFound("Topic Not Found !");
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Topic rec)
        {
            if(ModelState.IsValid)
            {
                var res = await this._repo.Create(rec);
                if (res.IsSuccess)
                    return Ok(res.Message);
                else
                    return StatusCode(500, res.Message);
            }
            return BadRequest(ModelState);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Topic rec)
        {
            if (ModelState.IsValid)
            {
                var res = await this._repo.Update(rec);
                if (res.IsSuccess)
                    return Ok(res.Message);
                else
                    return StatusCode(500, res.Message);
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Int64 id)
        {
            var rec = await this._repo.FindById(id);
            if (rec == null)
                return NotFound("Topic Not Found");

            var res = await this._repo.Delete(id);
            if (res.IsSuccess)
                return Ok(res.Message);
            else
                return StatusCode(500, res.Message);
        }
    }
}
