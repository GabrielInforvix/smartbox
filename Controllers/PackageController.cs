using Microsoft.AspNetCore.Mvc;
using SmartBox.Model;
using SmartBox.Repositorios.Interfaces;

namespace SmartBox.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class PackageController : ControllerBase
    {
        private readonly IPackageRepository _packagerepository;
        public PackageController(IPackageRepository packageRepository)
        {
            _packagerepository = packageRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<PackageModel>>> GetAllPackages()
        {
            List<PackageModel> packages = await _packagerepository.GetAllPackage();
            return Ok(packages);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<PackageModel>> GetId(int id)
        {
            PackageModel package = await _packagerepository.GetId(id);
            return Ok(package);
        }

        [HttpPost]
        public async Task<ActionResult<PackageModel>> Insert([FromBody] PackageModel _packageModel)
        {
            PackageModel package = await _packagerepository.Insert(_packageModel);
            return Ok(package);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PackageModel>> Update([FromBody] PackageModel _packageModel, int id)
        {
            _packageModel.Id = id;
            PackageModel package = await _packagerepository.Update(_packageModel, id);
            return Ok(package);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<PackageModel>> Delete(int id)
        {
            bool Deleted = await _packagerepository.Delete(id);
            return Ok(Deleted);
        }
    }
}
