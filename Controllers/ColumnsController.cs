using Microsoft.AspNetCore.Mvc;
using SmartBox.Model;
using SmartBox.Repositorios.Interfaces;

namespace SmartBox.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class ColumnsController : ControllerBase
    {
        private readonly IColumnsRepository _columnsrepository;
        public ColumnsController(IColumnsRepository columnsRepository)
        {
            _columnsrepository = columnsRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<ColumnsModel>>> GetAllColumns()
        {
            List<ColumnsModel> columns = await _columnsrepository.GetAllColumns();
            return Ok(columns);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<ColumnsModel>> GetId(int id)
        {
            ColumnsModel column = await _columnsrepository.GetId(id);
            return Ok(column);
        }

        [HttpPost]
        public async Task<ActionResult<ColumnsModel>> Insert([FromBody] ColumnsModel _columnModel)
        {
            ColumnsModel column = await _columnsrepository.Insert(_columnModel);
            return Ok(column);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ColumnsModel>> Update([FromBody] ColumnsModel _columnModel, int id)
        {
            _columnModel.Id = id;
            ColumnsModel column = await _columnsrepository.Update(_columnModel, id);
            return Ok(column);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ColumnsModel>> Delete(int id)
        {
            bool Deleted = await _columnsrepository.Delete(id);
            return Ok(Deleted);
        }
    }
}
