using SmartBox.Model;

namespace SmartBox.Repositorios.Interfaces
{
    public interface IUsuariosRepositorio
    {
    Task<List<UsuariosModel>> GetAllUsuarios();
    Task<UsuariosModel> GetId(int id);
    Task<UsuariosModel> Insert(UsuariosModel usuario);
    Task<UsuariosModel> Update(UsuariosModel usuario, int id);
    Task<bool> Delete(int id);

    }
}
