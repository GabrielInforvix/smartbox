using Microsoft.AspNetCore.Mvc;
using SmartBox.Model;
using SmartBox.Repositorios.Interfaces;


namespace SmartBox.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class BoxesController : ControllerBase
    {
        private readonly IBoxesRepository _BoxesRepository;
        public BoxesController(IBoxesRepository boxesRepository)
        {
            _BoxesRepository = boxesRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<BoxesModel>>> GetAllBoxes()
        {
            List<BoxesModel> boxes = await _BoxesRepository.GetAllBoxes();
            return Ok(boxes);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<BoxesModel>> GetId(int id)
        {
            BoxesModel boxes = await _BoxesRepository.GetId(id);
            return Ok(boxes);
        }

        [HttpPost]
        public async Task<ActionResult<BoxesModel>> Insert([FromBody] BoxesModel BoxesModel)
        {
            BoxesModel box = await _BoxesRepository.Insert(BoxesModel);
            return Ok(box);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<BoxesModel>> Update([FromBody] BoxesModel boxesModel, int id)
        {
            boxesModel.Id = id;
            BoxesModel box = await _BoxesRepository.Update(boxesModel, id);
            return Ok(box);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<BoxesModel>> Delete(int id)
        {
            bool Deleted = await _BoxesRepository.Delete(id);
            return Ok(Deleted);
        }
    }
}
