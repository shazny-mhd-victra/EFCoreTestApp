using DAL.DataService.IDataService;
using DAL.Db.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EFCoreTestApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly INewsService service;

        public NewsController(INewsService service)
        {
            this.service = service;
        }
        // GET: api/<NewsController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<News>>> Get()
        {
            var Data = await service.GetAll();
            return Ok(Data);
        }

        // GET api/<NewsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IResult>> Get(int id)
        {
            var Data = await service.Find(id);
            return Ok(Data);
        }

        // POST api/<NewsController>
        [HttpPost]
        public async Task<ActionResult<IResult>> Post([FromBody] News news)
        {
            var Data = await service.Insert(news);
            return Ok(Data);
        }

        // PUT api/<NewsController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<IResult>> Put(int id, [FromBody] News news)
        {
            var Data = await service.Update(news);
            return Ok(Data);
        }

        // DELETE api/<NewsController>/5
        [HttpDelete("{id}")]
        public ActionResult<IResult> Delete(int id)
        {
            service.DeleteNews(id);

            return Ok(true);
        }
    }
}
