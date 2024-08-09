using Microsoft.AspNetCore.Mvc;
using SmartBox.Model;
using SmartBox.Repositorios.Interfaces;

namespace SmartBox.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuariosRepositorio _usuariosRepositorio;
        public UsuarioController(IUsuariosRepositorio usuariosRepositorio)
        {
            _usuariosRepositorio = usuariosRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<UsuariosModel>>> GetAllUsuarios()
        {
            List<UsuariosModel> usuarios = await _usuariosRepositorio.GetAllUsuarios();
            return Ok(usuarios);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<UsuariosModel>> GetId(int id)
        {
            UsuariosModel usuario = await _usuariosRepositorio.GetId(id);
            return Ok(usuario);
        }

        [HttpPost]
        public async Task<ActionResult<UsuariosModel>> Insert([FromBody] UsuariosModel usuarioModel)
        {
            UsuariosModel usuario = await _usuariosRepositorio.Insert(usuarioModel);
            return Ok(usuario);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UsuariosModel>> Update([FromBody] UsuariosModel usuarioModel, int id)
        {
            usuarioModel.Id = id;
            UsuariosModel usuario = await _usuariosRepositorio.Update(usuarioModel, id);
            return Ok(usuario);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UsuariosModel>> Delete(int id)
        {
            bool Deleted = await _usuariosRepositorio.Delete(id);
            return Ok(Deleted);
        }
    }
}
